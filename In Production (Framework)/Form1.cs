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
        public String tempValue = "";
        public int directorCounter = 1;
        public int dopCounter = 1;
        public int artCounter = 1;
        public int soundCounter = 1;
        public int editorCounter = 1;
        public int gripCounter = 1;
        public int makeUpCounter = 1;
        public int sceneCounter = 1;
        public int actorCounter = 1;
        public int maxDirectorCount = 7;
        public int maxDopCounter = 6;
        public int maxArtCounter = 7;
        public int maxSoundCounter = 7;
        public int maxEditorCounter = 3;
        public int maxGripCounter = 19;
        public int maxMakeUpCounter = 8;
        public int maxSceneCounter = 2;
        public int maxActorCounter = 4;
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
            DoPLabel.Text = DPTextBox.Text;
            lblLocationValue.Text = LocationTextBox.Text;
            dtpLunchTime.Value = CallTime.Value;
            dtpLunchTime.Value = dtpLunchTime.Value.AddMinutes(60);
            if (CallTime.Value > ShootingTime.Value)
            {
                MessageBox.Show ("Warning your Call Time is later than your Shoot Time!");
            }

        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (directorCounter < maxDirectorCount)
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
            DirectorTeamTab.Controls.Add(directorTeamRole);
            intControler = intControler + 151;
            switch (this.directorCounter)
            {
                case 1:
                    directorTeamRole.Text = "2nd AD";
                    break;
                default:
                    directorTeamRole.Text = directorTeamRole.Text = "Role" + this.directorCounter.ToString();
                    break;

            }
            directorTeamRole.Name = "DirectorRole" + this.directorCounter.ToString();
            directorTeamRole.Tag = directorTeamRole.Text;
            directorTeamRole.Name = "DirectorRole" + this.directorCounter.ToString();
            directorTeamRole.Size = new System.Drawing.Size(80, 2000);
            directorTeamRole.Location = new System.Drawing.Point(25, (100 + (55 * this.directorCounter)));
            directorTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            directorTeamRole.Enter += input_GainFocus;
            directorTeamRole.Leave += input_LoseFocus;
            return directorTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewDirectorNameTextBox()
        {
            System.Windows.Forms.TextBox directorTeamName = new System.Windows.Forms.TextBox();
            DirectorTeamTab.Controls.Add(directorTeamName);

            directorTeamName.Text = "Name" + this.directorCounter.ToString();
            directorTeamName.Tag = directorTeamName.Text;
            directorTeamName.Name = "DirectorName" + this.directorCounter.ToString();
            directorTeamName.Size = new System.Drawing.Size(170, 2000);
            directorTeamName.Location = new System.Drawing.Point(120, (100 + (55 * this.directorCounter)));
            directorTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            directorTeamName.Enter += input_GainFocus;
            directorTeamName.Leave += input_LoseFocus;

            return directorTeamName;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            String filename = "D:\\config.txt";

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "D:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;

                // Default file

                String[] lines;

                if (System.IO.File.Exists(filename))
                {
                    lines = System.IO.File.ReadAllLines(filename);
                    int index = 0;
                    //The lines in the file are ordered in the following manner
                    ProductionTitleInput.Text = lines[index++];
                    dateTimePicker2.Value = DateTime.Parse(lines[index++]);
                    CallTime.Value = DateTime.Parse(lines[index++]);
                    ShootingTime.Value = DateTime.Parse(lines[index++]);
                    DirectorTextBox.Text = lines[index++];
                    ProducerTextBox.Text = lines[index++];
                    DPTextBox.Text = lines[index++];
                    FirstADTextBox.Text = lines[index++];
                    LocationTextBox.Text = lines[index++];
                    setPhone.Text = lines[index++];

                    // Load Director Tab
                    int roleIndex = 1;
                    ;
                    while (roleIndex < maxDirectorCount)
                    {
                        // Check for roles 1-5
                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = DirectorTeamTab.Controls.Find("DirectorRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (directorCounter < maxDirectorCount)
                                {
                                    btnDirectorAddRole.PerformClick();
                                    AddNewDirectorRoleTextBox();
                                    AddNewDirectorNameTextBox();
                                    directorCounter++;

                                    tbxs = DirectorTeamTab.Controls.Find("DirectorRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = DirectorTeamTab.Controls.Find("DirectorName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }

                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load DoP Tab
                    roleIndex = 1;

                    while (roleIndex < maxDopCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = CameraTeamTab.Controls.Find("dopRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (dopCounter < maxDopCounter)
                                {
                                    btnAddDP.PerformClick();
                                    AddNewDoPRoleTextBox();
                                    AddNewDoPNameTextBox();
                                    dopCounter++;

                                    tbxs = CameraTeamTab.Controls.Find("dopRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = CameraTeamTab.Controls.Find("dopName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load Arts Tab
                    roleIndex = 1;

                    while (roleIndex < maxArtCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = ArtTeamTab.Controls.Find("artRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (artCounter < maxArtCounter)
                                {
                                    btnAddArt.PerformClick();
                                    AddNewArtRoleTextBox();
                                    AddNewArtNameTextBox();
                                    artCounter++;

                                    tbxs = ArtTeamTab.Controls.Find("artRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = ArtTeamTab.Controls.Find("artName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load Sounds Tab
                    roleIndex = 1;

                    while (roleIndex < maxSoundCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = SoundTeamTab.Controls.Find("soundRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (soundCounter < maxSoundCounter)
                                {
                                    btnAddSound.PerformClick();
                                    AddNewSoundRoleTextBox();
                                    AddNewSoundNameTextBox();
                                    soundCounter++;

                                    tbxs = SoundTeamTab.Controls.Find("soundRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = SoundTeamTab.Controls.Find("soundName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skip this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }


                    // Load Editors Tab
                    roleIndex = 1;

                    while (roleIndex < maxEditorCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = EditorTeamTab.Controls.Find("editorRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (editorCounter < maxEditorCounter)
                                {
                                    button2.PerformClick();
                                    AddNewEditorRoleTextBox();
                                    AddNewEditorNameTextBox();
                                    editorCounter++;

                                    tbxs = EditorTeamTab.Controls.Find("editorRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = EditorTeamTab.Controls.Find("editorName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load Grips Tab
                    roleIndex = 1;

                    while (roleIndex < maxGripCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = GripTeamTab.Controls.Find("gripRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (gripCounter < maxGripCounter)
                                {
                                    btnGrip.PerformClick();
                                    AddNewGripRoleTextBox();
                                    AddNewGripNameTextBox();
                                    gripCounter++;

                                    tbxs = GripTeamTab.Controls.Find("gripRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = GripTeamTab.Controls.Find("gripName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load MakeUps Tab
                    roleIndex = 1;

                    while (roleIndex < maxMakeUpCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = MakeUpTeamTab.Controls.Find("makeUpRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (makeUpCounter < maxMakeUpCounter)
                                {
                                    btnAddMakeUp.PerformClick();
                                    AddNewMakeUpRoleTextBox();
                                    AddNewMakeUpNameTextBox();
                                    makeUpCounter++;

                                    tbxs = MakeUpTeamTab.Controls.Find("makeUpRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = MakeUpTeamTab.Controls.Find("makeUpName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load Scenes Tab
                    roleIndex = 1;

                    while (roleIndex < maxSceneCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = SceneTeamTab.Controls.Find("sceneRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (sceneCounter < maxSceneCounter)
                                {
                                    btnAddScene.PerformClick();
                                    AddNewSceneRoleTextBox();
                                    AddNewSceneNameTextBox();
                                    sceneCounter++;

                                    tbxs = SceneTeamTab.Controls.Find("sceneRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = SceneTeamTab.Controls.Find("sceneName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }
                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load Actors Tab
                    dtpScriptDate.Text = lines[index];
                    index++;

                    roleIndex = 1;

                    while (roleIndex < maxActorCounter)
                    {

                        if (lines[index].Length != 0)
                        {
                            Control[] tbxs = ActorTeamTab.Controls.Find("actorRole" + roleIndex.ToString(), true);
                            if (tbxs != null && tbxs.Length > 0)
                            {
                                tbxs[0].Text = lines[index];
                            }
                            else
                            {
                                if (actorCounter < maxActorCounter)
                                {
                                    button10.PerformClick();
                                    AddNewActorRoleTextBox();
                                    AddNewActorNameTextBox();
                                    AddNewActorMakeUpTime();
                                    AddNewActorSetTime();
                                    AddNewActorCommentsTextBox();
                                    actorCounter++;

                                    tbxs = ActorTeamTab.Controls.Find("actorRole" + roleIndex.ToString(), true);
                                    tbxs[0].Text = lines[index];

                                }
                            }

                            //add one to index to get the name
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = ActorTeamTab.Controls.Find("actorName" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }

                            //add one to index to get the MakeUp Time
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = ActorTeamTab.Controls.Find("actorMakeUpdateTimePicker" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }

                            //add one to index to get the Set Time
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = ActorTeamTab.Controls.Find("actorSetTimedateTimePicker" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }

                            //add one to index to get the Comments
                            index++;
                            if (lines[index] != null)
                            {
                                tbxs = ActorTeamTab.Controls.Find("actorComments" + roleIndex.ToString(), true);
                                if (tbxs != null && tbxs.Length > 0)
                                {
                                    tbxs[0].Text = lines[index];
                                }
                            }
                        }
                        else
                        {
                            //Skipp this line
                            index++;
                        }

                        roleIndex++;

                        // Go to the next line which would be the next role
                        index++;
                    }

                    // Load Location Tab
                    dtpLunchTime.Text = lines[index++];
                    dtpSunRise.Text = lines[index++];
                    dtpSunset.Text = lines[index++];
                    textBoxWeatherHigh.Text = lines[index++];
                    textBoxWeatherLow.Text = lines[index++];
                    textBoxParking.Text = lines[index++];
                    textBoxHospital.Text = lines[index++];
                    textBoxShootNumber.Text = lines[index++];
                    textBoxTotalShootDay.Text = lines[index++];

                    textBoxArtsInfo.Text = lines[index++];
                    textBoxCameraInfo.Text = lines[index++];
                    textBoxGripInfo.Text = lines[index++];
                    textBoxElectricInfo.Text = lines[index++];
                    textBoxMakeUpInfo.Text = lines[index++];
                    textBoxWardrobeInfo.Text = lines[index++];
                    textBoxLaborInfo.Text = lines[index++];
                    textBoxProductionInfo.Text = lines[index++];
                    textBoxLocationInfo.Text = lines[index++];
                    textBoxStandIns.Text = lines[index];
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
                sw.WriteLine(CallTime.Value.ToString());
                sw.WriteLine(ShootingTime.Value.ToString());
                sw.WriteLine(DirectorTextBox.Text);
                sw.WriteLine(ProducerTextBox.Text);
                sw.WriteLine(DPTextBox.Text);
                sw.WriteLine(FirstADTextBox.Text);
                sw.WriteLine(LocationTextBox.Text);
                sw.WriteLine(setPhone.Text);

                int roleIndex = 1;
                while (roleIndex < maxDirectorCount)
                {
                    Control[] tbxs = DirectorTeamTab.Controls.Find("DirectorRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = DirectorTeamTab.Controls.Find("DirectorName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxDopCounter)
                {
                    Control[] tbxs = CameraTeamTab.Controls.Find("dopRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = CameraTeamTab.Controls.Find("dopName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxArtCounter)
                {
                    Control[] tbxs = ArtTeamTab.Controls.Find("artRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = ArtTeamTab.Controls.Find("artName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxSoundCounter)
                {
                    Control[] tbxs = SoundTeamTab.Controls.Find("soundRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = SoundTeamTab.Controls.Find("soundName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxEditorCounter)
                {
                    Control[] tbxs = EditorTeamTab.Controls.Find("editorRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = EditorTeamTab.Controls.Find("editorName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxGripCounter)
                {
                    Control[] tbxs = GripTeamTab.Controls.Find("gripRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }

                    tbxs = GripTeamTab.Controls.Find("gripName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxMakeUpCounter)
                {
                    Control[] tbxs = MakeUpTeamTab.Controls.Find("makeUpRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = MakeUpTeamTab.Controls.Find("makeUpName" + roleIndex.ToString(), true);
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

                roleIndex = 1;
                while (roleIndex < maxSceneCounter)
                {
                    Control[] tbxs = SceneTeamTab.Controls.Find("sceneRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = SceneTeamTab.Controls.Find("sceneName" + roleIndex.ToString(), true);
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

                sw.WriteLine(dtpScriptDate.Text);

                roleIndex = 1;
                while (roleIndex < maxActorCounter)
                {
                    Control[] tbxs = ActorTeamTab.Controls.Find("actorRole" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }


                    tbxs = ActorTeamTab.Controls.Find("actorName" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }

                    tbxs = ActorTeamTab.Controls.Find("actorMakeUpdateTimePicker" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }

                    tbxs = ActorTeamTab.Controls.Find("actorSetTimedateTimePicker" + roleIndex.ToString(), true);
                    if (tbxs != null && tbxs.Length > 0)
                    {
                        sw.WriteLine(tbxs[0].Text);
                    }
                    else
                    {
                        sw.WriteLine();
                    }

                    tbxs = ActorTeamTab.Controls.Find("actorComments" + roleIndex.ToString(), true);
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

                sw.WriteLine(dtpLunchTime.Text);
                sw.WriteLine(dtpSunRise.Text);
                sw.WriteLine(dtpSunset.Text);
                sw.WriteLine(textBoxWeatherHigh.Text);
                sw.WriteLine(textBoxWeatherLow.Text);
                sw.WriteLine(textBoxParking.Text);
                sw.WriteLine(textBoxHospital.Text);
                sw.WriteLine(textBoxShootNumber.Text);
                sw.WriteLine(textBoxTotalShootDay.Text);
                sw.WriteLine(textBoxArtsInfo.Text);
                sw.WriteLine(textBoxCameraInfo.Text);
                sw.WriteLine(textBoxGripInfo.Text);
                sw.WriteLine(textBoxElectricInfo.Text);
                sw.WriteLine(textBoxMakeUpInfo.Text);
                sw.WriteLine(textBoxWardrobeInfo.Text);
                sw.WriteLine(textBoxLaborInfo.Text);
                sw.WriteLine(textBoxProductionInfo.Text);
                sw.WriteLine(textBoxLocationInfo.Text);
                sw.WriteLine(textBoxStandIns.Text);
                sw.Close();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            string callTimeSub = CallTime.Value.ToString();
            int found = callTimeSub.IndexOf(":");
            callTimeSub = callTimeSub.Substring(found - 2, 5) + callTimeSub.Substring(found + 6);

            string shootingTimeSub = ShootingTime.Value.ToString();
            found = shootingTimeSub.IndexOf(":");
            shootingTimeSub = shootingTimeSub.Substring(found - 2, 5) + shootingTimeSub.Substring(found + 6);


            _Application excel = new _Excel.Application();
            string workbookPath = System.Windows.Forms.Application.StartupPath + @"\template.xlsx";
            Workbook wb = excel.Workbooks.Open(workbookPath);
            Worksheet ws = wb.Worksheets[1];

            excel.Visible = true;
            ws.Cells[1, 12] = ProductionTitleInput.Text;
            ws.Cells[12, 1] = setPhone.Text;
            ws.Cells[2, 5] = DirectorTextBox.Text;
            ws.Cells[3, 5] = ProducerTextBox.Text;
            ws.Cells[34, 1] = ProducerTextBox.Text;
            ws.Cells[34, 7] = FirstADTextBox.Text;
            ws.Cells[42, 9] = DirectorTextBox.Text;
            ws.Cells[41, 9] = ProducerTextBox.Text;
            ws.Cells[43, 9] = FirstADTextBox.Text;
            ws.Cells[42, 17] = callTimeSub;
            ws.Cells[41, 17] = callTimeSub;
            ws.Cells[43, 17] = callTimeSub;
            ws.Cells[7, 12] = callTimeSub;
            ws.Cells[7, 23] = shootingTimeSub;
            ws.Cells[9, 5] = FirstADTextBox.Text;
            ws.Cells[12, 18] = dtpScriptDate.Value.ToString();
            ws.Cells[1, 32] = dateTimePicker2.Value.ToString();
            ws.Cells[15, 34] = LocationTextBox.Text;
            ws.Cells[51, 9] = DPTextBox.Text;
            ws.Cells[51, 17] = callTimeSub;
            ws.Cells[36, 31] = dateTimePicker2.Value.ToString();
            ws.Cells[12, 32] = dtpLunchTime.Text;
            ws.Cells[4, 32] = "Sunrise: " + dtpSunRise.Text + " Sunset: " + dtpSunset.Text;
            ws.Cells[3, 32] = "Weather: High: " + textBoxWeatherHigh.Text + " Low: " + textBoxWeatherLow.Text;
            ws.Cells[2, 32] = "Day: " + textBoxShootNumber.Text + " / " + textBoxTotalShootDay.Text;
            ws.Cells[6, 32] = textBoxParking.Text;
            ws.Cells[10, 32] = textBoxHospital.Text;



            int roleIndex = 1;
            int row = 44;
            int col = 1;
            while (roleIndex < maxDirectorCount)
            {
                col = 1;
                Control[] tbxs = DirectorTeamTab.Controls.Find("DirectorRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 17] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 17] = "";
                }
                col = 9;

                tbxs = DirectorTeamTab.Controls.Find("DirectorName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 41;
            col = 21;
            while (roleIndex < maxArtCounter)
            {
                col = 21;
                Control[] tbxs = ArtTeamTab.Controls.Find("artRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 37] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 37] = "";

                }
                col = 29;

                tbxs = ArtTeamTab.Controls.Find("artName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";

                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 48;
            col = 21;
            while (roleIndex < maxSoundCounter)
            {
                col = 21;
                Control[] tbxs = SoundTeamTab.Controls.Find("soundRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 37] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 37] = "";
                }
                col = 29;

                tbxs = SoundTeamTab.Controls.Find("soundName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 52;
            col = 1;
            while (roleIndex < maxDopCounter)
            {
                col = 1;
                Control[] tbxs = CameraTeamTab.Controls.Find("dopRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 17] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 17] = "";
                }
                col = 9;

                tbxs = CameraTeamTab.Controls.Find("dopName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 55;
            col = 21;
            while (roleIndex < maxEditorCounter)
            {
                col = 21;
                Control[] tbxs = EditorTeamTab.Controls.Find("editorRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 37] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 37] = "";
                }
                col = 29;

                tbxs = EditorTeamTab.Controls.Find("editorName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 58;
            col = 21;
            while (roleIndex < maxMakeUpCounter)
            {
                col = 21;
                Control[] tbxs = MakeUpTeamTab.Controls.Find("makeUpRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 37] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 37] = "";
                }
                col = 29;

                tbxs = MakeUpTeamTab.Controls.Find("makeUpName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 58;
            col = 1;
            while (roleIndex < maxGripCounter)
            {
                col = 1;
                Control[] tbxs = GripTeamTab.Controls.Find("gripRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 17] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 17] = "";
                }
                col = 9;

                tbxs = GripTeamTab.Controls.Find("gripName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 66;
            col = 21;
            while (roleIndex < maxSceneCounter)
            {
                col = 21;
                Control[] tbxs = SceneTeamTab.Controls.Find("sceneRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 37] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 37] = "";

                }
                col = 29;

                tbxs = SceneTeamTab.Controls.Find("sceneName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                    ws.Cells[row, 37] = callTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                    ws.Cells[row, 37] = "";

                }
                row++;

                roleIndex++;
            }

            roleIndex = 1;
            row = 21;
            col = 11;
            while (roleIndex < maxActorCounter)
            {
                col = 11;
                Control[] tbxs = ActorTeamTab.Controls.Find("actorRole" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }

                col = 2;
                tbxs = ActorTeamTab.Controls.Find("actorName" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }

                col = 19;
                tbxs = ActorTeamTab.Controls.Find("actorMakeUpdateTimePicker" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    string makeUpTimeSub = tbxs[0].Text;
                    found = makeUpTimeSub.IndexOf(":");
                    makeUpTimeSub = makeUpTimeSub.Substring(found - 2, 5) + makeUpTimeSub.Substring(found + 6);
                    ws.Cells[row, col] = makeUpTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }

                col = 23;
                tbxs = ActorTeamTab.Controls.Find("actorSetTimedateTimePicker" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    string setTimeSub = tbxs[0].Text;
                    found = setTimeSub.IndexOf(":");
                    setTimeSub = setTimeSub.Substring(found - 2, 5) + setTimeSub.Substring(found + 6);
                    ws.Cells[row, col] = setTimeSub;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }

                col = 27;
                tbxs = ActorTeamTab.Controls.Find("actorComments" + roleIndex.ToString(), true);
                if (tbxs != null && tbxs.Length > 0)
                {
                    ws.Cells[row, col] = tbxs[0].Text;
                }
                else
                {
                    ws.Cells[row, col] = "";
                }

                row++;
                roleIndex++;
            }

            MessageBox.Show("Exported To Excel Sucesfully. Remember to 'Save As' so you don't overwrite the template file");

        }

        private void input_GainFocus(object sender, EventArgs e)
        {
            var input = (System.Windows.Forms.TextBox)sender;
            if (input.Text == input.Tag.ToString())
            {
                // We need to save the old value in case we need to reset it
                tempValue = input.Tag.ToString();
                input.Text = "";
            }
        }

        private void input_LoseFocus(object sender, EventArgs e)
        {
            // input is the text that they entered
            var input = (System.Windows.Forms.TextBox)sender;

            // input.Tag is the original value of the text box. 
            // So if they entered a value use that otherwise leave as is
            if (input.Text.Length == 0)
            {
                input.Text = tempValue.ToString();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DoPLabel_Click(object sender, EventArgs e)
        {

        }

        public System.Windows.Forms.TextBox AddNewDoPRoleTextBox()
        {
            System.Windows.Forms.TextBox dopTeamRole = new System.Windows.Forms.TextBox();
            CameraTeamTab.Controls.Add(dopTeamRole);
            intControler = intControler + 151;
            switch (this.dopCounter)
            {
                case 1:
                    dopTeamRole.Text = "1st AC";
                    break;
                case 2:
                    dopTeamRole.Text = "2nd AC";
                    break;
                default:
                    dopTeamRole.Text = "Role" + this.dopCounter.ToString();
                    break;

            }
            dopTeamRole.Tag = dopTeamRole.Text;
            dopTeamRole.Name = "dopRole" + this.dopCounter.ToString();
            dopTeamRole.Size = new System.Drawing.Size(80, 2000);
            dopTeamRole.Location = new System.Drawing.Point(25, (93 + (55 * this.dopCounter)));
            dopTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            dopTeamRole.Enter += input_GainFocus;
            dopTeamRole.Leave += input_LoseFocus;
            return dopTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewDoPNameTextBox()
        {
            System.Windows.Forms.TextBox dopTeamName = new System.Windows.Forms.TextBox();
            CameraTeamTab.Controls.Add(dopTeamName);

            dopTeamName.Text = "Name" + this.dopCounter.ToString();
            dopTeamName.Tag = dopTeamName.Text;
            dopTeamName.Name = "dopName" + this.dopCounter.ToString();
            dopTeamName.Size = new System.Drawing.Size(170, 2000);
            dopTeamName.Location = new System.Drawing.Point(120, (93 + (55 * this.dopCounter)));
            dopTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dopTeamName.Enter += input_GainFocus;
            dopTeamName.Leave += input_LoseFocus;

            return dopTeamName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dopCounter < maxDopCounter)
            {
                AddNewDoPRoleTextBox();
                AddNewDoPNameTextBox();

                dopCounter++;
            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of DoP roles.");
            }

        }

        public System.Windows.Forms.TextBox AddNewArtRoleTextBox()
        {
            System.Windows.Forms.TextBox artTeamRole = new System.Windows.Forms.TextBox();
            ArtTeamTab.Controls.Add(artTeamRole);
            intControler = intControler + 151;
            switch (this.artCounter)
            {
                case 1:
                    artTeamRole.Text = "Production Designer";
                    break;

                default:
                    artTeamRole.Text = "Role" + this.artCounter.ToString();
                    break;

            }

            artTeamRole.Tag = artTeamRole.Text;
            artTeamRole.Name = "artRole" + this.artCounter.ToString();
            artTeamRole.Size = new System.Drawing.Size(200, 2000);
            artTeamRole.Location = new System.Drawing.Point(25, (10 + (55 * this.artCounter)));
            artTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            artTeamRole.Enter += input_GainFocus;
            artTeamRole.Leave += input_LoseFocus;
            return artTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewArtNameTextBox()
        {
            System.Windows.Forms.TextBox artTeamName = new System.Windows.Forms.TextBox();
            ArtTeamTab.Controls.Add(artTeamName);

            artTeamName.Text = "Name" + this.artCounter.ToString();
            artTeamName.Tag = artTeamName.Text;
            artTeamName.Name = "artName" + this.artCounter.ToString();
            artTeamName.Size = new System.Drawing.Size(170, 2000);
            artTeamName.Location = new System.Drawing.Point(250, (10 + (55 * this.artCounter)));
            artTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            artTeamName.Enter += input_GainFocus;
            artTeamName.Leave += input_LoseFocus;

            return artTeamName;
        }

        private void btnAddArt_Click(object sender, EventArgs e)
        {
            if (artCounter < maxArtCounter)
            {
                AddNewArtRoleTextBox();
                AddNewArtNameTextBox();

                artCounter++;
            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of ART roles.");
            }
        }
        public System.Windows.Forms.TextBox AddNewSoundRoleTextBox()
        {
            System.Windows.Forms.TextBox soundTeamRole = new System.Windows.Forms.TextBox();
            SoundTeamTab.Controls.Add(soundTeamRole);
            intControler = intControler + 151;

            switch (this.soundCounter)
            {
                case 1:
                    soundTeamRole.Text = "Sound Mixer";
                    break;
                case 2:
                    soundTeamRole.Text = "Boom Op";
                    break;
                default:
                    soundTeamRole.Text = "Role" + this.soundCounter.ToString();
                    break;

            }

            soundTeamRole.Tag = soundTeamRole.Text;
            soundTeamRole.Name = "soundRole" + this.soundCounter.ToString();
            soundTeamRole.Size = new System.Drawing.Size(200, 2000);
            soundTeamRole.Location = new System.Drawing.Point(25, (10 + (55 * this.soundCounter)));
            soundTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            soundTeamRole.Enter += input_GainFocus;
            soundTeamRole.Leave += input_LoseFocus;
            return soundTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewSoundNameTextBox()
        {
            System.Windows.Forms.TextBox soundTeamName = new System.Windows.Forms.TextBox();
            SoundTeamTab.Controls.Add(soundTeamName);

            soundTeamName.Text = "Name" + this.soundCounter.ToString();
            soundTeamName.Tag = soundTeamName.Text;
            soundTeamName.Name = "soundName" + this.soundCounter.ToString();
            soundTeamName.Size = new System.Drawing.Size(170, 2000);
            soundTeamName.Location = new System.Drawing.Point(250, (10 + (55 * this.soundCounter)));
            soundTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            soundTeamName.Enter += input_GainFocus;
            soundTeamName.Leave += input_LoseFocus;

            return soundTeamName;
        }

        private void btnAddSound_Click(object sender, EventArgs e)
        {
            if (soundCounter < maxSoundCounter)
            {
                AddNewSoundRoleTextBox();
                AddNewSoundNameTextBox();

                soundCounter++;
            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of Sound roles.");
            }
        }

        public System.Windows.Forms.TextBox AddNewEditorRoleTextBox()
        {
            System.Windows.Forms.TextBox editorTeamRole = new System.Windows.Forms.TextBox();
            EditorTeamTab.Controls.Add(editorTeamRole);
            intControler = intControler + 151;

            switch (this.editorCounter)
            {
                case 1:
                    editorTeamRole.Text = "Editor";
                    break;
                case 2:
                    editorTeamRole.Text = "DIT";
                    break;
                default:
                    editorTeamRole.Text = "Role" + this.editorCounter.ToString();
                    break;

            }

            editorTeamRole.Tag = editorTeamRole.Text;
            editorTeamRole.Name = "editorRole" + this.editorCounter.ToString();
            editorTeamRole.Size = new System.Drawing.Size(80, 2000);
            editorTeamRole.Location = new System.Drawing.Point(25, (10 + (55 * this.editorCounter)));
            editorTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            editorTeamRole.Enter += input_GainFocus;
            editorTeamRole.Leave += input_LoseFocus;
            return editorTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewEditorNameTextBox()
        {
            System.Windows.Forms.TextBox editorTeamName = new System.Windows.Forms.TextBox();
            EditorTeamTab.Controls.Add(editorTeamName);

            editorTeamName.Text = "Name" + this.editorCounter.ToString();
            editorTeamName.Tag = editorTeamName.Text;
            editorTeamName.Name = "editorName" + this.editorCounter.ToString();
            editorTeamName.Size = new System.Drawing.Size(170, 2000);
            editorTeamName.Location = new System.Drawing.Point(120, (10 + (55 * this.editorCounter)));
            editorTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            editorTeamName.Enter += input_GainFocus;
            editorTeamName.Leave += input_LoseFocus;

            return editorTeamName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (editorCounter < maxEditorCounter)
            {
                AddNewEditorRoleTextBox();
                AddNewEditorNameTextBox();

                editorCounter++;
            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of Editor roles.");
            }
        }

        public System.Windows.Forms.TextBox AddNewGripRoleTextBox()
        {
            System.Windows.Forms.TextBox gripTeamRole = new System.Windows.Forms.TextBox();
            GripTeamTab.Controls.Add(gripTeamRole);
            intControler = intControler + 151;
            switch (this.gripCounter)
            {
                case 1:
                    gripTeamRole.Text = "Gaffer";
                    break;
                case 2:
                    gripTeamRole.Text = "Key Grip";
                    break;
                case 3:
                    gripTeamRole.Text = "BBG";
                    break;
                case 4:
                    gripTeamRole.Text = "BBE";
                    break;
                case 5:
                    gripTeamRole.Text = "Dolly Grip";
                    break;
                default:
                    gripTeamRole.Text = "Role" + this.gripCounter.ToString();
                    break;

            }
            gripTeamRole.Tag = gripTeamRole.Text;
            gripTeamRole.Name = "gripRole" + this.gripCounter.ToString();
            gripTeamRole.Size = new System.Drawing.Size(200, 2000);
            gripTeamRole.Location = new System.Drawing.Point(25, (2 + (55 * this.gripCounter)));
            gripTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            gripTeamRole.Enter += input_GainFocus;
            gripTeamRole.Leave += input_LoseFocus;
            return gripTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewGripNameTextBox()
        {
            System.Windows.Forms.TextBox gripTeamName = new System.Windows.Forms.TextBox();
            GripTeamTab.Controls.Add(gripTeamName);

            gripTeamName.Text = "Name" + this.gripCounter.ToString();
            gripTeamName.Tag = gripTeamName.Text;
            gripTeamName.Name = "gripName" + this.gripCounter.ToString();
            gripTeamName.Size = new System.Drawing.Size(170, 2000);
            gripTeamName.Location = new System.Drawing.Point(250, (2 + (55 * this.gripCounter)));
            gripTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gripTeamName.Enter += input_GainFocus;
            gripTeamName.Leave += input_LoseFocus;

            return gripTeamName;
        }

        private void btnGrip_Click(object sender, EventArgs e)
        {
            if (gripCounter < maxGripCounter)
            {
                AddNewGripRoleTextBox();
                AddNewGripNameTextBox();

                gripCounter++;

            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of Grip roles.");
            }
        }

        public System.Windows.Forms.TextBox AddNewMakeUpRoleTextBox()
        {
            System.Windows.Forms.TextBox makeUpTeamRole = new System.Windows.Forms.TextBox();
            MakeUpTeamTab.Controls.Add(makeUpTeamRole);
            intControler = intControler + 151;
            switch (this.makeUpCounter)
            {
                case 1:
                    makeUpTeamRole.Text = "Make-up / Hair";
                    break;

                default:
                    makeUpTeamRole.Text = "Role" + this.makeUpCounter.ToString();
                    break;

            }
            makeUpTeamRole.Tag = makeUpTeamRole.Text;
            makeUpTeamRole.Name = "makeUpRole" + this.makeUpCounter.ToString();
            makeUpTeamRole.Size = new System.Drawing.Size(200, 2000);
            makeUpTeamRole.Location = new System.Drawing.Point(25, (2 + (55 * this.makeUpCounter)));
            makeUpTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            makeUpTeamRole.Enter += input_GainFocus;
            makeUpTeamRole.Leave += input_LoseFocus;
            return makeUpTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewMakeUpNameTextBox()
        {
            System.Windows.Forms.TextBox makeUpTeamName = new System.Windows.Forms.TextBox();
            MakeUpTeamTab.Controls.Add(makeUpTeamName);

            makeUpTeamName.Text = "Name" + this.makeUpCounter.ToString();
            makeUpTeamName.Tag = makeUpTeamName.Text;
            makeUpTeamName.Name = "makeUpName" + this.makeUpCounter.ToString();
            makeUpTeamName.Size = new System.Drawing.Size(170, 2000);
            makeUpTeamName.Location = new System.Drawing.Point(250, (2 + (55 * this.makeUpCounter)));
            makeUpTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            makeUpTeamName.Enter += input_GainFocus;
            makeUpTeamName.Leave += input_LoseFocus;

            return makeUpTeamName;
        }

        private void btnAddMakeUp_Click(object sender, EventArgs e)
        {
            if (makeUpCounter < maxMakeUpCounter)
            {
                AddNewMakeUpRoleTextBox();
                AddNewMakeUpNameTextBox();

                makeUpCounter++;

            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of MakeUp roles.");
            }
        }

        public System.Windows.Forms.TextBox AddNewSceneRoleTextBox()
        {
            System.Windows.Forms.TextBox sceneTeamRole = new System.Windows.Forms.TextBox();
            SceneTeamTab.Controls.Add(sceneTeamRole);
            intControler = intControler + 151;
            switch (this.sceneCounter)
            {
                case 1:
                    sceneTeamRole.Text = "BTS Photographer";
                    break;

                default:
                    sceneTeamRole.Text = "Role" + this.sceneCounter.ToString();
                    break;

            }

            sceneTeamRole.Tag = sceneTeamRole.Text;
            sceneTeamRole.Name = "sceneRole" + this.sceneCounter.ToString();
            sceneTeamRole.Size = new System.Drawing.Size(200, 2000);
            sceneTeamRole.Location = new System.Drawing.Point(25, (2 + (55 * this.sceneCounter)));
            sceneTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            sceneTeamRole.Enter += input_GainFocus;
            sceneTeamRole.Leave += input_LoseFocus;
            return sceneTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewSceneNameTextBox()
        {
            System.Windows.Forms.TextBox sceneTeamName = new System.Windows.Forms.TextBox();
            SceneTeamTab.Controls.Add(sceneTeamName);

            sceneTeamName.Text = "Name" + this.sceneCounter.ToString();
            sceneTeamName.Tag = sceneTeamName.Text;
            sceneTeamName.Name = "sceneName" + this.sceneCounter.ToString();
            sceneTeamName.Size = new System.Drawing.Size(170, 2000);
            sceneTeamName.Location = new System.Drawing.Point(250, (2 + (55 * this.sceneCounter)));
            sceneTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sceneTeamName.Enter += input_GainFocus;
            sceneTeamName.Leave += input_LoseFocus;

            return sceneTeamName;
        }
        private void btnAddScene_Click(object sender, EventArgs e)
        {
            if (sceneCounter < maxSceneCounter)
            {
                AddNewSceneRoleTextBox();
                AddNewSceneNameTextBox();

                sceneCounter++;

            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of Scene roles.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (directorCounter != 1)
            {
                DelDirectorRoleTextBox();
                DelDirectorNameTextBox();

                directorCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }

        //Jeevans
        public void DelDirectorRoleTextBox()
        {
            int deleteIndex = directorCounter - 1;
            // Find the last one
            Control[] tbxs = DirectorTeamTab.Controls.Find("DirectorRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                DirectorTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelDirectorNameTextBox()
        {
            int deleteIndex = directorCounter - 1;
            // Find the last one
            Control[] tbxs = DirectorTeamTab.Controls.Find("DirectorName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                DirectorTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dopCounter != 1)
            {
                DelDoPRoleTextBox();
                DelDoPNameTextBox();

                dopCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }

        public void DelDoPRoleTextBox()
        {
            int deleteIndex = dopCounter - 1;
            // Find the last one
            Control[] tbxs = CameraTeamTab.Controls.Find("DoPRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                CameraTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelDoPNameTextBox()
        {
            int deleteIndex = dopCounter - 1;
            // Find the last one
            Control[] tbxs = CameraTeamTab.Controls.Find("DoPName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                CameraTeamTab.Controls.Remove(tbxs[0]);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (artCounter != 1)
            {
                DelArtRoleTextBox();
                DelArtNameTextBox();

                artCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }

        public void DelArtRoleTextBox()
        {
            int deleteIndex = artCounter - 1;
            // Find the last one
            Control[] tbxs = ArtTeamTab.Controls.Find("ArtRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ArtTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelArtNameTextBox()
        {
            int deleteIndex = artCounter - 1;
            // Find the last one
            Control[] tbxs = ArtTeamTab.Controls.Find("ArtName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ArtTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (soundCounter != 1)
            {
                DelSoundRoleTextBox();
                DelSoundNameTextBox();

                soundCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }
        public void DelSoundRoleTextBox()
        {
            int deleteIndex = soundCounter - 1;
            // Find the last one
            Control[] tbxs = SoundTeamTab.Controls.Find("SoundRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                SoundTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelSoundNameTextBox()
        {
            int deleteIndex = soundCounter - 1;
            // Find the last one
            Control[] tbxs = SoundTeamTab.Controls.Find("SoundName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                SoundTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (editorCounter != 1)
            {
                DelEditorRoleTextBox();
                DelEditorNameTextBox();

                editorCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }
        public void DelEditorRoleTextBox()
        {
            int deleteIndex = editorCounter - 1;
            // Find the last one
            Control[] tbxs = EditorTeamTab.Controls.Find("EditorRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                EditorTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelEditorNameTextBox()
        {
            int deleteIndex = editorCounter - 1;
            // Find the last one
            Control[] tbxs = EditorTeamTab.Controls.Find("EditorName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                EditorTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (gripCounter != 1)
            {
                DelGripRoleTextBox();
                DelGripNameTextBox();

                gripCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }
        public void DelGripRoleTextBox()
        {
            int deleteIndex = gripCounter - 1;
            // Find the last one
            Control[] tbxs = GripTeamTab.Controls.Find("GripRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                GripTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelGripNameTextBox()
        {
            int deleteIndex = gripCounter - 1;
            // Find the last one
            Control[] tbxs = GripTeamTab.Controls.Find("GripName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                GripTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (makeUpCounter != 1)
            {
                DelMakeUpRoleTextBox();
                DelMakeUpNameTextBox();

                makeUpCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }
        public void DelMakeUpRoleTextBox()
        {
            int deleteIndex = makeUpCounter - 1;
            // Find the last one
            Control[] tbxs = MakeUpTeamTab.Controls.Find("makeUpRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                MakeUpTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelMakeUpNameTextBox()
        {
            int deleteIndex = makeUpCounter - 1;
            // Find the last one
            Control[] tbxs = MakeUpTeamTab.Controls.Find("makeUpName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                MakeUpTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (sceneCounter != 1)
            {
                DelSceneRoleTextBox();
                DelSceneNameTextBox();

                sceneCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }

        public void DelSceneRoleTextBox()
        {
            int deleteIndex = sceneCounter - 1;
            // Find the last one
            Control[] tbxs = SceneTeamTab.Controls.Find("sceneRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                SceneTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelSceneNameTextBox()
        {
            int deleteIndex = sceneCounter - 1;
            // Find the last one
            Control[] tbxs = SceneTeamTab.Controls.Find("sceneName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                SceneTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        private void CallTime_ValueChanged(object sender, EventArgs e)
        {
            if (CallTime.Value > ShootingTime.Value)
            {
                MessageBox.Show("Warning your Call Time is later than your Shoot Time!");
            }
        }

        private void ShootingTime_ValueChanged(object sender, EventArgs e)
        {
            if (CallTime.Value > ShootingTime.Value)
            {
                MessageBox.Show("Warning your Call Time is later than your Shoot Time!");
            }
        }
        public System.Windows.Forms.TextBox AddNewActorRoleTextBox()
        {
            System.Windows.Forms.TextBox actorTeamRole = new System.Windows.Forms.TextBox();
            ActorTeamTab.Controls.Add(actorTeamRole);
            intControler = intControler + 151;
            actorTeamRole.Text = "Role" + this.actorCounter.ToString();
            actorTeamRole.Tag = actorTeamRole.Text;
            actorTeamRole.Name = "actorRole" + this.actorCounter.ToString();
            actorTeamRole.Size = new System.Drawing.Size(200, 2000);
            actorTeamRole.Location = new System.Drawing.Point(25, (60 + (70 * this.actorCounter)));
            actorTeamRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            actorTeamRole.Enter += input_GainFocus;
            actorTeamRole.Leave += input_LoseFocus;
            return actorTeamRole;
        }
        public System.Windows.Forms.TextBox AddNewActorNameTextBox()
        {
            System.Windows.Forms.TextBox actorTeamName = new System.Windows.Forms.TextBox();
            ActorTeamTab.Controls.Add(actorTeamName);

            actorTeamName.Text = "Name" + this.actorCounter.ToString();
            actorTeamName.Tag = actorTeamName.Text;
            actorTeamName.Name = "actorName" + this.actorCounter.ToString();
            actorTeamName.Size = new System.Drawing.Size(170, 2000);
            actorTeamName.Location = new System.Drawing.Point(240, (60 + (70 * this.actorCounter)));
            actorTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            actorTeamName.Enter += input_GainFocus;
            actorTeamName.Leave += input_LoseFocus;

            return actorTeamName;
        }

        public System.Windows.Forms.DateTimePicker AddNewActorMakeUpTime()
        {
            System.Windows.Forms.DateTimePicker actorMakeUpdateTimePicker = new System.Windows.Forms.DateTimePicker();
            ActorTeamTab.Controls.Add(actorMakeUpdateTimePicker);

            actorMakeUpdateTimePicker.Tag = actorMakeUpdateTimePicker.Text;
            actorMakeUpdateTimePicker.Name = "actorMakeUpdateTimePicker" + this.actorCounter.ToString();
            actorMakeUpdateTimePicker.Size = new System.Drawing.Size(170, 100);
            actorMakeUpdateTimePicker.Location = new System.Drawing.Point(425, (60 + (70 * this.actorCounter)));
            actorMakeUpdateTimePicker.CustomFormat = "hh:mm tt";
            actorMakeUpdateTimePicker.Format = DateTimePickerFormat.Custom;
            actorMakeUpdateTimePicker.ShowCheckBox = true;
            actorMakeUpdateTimePicker.ShowUpDown = true;
            // Set the Makeup time to be Call Time + 20 Mins
            actorMakeUpdateTimePicker.Value = CallTime.Value;
            actorMakeUpdateTimePicker.Value = actorMakeUpdateTimePicker.Value.AddMinutes(20);

            return actorMakeUpdateTimePicker;
        }

        public System.Windows.Forms.DateTimePicker AddNewActorSetTime()
        {
            System.Windows.Forms.DateTimePicker actorSetTimedateTimePicker = new System.Windows.Forms.DateTimePicker();
            ActorTeamTab.Controls.Add(actorSetTimedateTimePicker);

            actorSetTimedateTimePicker.Tag = actorSetTimedateTimePicker.Text;
            actorSetTimedateTimePicker.Name = "actorSetTimedateTimePicker" + this.actorCounter.ToString();
            actorSetTimedateTimePicker.Size = new System.Drawing.Size(170, 100);
            actorSetTimedateTimePicker.Location = new System.Drawing.Point(425, (85 + (70 * this.actorCounter)));
            actorSetTimedateTimePicker.CustomFormat = "hh:mm tt";
            actorSetTimedateTimePicker.Format = DateTimePickerFormat.Custom;
            actorSetTimedateTimePicker.ShowCheckBox = true;
            actorSetTimedateTimePicker.ShowUpDown = true;

            // Set the Shoot time to be Call Time
            actorSetTimedateTimePicker.Value = ShootingTime.Value;

            return actorSetTimedateTimePicker;
        }
        public System.Windows.Forms.TextBox AddNewActorCommentsTextBox()
        {
            System.Windows.Forms.TextBox actorComments = new System.Windows.Forms.TextBox();
            ActorTeamTab.Controls.Add(actorComments);

            actorComments.Text = "Comments" + this.actorCounter.ToString();
            actorComments.Tag = actorComments.Text;
            actorComments.Name = "actorComments" + this.actorCounter.ToString();
            actorComments.Size = new System.Drawing.Size(170, 2000);
            actorComments.Location = new System.Drawing.Point(600, (60 + (70 * this.actorCounter)));
            actorComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            actorComments.Enter += input_GainFocus;
            actorComments.Leave += input_LoseFocus;

            return actorComments;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (actorCounter < maxActorCounter)
            {
                AddNewActorRoleTextBox();
                AddNewActorNameTextBox();
                AddNewActorMakeUpTime();
                AddNewActorSetTime();
                AddNewActorCommentsTextBox();

                actorCounter++;

            }
            else
            {
                MessageBox.Show("You have reached the maximum amount of Actor roles.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        public void DelActorRoleTextBox()
        {
            int deleteIndex = actorCounter - 1;
            // Find the last one
            Control[] tbxs = ActorTeamTab.Controls.Find("actorRole" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ActorTeamTab.Controls.Remove(tbxs[0]);
            }

        }
        public void DelActorNameTextBox()
        {
            int deleteIndex = actorCounter - 1;
            // Find the last one
            Control[] tbxs = ActorTeamTab.Controls.Find("actorName" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ActorTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        public void DelActorMakeUpTime()
        {
            int deleteIndex = actorCounter - 1;
            // Find the last one
            Control[] tbxs = ActorTeamTab.Controls.Find("actorMakeUpdateTimePicker" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ActorTeamTab.Controls.Remove(tbxs[0]);
            }
        }
        public void DelActorSetTime()
        {
            int deleteIndex = actorCounter - 1;
            // Find the last one
            Control[] tbxs = ActorTeamTab.Controls.Find("actorSetTimedateTimePicker" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ActorTeamTab.Controls.Remove(tbxs[0]);
            }
        }

        public void DelActorCommentsTextBox()
        {
            int deleteIndex = actorCounter - 1;
            // Find the last one
            Control[] tbxs = ActorTeamTab.Controls.Find("actorComments" + deleteIndex.ToString(), true);
            if (tbxs != null && tbxs.Length > 0)
            {
                ActorTeamTab.Controls.Remove(tbxs[0]);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (actorCounter != 1)
            {
                DelActorRoleTextBox();
                DelActorNameTextBox();
                DelActorMakeUpTime();
                DelActorSetTime();
                DelActorCommentsTextBox();

                actorCounter--;
            }
            else
            {
                MessageBox.Show("You cannot delete anymore roles.");
            }
        }

        private void lblLocation_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void chkBoxArt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxArt.Checked)
            {
                if (!AllTabs.TabPages.Contains(ArtTeamTab))
                {
                    AllTabs.TabPages.Add(ArtTeamTab);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(ArtTeamTab))
                {
                    AllTabs.TabPages.Remove(ArtTeamTab);
                }

            }
        }

        private void chkBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxSound.Checked)
            {
                if (!AllTabs.TabPages.Contains(SoundTeamTab))
                {
                    AllTabs.TabPages.Add(SoundTeamTab);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(SoundTeamTab))
                {
                    AllTabs.TabPages.Remove(SoundTeamTab);
                }

            }
        }

        private void chkBoxEditorial_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxEditorial.Checked)
            {
                if (!AllTabs.TabPages.Contains(EditorTeamTab))
                {
                    AllTabs.TabPages.Add(EditorTeamTab);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(EditorTeamTab))
                {
                    AllTabs.TabPages.Remove(EditorTeamTab);
                }

            }
        }

        private void chkBoxGrip_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxGrip.Checked)
            {
                if (!AllTabs.TabPages.Contains(GripTeamTab))
                {
                    AllTabs.TabPages.Add(GripTeamTab);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(GripTeamTab))
                {
                    AllTabs.TabPages.Remove(GripTeamTab);
                }

            }
        }

        private void chkBoxMakeUp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxMakeUp.Checked)
            {
                if (!AllTabs.TabPages.Contains(MakeUpTeamTab))
                {
                    AllTabs.TabPages.Add(MakeUpTeamTab);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(MakeUpTeamTab))
                {
                    AllTabs.TabPages.Remove(MakeUpTeamTab);
                }
            }
        }
        private void chkBoxScenes_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxScenes.Checked)
            {
                if (!AllTabs.TabPages.Contains(SceneTeamTab))
                {
                    AllTabs.TabPages.Add(SceneTeamTab);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(SceneTeamTab))
                {
                    AllTabs.TabPages.Remove(SceneTeamTab);
                }
            }
        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void chkInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxInfo.Checked)
            {
                if (!AllTabs.TabPages.Contains(AdditionalInfo))
                {
                    AllTabs.TabPages.Add(AdditionalInfo);
                }

            }
            else
            {
                if (AllTabs.TabPages.Contains(AdditionalInfo))
                {
                    AllTabs.TabPages.Remove(AdditionalInfo);
                }
            }
        }
    }
}
 