using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        StreamReader streamReader;
        StreamWriter streamWriter;
        String fileName;  //the name of the file that the user wants to open

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult) ;
            {
                fileName = openFileDialog.FileName;
            }

            if (fileName != null)  //open the file only if the file name is not blank
            {
                streamReader = new StreamReader(fileName);

                try
                {
                    txtMain.Text = streamReader.ReadToEnd();

                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "txt";   // Specifies that all the files to be saved are in txt format

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

                if(fileName !=null)
                {
                    streamWriter = new StreamWriter(fileName);

                    try
                    {
                        streamWriter.Write(txtMain.Text);
                    }

                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    finally
                    {
                        streamWriter.Close();
                    }
                    
                }
            }
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(File.GetCreationTime(fileName).ToString());
        }
    }
}
