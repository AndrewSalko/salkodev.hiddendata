namespace salkodev.hiddendata.Encryption
{
	partial class EncryptForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptForm));
			_ButtonCancel = new Button();
			_ButtonOK = new Button();
			_PictureBoxEncryption = new PictureBox();
			_LabelMain = new Label();
			_LabelDescr = new Label();
			_CheckBoxEnableEncryption = new CheckBox();
			_TextBoxPass = new TextBox();
			_ButtonShowPass = new Button();
			((System.ComponentModel.ISupportInitialize)_PictureBoxEncryption).BeginInit();
			SuspendLayout();
			// 
			// _ButtonCancel
			// 
			resources.ApplyResources(_ButtonCancel, "_ButtonCancel");
			_ButtonCancel.DialogResult = DialogResult.Cancel;
			_ButtonCancel.Name = "_ButtonCancel";
			_ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// _ButtonOK
			// 
			resources.ApplyResources(_ButtonOK, "_ButtonOK");
			_ButtonOK.DialogResult = DialogResult.OK;
			_ButtonOK.Name = "_ButtonOK";
			_ButtonOK.UseVisualStyleBackColor = true;
			// 
			// _PictureBoxEncryption
			// 
			resources.ApplyResources(_PictureBoxEncryption, "_PictureBoxEncryption");
			_PictureBoxEncryption.Image = Properties.Resources.Encrypt_Icon_48;
			_PictureBoxEncryption.Name = "_PictureBoxEncryption";
			_PictureBoxEncryption.TabStop = false;
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
			// _CheckBoxEnableEncryption
			// 
			resources.ApplyResources(_CheckBoxEnableEncryption, "_CheckBoxEnableEncryption");
			_CheckBoxEnableEncryption.Name = "_CheckBoxEnableEncryption";
			_CheckBoxEnableEncryption.UseVisualStyleBackColor = true;
			_CheckBoxEnableEncryption.CheckedChanged += _CheckBoxEnableEncryption_CheckedChanged;
			// 
			// _TextBoxPass
			// 
			resources.ApplyResources(_TextBoxPass, "_TextBoxPass");
			_TextBoxPass.Name = "_TextBoxPass";
			// 
			// _ButtonShowPass
			// 
			resources.ApplyResources(_ButtonShowPass, "_ButtonShowPass");
			_ButtonShowPass.Image = Properties.Resources.eye_icon_16;
			_ButtonShowPass.Name = "_ButtonShowPass";
			_ButtonShowPass.UseVisualStyleBackColor = true;
			_ButtonShowPass.Click += _ButtonShowPass_Click;
			// 
			// EncryptForm
			// 
			AcceptButton = _ButtonOK;
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = _ButtonCancel;
			Controls.Add(_ButtonShowPass);
			Controls.Add(_TextBoxPass);
			Controls.Add(_CheckBoxEnableEncryption);
			Controls.Add(_LabelDescr);
			Controls.Add(_LabelMain);
			Controls.Add(_PictureBoxEncryption);
			Controls.Add(_ButtonOK);
			Controls.Add(_ButtonCancel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "EncryptForm";
			Load += EncryptForm_Load;
			((System.ComponentModel.ISupportInitialize)_PictureBoxEncryption).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button _ButtonCancel;
		private Button _ButtonOK;
		private PictureBox _PictureBoxEncryption;
		private Label _LabelMain;
		private Label _LabelDescr;
		private CheckBox _CheckBoxEnableEncryption;
		private TextBox _TextBoxPass;
		private Button _ButtonShowPass;
	}
}