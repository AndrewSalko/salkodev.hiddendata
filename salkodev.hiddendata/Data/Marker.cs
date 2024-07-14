using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace salkodev.hiddendata.Data
{
	class Marker
	{
		/// <summary>
		/// This block will be at the end of "original" data, after will be our metadata xml (see class Metadata)
		/// </summary>
		public static readonly byte[] META_DATA_BEGIN_MARKER = { 0xB3, 0xD5, 0x26, 0x12, 0xA3, 0x86, 0x49, 0x44, 0x9F, 0x62, 0x42, 0xEF, 0xB3, 0x33, 0x1A, 0x22 };

		//public static readonly byte[] META_DATA_END_MARKER = { 0xB6, 0x10, 0x4A, 0xED, 0x17, 0x4C, 0x4E, 0x86, 0xAD, 0x10, 0xEF, 0xBE, 0x74, 0x11, 0x4A, 0x56 };
	}
}