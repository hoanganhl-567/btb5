using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btb5
{
    public partial class Form1 : Form
    {
        private bool isNewFile = true;
        private string currentFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        // lưu nội dung văn bản
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isNewFile)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        richText.SaveFile(saveFileDialog.FileName);
                        isNewFile = false;
                        currentFilePath = saveFileDialog.FileName;
                    }
                }
            }
            else
            {
                richText.SaveFile(currentFilePath);
                MessageBox.Show("Lưu thành công!");
            }
        }

        //định dạng
        private void địnhDạngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                richText.ForeColor = fontDlg.Color;
                richText.Font = fontDlg.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void tạoTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richText.Clear();
            toolStripComboBox1.SelectedItem = "Tahoma";
            toolStripComboBox2.SelectedItem = 14;
            isNewFile = true;
            currentFilePath = string.Empty;
        }


        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Files (*.rtf)|*.rtf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    richText.LoadFile(openFileDialog.FileName);
                    isNewFile = false;
                    currentFilePath = openFileDialog.FileName;
                }
            }
        }


        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // chọn 1 font mới
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem != null)
            {
                richText.Font = new System.Drawing.Font(toolStripComboBox1.SelectedItem.ToString(), richText.Font.Size);
            }
        }

        //chọn 1 kích thước mới
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox2.SelectedItem != null)
            {
                richText.Font = new System.Drawing.Font(richText.Font.FontFamily, Convert.ToInt32(toolStripComboBox2.SelectedItem));
            }
        }

        //in đậm
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richText.SelectionFont = new System.Drawing.Font(richText.SelectionFont, richText.SelectionFont.Bold ? richText.SelectionFont.Style & ~System.Drawing.FontStyle.Bold : richText.SelectionFont.Style | System.Drawing.FontStyle.Bold);
        }

        //in nghiêng
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richText.SelectionFont = new System.Drawing.Font(richText.SelectionFont, richText.SelectionFont.Italic ? richText.SelectionFont.Style & ~System.Drawing.FontStyle.Italic : richText.SelectionFont.Style | System.Drawing.FontStyle.Italic);
        }

        //gạch dưới
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richText.SelectionFont = new System.Drawing.Font(richText.SelectionFont, richText.SelectionFont.Underline ? richText.SelectionFont.Style & ~System.Drawing.FontStyle.Underline : richText.SelectionFont.Style | System.Drawing.FontStyle.Underline);
        }
    }
}


Copy hay tự làm tao lấy trên chat rồi sửa lại thôi á
  hoồi trưa t có bấm git 1 lần giống bạn hồi sáng á create gì á
    b coi github có k 
còn 1 cách nx là dùng lệnh mà m ko có tỉa cái git về nên đành phải tạo 1 cái project 
    mới ở folder mới thì nó mới có cái crea repository