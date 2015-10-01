using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEditor
{
    // class for just easier programming, memmory is not a concern
    public class LanguageEntry
    {
        public string key;
        public string value;

        public LanguageEntry(string k, string v)
        {
            key = k;
            value = v;
        }

        public override string ToString()
        {
            return string.Format("[{0}, {1}]", key, value);
        }
    }
}
