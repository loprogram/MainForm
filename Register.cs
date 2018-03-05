using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Register : Form
    {
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Mysql_excute msql_ex = new Mysql_excute();

            string str1 = watermarkTextBox1.Text.ToString();        //用户名
            string str2 = watermarkTextBox2.Text.ToString();        //职位
            string str3 = watermarkTextBox3.Text.ToString();        //密码
            string str4 = watermarkTextBox4.Text.ToString();        //确认密码

            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            sqlCnt1.Open();
            // msql_ex.getmysqlcon();

            string sql = string.Format(@"insert into Login 
values('{0}','{1}','{2}')",str1,str2,str4);
            SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
            
            if (sqlCmd1.ExecuteNonQuery()>0)
            {
                MessageBox.Show("注册成功！");
                this.Close();
            }
            sqlCnt1.Close();
        }

        private void watermarkTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void watermarkTextBox4_TextChanged(object sender, EventArgs e)
        {
            string str3 = watermarkTextBox3.Text.ToString();        //密码
            string str4 = watermarkTextBox4.Text.ToString();        //确认密码

            if(str3 != str4)
            {
                MessageBox.Show("两次输入的密码不一致！","提示");
            }
        }

        private void watermarkTextBox3_TextChanged(object sender, EventArgs e)
        {
            string str = watermarkTextBox3.Text.ToString();

            if(str.Length <8)
            {
                MessageBox.Show("长度太短，请重新输入", "提示");
            }
            return;
        }

        private void watermarkTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            sqlCnt1.Open();
            string str = watermarkTextBox1.Text.ToString();
            if (str == "")
            {
                MessageBox.Show("用户名不可以为空！");
                return;
            }
            else
            {
                string sql = string.Format(@"select usrId from Login where usrId = '{0}'", str);
                //MySqlDataReader MDR = myex.getmysqlread(sql);
                // MDR.GetValues();
                SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
                SqlDataReader reader = sqlCmd1.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("用户名重复！", "提示");
                }
            }        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
