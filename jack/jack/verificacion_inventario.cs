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
using _Excel = Microsoft.Office.Interop.Excel;

namespace jack
{
    public partial class verificacion_inventario : Form
    {
        public string path_inventory = @"C:\Users\jesus\Downloads\proyecto U6 Jack\catalogo - Copy.xlsx";
        public verificacion_inventario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuGeneral menuGeneral = new MenuGeneral();
            menuGeneral.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btVerificar_Click(object sender, EventArgs e)
        {
            Excel_verificar_inventario excel = new Excel_verificar_inventario(path_inventory, 1);
            for (int counter = 0; counter < 20; counter++)
            {
                if (textBox1.Text == excel.ReadCell(counter, 0))
                {       
                    MessageBox.Show("El inventario es " + excel.ReadCell(counter, 2));
                    break;
                }
                else if (excel.ReadCell(counter, 0) == "")
                { 
                    MessageBox.Show("No hay inventario o el nombre no fue introducido correctamente");
                    break;
                }
            }

        }
    }

    //podre heredar esto de abajo???
    class Excel_verificar_inventario
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel_verificar_inventario(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[Sheet];
        }
        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null)
                return ws.Cells[i, j].Value2.ToString();
            else
                return "";
        }
        public void WriteToCell(int i, int j, string s)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = s;
        }
        public void Save()
        { 
            wb.Save();
        }
        public void SaveAs(string path)
        {
            wb.SaveAs(path);
        }
        public void Close()
        {
            wb.Close();
        }
    }
}
