using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salkodev.hiddendata.Data
{
	/// <summary>
	/// File info (body, file name, and last write time)
	/// </summary>
	public class MetadataFile
	{
		public MetadataFile()
		{
		}

		/// <summary>
		/// File name
		/// </summary>
		public string FileName
		{
			get;
			set;
		}

		/// <summary>
		/// If file encrypted, FileName will be empty and real file name stored here
		/// </summary>
		public byte[] FileNameEncrypted
		{
			get;
			set;
		}

		/// <summary>
		/// File body (content)
		/// </summary>
		public byte[] Body
		{
			get;
			set;
		}

		/// <summary>
		/// File hash (for integrity control)
		/// </summary>
		public byte[] Hash
		{
			get;
			set;
		}


		/// <summary>
		/// Last write time of file (preserved during save and restore)
		/// </summary>
		public DateTime LastWriteTime
		{
			get;
			set;
		}

		public void UpdateFromFile(string fileName)
		{
			byte[] body = File.ReadAllBytes(fileName);
			Body = body;

			FileInfo fi = new FileInfo(fileName);
			LastWriteTime = fi.LastWriteTimeUtc;
		}

		public static MetadataFile FromFile(string fileName)
		{
			var result = new MetadataFile();
			result.FileName = Path.GetFileName(fileName);

			result.UpdateFromFile(fileName);
			return result;
		}

		public void SaveTo(string destFileName)
		{
			File.WriteAllBytes(destFileName, Body);

			File.SetLastWriteTimeUtc(destFileName, LastWriteTime);
		}
	}
}
