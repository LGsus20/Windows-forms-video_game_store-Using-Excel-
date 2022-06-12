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
    public partial class verificar_precio : Form
    {
        public string path_inventory = @"C:\Users\jesus\Downloads\proyecto U6 Jack\catalogo - Copy.xlsx";
        public verificar_precio()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
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
                    MessageBox.Show("El precio es de: " + excel.ReadCell(counter, 1) + "dolares americanos");
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
}
