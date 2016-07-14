namespace WorkersParser
{
    partial class WorkerParserForm
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
            this.exportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.databaseFileTextBox = new System.Windows.Forms.TextBox();
            this.excelFileTextBox = new System.Windows.Forms.TextBox();
            this.selectDatabaseFileButton = new System.Windows.Forms.Button();
            this.selectExcelFileButton = new System.Windows.Forms.Button();
            this.exportProgressBar = new System.Windows.Forms.ProgressBar();
            this.doneLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(12, 188);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(196, 54);
            this.exportButton.TabIndex = 0;
            this.exportButton.Text = "Экспортировать";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Укажите путь к GDB файлу базы данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(276, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выберите файл со списком сотрудников (XLS/XLSX)";
            // 
            // databaseFileTextBox
            // 
            this.databaseFileTextBox.Location = new System.Drawing.Point(25, 45);
            this.databaseFileTextBox.Name = "databaseFileTextBox";
            this.databaseFileTextBox.ReadOnly = true;
            this.databaseFileTextBox.Size = new System.Drawing.Size(269, 20);
            this.databaseFileTextBox.TabIndex = 3;
            // 
            // excelFileTextBox
            // 
            this.excelFileTextBox.Location = new System.Drawing.Point(25, 136);
            this.excelFileTextBox.Name = "excelFileTextBox";
            this.excelFileTextBox.ReadOnly = true;
            this.excelFileTextBox.Size = new System.Drawing.Size(269, 20);
            this.excelFileTextBox.TabIndex = 4;
            // 
            // selectDatabaseFileButton
            // 
            this.selectDatabaseFileButton.Location = new System.Drawing.Point(300, 42);
            this.selectDatabaseFileButton.Name = "selectDatabaseFileButton";
            this.selectDatabaseFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectDatabaseFileButton.TabIndex = 5;
            this.selectDatabaseFileButton.Text = "Открыть";
            this.selectDatabaseFileButton.UseVisualStyleBackColor = true;
            this.selectDatabaseFileButton.Click += new System.EventHandler(this.selectDatabaseFileButton_Click);
            // 
            // selectExcelFileButton
            // 
            this.selectExcelFileButton.Location = new System.Drawing.Point(300, 136);
            this.selectExcelFileButton.Name = "selectExcelFileButton";
            this.selectExcelFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectExcelFileButton.TabIndex = 6;
            this.selectExcelFileButton.Text = "Открыть";
            this.selectExcelFileButton.UseVisualStyleBackColor = true;
            this.selectExcelFileButton.Click += new System.EventHandler(this.selectExcelFileButton_Click);
            // 
            // exportProgressBar
            // 
            this.exportProgressBar.Location = new System.Drawing.Point(12, 248);
            this.exportProgressBar.Name = "exportProgressBar";
            this.exportProgressBar.Size = new System.Drawing.Size(363, 23);
            this.exportProgressBar.TabIndex = 7;
            // 
            // doneLabel
            // 
            this.doneLabel.AutoSize = true;
            this.doneLabel.Location = new System.Drawing.Point(233, 189);
            this.doneLabel.Name = "doneLabel";
            this.doneLabel.Size = new System.Drawing.Size(0, 13);
            this.doneLabel.TabIndex = 8;
            // 
            // WorkerParserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 283);
            this.Controls.Add(this.doneLabel);
            this.Controls.Add(this.exportProgressBar);
            this.Controls.Add(this.selectExcelFileButton);
            this.Controls.Add(this.selectDatabaseFileButton);
            this.Controls.Add(this.excelFileTextBox);
            this.Controls.Add(this.databaseFileTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportButton);
            this.Name = "WorkerParserForm";
            this.Text = "Export workers list from EXCEL file to DataBase";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox databaseFileTextBox;
        private System.Windows.Forms.TextBox excelFileTextBox;
        private System.Windows.Forms.Button selectDatabaseFileButton;
        private System.Windows.Forms.Button selectExcelFileButton;
        private System.Windows.Forms.ProgressBar exportProgressBar;
        private System.Windows.Forms.Label doneLabel;
    }
}

