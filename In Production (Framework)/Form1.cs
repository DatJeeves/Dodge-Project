using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        }
        
        public System.Windows.Forms.TextBox AddNewDirectorRoleTextBox()
        {            
            System.Windows.Forms.TextBox directorTeamRole = new System.Windows.Forms.TextBox();
           // DirectorTeamTab.Controls.Add(directorTeamRole);
            intControler = intControler + 151;
            // Need to increase the intController value for the next box
            //directorTeamRole.Top = intControler;
            //directorTeamRole.Left = 73;
            directorTeamRole.Name = "Role" + this.directorCounter.ToString();
            directorTeamRole.Text = "Role" + this.directorCounter.ToString();
            directorTeamRole.Size = new System.Drawing.Size(300, 2000);
            directorTeamRole.Location = new System.Drawing.Point(80, (150+(55*this.directorCounter)));
            directorTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            DirectorTeamTab.Controls.Add(directorTeamRole);
            return directorTeamRole;
        } 
        public System.Windows.Forms.TextBox AddNewDirectorNameTextBox()
        {            
            TextBox directorTeamName = new TextBox();
            DirectorTeamTab.Controls.Add(directorTeamName);
            //directorTeamName.Top = intControler + 151;
            //directorTeamName.Left = 384;
            directorTeamName.Text = "Name" + this.directorCounter.ToString();

            directorTeamName.Size = new System.Drawing.Size(300, 2000);
            directorTeamName.Location = new System.Drawing.Point(400, (150 + (55 * this.directorCounter)));
            directorTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            return directorTeamName;
        }
    }
}
 