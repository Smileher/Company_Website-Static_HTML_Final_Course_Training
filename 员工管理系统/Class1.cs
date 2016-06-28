using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace 员工管理系统
{
    class Class1
    {
        static string str = Properties.Settings.Default.sql;
        SqlConnection cn = new SqlConnection(str);
        SqlDataAdapter dat = new SqlDataAdapter();
        DataSet ds = new DataSet();
        SqlCommand cmd;
        public DataSet FillData()
        {
            cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表", cn);
            dat.SelectCommand = cmd;
            dat.Fill(ds, "员工信息表");
            return ds;
        }

        public DataSet FillData(string dept)
        {
            if(dept== "公司员工管理系统")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表", cn);
        
            if(dept== "营销中心")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID=1001 or 所在部门ID=1002 or 所在部门ID=1003", cn);

            if (dept == "管理中心")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID=1004 or 所在部门ID=1005 or 所在部门ID=1006", cn);

            if (dept == "采购部门")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID=1001", cn);

            if (dept == "销售部门")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID='1002'", cn);

            if (dept == "售后部门")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID='1003'", cn);

            if (dept == "人事部门")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID='1004'", cn);

            if (dept == "财务部门")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID='1005'", cn);
            
            if (dept == "经理")
                cmd = new SqlCommand("select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表 where 所在部门ID='1006'", cn);
            
            dat.SelectCommand = cmd;
            dat.Fill(ds, "员工信息表");
            return ds;
        }






    }
}
