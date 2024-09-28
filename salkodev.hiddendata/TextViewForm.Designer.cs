namespace salkodev.hiddendata
{
	partial class TextViewForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextViewForm));
			_ButtonClose = new Button();
			_ButtonOK = new Button();
			_CheckBoxAllowEditing = new CheckBox();
			_TextBoxContent = new TextBox();
			SuspendLayout();
			// 
			// _ButtonClose
			// 
			resources.ApplyResources(_ButtonClose, "_ButtonClose");
			_ButtonClose.DialogResult = DialogResult.Cancel;
			_ButtonClose.Name = "_ButtonClose";
			_ButtonClose.UseVisualStyleBackColor = true;
			// 
			// _ButtonOK
			// 
			resources.ApplyResources(_ButtonOK, "_ButtonOK");
			_ButtonOK.DialogResult = DialogResult.OK;
			_ButtonOK.Name = "_ButtonOK";
			_ButtonOK.UseVisualStyleBackColor = true;
			// 
			// _CheckBoxAllowEditing
			// 
			resources.ApplyResources(_CheckBoxAllowEditing, "_CheckBoxAllowEditing");
			_CheckBoxAllowEditing.Name = "_CheckBoxAllowEditing";
			_CheckBoxAllowEditing.UseVisualStyleBackColor = true;
			_CheckBoxAllowEditing.CheckedChanged += _CheckBoxAllowEditing_CheckedChanged;
			// 
			// _TextBoxContent
			// 
			resources.ApplyResources(_TextBoxContent, "_TextBoxContent");
			_TextBoxContent.Name = "_TextBoxContent";
			// 
			// TextViewForm
			// 
			resources.ApplyResources(this, "$this");
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(_TextBoxContent);
			Controls.Add(_CheckBoxAllowEditing);
			Controls.Add(_ButtonOK);
			Controls.Add(_ButtonClose);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TextViewForm";
			Load += TextViewForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button _ButtonClose;
		private Button _ButtonOK;
		private CheckBox _CheckBoxAllowEditing;
		private TextBox _TextBoxContent;
	}
}