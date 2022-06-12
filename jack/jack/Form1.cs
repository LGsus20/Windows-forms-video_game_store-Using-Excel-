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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string path_login_excel = @"C:\Users\jesus\Downloads\proyecto U6 Jack\login.xlsx";
            Excel excel = new Excel(path_login_excel, 1);
            string user = textBox1.Text;
            string password = textBox2.Text;
            //excel.ReadCell(y-1,x-1) asi funciona
            bool login_pass = false;
            if ((user == excel.ReadCell(1, 1)) && (password == excel.ReadCell(1, 2)))
                login_pass = true;
            else if ((user == excel.ReadCell(2, 1)) && (password == excel.ReadCell(2, 2)))
                login_pass = true;
            else if ((user == excel.ReadCell(3, 1)) && (password == excel.ReadCell(3, 2)))
                login_pass = true;

            if (login_pass)
            {
                MessageBox.Show("logeado");
                progressBar1.Visible = true;
                this.timer1.Enabled = true;
                excel.Close();
            } 
            else
                MessageBox.Show("password o usuario incorrectos");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.progressBar1.Maximum = 20;
            progressBar1.Visible = false;

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            if (checkBox1.Checked == true)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value >= 20)
            {
                this.timer1.Enabled = false;
                this.Hide();
                MenuGeneral menuGeneral = new MenuGeneral();
                menuGeneral.Show();
            }
            else
                this.progressBar1.Value += 1;
        }
    }
    class Excel
    {
        string path;
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int Sheet)
        {
            this.path=path;
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
        public void Close()
        {
            wb.Close();
        }
    }
}
