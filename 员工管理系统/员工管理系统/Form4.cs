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
    public partial class Form4 : Form
    {
        static string str = Properties.Settings.Default.sql;
        SqlConnection cn = new SqlConnection(str);

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 =
                new SqlCommand(
                    "update 员工信息表  set 所在部门ID='" + textBox4.Text + "',姓名='" + textBox2.Text + "',性别='" + textBox5.Text + "',出生日期='" + textBox3.Text + "',电话='"+
                    textBox6.Text +"' where 员工ID=@sID", cn);
            cmd1.Parameters.AddWithValue("@sID", textBox1.Text.Trim());

            cn.Open();
            if (cmd1.ExecuteNonQuery() == 1)
            {
                cn.Close();
                SqlCommand cmd =
                new SqlCommand(
                    "update 用户表 set 密码 ='"+textBox7.Text+"'where 用户ID=@sID", cn);
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
            else
            {
                MessageBox.Show("修改账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            textBox1.Text = null;
            textBox4.Text = null;
            textBox3.Text = null;
            textBox2.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("请输入ID", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select * from 员工信息表 where 员工ID=@sID", cn);
                cmd.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr["姓名"].ToString().Trim();
                    textBox3.Text = dr["出生日期"].ToString().Trim();
                    textBox4.Text = dr["所在部门ID"].ToString().Trim();
                    textBox5.Text = dr["性别"].ToString().Trim();
                    textBox6.Text = dr["电话"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("该ID不存在", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dr.Close();
                SqlCommand cmd1 = new SqlCommand("select * from 用户表 where 用户ID=@sID", cn);
                cmd1.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    textBox7.Text = dr1["密码"].ToString().Trim();
                }
                else
                {
                    MessageBox.Show("该ID不存在", "错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dr1.Close();
                cn.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete  from 员工信息表 where 员工ID=@sID", cn);
            cmd.Parameters.AddWithValue("@sID", textBox1.Text.Trim());
            cn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                cn.Close();
                SqlCommand cm = new SqlCommand("delete from 用户表 where 用户ID=@sID", cn);
                cm.Parameters.AddWithValue("@sID", textBox1.Text.Trim());

                cn.Open();
                if (cm.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            cn.Close();
            textBox1.Text = null;
            textBox4.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
             SqlCommand cmd1 =
                new SqlCommand(
                    "insert 员工信息表 (员工ID,所在部门ID,姓名,性别,出生日期,电话) values('" + textBox1.Text + "', '" + 
                    textBox4.Text + "','" + textBox2.Text + "','" +textBox5.Text + "','" + textBox3.Text + "','" + 
                    textBox6.Text + "')", cn);
             
                cn.Open();
                if (cmd1.ExecuteNonQuery() == 1)
                {
                    cn.Close();
                    SqlCommand cmd =
                    new SqlCommand(
                        "insert 用户表 (用户ID,密码,角色) values('" + textBox1.Text + "', '" +
                        textBox7.Text + "', '员工')", cn);
                    cn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("添加账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("添加账户失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                
                textBox1.Text = null;
                textBox4.Text = null;
                textBox3.Text = null;
                textBox2.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
                textBox7.Text = null;


            }


        }
    }


