using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CrypHelpers
{
    public class HashHelper : IHashHelper
    {
        public Task<string> Base64Decode(string word)
        {
            throw new NotImplementedException();
        }

        public Task<string> Base64Encode(string word)
        {
            throw new NotImplementedException();
        }

        public async Task<string> MD5(string word)
        {
            return await Task.Run(() => {
                MD5 md5 = MD5CryptoServiceProvider.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(word));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            });
        }

        public Task<string> SHA1(string str)
        {
            throw new NotImplementedException();
        }

        public Task<string> SHA256(string str)
        {
            throw new NotImplementedException();
        }

        public Task<string> SHA384(string str)
        {
            throw new NotImplementedException();
        }

        public Task<string> SHA512(string str)
        {
            throw new NotImplementedException();
        }

        public Task<string> Token()
        {
            throw new NotImplementedException();
        }
    }
}
