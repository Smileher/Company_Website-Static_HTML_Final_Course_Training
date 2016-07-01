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

        private const string BaseContent = "select 员工ID,所在部门ID,姓名,性别,出生日期,电话 from 员工信息表";

        private static readonly Dictionary<string, string> Dic = new Dictionary<string, string>
        {
            {"公司员工管理系统", BaseContent },
            {"营销中心", BaseContent + " where 所在部门ID=1001 or 所在部门ID=1002 or 所在部门ID=1003" },
            {"管理中心", BaseContent + " where 所在部门ID=1004 or 所在部门ID=1005 or 所在部门ID=1006" },
            {"采购部门", BaseContent + " where 所在部门ID=1001" },
            {"销售部门", BaseContent + " where 所在部门ID=1002" },
            {"售后部门", BaseContent + " where 所在部门ID=1003" },
            {"人事部门", BaseContent + " where 所在部门ID=1004" },
            {"财务部门", BaseContent + " where 所在部门ID=1005" },
            {"经理", BaseContent + " where 所在部门ID=1006" }
        };

        public DataSet FillData(string dept)
        {
            if (Dic.ContainsKey(dept))
            {
                cmd = new SqlCommand(Dic[dept], cn);
            }
            else
            {
                throw new ArgumentNullException("未找到参数");
            }

            dat.SelectCommand = cmd;
            dat.Fill(ds, "员工信息表");
            return ds;
        }






    }
}
