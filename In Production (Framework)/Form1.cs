using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using _Excel = Microsoft.Office.Interop.Excel;

namespace In_Production__Framework_
{
    public partial class InitialScreen : Form
    {
        public int intControler = 416;
        public int directorCounter = 1;
        public InitialScreen()
        {
            InitializeComponent();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string prodText = ProductionTitleInput.Text;
        }

        private void InitialScreen_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string productionTitle = ProductionTitleInput.Text;
        }

        private void CallTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            string callTime = CallTimeTextBox.Text;
        }

        private void ShootingTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            string shootingTime = ShootingTimeTextBox.Text;
        }

        private void DirectorTextBox_TextChanged(object sender, EventArgs e)
        {
            string directorName = DirectorTextBox.Text;
        }
    

        private void ProducerTextBox_TextChanged(object sender, EventArgs e)
        {
            string producerName = ProducerTextBox.Text;
        }

        private void DPTextBox_TextChanged(object sender, EventArgs e)
        {
            string dpName = DPTextBox.Text;
        }

        private void FirstADTextBox_TextChanged(object sender, EventArgs e)
        {
            string firstAD = FirstADTextBox.Text;
        }

        private void LocationTextBox_TextChanged(object sender, EventArgs e)
        {
            string location = LocationTextBox.Text;
        }        

        private void DirectorLabel_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            DirectorLabel.Text = DirectorTextBox.Text;
            FirstADLabel.Text = FirstADTextBox.Text;

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if(directorCounter < 6)
            {
               AddNewDirectorRoleTextBox();
               AddNewDirectorNameTextBox();
                
                directorCounter++;
            }  
            else
            {
                MessageBox.Show("You have reached the maximum amount of roles.");
            }

        }
        
        public System.Windows.Forms.TextBox AddNewDirectorRoleTextBox()
        {            
            System.Windows.Forms.TextBox directorTeamRole = new System.Windows.Forms.TextBox();
           // DirectorTeamTab.Controls.Add(directorTeamRole);
            intControler = intControler + 151;
            // Need to increase the intController value for the next box
            //directorTeamRole.Top = intControler;
            //directorTeamRole.Left = 73;            
            directorTeamRole.Text = "Role" + this.directorCounter.ToString();
            directorTeamRole.Name = "DirectorRole" + this.directorCounter.ToString();
            directorTeamRole.Size = new System.Drawing.Size(80, 2000);
            directorTeamRole.Location = new System.Drawing.Point(25, (150+(55*this.directorCounter)));
            directorTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            DirectorTeamTab.Controls.Add(directorTeamRole);
            return directorTeamRole;
        } 
        public System.Windows.Forms.TextBox AddNewDirectorNameTextBox()
        {            
            System.Windows.Forms.TextBox directorTeamName = new System.Windows.Forms.TextBox();
            DirectorTeamTab.Controls.Add(directorTeamName);
            //directorTeamName.Top = intControler + 151;
            //directorTeamName.Left = 384;
            directorTeamName.Text = "Name" + this.directorCounter.ToString();
            directorTeamName.Tag = directorTeamName.Text;
            directorTeamName.Name = "DirectorName" + this.directorCounter.ToString();
            directorTeamName.Size = new System.Drawing.Size(170, 2000);
            directorTeamName.Location = new System.Drawing.Point(120, (150 + (55 * this.directorCounter)));
            directorTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            directorTeamName.Enter += input_GainFocus;
            //if (directorTeamName.Text.Length == 0 )
            //{
            //    
            //}
            directorTeamName.Leave += input_LoseFocus;
            return directorTeamName;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            String fileContent;
            String filename = "D:\\config.txt";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                MessageBox.Show(filename);

                // Default file

                String[] lines;

                if (System.IO.File.Exists(filename))
                {
                    lines = System.IO.File.ReadAllLines(filename);

                    //The lines in the file are ordered in the following manner
                    ProductionTitleInput.Text = lines[0];

                    DateTime tempDate = DateTime.Parse(lines[1]);
                    dateTimePicker2.Value = tempDate;

                    CallTimeTextBox.Text = lines[2];
                    ShootingTimeTextBox.Text = lines[3];
                    DirectorTextBox.Text = lines[4];
                    ProducerTextBox.Text = lines[5];
                    DPTextBox.Text = lines[6];
                    FirstADTextBox.Text = lines[7];
                    LocationTextBox.Text = lines[8];

                    int index = 9;
                    int roleIndex = 1;
                    while (index < 19)
                    {
                        // Check for roles 1-5
                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = DirectorTeamTab.Controls.Find("Role" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (directorCounter < 6)
                                {
                                    btnDirectorAddRole.PerformClick();
                                    AddNewDirectorRoleTextBox();
                                    AddNewDirectorNameTextBox();
                                    directorCounter++;

                                    tbxs = DirectorTeamTab.Controls.Find("Role" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = DirectorTeamTab.Controls.Find("Name" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }


                        }
                        roleIndex++;

                        // Go to the next line which woyud be the next role
                        index++;
                    }

                }
                
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            // Default file
            String filename = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "D:\\";
            saveFileDialog.Title = "Save config file.";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog.FileName;

                // Create or overwrite the file
                System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, false);
                sw.WriteLine(ProductionTitleInput.Text);
                sw.WriteLine(dateTimePicker2.Value.ToString());
                sw.WriteLine(CallTimeTextBox.Text);
                sw.WriteLine(ShootingTimeTextBox.Text);
                sw.WriteLine(DirectorTextBox.Text);
                sw.WriteLine(ProducerTextBox.Text);
                sw.WriteLine(DPTextBox.Text);
                sw.WriteLine(FirstADTextBox.Text);
                sw.WriteLine(LocationTextBox.Text);

                int roleIndex = 1;
                while (roleIndex < 6)
                {
                    Control[] tbxs = DirectorTeamTab.Controls.Find("Role" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = DirectorTeamTab.Controls.Find("Name" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }

                    roleIndex++;
                }
                sw.Close();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            /*Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;*/
            _Application excel = new _Excel.Application();
            string workbookPath = System.Windows.Forms.Application.StartupPath + @"\template.xlsx";
            Workbook wb = excel.Workbooks.Open(workbookPath);
            Worksheet ws = wb.Worksheets[1];

            excel.Visible = true;
            ws.Cells[1,12] = ProductionTitleInput.Text;
            ws.Cells[2,5] = DirectorTextBox.Text;
            ws.Cells[3, 5] = ProducerTextBox.Text;
            ws.Cells[7,12] = CallTimeTextBox.Text;
            ws.Cells[7, 23] = ShootingTimeTextBox.Text;
        }

        private void input_GainFocus(object sender, EventArgs e)
        {
            var input = (System.Windows.Forms.TextBox)sender;
            if(input.Text == input.Tag.ToString())
            {
                input.Text = "";
            }
        }

        private void input_LoseFocus(object sender, EventArgs e)
        {
            var input = (System.Windows.Forms.TextBox)sender;
            input.Text = input.Tag.ToString();
        }
    }
}
 