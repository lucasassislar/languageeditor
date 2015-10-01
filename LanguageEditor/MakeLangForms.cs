using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageEditor
{
    public partial class MakeLangForms : Form
    {
        public MakeLangForms()
        {
            InitializeComponent();
            htmls = new List<string>();
        }

        private List<string> htmls;

        private void btnSearchFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    txtFolder.Text = folder.SelectedPath;
                }
            }
        }

        private void button_addHtml_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    htmls.Add(open.FileName);
                    list_htmls.Items.Add(open.FileName);
                }
            }
        }

        private void button_Make_Click(object sender, EventArgs e)
        {
            string folder = txtFolder.Text;
            string output = Path.Combine(folder, "html");
            Directory.CreateDirectory(output);

            List<LanguageFileSerializable> langs = new List<LanguageFileSerializable>();
            FileInfo[] files = new DirectoryInfo(folder).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo f = files[i];
                langs.Add(LanguageFile.LoadIntermediate(f.FullName));
            }


            for (int i = 0; i < htmls.Count; i++)
            {
                string htmlPath = htmls[i];

                for (int j = 0; j < langs.Count; j++)
                {
                    string html = File.ReadAllText(htmlPath);
                    LanguageFileSerializable lang = langs[j];

                    int start = 0;
                    int index = 0;
                    for (; ; )
                    {
                        index = html.IndexOf('$', start);
                        if (index == -1)
                        {
                            break;
                        }
                        if (index > 0)
                        {
                            var bf = html[index - 1];
                            if (bf == 'R')
                            {
                                start = index + 1;
                                continue;
                            }
                        }

                        int endIndex = html.IndexOf('$', index + 1);
                        if (endIndex == -1)
                        {
                            break;
                        }

                        string word = html.Substring(index + 1, endIndex - index - 1);
                        start = endIndex + 1;

                        string value;
                        if (lang.data.TryGetValue(word, out value))
                        {
                            html = html.Remove(index, endIndex - index + 1);
                            html = html.Insert(index, value);
                        }
                    }

                    string fileName = Path.GetFileNameWithoutExtension(htmlPath) + "." + lang.languageCode + ".html";
                    string path = Path.Combine(output, fileName);
                    File.WriteAllText(path, html, Encoding.UTF8);
                }
            }
        }
    }
}
