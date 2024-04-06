using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WikiApp_v2
{
    public partial class WikiApp : Form
    {
        public WikiApp()
        {
            InitializeComponent();          
        }

        List<Information> Wiki = new List<Information>();
        string ReadFileName = "";

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            // check name in TextBox
            bool valid = validName(textBoxName.Text);

            // If name is Not a duplicate
            if (valid)
            {
                // add new record
                Information information = new Information();
                information.SetName(textBoxName.Text);
                information.SetCategory(comboBoxCategory.Text);
                information.SetStructure(GetRadioButton());
                information.SetDefinition(textBoxDefinition.Text);

                Wiki.Add(information);

                // clear textboxes
                ClearAllTextBoxes();

                // set focus
                textBoxName.Focus();

                // display all Wiki Information
                DisplayWikiInformation();
            }
            else
            {
                toolStripStatusLabel1.Text = "Input Name is invalid. Input Name already exist in the list...";
                MessageBox.Show("Input Name is invalid. Input Name already exist in the list...");
            }
        }

        private bool validName(string wikiName)
        {
            if (Wiki.Exists(dup => dup.GetName() == wikiName))
                return false;
            else
                return true;
        }

        private string GetRadioButton()
        {
            string radioText = "";

            if (radioButtonLinear.Checked)
                radioText = radioButtonLinear.Text;
            else if (radioButtonNonLinear.Checked)
                radioText = radioButtonNonLinear.Text;

            return radioText;
        }
        private void SetRadioButton(int item)
        {
            if (Wiki[item].GetStructure() == "Linear")
                radioButtonLinear.Checked = true;
            if (Wiki[item].GetStructure() == "Non-Linear")
                radioButtonNonLinear.Checked = true;
        }

        private void DisplayWikiInformation()
        {
            Wiki.Sort();
            listViewWikiApp.Items.Clear();

            foreach (var item in Wiki)
            {
                ListViewItem listViewItem = new ListViewItem(item.GetName());
                listViewItem.SubItems.Add(item.GetCategory());
                listViewItem.SubItems.Add(item.GetStructure());
                listViewItem.SubItems.Add(item.GetDefinition());
                listViewWikiApp.Items.Add(listViewItem);
            }
        }
        private void ClearAllTextBoxes()
        {
            textBoxName.Clear();
            comboBoxCategory.Text = "";
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            textBoxDefinition.Clear();
        }

        private void buttonEdit_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editing the selected Wiki record......";

            int selectedItem = listViewWikiApp.SelectedIndices[0];

            if (selectedItem > -1)
            {
                Wiki[selectedItem].SetName(textBoxName.Text);
                Wiki[selectedItem].SetCategory(comboBoxCategory.Text);
                Wiki[selectedItem].SetStructure(GetRadioButton());
                Wiki[selectedItem].SetDefinition(textBoxDefinition.Text);

                DisplayWikiInformation();
                ClearAllTextBoxes();
 
                MessageBox.Show("Recorded successfully updated...");

                toolStripStatusLabel1.Text = "";
            }
        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {           
            var result = MessageBox.Show("Confirm to delete the record!", "Delete Record!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                int selectedItem = listViewWikiApp.SelectedIndices[0];
                if (selectedItem > -1)
                {
                    toolStripStatusLabel1.Text = "Deleting the selected Wiki record......";

                    Wiki.RemoveAt(selectedItem);

                    DisplayWikiInformation();
                    ClearAllTextBoxes();

                    MessageBox.Show("Recorded successfully deleted...");

                    toolStripStatusLabel1.Text = "";
                }
            }           
        }



        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            if (textBoxSearch.Text.Length > 0)
            {
                Information searchWiki = new Information();
                // set name from textbox
                searchWiki.SetName(textBoxSearch.Text);
                // if found return 0
                int found = Wiki.BinarySearch(searchWiki);

                if (found >= 0)
                {
                    listViewWikiApp.SelectedItems.Clear();
                    listViewWikiApp.Items[found].Selected = true;
                    listViewWikiApp.Focus();
                    textBoxName.Text = Wiki[found].GetName();
                    comboBoxCategory.Text = Wiki[found].GetCategory();
                    textBoxDefinition.Text = Wiki[found].GetDefinition().ToString();
                    SetRadioButton(found);

                    toolStripStatusLabel1.Text = "Search found...";
                }
                else
                {
                    toolStripStatusLabel1.Text = "Cannot find item - " + textBoxSearch.Text;

                    MessageBox.Show("Cannot find item - " + textBoxSearch.Text);
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Missing input for search...";

                MessageBox.Show("Missing input for search...");
            }
        }
    


        private void buttonLoad_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "Loading Wiki Records from data file...";

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "*.dat|";
            openFileDialog.Title = "Open a dat file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenRecords(openFileDialog.FileName);
                ReadFileName = openFileDialog.FileName;

                DisplayWikiInformation();
            }

            toolStripStatusLabel1.Text = "";
        }

        // Open and read the wiki data file
        private void OpenRecords(String fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (var stream = File.Open(fileName, FileMode.Open))
                    {
                        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                        {
                            Wiki.Clear();

                            while (stream.Position < stream.Length)
                            {
                                Information readinfo = new Information();
                                readinfo.SetName(reader.ReadString());
                                readinfo.SetCategory(reader.ReadString());
                                readinfo.SetStructure(reader.ReadString());
                                readinfo.SetDefinition(reader.ReadString());
                                Wiki.Add(readinfo);
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "Saving Wiki Records to data file...";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.Filter = "*.dat|";
            saveFileDialog.Title = "Save a dat file";
            saveFileDialog.DefaultExt = "dat";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveRecords(saveFileDialog.FileName);
                MessageBox.Show("Wiki data file saved - " + saveFileDialog.FileName);
            }

            toolStripStatusLabel1.Text = "";            
        }

        private void SaveRecords(String saveFileName)
        {
            using (var stream = File.Open(saveFileName, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    foreach (var x in Wiki)
                    {
                        writer.Write(x.GetName());
                        writer.Write(x.GetCategory());
                        writer.Write(x.GetStructure());
                        writer.Write(x.GetDefinition());
                    }
                }
            }
        }

        private void listViewWikiApp_MouseClick(object sender, EventArgs e)
        {
            int selectedItem = listViewWikiApp.SelectedIndices[0];

            textBoxName.Text = Wiki[selectedItem].GetName();
            comboBoxCategory.Text = Wiki[selectedItem].GetCategory();
            SetRadioButton(selectedItem);
            textBoxDefinition.Text = Wiki[selectedItem].GetDefinition();
        }

        

        // Open and read the wiki category data for combo box
        private void LoadCategory()
        {
            string fileName = "WikiCategory.txt";

            try
            {
                if (File.Exists(fileName))
                {
                    using (TextReader reader = new StreamReader(fileName))
                    {
                        Wiki.Clear();

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            comboBoxCategory.Items.Add(line);
                        }
                    }                   
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Error: " + exp.Message);
            }
        }

        private void DisplayArray()
        {
        }

       
        private void sort()
        {
        }

        private void Swap(int indxI, int indxJ)
        {

        }


        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAllTextBoxes();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes();
        }

        private void WikiApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReadFileName.Length > 0)
            {
                SaveRecords(ReadFileName);

                MessageBox.Show("Saved Wiki data to the file - " + ReadFileName);
            }
            else
            {
                MessageBox.Show("Exiting without saving the Wiki data into file...");
            }
        }

        private void WikiApp_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            LoadCategory();
        }

        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            if (ReadFileName.Length > 0)
            {
                SaveRecords(ReadFileName);

                MessageBox.Show("Saved Wiki data to the file - " + ReadFileName);
            }
            else
            {
                MessageBox.Show("Exiting without saving the Wiki data into file...");
            }
            Environment.Exit(0);
        }

    }
}