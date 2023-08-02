using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CreateMosFileDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[][] lists;
        string projectFolderPath = "C:\\Proje Dosyaları\\";
        string nodeFolderPath = string.Empty;

        private void buttonExcelOku_Click(object sender, EventArgs e)
        {

            if(listBoxIslemler.Items.Count != 0)
            {
                listBoxIslemler.Items.Clear();
            }
            string cellValue = null;
            bool stop = false;
            string excelFileName = null;
            int index = 0;
            do
            {
                string excelFilePath = string.Empty;
                openFileDialog1.InitialDirectory = Application.StartupPath;
                openFileDialog1.FileName = "*.xlsx";
                openFileDialog1.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    excelFilePath = openFileDialog1.FileName;
                    index = excelFilePath.LastIndexOf("\\") + 1;
                    excelFileName = excelFilePath.Substring(index);
                    MessageBox.Show(excelFileName + " dosyası seçildi.");
                    listBoxIslemler.Items.Add(excelFileName + " dosyası seçildi.");
                    Excel.Application xlApp = new Excel.Application();
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(excelFilePath);
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                    Excel.Range xlRange = xlWorksheet.UsedRange;
                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;
                    lists = new string[rowCount][];
                    for (int i = 0; i <= rowCount - 1; i++)
                    {
                        lists[i] = new string[colCount];
                        for (int j = 0; j <= colCount - 1; j++)
                        {
                            if (xlRange.Cells[i + 1, j + 1] != null && xlRange.Cells[i + 1, j + 1].Value2 != null)
                            {
                                cellValue = xlRange.Cells[i + 1, j + 1].Value2.ToString();
                                lists[i][j] = cellValue;
                            }
                        }
                    }
                    listBoxIslemler.Items.Add("Excel dosyası okundu.");
                    for (int i = 1; i < lists.Length; i++)
                    {
                        nodeFolderPath = projectFolderPath + lists[i][0];
                        if (Directory.Exists(nodeFolderPath))
                        {
                            Directory.Delete(nodeFolderPath, true);
                            MessageBox.Show("Mevcut olan " + lists[i][0] + " klasörü silindi.");
                            listBoxIslemler.Items.Add("Mevcut olan " + lists[i][0] + " klasörü silindi.");
                        }
                    }
                    buttonDosyaOlustur.Enabled = true;
                    xlApp.Workbooks.Close();
                    xlApp.Quit();

                    xlRange = null;
                    xlWorksheet = null;
                    xlWorkbook = null;
                    xlApp = null;
                    stop = true;
                }
                else
                {
                    MessageBox.Show("Excel dosyasını seçmediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }
            while (stop == false);
        }



        private void buttonDosyaOlustur_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(projectFolderPath);
            for (int i = 1; i < lists.Length; i++)
            {
                nodeFolderPath = projectFolderPath + lists[i][0];
                Directory.CreateDirectory(nodeFolderPath);
                listBoxIslemler.Items.Add(lists[i][0] + " klasörü oluşturuldu.");
            }
            buttonMosOlustur.Enabled = true;
        }


        string mosFileName = string.Empty;
        string mosFilePath = string.Empty;
        string value = string.Empty;

        private void buttonMosOlustur_Click(object sender, EventArgs e)
        {
            string mosText = string.Empty;
            for (int i = 1; i < lists.Length; i++)
            {
                for (int j = 1; j < lists[i].Length; j++)
                {
                    if(lists[i][j] == null)
                    {
                        lists[i][j] = "-";
                    }
                    else
                    {
                        if (lists[0][j].StartsWith("IPV6"))
                        {
                            string [] seperate = lists[i][j].Split(':');
                            for (int k = 0; k < 8; k++)
                            {
                                if (seperate[k].StartsWith("0000"))
                                {
                                    value += ":";
                                }
                                else if (seperate[k].StartsWith("000"))
                                {
                                    value += seperate[k].Substring(3) + ":";
                                }
                                else if (seperate[k].StartsWith("00"))
                                {
                                    value += seperate[k].Substring(2) + ":";
                                }
                                else if (seperate[k].StartsWith("0"))
                                {
                                    value += seperate[k].Substring(1) + ":";
                                }
                                else
                                {
                                    value += seperate[k] + ":";
                                }
                            }
                            while (value.Contains(":::"))
                            {
                                value = value.Replace(":::", "::");
                            }
                            lists[i][j] = value.Substring(0,value.Length-1);

                            value = "";



                            //for (int k = 0; k < lists[i][j].Length; k+=5)
                            //{
                            //    if (lists[i][j].Substring(k, 4) == "0000")
                            //    {
                            //        value = lists[i][j].Substring(k + 4, 1);
                            //    }
                            //    else if(lists[i][j].Substring(k, 4).StartsWith("000")){
                            //        value = lists[i][j].Substring(k + 3, 2);
                            //    }
                            //    else if(lists[i][j].Substring(k, 4).StartsWith("00"))
                            //    {
                            //        value = lists[i][j].Substring(k + 2, 3);
                            //    }
                            //    else if(lists[i][j].Substring(k, 4).StartsWith("0"))
                            //    {
                            //        value = lists[i][j].Substring(k + 1, 4);
                            //    }
                            //    else
                            //    {
                            //        if (lists[i][j].Substring(k, 5).Length < 5)
                            //        {
                            //            value = lists[i][j].Substring(k, 4);
                            //        }
                            //        else
                            //        {
                            //            value = lists[i][j].Substring(k, 5);
                            //        }
                            //    }
                            //    lists[i][j] += value;  
                            //}

                        }
                    }
                    mosText += lists[0][j] + " " + lists[i][j] + Environment.NewLine;

                    //value = lists[i][j];
                    //if(lists[i][j] == string.Empty)
                    //{
                    //    lists[i][j] = "-";
                    //}
                    //if (lists[0][j].StartsWith("IPV6") && lists[i][j] != "-")
                    //{
                    //    string[] eachValue = new string[8];
                    //    for (int k = 0; k / 5 < eachValue.Length; k += 5)
                    //    {
                    //        eachValue[k / 5] = value.Substring(k, 4);
                    //    }
                    //    for (int l = 0; l < 8; l++)
                    //    {
                    //        if (eachValue[l].StartsWith("0"))
                    //        {
                    //            eachValue[l] = eachValue[l].Substring(1); 
                    //            lists[i][j] += eachValue[l] + ":";
                    //        }  
                    //        lists[i][j] = lists[i][j].Substring(0, lists[i][j].Length - 1);                       
                    //    }

                    //    mosText += lists[0][j] + " " + lists[i][j] + Environment.NewLine;
                    //}
                    //else
                    //{
                    //    mosText += lists[0][j] + " " + lists[i][j] + Environment.NewLine;
                    //}

                }
                nodeFolderPath = projectFolderPath + lists[i][0];
                mosFileName = lists[i][0] + ".mos";
                mosFilePath = Path.Combine(nodeFolderPath, mosFileName);
                StreamWriter sw = new StreamWriter(mosFilePath);
                sw.WriteLine(mosText);
                sw.Close();
                mosText = "";
                listBoxIslemler.Items.Add(mosFileName + " dosyası oluşturuldu.");
            }
            listBoxIslemler.Items.Add("İşlem tamamlandı.");
            if (buttonDosyaOlustur.Enabled || buttonMosOlustur.Enabled)
            {
                buttonDosyaOlustur.Enabled = false;
                buttonMosOlustur.Enabled = false;
            }
        }
    }
}
