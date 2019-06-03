using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mirror(string name)
        {
            Bitmap image = new Bitmap(Image.FromFile(name));//geting file
            Bitmap bitmap = new Bitmap(image.Width, image.Height);

            for (int y=0;y<image.Height;y++)
            {
                for (int x=0;x<image.Width;x++)
                {
                    bitmap.SetPixel(x,y,image.GetPixel(image.Width-x-1,y));//copying image reversed
                }
            }
            pictureBox1.Image = bitmap;
        }

        private void SaveImage(string name)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            bitmap.Save(name);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveImage(saveFileDialog.FileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "PNG (*.png)|*.png|JPG (*.jpg)|*.jpg";


            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                mirror(fileDialog.FileName);

                saveToolStripMenuItem.Enabled = true;
            }
        }
    }
}
