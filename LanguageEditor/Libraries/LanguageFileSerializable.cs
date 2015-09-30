using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEditor
{
    public class LanguageFileSerializable
    {
        public double version;
        public string name;
        public string languageCode;
        public Dictionary<string, string> data;
    }
}
