namespace WikiApp_v2
{
    partial class WikiApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewWikiApp = new System.Windows.Forms.ListView();
            this.WikiName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WikiCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_Name = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDefinition = new System.Windows.Forms.TextBox();
            this.label_Category = new System.Windows.Forms.Label();
            this.label_Definition = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.radioButtonLinear = new System.Windows.Forms.RadioButton();
            this.radioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.groupBoxStructure = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxStructure.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewWikiApp
            // 
            this.listViewWikiApp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.WikiName,
            this.WikiCategory});
            this.listViewWikiApp.HideSelection = false;
            this.listViewWikiApp.Location = new System.Drawing.Point(582, 146);
            this.listViewWikiApp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listViewWikiApp.Name = "listViewWikiApp";
            this.listViewWikiApp.Size = new System.Drawing.Size(571, 436);
            this.listViewWikiApp.TabIndex = 8;
            this.listViewWikiApp.UseCompatibleStateImageBehavior = false;
            this.listViewWikiApp.View = System.Windows.Forms.View.Details;
            this.listViewWikiApp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewWikiApp_MouseClick);
            // 
            // WikiName
            // 
            this.WikiName.Text = "Name";
            this.WikiName.Width = 128;
            // 
            // WikiCategory
            // 
            this.WikiCategory.Text = "Category";
            this.WikiCategory.Width = 63;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Location = new System.Drawing.Point(33, 63);
            this.label_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(51, 20);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(38, 88);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(272, 26);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxDefinition
            // 
            this.textBoxDefinition.Location = new System.Drawing.Point(39, 388);
            this.textBoxDefinition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxDefinition.Multiline = true;
            this.textBoxDefinition.Name = "textBoxDefinition";
            this.textBoxDefinition.Size = new System.Drawing.Size(271, 270);
            this.textBoxDefinition.TabIndex = 5;
            // 
            // label_Category
            // 
            this.label_Category.AutoSize = true;
            this.label_Category.Location = new System.Drawing.Point(34, 146);
            this.label_Category.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Category.Name = "label_Category";
            this.label_Category.Size = new System.Drawing.Size(73, 20);
            this.label_Category.TabIndex = 6;
            this.label_Category.Text = "Category";
            // 
            // label_Definition
            // 
            this.label_Definition.AutoSize = true;
            this.label_Definition.Location = new System.Drawing.Point(34, 363);
            this.label_Definition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Definition.Name = "label_Definition";
            this.label_Definition.Size = new System.Drawing.Size(76, 20);
            this.label_Definition.TabIndex = 8;
            this.label_Definition.Text = "Definition";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(582, 52);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(391, 26);
            this.textBoxSearch.TabIndex = 9;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(384, 168);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(134, 69);
            this.buttonAdd.TabIndex = 10;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(384, 291);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(134, 58);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(384, 415);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(134, 60);
            this.buttonDelete.TabIndex = 12;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(1028, 608);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(112, 52);
            this.buttonExit.TabIndex = 13;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(645, 608);
            this.buttonOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(124, 52);
            this.buttonOpen.TabIndex = 14;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(846, 608);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(130, 52);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(1002, 45);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(153, 45);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Abstract",
            "Array",
            "Graphs",
            "Hash",
            "List",
            "Tree"});
            this.comboBoxCategory.Location = new System.Drawing.Point(39, 168);
            this.comboBoxCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(271, 28);
            this.comboBoxCategory.TabIndex = 17;
            // 
            // radioButtonLinear
            // 
            this.radioButtonLinear.AutoSize = true;
            this.radioButtonLinear.Location = new System.Drawing.Point(9, 29);
            this.radioButtonLinear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonLinear.Name = "radioButtonLinear";
            this.radioButtonLinear.Size = new System.Drawing.Size(78, 24);
            this.radioButtonLinear.TabIndex = 18;
            this.radioButtonLinear.TabStop = true;
            this.radioButtonLinear.Text = "Linear";
            this.radioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // radioButtonNonLinear
            // 
            this.radioButtonNonLinear.AutoSize = true;
            this.radioButtonNonLinear.Location = new System.Drawing.Point(9, 65);
            this.radioButtonNonLinear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioButtonNonLinear.Name = "radioButtonNonLinear";
            this.radioButtonNonLinear.Size = new System.Drawing.Size(112, 24);
            this.radioButtonNonLinear.TabIndex = 19;
            this.radioButtonNonLinear.TabStop = true;
            this.radioButtonNonLinear.Text = "Non-Linear";
            this.radioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // groupBoxStructure
            // 
            this.groupBoxStructure.Controls.Add(this.radioButtonLinear);
            this.groupBoxStructure.Controls.Add(this.radioButtonNonLinear);
            this.groupBoxStructure.Location = new System.Drawing.Point(39, 228);
            this.groupBoxStructure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxStructure.Name = "groupBoxStructure";
            this.groupBoxStructure.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBoxStructure.Size = new System.Drawing.Size(274, 108);
            this.groupBoxStructure.TabIndex = 20;
            this.groupBoxStructure.TabStop = false;
            this.groupBoxStructure.Text = "Structure";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 682);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1191, 32);
            this.statusStrip.TabIndex = 21;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(179, 25);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // WikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 714);
            this.Controls.Add(this.groupBoxStructure);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label_Definition);
            this.Controls.Add(this.label_Category);
            this.Controls.Add(this.textBoxDefinition);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.listViewWikiApp);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WikiApp";
            this.Text = "Wiki Application V2";
            this.groupBoxStructure.ResumeLayout(false);
            this.groupBoxStructure.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewWikiApp;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDefinition;
        private System.Windows.Forms.Label label_Category;
        private System.Windows.Forms.Label label_Definition;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.RadioButton radioButtonLinear;
        private System.Windows.Forms.RadioButton radioButtonNonLinear;
        private System.Windows.Forms.GroupBox groupBoxStructure;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ColumnHeader WikiName;
        private System.Windows.Forms.ColumnHeader WikiCategory;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

