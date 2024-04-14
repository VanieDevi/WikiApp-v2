using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WikiApp_v2
{
    // Vanie Devi Srinivasan
    // Date: 08/04/2024
    // Version: 2
    // Name of the program:  The Wiki Application
    // Description: This Wiki application is to facilitate add, edit, delete, search, save and load
    // manage the wiki data records.

    public partial class WikiApp : Form
    {
        public WikiApp()
        {
            InitializeComponent();          
        }

        // Create and Initialize a wiki list
        List<Information> Wiki = new List<Information>();
        string ReadFileName = "";
        
        // A method for checking duplicatesusing " Exists" method.
        private bool validName(string wikiName)
        {
            if (Wiki.Exists(dup => dup.GetName() == wikiName))
            {
                Trace.TraceWarning("Invalid Name - Name is duplicate...");
                return false;
            }
            else
            {
                Trace.TraceInformation("Valid Name");
                return true;
            }
        }
        
        // Method for the radio buttons to be checked
        private string GetRadioButton()
        {
            string radioText = "";

            if (radioButtonLinear.Checked)
                radioText = radioButtonLinear.Text;
            else if (radioButtonNonLinear.Checked)
                radioText = radioButtonNonLinear.Text;

            return radioText;
        }
        
        // Method for checking either of the the radio button
        private void SetRadioButton(int item)
        {
            if (Wiki[item].GetStructure() == "Linear")
                radioButtonLinear.Checked = true;
            if (Wiki[item].GetStructure() == "Non-Linear")
                radioButtonNonLinear.Checked = true;
        }

        #region Dispaly-Search-Clear
        // Method to display the Wiki records
        private void DisplayWikiInformation()
        {
            // Method to sort the wiki list.
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
        
        // Loading data from the binaryfile when the application loads..
        private void WikiApp_Load(object sender, EventArgs e)
        {
            string datFile = "wiki-data.dat";
            ReadFileName = datFile;
            toolStripStatusLabel1.Text = "";
            LoadCategory();
            OpenRecords(datFile);
            DisplayWikiInformation();
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

        // Method to clear all the textboxes and radiobuttons
        private void ClearAllTextBoxes()
        {
            textBoxName.Clear();
            comboBoxCategory.Text = "";
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            textBoxDefinition.Clear();
        }

        // Search Button
        private void buttonSearch_Click(object sender, System.EventArgs e)
        {
            if (textBoxSearch.Text.Length > 0)
            {
                Information searchWiki = new Information();
                // set name from textbox
                TextInfo nameTI = new CultureInfo("en-US", false).TextInfo;
                var name = nameTI.ToTitleCase(textBoxSearch.Text);
                searchWiki.SetName(name);
                // if found return 0
                int found = Wiki.BinarySearch(searchWiki);
                // Builtin Binary Search method to find a Data Structure name
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

                    textBoxSearch.Text = "";
                    textBoxSearch.Focus();
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

        // To dispaly data in the respective textboxes when the data is selected.
        private void listViewWikiApp_MouseClick(object sender, EventArgs e)
        {
            int selectedItem = listViewWikiApp.SelectedIndices[0];

            textBoxName.Text = Wiki[selectedItem].GetName();
            comboBoxCategory.Text = Wiki[selectedItem].GetCategory();
            SetRadioButton(selectedItem);
            textBoxDefinition.Text = Wiki[selectedItem].GetDefinition();
        }

        // To clear the textboxes when the name is double clicked.
        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            ClearAllTextBoxes();
        }

        // Resets all the textboxes
        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxes();
        }

        #endregion

        #region Add-Edit-Delete 

        //Add Button
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
        
        // Edit Button
        private void buttonEdit_Click(object sender, System.EventArgs e)
        {
            toolStripStatusLabel1.Text = "Editing the selected Wiki record......";

            int selectedItem = listViewWikiApp.SelectedIndices[0];
            
            if (selectedItem > -1)
            {
                Trace.TraceInformation("Record found for edit...");
                 // The edited data is updated in the records.
                Wiki[selectedItem].SetName(textBoxName.Text);
                Wiki[selectedItem].SetCategory(comboBoxCategory.Text);
                Wiki[selectedItem].SetStructure(GetRadioButton());
                Wiki[selectedItem].SetDefinition(textBoxDefinition.Text);

                DisplayWikiInformation();
                ClearAllTextBoxes();
 
                MessageBox.Show("Recorded successfully updated...");

                toolStripStatusLabel1.Text = "";
            }
            else
            {
                Trace.TraceWarning("Record not found for edit...");
            }
        }
        
        // Delete Button
        private void buttonDelete_Click(object sender, System.EventArgs e)
        {           
            var result = MessageBox.Show("Confirm to delete the record!", "Delete Record!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            if (result == DialogResult.OK)
            {
                int selectedItem = listViewWikiApp.SelectedIndices[0];
               
                if (selectedItem > -1)
                {
                    Trace.TraceInformation("Record found for delete...");

                    toolStripStatusLabel1.Text = "Deleting the selected Wiki record......";
                    // Removes the selected record from the Wiki list
                    Wiki.RemoveAt(selectedItem);

                    DisplayWikiInformation();
                    ClearAllTextBoxes();

                    MessageBox.Show("Recorded successfully deleted...");

                    toolStripStatusLabel1.Text = "";
                }
                else
                {
                    Trace.TraceWarning("Record not found for delete...");
                }
            }           
        }

        #endregion        
                      
        #region Open and Save wiki data file
        
        // Open Button
        // Load the wiki records from input data file
        // Open button that will read the information from a binary file called wiki-data.dat into the list,
        // ensured the user has the option to select an alternative file. Use a file stream and BinaryReader to complete this task.
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

        // Save Button: Save the wiki records into a data file
        // SAVE button so the information from the list can be written into a binary file called wiki-data.dat
        // which is sorted by Name, ensured the user has the option to select an alternative file.
        // Used a file stream and BinaryWriter to create the file.

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

        // Writes data into the file
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

        #endregion

       
        

        // Saving the data into the file while closing the form.
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

        // Exit button - saves the data to the file when exiting
        private void buttonExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        
        

        

    }
}