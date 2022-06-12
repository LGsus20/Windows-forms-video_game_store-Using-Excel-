using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jack
{
    public partial class Modificar_excel : Form
    {
        public string path_inventory = @"C:\Users\jesus\Downloads\proyecto U6 Jack\catalogo - Copy.xlsx";
        public Modificar_excel()
        {
            InitializeComponent();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuGeneral menuGeneral = new MenuGeneral();
            menuGeneral.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //catalogo - Copy
            
            Excel_verificar_inventario excel_new = new Excel_verificar_inventario(path_inventory, 1);

            int cell_to_change = 0;
            if (radioButton1.Checked)
                cell_to_change = 1;
            else if (radioButton2.Checked)
                cell_to_change = 2;

            if ((radioButton2.Checked) || (radioButton1.Checked))
            {
                for (int counter = 0; counter < 20; counter++)
                {
                    if (textBox3.Text == excel_new.ReadCell(counter, 0))
                    {
                        Convert.ToDouble(textBox2.Text);
                        excel_new.WriteToCell(counter, cell_to_change, textBox2.Text);
                        break;
                    }
                    else if (excel_new.ReadCell(counter, 0) == "")
                    {
                        MessageBox.Show("no existe ese articulo");
                        break;
                    }
                }
                excel_new.Save();
                excel_new.Close();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Excel_verificar_inventario excel = new Excel_verificar_inventario(path_inventory, 1);
            for (int counter = 0; counter < 20; counter++)
            {
                if (textBox3.Text == excel.ReadCell(counter, 0))
                {
                    textBox1.Text = excel.ReadCell(counter, 2);
                    break;
                }
                else if (excel.ReadCell(counter, 0) == "")
                {
                    MessageBox.Show("no existe ese articulo");
                    break;
                }
            }
            excel.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Excel_verificar_inventario excel = new Excel_verificar_inventario(path_inventory, 1);
            for (int counter = 0; counter < 20; counter++)
            {
                if (textBox3.Text == excel.ReadCell(counter, 0))
                {
 
                    textBox1.Text = excel.ReadCell(counter, 1);
                    break;
                }
                else if (excel.ReadCell(counter, 0) == "")
                {
                    MessageBox.Show("no existe ese articulo");
                    break;
                }
            }
            excel.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
