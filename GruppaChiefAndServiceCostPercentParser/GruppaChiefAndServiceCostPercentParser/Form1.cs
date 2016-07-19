using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DbfOperationsClassLibrary;
using GdbOperationsClassLibrary;

namespace GruppaChiefAndServiceCostPercentParser
{
    public partial class Form1 : Form
    {
        #region константы соответсвия ID касс названиям
        private const int Poliklinika = 8;
        private const int Reabilit = 9;
        private const int Diagnostic = 10;
        #endregion

        DbfOperationsUnit dbfUnit;
        GdbOperationsUnit gdbUnit;

        DbfOperationsUnitsClassFactory dbfClassFactory = new DbfOperationsUnitsClassFactory();
        int cashDescId;
        string gdbPath;
        string dbfPath;

        public Form1()
        {
            InitializeComponent();
            cashDeskComboBox.SelectedIndex = 0;
        }

        private void openGdbDialogButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog GDBFileDialog = new OpenFileDialog();
            GDBFileDialog.InitialDirectory = "C:\\";
            GDBFileDialog.FileName = "*.GDB";

            if (GDBFileDialog.ShowDialog() == DialogResult.OK)
            {
                gdbPath = GDBFileDialog.FileName.ToString();

                pathGdbTextBox.Text = gdbPath;
            }
        }

        private void openDbfDialogButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DBFDirDialog = new FolderBrowserDialog();
            if (DBFDirDialog.ShowDialog() == DialogResult.OK)
            {
                dbfPath = DBFDirDialog.SelectedPath.ToString();
                pathDbfTextBox.Text = dbfPath;

                dbfClassFactory.Initialize(dbfPath);
            }
        }

        private void exportGruppaChiefButton_Click(object sender, EventArgs e)
        {
            dbfUnit = dbfClassFactory.CreateChiefAndGruppaUnit(cashDescId);
            gdbUnit = new GdbInsertChiefUnit(gdbPath);

            InsertRecords();
        }

        private void exportServiceCostPercentButtom_Click(object sender, EventArgs e)
        {
            dbfUnit = dbfClassFactory.CreateServiceCostPercentUnit(cashDescId);
            gdbUnit = new GdbInsertServiceCostPercentUnit(gdbPath);

            InsertRecords();
        }

        private void InsertRecords()
        {
            progressBar.Maximum = dbfUnit.GetSize();

            foreach (Dictionary<string, object> data in dbfUnit.RecordsForInsert())
            {
                gdbUnit.InsertRecord(data);

                progressBar.Value += 1;
            }

            resultLabel.Text = "Экспорт завершен";
            progressBar.Value = 1;
        }

        private void cashDeskComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cashDeskComboBox.SelectedItem.ToString())
            {
                case "Поликлиника":
                    cashDescId = Poliklinika;
                    break;
                case "Реабилитационный центр":
                    cashDescId = Reabilit;
                    break;
                case "Диагностический центр":
                    cashDescId = Diagnostic;
                    break;
                default:
                    MessageBox.Show("Выберите корневое подразделение");
                    break;
            }
        }
    }
}
