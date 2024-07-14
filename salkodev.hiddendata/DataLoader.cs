using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using salkodev.hiddendata.Data;

namespace salkodev.hiddendata
{
	class DataLoader
	{
		public const int BUFFER_SIZE = 1024 * 256;

		public DataLoader()
		{
		}


		public bool Load(string fileName, byte[] markerBegin, out Metadata info, out int bytesCountBeforeMarker, out byte[] fileNamePureBody)
		{
			info = null;
			fileNamePureBody = null;
			bytesCountBeforeMarker = 0;

			byte[] block = new byte[BUFFER_SIZE];

			var metaDataBody = new List<byte>();
			var pureFileBody = new List<byte>(); //original image (pure) without our marker and metadata

			using (var fs = File.OpenRead(fileName))
			{
				int read;

				int indexInBeginMarker = 0; //начальный индекс маркера "начала" блока метаданных
				bool beginMarkerPassed = false;

				do
				{
					read = fs.Read(block, 0, BUFFER_SIZE);
					if (read > 0)
					{
						for (int i = 0; i < read; i++)
						{
							if (!beginMarkerPassed)
							{
								bytesCountBeforeMarker++;
								pureFileBody.Add(block[i]);

								bool found = _AddToTestBuffer(markerBegin, block[i], ref indexInBeginMarker);
								if (found)
								{
									//найден блок...читаем далее метаданные до "маркера завершения"
									beginMarkerPassed = true;

									//когда блок-маркер нашелся, нужно вычесть его длину из bytesCountBeforeMarker чтобы получить ориг.размер файла-изображения
									bytesCountBeforeMarker -= markerBegin.Length;
									fileNamePureBody = pureFileBody.Take(pureFileBody.Count- markerBegin.Length).ToArray();
								}
							}
							else
							{
								//после маркера начала накапливаем в буфер 
								metaDataBody.Add(block[i]);
							}

						}//for
					}

				} while (read == BUFFER_SIZE);

				//in case marker not found
				if (fileNamePureBody == null)
				{
					fileNamePureBody = pureFileBody.ToArray();
				}

				if (!beginMarkerPassed)
					return false;

				byte[] xmlBody = metaDataBody.ToArray();
				info = Metadata.Deserialize(xmlBody);

				return true;

			}//using

		}//Load

		/// <summary>
		/// 
		/// </summary>
		/// <param name="marker">special marker (buffer)</param>
		/// <param name="srcByte"></param>
		/// <param name="indexInMarker"></param>
		/// <returns>true if full block found</returns>
		bool _AddToTestBuffer(byte[] marker, byte srcByte, ref int indexInMarker)
		{
			//проверяем байт тот что ожидаем?
			if (marker[indexInMarker] != srcByte)
			{
				//начать с начала
				indexInMarker = 0;
				return false;
			}

			indexInMarker++;

			if (indexInMarker == marker.Length)
			{
				return true;
			}

			return false;
		}


	}
}
