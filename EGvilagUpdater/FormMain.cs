using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EGvilagUpdater
{
    public partial class FormMain : Form
    {
        public FormCheck fc = new FormCheck();

        

        public FormMain()
        {
            InitializeComponent();
        }
#region woot
        private void FormMain_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnCount = 10;
            //tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.AutoSize = true;
            for (int i = 0; i < 100; i++)
            {
                tableLayoutPanel1.Controls.Add(new Button());
                //(tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1] as Button).Dock = DockStyle.Fill;
                (tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1] as Button).FlatStyle = FlatStyle.Flat;
                (tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1] as Button).FlatAppearance.BorderSize = 0;
                
                (tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1] as Button).BackColor = Color.White;
                (tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1] as Button).Margin = new Padding(0);
                tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1].Width = 25;
                tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1].Height = 25;
                tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1].Name = "button" + i;
                tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1].Text = "O";
                tableLayoutPanel1.Controls[tableLayoutPanel1.Controls.Count - 1].Click += new System.EventHandler(this.ButtonClick);
            }
            (tableLayoutPanel1.Controls.Find("button5", true)[0] as Button).Text = "?";
        }
           
        private void ButtonClick(object sender, EventArgs e)
        {
            string name = (sender as Button).Text;
            string s = (sender as Button).Name.Substring(6, (sender as Button).Name.Length - 6);
            int number = Convert.ToInt32((sender as Button).Name.Substring(6, (sender as Button).Name.Length - 6));
            MessageBox.Show(name);
        }

#endregion
        private void FormMain_Shown(object sender, EventArgs e)
        {
            //fc.ShowDialog();
        }
    }
}
