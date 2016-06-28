using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 员工管理系统
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Class1 mes1 = new Class1();
            DataSet mes = new DataSet();
            mes = mes1.FillData();
            dataGridView1.DataSource = mes;
            dataGridView1.DataMember = "员工信息表";
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Class1 tree = new Class1();
            DataSet ds = new DataSet();
            ds.Clear();
            ds = tree.FillData(e.Node.Text);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "员工信息表";
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Form6 about = new Form6();
           about.ShowDialog();
        }

        private void 注销登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("员工管理系统");
            Application.Exit();

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("请确认退出！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                Application.Exit();

        }

        private void 更改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            if (ID.Text == "admin")
            {
                f5.textBox1.Text = "";
                f5.textBox1.ReadOnly = false;
            }
            else
            {
                f5.textBox1.Text = ID.Text;
            }
            f5.ShowDialog();
        }

        private void 员工信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.button1.Visible = true;
            f4.button3.Visible = true;
            f4.button4.Visible = true;
            if (ID.Text != "admin")
            {
                f4.button1.Visible = false;
                f4.button3.Visible = false;
                f4.button4.Visible = false;
                f4.textBox2.ReadOnly = true;
                f4.textBox3.ReadOnly = true;
                f4.textBox4.ReadOnly = true;
                f4.textBox5.ReadOnly = true;
                f4.textBox6.ReadOnly = true;
                f4.textBox7.Visible = false;
                f4.label7.Visible = false;
            }
            f4.ShowDialog();
        }

        private void 部门信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.button1.Visible = true;
            f3.button3.Visible = true;
            f3.button4.Visible = true;
            if (ID.Text != "admin")
            {
                f3.button1.Visible = false;
                f3.button3.Visible = false;
                f3.button4.Visible = false;
                f3.textBox2.ReadOnly = true;
                f3.textBox3.ReadOnly = true;
                f3.textBox4.ReadOnly = true;
            }
            f3.ShowDialog();
        }


    }
}
