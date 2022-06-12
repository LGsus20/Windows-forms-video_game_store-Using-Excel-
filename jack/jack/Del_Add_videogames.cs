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
    public partial class Del_Add_videogames : Form
    {
        public string path_inventory = @"C:\Users\jesus\Downloads\proyecto U6 Jack\catalogo - Copy.xlsx";
        public Del_Add_videogames()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
                MessageBox.Show("Llenar todos los campos");
            else 
            {
                Excel_verificar_inventario excel = new Excel_verificar_inventario(path_inventory, 1);
                for (int counter = 0; counter < 20; counter++)
                {
                    if ("." == excel.ReadCell(counter, 0))
                    {
                        excel.WriteToCell(counter, 0, textBox2.Text);
                        excel.WriteToCell(counter, 1, textBox3.Text);
                        excel.WriteToCell(counter, 2, textBox4.Text);
                        excel.WriteToCell(counter, 3, textBox5.Text);
                        excel.Save();
                        excel.Close();
                        break;
                    }
                }
            }
        }

        private void salir(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel_verificar_inventario excel = new Excel_verificar_inventario(path_inventory, 1);
            for (int counter = 0; counter < 20; counter++)
            {
                if (textBox1.Text == excel.ReadCell(counter, 0))
                {
                    excel.WriteToCell(counter, 0, ".");
                    excel.WriteToCell(counter, 1, ".");
                    excel.WriteToCell(counter, 2, ".");
                    excel.WriteToCell(counter, 3, ".");
                    excel.Save();
                    excel.Close();
                    break;
                }
            }
            System.Threading.Thread.Sleep(6000);
            MessageBox.Show("Se ha borrado el juego");
        }

        private void BTRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuGeneral menuGeneral = new MenuGeneral();
            menuGeneral.Show();
        }
    }
}
