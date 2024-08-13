using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace salkodev.hiddendata
{
	public partial class TextViewForm : Form
	{
		public TextViewForm()
		{
			InitializeComponent();
		}

		public string FileContent
		{
			get
			{
				return _TextBoxContent.Text;
			}
			set
			{
				_TextBoxContent.Text = value;
			}
		}

		void _UpdateControls()
		{
			bool allowEditing = _CheckBoxAllowEditing.Checked;

			_ButtonOK.Enabled = allowEditing;
			_TextBoxContent.ReadOnly = !allowEditing;
		}

		void _CheckBoxAllowEditing_CheckedChanged(object sender, EventArgs e)
		{
			_UpdateControls();
		}

		void TextViewForm_Load(object sender, EventArgs e)
		{
			_UpdateControls();
		}
	}
}
