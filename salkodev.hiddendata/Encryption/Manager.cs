using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace salkodev.hiddendata.Encryption
{
	class Manager
	{
		public const int BUFF_SIZE = 256 * 1024;


		public Manager()
		{
		}

		/// <summary>
		/// Generate hash for data (data may be file body, or file name)
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public byte[] GetHash(byte[] data)
		{
			using (var sha256 = SHA256.Create())
			{
				return sha256.ComputeHash(data);
			}
		}

		public byte[] GetHash(string fileName)
		{
			var data = Encoding.UTF8.GetBytes(fileName);

			return GetHash(data);
		}

		/// <summary>
		/// AES encryption
		/// </summary>
		/// <param name="data">data (file body or file name)</param>
		/// <param name="key">Encryption key (this is hash of password)</param>
		/// <returns>encrypted data with init vector at the beginning</returns>
		public byte[] EncryptData(byte[] data, byte[] key)
		{
			using (var aesAlg = Aes.Create())
			{
				aesAlg.Key = key;
				aesAlg.GenerateIV(); // Initialization Vector

				ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

				using (var ms = new MemoryStream())
				{
					// save init vector (we will need it on decryption)
					ms.Write(aesAlg.IV, 0, aesAlg.IV.Length);

					using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						cs.Write(data, 0, data.Length);
					}

					return ms.ToArray();
				}

			}//using aesAlg
		}


		/// <summary>
		/// AES decryption 
		/// </summary>
		/// <param name="encryptedData"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public byte[] DecryptData(byte[] encryptedData, byte[] key)
		{
			using (Aes aesAlg = Aes.Create())
			{
				using (MemoryStream ms = new MemoryStream(encryptedData))
				{
					// read init vector from beginning
					byte[] iv = new byte[16];
					ms.Read(iv, 0, iv.Length);

					aesAlg.Key = key;
					aesAlg.IV = iv;

					ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

					using (var csDecrypt = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
					{
						byte[] buff = new byte[BUFF_SIZE];

						using (var destMs = new MemoryStream())
						{
							int read = csDecrypt.Read(buff, 0, buff.Length);
							while (read > 0)
							{
								destMs.Write(buff, 0, read);
								read = csDecrypt.Read(buff, 0, buff.Length);
							}

							return destMs.ToArray();
						}
					}
				}//using ms
			}//using aesAlg

		}//DecryptData

		public bool HashEquals(byte[] hash, byte[] decryptedHash)
		{
			if (hash == null)
				throw new ArgumentNullException(nameof(hash));

			if (decryptedHash == null)
				throw new ArgumentNullException(nameof(decryptedHash));

			bool eq = hash.SequenceEqual(decryptedHash);
			return eq;
		}
	}
}
