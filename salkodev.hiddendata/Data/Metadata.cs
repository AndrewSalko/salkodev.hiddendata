using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace salkodev.hiddendata.Data
{
	[Serializable]
	public class Metadata
	{
		public Metadata()
		{
			Files = new MetadataFile[0];
		}

		/// <summary>
		/// Custom description will be shown (main text)
		/// </summary>
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		/// Files (with name, body...)
		/// </summary>
		public MetadataFile[] Files
		{
			get;
			set;
		}

		static XmlSerializer _Serializer = new XmlSerializer(typeof(Metadata));

		public byte[] Serialize()
		{
			using (var memStream = new MemoryStream())
			{
				using (var fs = new StreamWriter(memStream, new UTF8Encoding(true)))
				{
					_Serializer.Serialize(fs, this);
				}

				byte[] bytes = memStream.ToArray();
				return bytes;
			}
		}

		public static Metadata Deserialize(byte[] data)
		{
			using (var memStream = new MemoryStream(data))
			{
				using (var fs = new StreamReader(memStream, new UTF8Encoding(true)))
				{
					var result = (Metadata)_Serializer.Deserialize(fs);
					return result;
				}
			}
		}

	}
}
