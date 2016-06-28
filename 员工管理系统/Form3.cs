using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace 员工管理系统
{
    public partial class Form3 : Form
    {
        static string str = Properties.Settings.Default.sql;
        SqlConnection cn = new SqlConnection(str);
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入ID", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from 部门信息表 where 部门ID=@sID", cn);
                cmd.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr["部门名称"].ToString().Trim();
                    textBox3.Text = dr["办公室房间号"].ToString().Trim();
                    textBox4.Text = dr["电话"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("该ID不存在", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd =
                new SqlCommand(
                    "update 部门信息表 set 部门名称 ='"+textBox2.Text+"',办公室房间号='" +textBox3.Text + "',电话='" + textBox4.Text + "'where 部门ID=@sID", cn);
                    cmd.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
                cn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cn.Close();
            }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 =
                   new SqlCommand(
                       "insert 部门信息表 (部门ID,部门名称,办公室房间号,电话) values('" + textBox1.Text + "', '" +
                       textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", cn);

            cn.Open();
            if (cmd1.ExecuteNonQuery() == 1)
            {
                cn.Close();

                {
                    MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("添加账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cn.Close();

            textBox1.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
            textBox2.Text = null;
        
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete  from 部门信息表 where 部门ID=@sID", cn);
            cmd.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
            cn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                cn.Close();

                MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("删除账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cn.Close();
            textBox1.Text = null;
            textBox4.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }
    }
}
