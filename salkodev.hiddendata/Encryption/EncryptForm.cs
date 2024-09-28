using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salkodev.hiddendata.Encryption
{
	public partial class EncryptForm : Form
	{
		public EncryptForm()
		{
			InitializeComponent();
		}

		public string Password
		{
			get
			{
				return _TextBoxPass.Text;
			}
			set
			{
				_TextBoxPass.Text = value;
			}
		}

		public bool PasswordUse
		{
			get
			{
				return _CheckBoxEnableEncryption.Checked;
			}
			set
			{
				_CheckBoxEnableEncryption.Checked = value;
			}
		}

		void _UpdateControls()
		{
			_TextBoxPass.Enabled = PasswordUse;
			_ButtonShowPass.Enabled = PasswordUse;
		}

		void EncryptForm_Load(object sender, EventArgs e)
		{
			_UpdateControls();

			_ApplyPassVisibility();
		}

		void _ApplyPassVisibility()
		{
			var c = _TextBoxPass.PasswordChar;

			if (c == '\0')
			{
				_TextBoxPass.PasswordChar = '*';
			}
			else
			{
				_TextBoxPass.PasswordChar = '\0';
			}
		}

		void _ButtonShowPass_Click(object sender, EventArgs e)
		{
			_ApplyPassVisibility();
		}

		void _CheckBoxEnableEncryption_CheckedChanged(object sender, EventArgs e)
		{
			_UpdateControls();
		}
	}
}
