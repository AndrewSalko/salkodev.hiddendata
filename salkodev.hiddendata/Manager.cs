using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using salkodev.hiddendata.Data;

namespace salkodev.hiddendata
{
	class Manager
	{
		public Manager()
		{
		}

		public DataState State
		{
			get;
			set;
		}

		/// <summary>
		/// Opened file name (.jpg image, etc.)
		/// </summary>
		public string FileName
		{
			get;
			set;
		}

		/// <summary>
		/// Original (pure, without meta-data) file body
		/// </summary>
		public byte[] FileNameBody
		{
			get;
			set;
		}

		/// <summary>
		/// Use password encryption (file names, file content)
		/// </summary>
		public bool PasswordEncryption
		{
			get;
			set;
		}

		/// <summary>
		/// Password (from settings dialog)
		/// </summary>
		public string Password
		{
			get;
			set;
		}

		public Metadata Data
		{
			get;
			set;
		}

		/// <summary>
		/// if something changed after load (description, files..., encryption)
		/// </summary>
		public bool Dirty
		{
			get;
			set;
		}



		public void AddFile(string fileName)
		{
			if (Data == null)
			{
				Data = new Metadata();
			}

			//проверим, если такое имя есть - перезапишем его
			bool foundAndUpdated = false;
			
			foreach (var fd in Data.Files)
			{
				if (fd.FileName == fileName)
				{
					fd.UpdateFromFile(fileName);

					foundAndUpdated = true;
					break;
				}
			}
			

			if (foundAndUpdated)
				return;

			//нужно добавить в сущ.набор
			int count = Data.Files.Length + 1;

			List<MetadataFile> files = new List<MetadataFile>(count);
			files.AddRange(Data.Files);

			var addFile = MetadataFile.FromFile(fileName);
			files.Add(addFile);

			Data.Files = files.ToArray();
		}


	}
}
