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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
          
        }

        private void btt_Q_Click(object sender, EventArgs e)
        {

            string str = Properties.Settings.Default.sql;
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select * from Number where 用户ID=@sID", cn);
            cmd.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["密码"].ToString().Trim() == textBox2.Text.Trim())
                {
                   
                }
                else
                {
                    MessageBox.Show("你输入的密码错误", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox2.Text = "";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string str = Properties.Settings.Default.sql;
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("update 用户表 set 密码=@new_password where 用户ID=@sID and 密码=@ori_password", cn);
            cmd.Parameters.AddWithValue("@sID", textBox1.Text);
            cmd.Parameters.AddWithValue("@ori_password", textBox2.Text);
            cmd.Parameters.AddWithValue("@new_password", textBox3.Text);

            cn.Open();

            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("密码修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("密码修改失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            if (textBox1.ReadOnly == false)
            {
                textBox1.Text = null;
            }
            else
            {
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
