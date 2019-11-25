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
            DirectorLabel.Text = DirectorTextBox.Text;
        }
    }
}
 