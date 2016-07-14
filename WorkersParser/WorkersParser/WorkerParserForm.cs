using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GdbOperationsClassLibrary;
using ExcelOperationsClassLibrary;

namespace WorkersParser
{
    public partial class WorkerParserForm : Form
    {
        ExcelOperationsUnit excelUnit;
        GdbOperationsUnit gdbUnit;

        public WorkerParserForm()
        {
            InitializeComponent();
        }

        private void selectDatabaseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog GDBFileDialog = new OpenFileDialog();
            GDBFileDialog.InitialDirectory = "C:\\";
            GDBFileDialog.FileName = "*.GDB";

            if (GDBFileDialog.ShowDialog() == DialogResult.OK)
            {
                gdbUnit = new GdbInsertWorkerUnit(GDBFileDialog.FileName.ToString());

                databaseFileTextBox.Text = GDBFileDialog.FileName.ToString();
            }
        }

        private void selectExcelFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog XLSFileDialog = new OpenFileDialog();
            XLSFileDialog.InitialDirectory = "C:\\";
            XLSFileDialog.Filter = "New excel files (*.xlsx)|*.xlsx|Old excel files (*.xls)|*.xls";

            if (XLSFileDialog.ShowDialog() == DialogResult.OK)
            {
                excelUnit = new ExcelOperationsUnit(XLSFileDialog.FileName.ToString());

                excelFileTextBox.Text = XLSFileDialog.FileName.ToString();

                exportProgressBar.Maximum = excelUnit.GetSize();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            foreach(Dictionary<string, object> data in excelUnit.WorkersList())
            {
                gdbUnit.InsertRecord(data);

                exportProgressBar.Value += 1;
            }

            doneLabel.Text = "Экспорт завершен";
        }
    }
}
