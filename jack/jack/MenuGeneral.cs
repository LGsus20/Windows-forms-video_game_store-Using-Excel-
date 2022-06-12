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
    public partial class MenuGeneral : Form
    {
        public MenuGeneral()
        {
            InitializeComponent();
        }

        private void verificarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verificacion_inventario verificacion_Inventario = new verificacion_inventario();
            this.Hide();
            verificacion_Inventario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void verificarPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            verificar_precio verificar_Precio = new verificar_precio();
            this.Hide();
            verificar_Precio.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modificar_excel modificar_Excel = new Modificar_excel();
            this.Hide();
            modificar_Excel.Show();
        }

        private void MenuGeneral_Load(object sender, EventArgs e)
        {

        }

        private void ventaYFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Del_Add_videogames del_Add_Videogames = new Del_Add_videogames();
            this.Hide();
            del_Add_Videogames.Show();
        }
    }
}
