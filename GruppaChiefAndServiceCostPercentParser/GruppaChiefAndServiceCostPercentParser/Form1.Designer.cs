namespace GruppaChiefAndServiceCostPercentParser
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.pathGdbTextBox = new System.Windows.Forms.TextBox();
            this.pathDbfTextBox = new System.Windows.Forms.TextBox();
            this.cashDeskComboBox = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.exportGruppaChiefButton = new System.Windows.Forms.Button();
            this.exportServiceCostPercentButtom = new System.Windows.Forms.Button();
            this.openGdbDialogButton = new System.Windows.Forms.Button();
            this.openDbfDialogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Укажите путь к файлу базы данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Укажите путь к каталогу с DBF файлами";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Выберите кассу";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(308, 286);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 3;
            // 
            // pathGdbTextBox
            // 
            this.pathGdbTextBox.Location = new System.Drawing.Point(58, 63);
            this.pathGdbTextBox.Name = "pathGdbTextBox";
            this.pathGdbTextBox.Size = new System.Drawing.Size(278, 20);
            this.pathGdbTextBox.TabIndex = 4;
            // 
            // pathDbfTextBox
            // 
            this.pathDbfTextBox.Location = new System.Drawing.Point(58, 141);
            this.pathDbfTextBox.Name = "pathDbfTextBox";
            this.pathDbfTextBox.Size = new System.Drawing.Size(278, 20);
            this.pathDbfTextBox.TabIndex = 5;
            // 
            // cashDeskComboBox
            // 
            this.cashDeskComboBox.FormattingEnabled = true;
            this.cashDeskComboBox.Items.AddRange(new object[] {
            "Поликлиника",
            "Реабилитационный центр",
            "Диагностический центр"});
            this.cashDeskComboBox.Location = new System.Drawing.Point(58, 226);
            this.cashDeskComboBox.Name = "cashDeskComboBox";
            this.cashDeskComboBox.Size = new System.Drawing.Size(278, 21);
            this.cashDeskComboBox.TabIndex = 6;
            this.cashDeskComboBox.SelectedIndexChanged += new System.EventHandler(this.cashDeskComboBox_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 319);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(683, 23);
            this.progressBar.TabIndex = 7;
            // 
            // exportGruppaChiefButton
            // 
            this.exportGruppaChiefButton.Location = new System.Drawing.Point(495, 63);
            this.exportGruppaChiefButton.Name = "exportGruppaChiefButton";
            this.exportGruppaChiefButton.Size = new System.Drawing.Size(150, 67);
            this.exportGruppaChiefButton.TabIndex = 8;
            this.exportGruppaChiefButton.Text = "Экспортировать начальников групп";
            this.exportGruppaChiefButton.UseVisualStyleBackColor = true;
            this.exportGruppaChiefButton.Click += new System.EventHandler(this.exportGruppaChiefButton_Click);
            // 
            // exportServiceCostPercentButtom
            // 
            this.exportServiceCostPercentButtom.Location = new System.Drawing.Point(495, 182);
            this.exportServiceCostPercentButtom.Name = "exportServiceCostPercentButtom";
            this.exportServiceCostPercentButtom.Size = new System.Drawing.Size(150, 65);
            this.exportServiceCostPercentButtom.TabIndex = 9;
            this.exportServiceCostPercentButtom.Text = "Экспортировать проценты распределения";
            this.exportServiceCostPercentButtom.UseVisualStyleBackColor = true;
            this.exportServiceCostPercentButtom.Click += new System.EventHandler(this.exportServiceCostPercentButtom_Click);
            // 
            // openGdbDialogButton
            // 
            this.openGdbDialogButton.Location = new System.Drawing.Point(356, 60);
            this.openGdbDialogButton.Name = "openGdbDialogButton";
            this.openGdbDialogButton.Size = new System.Drawing.Size(75, 23);
            this.openGdbDialogButton.TabIndex = 10;
            this.openGdbDialogButton.Text = "Открыть";
            this.openGdbDialogButton.UseVisualStyleBackColor = true;
            this.openGdbDialogButton.Click += new System.EventHandler(this.openGdbDialogButton_Click);
            // 
            // openDbfDialogButton
            // 
            this.openDbfDialogButton.Location = new System.Drawing.Point(356, 138);
            this.openDbfDialogButton.Name = "openDbfDialogButton";
            this.openDbfDialogButton.Size = new System.Drawing.Size(75, 23);
            this.openDbfDialogButton.TabIndex = 11;
            this.openDbfDialogButton.Text = "Открыть";
            this.openDbfDialogButton.UseVisualStyleBackColor = true;
            this.openDbfDialogButton.Click += new System.EventHandler(this.openDbfDialogButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 354);
            this.Controls.Add(this.openDbfDialogButton);
            this.Controls.Add(this.openGdbDialogButton);
            this.Controls.Add(this.exportServiceCostPercentButtom);
            this.Controls.Add(this.exportGruppaChiefButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.cashDeskComboBox);
            this.Controls.Add(this.pathDbfTextBox);
            this.Controls.Add(this.pathGdbTextBox);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Экспорт в БД информации о начальниках групп и процентах распрделения для выбранно" +
    "й кассы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.TextBox pathGdbTextBox;
        private System.Windows.Forms.TextBox pathDbfTextBox;
        private System.Windows.Forms.ComboBox cashDeskComboBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button exportGruppaChiefButton;
        private System.Windows.Forms.Button exportServiceCostPercentButtom;
        private System.Windows.Forms.Button openGdbDialogButton;
        private System.Windows.Forms.Button openDbfDialogButton;
    }
}

