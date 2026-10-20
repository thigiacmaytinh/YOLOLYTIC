using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TGMTcs;


namespace YoloSegment
{
    public partial class PopupRecent : Form
    {
        static PopupRecent m_instance;
        string selected = "";

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PopupRecent()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static PopupRecent GetInstance()
        {
            if (m_instance == null)
                m_instance = new PopupRecent();
            return m_instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PopupRecent_Load(object sender, EventArgs e)
        {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Choose(string controlName)
        {
            selected = string.Empty;

            listView1.Items.Clear();

            string text = TGMTregistry.GetInstance().ReadString(controlName + "_recent");
            string[] splitted = text.Split(';');

            int index = 0;
            for(int i = 0; i < splitted.Length; i++)
            {
                string stream = splitted[i];
                if(stream == "")
                    continue;

                ListViewItem item = new ListViewItem((++index).ToString());
                item.SubItems.Add(stream);
                listView1.Items.Add(item);
            }

            DialogResult result = this.ShowDialog();
            return result == DialogResult.OK ? selected : string.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            int index = listView1.SelectedIndices[0];

            selected = listView1.Items[index].SubItems[1].Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedIndices.Count == 0)
                return;
            
            int index = listView1.SelectedIndices[0];
            listView1.Items.RemoveAt(index);


            List<string> streams = new List<string>();
            for(int i=0; i< listView1.Items.Count; i++)
            {
                streams.Add(listView1.Items[i].SubItems[1].Text);
            }
            string text = string.Join(";", streams);
            TGMTregistry.GetInstance().SaveValue("streams", text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            int index = listView1.SelectedIndices[0];


            selected = listView1.Items[index].SubItems[1].Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////


        public static void SaveStream(string controlName, string recent)
        {
            string streams = TGMTregistry.GetInstance().ReadString(controlName + "_recent");
            List<string> recentList = new List<string>(streams.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
            if (!recentList.Contains(recent))
            {
                recentList.Add(recent);
                TGMTregistry.GetInstance().SaveValue(controlName + "_recent", string.Join(";", recentList));
            }
        }
    }
}
