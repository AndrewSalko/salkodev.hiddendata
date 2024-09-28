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
	public partial class PasswordForm : Form
	{
		public PasswordForm()
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


		void PasswordForm_Load(object sender, EventArgs e)
		{
			_ApplyPassVisibility();
			_UpdateControls();
		}

		void _UpdateControls()
		{
			_ButtonOK.Enabled = !string.IsNullOrWhiteSpace(Password);
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

		private void _TextBoxPass_TextChanged(object sender, EventArgs e)
		{
			_UpdateControls();
		}
	}
}
