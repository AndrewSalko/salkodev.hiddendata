using System.Text;
using salkodev.hiddendata.Data;

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

				_Manager.State = (info != null) ? DataState.OpenedWithData : DataState.OpenedNoData;
				_Manager.FileName = fileName;
				_Manager.Data = info;
				_Manager.FileNameBody = origFileBody;

				//fill list files...
				_UpdateFilesList();

				_UpdateControls();
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


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

				byte[] data = _Manager.Data.Serialize();

				//...test save to xml
				//string destFile = Path.Combine(Application.StartupPath, "result.xml");
				//File.WriteAllBytes(destFile, data);

				var saver = new DataSaver();
				saver.Save(_Manager.FileName, _Manager.FileNameBody, Data.Marker.META_DATA_BEGIN_MARKER, _Manager.Data);
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
	}
}