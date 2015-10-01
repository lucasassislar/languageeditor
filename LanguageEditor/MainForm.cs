using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageEditor
{
    public partial class MainForm : Form
    {
        private LanguageFile langFile;

        public MainForm()
        {
            InitializeComponent();

            //this.SetStyle(
            //   ControlStyles.AllPaintingInWmPaint |
            //   ControlStyles.UserPaint |
            //   ControlStyles.DoubleBuffer,
            //   true);

            langFile = new LanguageFile();
            langFile.data = new List<LanguageEntry>();

            list_keys.DataSource = langFile.data;
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
            txtValue.Text = "";

            selected = null;
            langFile = new LanguageFile();
            langFile.data = new List<LanguageEntry>();
            list_keys.DataSource = langFile.data;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtKey.Text = "";
                    txtValue.Text = "";
                    selected = null;

                    langFile = LanguageFile.Load(open.FileName);
                    savePath = open.FileName;

                    list_keys.DataSource = langFile.data;
                }
            }
        }


        private string savePath;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(savePath))
            {
                DoSaveAs();
            }
            else
            {
                DoSave();
            }
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSaveAs();
        }

        private void DoSaveAs()
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "Nucleus Language Files|*.nl|All Files|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    savePath = save.FileName;
                    langFile.Save(savePath);
                }
            }
        }

        private void DoSave()
        {
            langFile.Save(savePath);
        }

        private bool locked;
        private int top;
        private int lastSelected;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            BeginUpdateList();

            langFile.data.Add(new LanguageEntry(langFile.data.Count.ToString(), ""));

            EndUpdateList();
        }

        private void BeginUpdateList()
        {
            locked = true;
            top = list_keys.TopIndex;
            lastSelected = list_keys.SelectedIndex;
            list_keys.DataSource = null;
        }

        private void EndUpdateList()
        {
            list_keys.DataSource = langFile.data;
            list_keys.TopIndex = top;
            list_keys.SelectedIndex = lastSelected;
            locked = false;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private LanguageEntry selected;
        private void list_keys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (locked || list_keys.SelectedIndex == -1)
            {
                return;
            }

            selected = (LanguageEntry)list_keys.SelectedValue;
            txtKey.Text = selected.key;
            txtValue.Text = selected.value;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (selected != null)
            {
                BeginUpdateList();
                selected.value = txtValue.Text;
                list_keys.Invalidate();
                EndUpdateList();
            }
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            if (selected != null)
            {
                BeginUpdateList();
                selected.key = txtKey.Text;
                list_keys.Invalidate();
                EndUpdateList();
            }
        }

        private void preProcessHtmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakeLangForms form = new MakeLangForms();
            form.Show();
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            langFile.languageCode = txtCode.Text;
        }

     
      

       

    }
}
