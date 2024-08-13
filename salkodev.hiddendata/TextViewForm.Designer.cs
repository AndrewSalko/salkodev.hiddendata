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
			_ButtonClose = new Button();
			_ButtonOK = new Button();
			_CheckBoxAllowEditing = new CheckBox();
			_TextBoxContent = new TextBox();
			SuspendLayout();
			// 
			// _ButtonClose
			// 
			_ButtonClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			_ButtonClose.DialogResult = DialogResult.Cancel;
			_ButtonClose.Location = new Point(570, 370);
			_ButtonClose.Name = "_ButtonClose";
			_ButtonClose.Size = new Size(75, 23);
			_ButtonClose.TabIndex = 0;
			_ButtonClose.Text = "Close";
			_ButtonClose.UseVisualStyleBackColor = true;
			// 
			// _ButtonOK
			// 
			_ButtonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			_ButtonOK.DialogResult = DialogResult.OK;
			_ButtonOK.Location = new Point(489, 370);
			_ButtonOK.Name = "_ButtonOK";
			_ButtonOK.Size = new Size(75, 23);
			_ButtonOK.TabIndex = 1;
			_ButtonOK.Text = "OK";
			_ButtonOK.UseVisualStyleBackColor = true;
			// 
			// _CheckBoxAllowEditing
			// 
			_CheckBoxAllowEditing.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			_CheckBoxAllowEditing.AutoSize = true;
			_CheckBoxAllowEditing.Location = new Point(12, 370);
			_CheckBoxAllowEditing.Name = "_CheckBoxAllowEditing";
			_CheckBoxAllowEditing.Size = new Size(96, 19);
			_CheckBoxAllowEditing.TabIndex = 2;
			_CheckBoxAllowEditing.Text = "Allow editing";
			_CheckBoxAllowEditing.UseVisualStyleBackColor = true;
			_CheckBoxAllowEditing.CheckedChanged += _CheckBoxAllowEditing_CheckedChanged;
			// 
			// _TextBoxContent
			// 
			_TextBoxContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			_TextBoxContent.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			_TextBoxContent.Location = new Point(12, 12);
			_TextBoxContent.Multiline = true;
			_TextBoxContent.Name = "_TextBoxContent";
			_TextBoxContent.ScrollBars = ScrollBars.Both;
			_TextBoxContent.Size = new Size(633, 352);
			_TextBoxContent.TabIndex = 3;
			// 
			// TextViewForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(657, 405);
			Controls.Add(_TextBoxContent);
			Controls.Add(_CheckBoxAllowEditing);
			Controls.Add(_ButtonOK);
			Controls.Add(_ButtonClose);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "TextViewForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "File content";
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