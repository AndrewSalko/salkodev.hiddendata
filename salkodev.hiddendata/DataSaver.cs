using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salkodev.hiddendata
{
	class DataSaver
	{
		public DataSaver()
		{
		}

		public void Save(string destFileName, byte[] fileBody, byte[] marker, Data.Metadata metadata)
		{
			if (fileBody == null || fileBody.Length == 0)
				throw new ArgumentNullException(nameof(fileBody));

			if (marker == null || marker.Length == 0)
				throw new ArgumentNullException(nameof(marker));

			if (metadata == null)
				throw new ArgumentNullException(nameof(metadata));

			//image file - destFileName, his pure (original) body in fileNameBody

			using (var fs = File.Create(destFileName))
			{
				fs.Write(fileBody, 0, fileBody.Length);

				fs.Write(marker, 0, marker.Length);

				byte[] hiddenData = metadata.Serialize();

				fs.Write(hiddenData, 0, hiddenData.Length);

			}//using

		}//Save

	}//DataSaver
}
