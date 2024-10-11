namespace salkodev.hiddendata
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			_PictureBox = new PictureBox();
			_LabelMain = new Label();
			_LabelDescr = new Label();
			_OpenFileDialog = new OpenFileDialog();
			_LabelOpenedFile = new Label();
			_LabelOpenedFileName = new Label();
			_ToolStripMain = new ToolStrip();
			_ToolStripButtonOpen = new ToolStripButton();
			_ToolStripButtonSave = new ToolStripButton();
			_ToolStripButtonEncryption = new ToolStripButton();
			_OpenFileDialogForData = new OpenFileDialog();
			_ListViewFilesInside = new ListView();
			_ColumnHeaderFileName = new ColumnHeader();
			_ContextMenuStrip = new ContextMenuStrip(components);
			_MenuItemAddFiles = new ToolStripMenuItem();
			_MenuItemOpen = new ToolStripMenuItem();
			_MenuItemSaveAs = new ToolStripMenuItem();
			_lmageListFileIcons = new ImageList(components);
			_LabelNoFilesInsideFound = new Label();
			_LinkLabelOpenImageFile = new LinkLabel();
			_SaveFileDialog = new SaveFileDialog();
			_TextBoxDescription = new TextBox();
			((System.ComponentModel.ISupportInitialize)_PictureBox).BeginInit();
			_ToolStripMain.SuspendLayout();
			_ContextMenuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// _PictureBox
			// 
			_PictureBox.Image = Properties.Resources.lock_secure;
			resources.ApplyResources(_PictureBox, "_PictureBox");
			_PictureBox.Name = "_PictureBox";
			_PictureBox.TabStop = false;
			// 
			// _LabelMain
			// 
			resources.ApplyResources(_LabelMain, "_LabelMain");
			_LabelMain.Name = "_LabelMain";
			// 
			// _LabelDescr
			// 
			resources.ApplyResources(_LabelDescr, "_LabelDescr");
			_LabelDescr.Name = "_LabelDescr";
			// 
			// _OpenFileDialog
			// 
			resources.ApplyResources(_OpenFileDialog, "_OpenFileDialog");
			// 
			// _LabelOpenedFile
			// 
			resources.ApplyResources(_LabelOpenedFile, "_LabelOpenedFile");
			_LabelOpenedFile.Name = "_LabelOpenedFile";
			// 
			// _LabelOpenedFileName
			// 
			resources.ApplyResources(_LabelOpenedFileName, "_LabelOpenedFileName");
			_LabelOpenedFileName.AutoEllipsis = true;
			_LabelOpenedFileName.Name = "_LabelOpenedFileName";
			// 
			// _ToolStripMain
			// 
			_ToolStripMain.Items.AddRange(new ToolStripItem[] { _ToolStripButtonOpen, _ToolStripButtonSave, _ToolStripButtonEncryption });
			resources.ApplyResources(_ToolStripMain, "_ToolStripMain");
			_ToolStripMain.Name = "_ToolStripMain";
			// 
			// _ToolStripButtonOpen
			// 
			_ToolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(_ToolStripButtonOpen, "_ToolStripButtonOpen");
			_ToolStripButtonOpen.Name = "_ToolStripButtonOpen";
			_ToolStripButtonOpen.Click += _ToolStripButtonOpen_Click;
			// 
			// _ToolStripButtonSave
			// 
			_ToolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(_ToolStripButtonSave, "_ToolStripButtonSave");
			_ToolStripButtonSave.Name = "_ToolStripButtonSave";
			_ToolStripButtonSave.Click += _ToolStripButtonSave_Click;
			// 
			// _ToolStripButtonEncryption
			// 
			resources.ApplyResources(_ToolStripButtonEncryption, "_ToolStripButtonEncryption");
			_ToolStripButtonEncryption.Name = "_ToolStripButtonEncryption";
			_ToolStripButtonEncryption.Click += _ToolStripButtonEncryption_Click;
			// 
			// _OpenFileDialogForData
			// 
			resources.ApplyResources(_OpenFileDialogForData, "_OpenFileDialogForData");
			_OpenFileDialogForData.Multiselect = true;
			// 
			// _ListViewFilesInside
			// 
			resources.ApplyResources(_ListViewFilesInside, "_ListViewFilesInside");
			_ListViewFilesInside.Columns.AddRange(new ColumnHeader[] { _ColumnHeaderFileName });
			_ListViewFilesInside.ContextMenuStrip = _ContextMenuStrip;
			_ListViewFilesInside.FullRowSelect = true;
			_ListViewFilesInside.Name = "_ListViewFilesInside";
			_ListViewFilesInside.SmallImageList = _lmageListFileIcons;
			_ListViewFilesInside.UseCompatibleStateImageBehavior = false;
			_ListViewFilesInside.View = View.Details;
			// 
			// _ColumnHeaderFileName
			// 
			resources.ApplyResources(_ColumnHeaderFileName, "_ColumnHeaderFileName");
			// 
			// _ContextMenuStrip
			// 
			_ContextMenuStrip.Items.AddRange(new ToolStripItem[] { _MenuItemAddFiles, _MenuItemOpen, _MenuItemSaveAs });
			_ContextMenuStrip.Name = "_ContextMenuStrip";
			resources.ApplyResources(_ContextMenuStrip, "_ContextMenuStrip");
			_ContextMenuStrip.Opening += _ContextMenuStrip_Opening;
			// 
			// _MenuItemAddFiles
			// 
			_MenuItemAddFiles.Name = "_MenuItemAddFiles";
			resources.ApplyResources(_MenuItemAddFiles, "_MenuItemAddFiles");
			_MenuItemAddFiles.Click += _MenuItemAddFiles_Click;
			// 
			// _MenuItemOpen
			// 
			_MenuItemOpen.Name = "_MenuItemOpen";
			resources.ApplyResources(_MenuItemOpen, "_MenuItemOpen");
			_MenuItemOpen.Click += _MenuItemOpen_Click;
			// 
			// _MenuItemSaveAs
			// 
			_MenuItemSaveAs.Name = "_MenuItemSaveAs";
			resources.ApplyResources(_MenuItemSaveAs, "_MenuItemSaveAs");
			_MenuItemSaveAs.Click += _MenuItemSaveAs_Click;
			// 
			// _lmageListFileIcons
			// 
			_lmageListFileIcons.ColorDepth = ColorDepth.Depth32Bit;
			_lmageListFileIcons.ImageStream = (ImageListStreamer)resources.GetObject("_lmageListFileIcons.ImageStream");
			_lmageListFileIcons.TransparentColor = Color.Transparent;
			_lmageListFileIcons.Images.SetKeyName(0, "file_16");
			// 
			// _LabelNoFilesInsideFound
			// 
			resources.ApplyResources(_LabelNoFilesInsideFound, "_LabelNoFilesInsideFound");
			_LabelNoFilesInsideFound.BackColor = SystemColors.Window;
			_LabelNoFilesInsideFound.ForeColor = SystemColors.AppWorkspace;
			_LabelNoFilesInsideFound.Name = "_LabelNoFilesInsideFound";
			// 
			// _LinkLabelOpenImageFile
			// 
			resources.ApplyResources(_LinkLabelOpenImageFile, "_LinkLabelOpenImageFile");
			_LinkLabelOpenImageFile.BackColor = SystemColors.Window;
			_LinkLabelOpenImageFile.Name = "_LinkLabelOpenImageFile";
			_LinkLabelOpenImageFile.TabStop = true;
			_LinkLabelOpenImageFile.LinkClicked += _LinkLabelOpenImageFile_LinkClicked;
			// 
			// _TextBoxDescription
			// 
			resources.ApplyResources(_TextBoxDescription, "_TextBoxDescription");
			_TextBoxDescription.Name = "_TextBoxDescription";
			_TextBoxDescription.TextChanged += _TextBoxDescription_TextChanged;
			// 
			// FormMain
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(_TextBoxDescription);
			Controls.Add(_LabelNoFilesInsideFound);
			Controls.Add(_LinkLabelOpenImageFile);
			Controls.Add(_ListViewFilesInside);
			Controls.Add(_ToolStripMain);
			Controls.Add(_LabelOpenedFileName);
			Controls.Add(_LabelOpenedFile);
			Controls.Add(_LabelDescr);
			Controls.Add(_LabelMain);
			Controls.Add(_PictureBox);
			Name = "FormMain";
			Load += FormMain_Load;
			((System.ComponentModel.ISupportInitialize)_PictureBox).EndInit();
			_ToolStripMain.ResumeLayout(false);
			_ToolStripMain.PerformLayout();
			_ContextMenuStrip.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox _PictureBox;
		private Label _LabelMain;
		private Label _LabelDescr;
		private OpenFileDialog _OpenFileDialog;
		private Label _LabelOpenedFile;
		private Label _LabelOpenedFileName;
		private ToolStrip _ToolStripMain;
		private ToolStripButton _ToolStripButtonOpen;
		private ToolStripButton _ToolStripButtonSave;
		private OpenFileDialog _OpenFileDialogForData;
		private ListView _ListViewFilesInside;
		private Label _LabelNoFilesInsideFound;
		private ContextMenuStrip _ContextMenuStrip;
		private ToolStripMenuItem _MenuItemAddFiles;
		private ColumnHeader _ColumnHeaderFileName;
		private LinkLabel _LinkLabelOpenImageFile;
		private ImageList _lmageListFileIcons;
		private ToolStripMenuItem _MenuItemSaveAs;
		private SaveFileDialog _SaveFileDialog;
		private ToolStripMenuItem _MenuItemOpen;
		private TextBox _TextBoxDescription;
		private ToolStripButton _ToolStripButtonEncryption;
	}
}