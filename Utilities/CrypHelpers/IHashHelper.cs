using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.CrypHelpers
{
    public interface IHashHelper
    {
        Task<string> MD5(string word);
        Task<string> Token();
        Task<string> Base64Encode(string word);
        Task<string> Base64Decode(string word);
        Task<string> SHA1(string str);
        Task<string> SHA256(string str);
        Task<string> SHA384(string str);
        Task<string> SHA512(string str);
      
    }
}
