using System.Text;
using System.Text.Unicode;
using salkodev.hiddendata.Data;
using salkodev.hiddendata.Properties;

namespace salkodev.hiddendata
{
	public partial class FormMain : Form
	{
		const string _GENERIC_FILE_ICON_KEY = "file_16";

		public FormMain()
		{
			InitializeComponent();
		}

		Manager _Manager = new Manager();

		void _ButtonOpenFile_Click(object sender, EventArgs e)
		{
			_OpenFile();
		}

		void _ToolStripButtonOpen_Click(object sender, EventArgs e)
		{
			_OpenFile();
		}

		void _LinkLabelOpenImageFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			_OpenFile();
		}

		void FormMain_Load(object sender, EventArgs e)
		{
			_LabelOpenedFileName.Text = null;

			_UpdateControls();
		}

		/// <summary>
		/// Open main image file (with data inside, or for data storage)
		/// </summary>
		void _OpenFile()
		{
			try
			{
				if (_OpenFileDialog.ShowDialog() != DialogResult.OK)
					return;

				string fileName = _OpenFileDialog.FileName;

				var loader = new DataLoader();

				loader.Load(fileName, Data.Marker.META_DATA_BEGIN_MARKER, out Data.Metadata info, out int origFileLength, out byte[] origFileBody);

				//info will be null if we open jpg file without data inside
				if (info != null)
				{
					if (info.Encrypted)
					{
						//ask password to decrypt now...
						string password = null;

						using (var passDlg = new Encryption.PasswordForm())
						{
							if (passDlg.ShowDialog() != DialogResult.OK)
								return;

							password = passDlg.Password;
						}

						if (!_Decrypt(info, password))
						{
							MessageBox.Show(this, string.Format(Resources.DecryptErrorWrongPassword, string.Empty), Resources.OpenFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}

						//if we successfully decrypt, remember pass in memory (we need it for save later)
						_Manager.PasswordEncryption = true;
						_Manager.Password = password;
					}

					_TextBoxDescription.Text = info.Description;
				}

				_Manager.State = (info != null) ? DataState.OpenedWithData : DataState.OpenedNoData;
				_Manager.FileName = fileName;
				_Manager.Data = info;
				_Manager.FileNameBody = origFileBody;

				//fill list files...
				_UpdateFilesList();

				_UpdateControls();

				_Manager.Dirty = false;
			}
			catch (System.Security.Cryptography.CryptographicException crEx)
			{
				string complexMsg = string.Format(Resources.DecryptErrorWrongPassword, Environment.NewLine + crEx.Message);
				MessageBox.Show(this, complexMsg, Resources.OpenFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, Resources.OpenFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		bool _Decrypt(Metadata info, string password)
		{
			if (info == null)
				throw new ArgumentNullException(nameof(info));

			if (!info.Encrypted)
				throw new ArgumentException("info not encrypted");

			if(string.IsNullOrWhiteSpace(password))
				throw new ArgumentNullException(nameof(password),"Password can't be empty");


			var files= info.Files;
			if (files == null)
				throw new ApplicationException("Encryption exists, but Files not found");

			foreach (var f in files)
			{
				if (!_DecryptFile(f, password))
					return false;

			}//foreach

			return true;
		}

		bool _DecryptFile(MetadataFile file, string password)
		{
			if (file == null)
				throw new ArgumentNullException(nameof(file));

			if (file.Hash == null || file.Hash.Length == 0)
				throw new ArgumentNullException(nameof(file), "file.Hash empty");

			//first try decrypt body, and check hash.
			if (file.Body == null || file.Body.Length == 0)
				throw new ApplicationException("file.Body null or empty");

			var manager = new Encryption.Manager();
			var passHash = manager.GetHash(password);

			byte[] bodyDecrypted = manager.DecryptData(file.Body, passHash);
			byte[] bodyDecryptedHash = manager.GetHash(bodyDecrypted);

			//now check Hash - it must be equals (or decryption not successful)
			if (!manager.HashEquals(file.Hash, bodyDecryptedHash))
				return false;

			byte[] fnameBin = manager.DecryptData(file.FileNameEncrypted, passHash);
			string fileNameReal = Encoding.UTF8.GetString(fnameBin);

			file.Body = bodyDecrypted;
			file.FileName = fileNameReal;

			return true;

		}//_DecryptFile

		void _ToolStripButtonSave_Click(object sender, EventArgs e)
		{
			try
			{
				if (_Manager.State == DataState.Unspecified)
				{
					MessageBox.Show(this, Properties.Resources.OpenImageFileDescr, Properties.Resources.OpenFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				if (_Manager.FileName == null)
				{
					MessageBox.Show(this, Properties.Resources.OpenWorkImageFileFirst, Properties.Resources.SelectFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}

				//собрать файлы в памяти и смержить их в мета-дата структуру
				if (_Manager.Data == null)
					throw new ApplicationException("_Manager.Data == null");

				var files = _Manager.Data.Files;

				if (files == null || files.Length == 0)
				{
					MessageBox.Show(this, Properties.Resources.YouNeedToAddAtLeastFile, Properties.Resources.AddFilesCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				var dataToSave = new Metadata();
				dataToSave.Files = _Manager.Data.Files; //if not encrypted, use original files
				dataToSave.Description = _TextBoxDescription.Text;

				if (_Manager.PasswordEncryption && !string.IsNullOrWhiteSpace(_Manager.Password))
				{
					dataToSave.Encrypted = true;

					var encManager = new Encryption.Manager();
					var passwordHash = encManager.GetHash(_Manager.Password);

					//encrypt file names and file content
					List<MetadataFile> filesEncrypted = new List<MetadataFile>();

					foreach (var file in files)
					{
						var fileBodyHash = encManager.GetHash(file.Body);

						var fileNameBin = Encoding.UTF8.GetBytes(file.FileName);
						var fileNameEncrypted = encManager.EncryptData(fileNameBin, passwordHash);
						var fileBodyEncrypted = encManager.EncryptData(file.Body, passwordHash);

						var fileEnc = new MetadataFile();
						fileEnc.FileName = null; //normal file name not saved if file encrypted
						fileEnc.FileNameEncrypted = fileNameEncrypted;
						fileEnc.LastWriteTime = file.LastWriteTime;
						fileEnc.Body = fileBodyEncrypted;
						fileEnc.Hash = fileBodyHash;

						filesEncrypted.Add(fileEnc);
					}

					dataToSave.Files = filesEncrypted.ToArray();
				}

				//...test save to xml
				//byte[] data = dataToSave.Serialize();
				//string destFile = Path.Combine(Application.StartupPath, "result.xml");
				//File.WriteAllBytes(destFile, data);

				var saver = new DataSaver();
				saver.Save(_Manager.FileName, _Manager.FileNameBody, Data.Marker.META_DATA_BEGIN_MARKER, dataToSave);
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		void _UpdateControls()
		{
			bool openedFileVisible = false;

			bool showOpenLink = false;
			if (_Manager.State != DataState.Unspecified)
			{
				openedFileVisible = true;
			}
			else
			{
				showOpenLink = true;
			}

			if (_Manager.FileName != null)
			{
				_LabelOpenedFileName.Text = Path.GetFileName(_Manager.FileName);
			}

			_LinkLabelOpenImageFile.Visible = showOpenLink;

			_LabelOpenedFile.Visible = openedFileVisible;
			_LabelOpenedFileName.Visible = openedFileVisible;
		}


		void _MenuItemAddFiles_Click(object sender, EventArgs e)
		{
			if (_Manager.State == DataState.Unspecified)
			{
				MessageBox.Show(this, Properties.Resources.OpenWorkImageFileFirst, Properties.Resources.OpenSourceImageFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if (_OpenFileDialogForData.ShowDialog() != DialogResult.OK)
				return;

			try
			{
				string[] fileNames = _OpenFileDialogForData.FileNames;

				foreach (string fileName in fileNames)
				{
					if (_Manager.FileName == fileName)
					{
						continue; //don't add same file you opened
					}

					_Manager.AddFile(fileName);
				}

				_UpdateFilesList();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		void _UpdateFilesList()
		{
			if (_Manager.State == DataState.Unspecified || _Manager.Data == null || _Manager.Data.Files.Length == 0)
			{
				_ListViewFilesInside.Items.Clear();
				return;
			}

			var inList = new Dictionary<string, object>();
			foreach (ListViewItem item in _ListViewFilesInside.Items)
			{
				var mtFile = (MetadataFile)item.Tag;
				if (mtFile == null)
					throw new ApplicationException("mtFile == null");

				inList[mtFile.FileName] = null;
			}

			foreach (var fi in _Manager.Data.Files)
			{
				if (inList.ContainsKey(fi.FileName))
					continue;

				ListViewItem li = new ListViewItem(fi.FileName);
				li.Tag = fi;
				li.ImageKey = _GENERIC_FILE_ICON_KEY;


				_ListViewFilesInside.Items.Add(li);

			}//foreach 

		}//_UpdateFilesList

		void _MenuItemSaveAs_Click(object sender, EventArgs e)
		{
			//save files ... (all selected)
			if (_ListViewFilesInside.SelectedItems.Count == 0)
				return;

			//if selected multiple files, display dialog for first, and use dest folder for all
			string destFolder = null;

			foreach (ListViewItem li in _ListViewFilesInside.SelectedItems)
			{
				var metaFile = (MetadataFile)li.Tag;
				if (metaFile == null)
					throw new NullReferenceException("metaFile == null");

				if (destFolder == null)
				{
					_SaveFileDialog.FileName = metaFile.FileName;

					if (_SaveFileDialog.ShowDialog() != DialogResult.OK)
						return;

					destFolder = Path.GetDirectoryName(_SaveFileDialog.FileName);

					metaFile.SaveTo(_SaveFileDialog.FileName);
				}
				else
				{
					string destFileName = Path.Combine(destFolder, metaFile.FileName);
					metaFile.SaveTo(destFileName);
				}

			}//foreach

		}//_MenuItemSaveAs_Click

		void _MenuItemOpen_Click(object sender, EventArgs e)
		{
			if (_ListViewFilesInside.SelectedItems.Count == 0)
				return;

			if (_ListViewFilesInside.SelectedItems.Count > 1)
			{
				MessageBox.Show(this, Properties.Resources.SelectOnlyOneFileToOpen, Properties.Resources.SelectFileCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			try
			{
				var li = _ListViewFilesInside.SelectedItems[0];
				var metaFile = (MetadataFile)li.Tag;
				if (metaFile == null)
					throw new NullReferenceException("metaFile == null");

				byte[] body = metaFile.Body;

				//decode (we support UTF-8 for now)
				string textInitial = Encoding.UTF8.GetString(body, 0, body.Length);

				var viewForm = new TextViewForm();
				viewForm.FileContent = textInitial;

				if (viewForm.ShowDialog(this) != DialogResult.OK)
					return;

				//need to save content back... if changed
				string textChanged = viewForm.FileContent;
				if (textChanged == textInitial)
					return; //no changes

				//TODO@: update metadata, and mark as "modified"

			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void _ToolStripButtonEncryption_Click(object sender, EventArgs e)
		{
			//Ask use for password-encryption option (real encryption will be during save process)

			using (var dlg = new Encryption.EncryptForm())
			{
				dlg.Password = _Manager.Password;
				dlg.PasswordUse = !string.IsNullOrWhiteSpace(_Manager.Password);

				var askRes = dlg.ShowDialog(this);
				if (askRes != DialogResult.OK)
					return;

				_Manager.PasswordEncryption = dlg.PasswordUse;
				_Manager.Password = dlg.Password;

				if (string.IsNullOrWhiteSpace(_Manager.Password))
					_Manager.PasswordEncryption = false;
			}
		}

		void _TextBoxDescription_TextChanged(object sender, EventArgs e)
		{
			_Manager.Dirty = true;
		}
	}
}