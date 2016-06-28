using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace 员工管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string str = Properties.Settings.Default.sql;
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select * from 用户表 where 用户ID=@sID", cn);
            cmd.Parameters.AddWithValue("@sID", txtUserName.Text.Trim());
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Form2 mes = new Form2();
            if (dr.Read())
            {
                if (dr["密码"].ToString().Trim() == txtUserPwd.Text.Trim())
                {
                    mes.role.Text = dr["角色"].ToString().Trim();
                    mes.ID.Text = dr["用户ID"].ToString().Trim();
          
                    if (txtUserName.Text == string.Empty)
                    {
                        MessageBox.Show("用户名不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Hide();
                    mes.ShowDialog();
                    Application.ExitThread();
                }

                else
                {
                    MessageBox.Show("密码不正确！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("用户名不存在！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

