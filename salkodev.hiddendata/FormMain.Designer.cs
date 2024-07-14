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
			_OpenFileDialogForData = new OpenFileDialog();
			_ListViewFilesInside = new ListView();
			_ColumnHeaderFileName = new ColumnHeader();
			_ContextMenuStrip = new ContextMenuStrip(components);
			_MenuItemAddFiles = new ToolStripMenuItem();
			_MenuItemSaveAs = new ToolStripMenuItem();
			_MenuItemSaveAllFiles = new ToolStripMenuItem();
			_lmageListFileIcons = new ImageList(components);
			_LabelNoFilesInsideFound = new Label();
			_LinkLabelOpenImageFile = new LinkLabel();
			_SaveFileDialog = new SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)_PictureBox).BeginInit();
			_ToolStripMain.SuspendLayout();
			_ContextMenuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// _PictureBox
			// 
			_PictureBox.Image = Properties.Resources.lock_secure;
			_PictureBox.Location = new Point(12, 34);
			_PictureBox.Name = "_PictureBox";
			_PictureBox.Size = new Size(50, 62);
			_PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			_PictureBox.TabIndex = 0;
			_PictureBox.TabStop = false;
			// 
			// _LabelMain
			// 
			_LabelMain.AutoSize = true;
			_LabelMain.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			_LabelMain.Location = new Point(74, 36);
			_LabelMain.Name = "_LabelMain";
			_LabelMain.Size = new Size(222, 25);
			_LabelMain.TabIndex = 1;
			_LabelMain.Text = "Hide information in a file";
			// 
			// _LabelDescr
			// 
			_LabelDescr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_LabelDescr.Location = new Point(74, 72);
			_LabelDescr.Name = "_LabelDescr";
			_LabelDescr.Size = new Size(571, 52);
			_LabelDescr.TabIndex = 2;
			_LabelDescr.Text = "The utility allows you to write additional information to a file (for example, .jpg) at the end of the file.";
			// 
			// _OpenFileDialog
			// 
			_OpenFileDialog.Filter = "All files (*.*)|*.*|Jpg files(*.jpg)|*.jpg";
			// 
			// _LabelOpenedFile
			// 
			_LabelOpenedFile.AutoSize = true;
			_LabelOpenedFile.Location = new Point(80, 128);
			_LabelOpenedFile.Name = "_LabelOpenedFile";
			_LabelOpenedFile.Size = new Size(71, 15);
			_LabelOpenedFile.TabIndex = 5;
			_LabelOpenedFile.Text = "Opened file:";
			// 
			// _LabelOpenedFileName
			// 
			_LabelOpenedFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			_LabelOpenedFileName.AutoEllipsis = true;
			_LabelOpenedFileName.Location = new Point(170, 128);
			_LabelOpenedFileName.Name = "_LabelOpenedFileName";
			_LabelOpenedFileName.Size = new Size(475, 15);
			_LabelOpenedFileName.TabIndex = 6;
			_LabelOpenedFileName.Text = "(...)";
			// 
			// _ToolStripMain
			// 
			_ToolStripMain.Items.AddRange(new ToolStripItem[] { _ToolStripButtonOpen, _ToolStripButtonSave });
			_ToolStripMain.Location = new Point(0, 0);
			_ToolStripMain.Name = "_ToolStripMain";
			_ToolStripMain.Size = new Size(657, 25);
			_ToolStripMain.TabIndex = 7;
			_ToolStripMain.Text = "toolStrip1";
			// 
			// _ToolStripButtonOpen
			// 
			_ToolStripButtonOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
			_ToolStripButtonOpen.Image = (Image)resources.GetObject("_ToolStripButtonOpen.Image");
			_ToolStripButtonOpen.ImageTransparentColor = Color.Magenta;
			_ToolStripButtonOpen.Name = "_ToolStripButtonOpen";
			_ToolStripButtonOpen.Size = new Size(23, 22);
			_ToolStripButtonOpen.Text = "Open";
			_ToolStripButtonOpen.ToolTipText = "Open file";
			_ToolStripButtonOpen.Click += _ToolStripButtonOpen_Click;
			// 
			// _ToolStripButtonSave
			// 
			_ToolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
			_ToolStripButtonSave.Image = (Image)resources.GetObject("_ToolStripButtonSave.Image");
			_ToolStripButtonSave.ImageTransparentColor = Color.Magenta;
			_ToolStripButtonSave.Name = "_ToolStripButtonSave";
			_ToolStripButtonSave.Size = new Size(23, 22);
			_ToolStripButtonSave.Text = "Save";
			_ToolStripButtonSave.ToolTipText = "Save changes";
			_ToolStripButtonSave.Click += _ToolStripButtonSave_Click;
			// 
			// _OpenFileDialogForData
			// 
			_OpenFileDialogForData.Filter = "All files(*.*)|*.*|Zip archives (*.zip)|*.zip";
			_OpenFileDialogForData.Multiselect = true;
			_OpenFileDialogForData.Title = "Select file which you need to hide inside";
			// 
			// _ListViewFilesInside
			// 
			_ListViewFilesInside.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			_ListViewFilesInside.Columns.AddRange(new ColumnHeader[] { _ColumnHeaderFileName });
			_ListViewFilesInside.ContextMenuStrip = _ContextMenuStrip;
			_ListViewFilesInside.FullRowSelect = true;
			_ListViewFilesInside.Location = new Point(12, 175);
			_ListViewFilesInside.Name = "_ListViewFilesInside";
			_ListViewFilesInside.Size = new Size(633, 178);
			_ListViewFilesInside.SmallImageList = _lmageListFileIcons;
			_ListViewFilesInside.TabIndex = 8;
			_ListViewFilesInside.UseCompatibleStateImageBehavior = false;
			_ListViewFilesInside.View = View.Details;
			// 
			// _ColumnHeaderFileName
			// 
			_ColumnHeaderFileName.Text = "File name";
			_ColumnHeaderFileName.Width = 570;
			// 
			// _ContextMenuStrip
			// 
			_ContextMenuStrip.Items.AddRange(new ToolStripItem[] { _MenuItemAddFiles, _MenuItemSaveAs, _MenuItemSaveAllFiles });
			_ContextMenuStrip.Name = "_ContextMenuStrip";
			_ContextMenuStrip.Size = new Size(195, 70);
			// 
			// _MenuItemAddFiles
			// 
			_MenuItemAddFiles.Name = "_MenuItemAddFiles";
			_MenuItemAddFiles.Size = new Size(194, 22);
			_MenuItemAddFiles.Text = "Add files...";
			_MenuItemAddFiles.Click += _MenuItemAddFiles_Click;
			// 
			// _MenuItemSaveAs
			// 
			_MenuItemSaveAs.Name = "_MenuItemSaveAs";
			_MenuItemSaveAs.Size = new Size(194, 22);
			_MenuItemSaveAs.Text = "Save as...";
			_MenuItemSaveAs.Click += _MenuItemSaveAs_Click;
			// 
			// _MenuItemSaveAllFiles
			// 
			_MenuItemSaveAllFiles.Name = "_MenuItemSaveAllFiles";
			_MenuItemSaveAllFiles.Size = new Size(194, 22);
			_MenuItemSaveAllFiles.Text = "Save all files to folder...";
			_MenuItemSaveAllFiles.Click += _MenuItemSaveAllFiles_Click;
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
			_LabelNoFilesInsideFound.Anchor = AnchorStyles.Top;
			_LabelNoFilesInsideFound.AutoSize = true;
			_LabelNoFilesInsideFound.BackColor = SystemColors.Window;
			_LabelNoFilesInsideFound.ForeColor = SystemColors.AppWorkspace;
			_LabelNoFilesInsideFound.Location = new Point(237, 249);
			_LabelNoFilesInsideFound.Name = "_LabelNoFilesInsideFound";
			_LabelNoFilesInsideFound.Size = new Size(195, 15);
			_LabelNoFilesInsideFound.TabIndex = 9;
			_LabelNoFilesInsideFound.Text = "No files found inside opened image";
			_LabelNoFilesInsideFound.Visible = false;
			// 
			// _LinkLabelOpenImageFile
			// 
			_LinkLabelOpenImageFile.Anchor = AnchorStyles.Top;
			_LinkLabelOpenImageFile.AutoSize = true;
			_LinkLabelOpenImageFile.BackColor = SystemColors.Window;
			_LinkLabelOpenImageFile.Location = new Point(254, 222);
			_LinkLabelOpenImageFile.Name = "_LinkLabelOpenImageFile";
			_LinkLabelOpenImageFile.Size = new Size(158, 15);
			_LinkLabelOpenImageFile.TabIndex = 10;
			_LinkLabelOpenImageFile.TabStop = true;
			_LinkLabelOpenImageFile.Text = "Click here to open image file";
			_LinkLabelOpenImageFile.Visible = false;
			_LinkLabelOpenImageFile.LinkClicked += _LinkLabelOpenImageFile_LinkClicked;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(657, 398);
			Controls.Add(_LabelNoFilesInsideFound);
			Controls.Add(_LinkLabelOpenImageFile);
			Controls.Add(_ListViewFilesInside);
			Controls.Add(_ToolStripMain);
			Controls.Add(_LabelOpenedFileName);
			Controls.Add(_LabelOpenedFile);
			Controls.Add(_LabelDescr);
			Controls.Add(_LabelMain);
			Controls.Add(_PictureBox);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FormMain";
			Text = "Hide data in file";
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
		private ToolStripMenuItem _MenuItemSaveAllFiles;
		private ColumnHeader _ColumnHeaderFileName;
		private LinkLabel _LinkLabelOpenImageFile;
		private ImageList _lmageListFileIcons;
		private ToolStripMenuItem _MenuItemSaveAs;
		private SaveFileDialog _SaveFileDialog;
	}
}