using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageEditor
{
    public class LanguageFile
    {
        public static readonly double Version = 1.0;

        public double version;
        public string name;
        public string languageCode;
        public List<LanguageEntry> data;

        public LanguageFile()
        {
            version = Version;
        }

        public LanguageFileSerializable GetSerializable()
        {
            LanguageFileSerializable ser = new LanguageFileSerializable();
            ser.version = version;
            ser.name = name;
            ser.languageCode = languageCode;
            ser.data = new Dictionary<string, string>();

            for (int i = 0; i < data.Count; i++)
            {
                LanguageEntry e = data[i];
                ser.data.Add(e.key, e.value);
            }
            return ser;
        }

        public static LanguageFile ToLanguageFile(LanguageFileSerializable ser)
        {
            LanguageFile f = new LanguageFile();
            f.version = ser.version;
            f.name = ser.name;
            f.languageCode = ser.languageCode;
            f.data = new List<LanguageEntry>();

            foreach (var pair in ser.data)
            {
                f.data.Add(new LanguageEntry(pair.Key, pair.Value));
            }
            return f;
        }

        public string Save()
        {
            return JsonConvert.SerializeObject(GetSerializable());
        }
        public void Save(string path)
        {
            File.WriteAllText(path, Save());
        }
        public static LanguageFile Deserialize(string data)
        {
            LanguageFileSerializable file = JsonConvert.DeserializeObject<LanguageFileSerializable>(data);
            return ToLanguageFile(file);
        }
        public static LanguageFile Load(string path)
        {
            return Deserialize(File.ReadAllText(path));
        }
        public static LanguageFileSerializable DeserializeIntermediate(string data)
        {
            LanguageFileSerializable file = JsonConvert.DeserializeObject<LanguageFileSerializable>(data);
            return file;
        }

        public static LanguageFileSerializable LoadIntermediate(string path)
        {
            return DeserializeIntermediate(File.ReadAllText(path));
        }
    }
}
