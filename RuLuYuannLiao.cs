//using MySql.Data.MySqlClient;
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
using WindowsFormsApplication1.ShiTiLei;

namespace WindowsFormsApplication1
{
    public partial class RuLuYuannLiao : Form
    {
        public RuLuYuannLiao()
        {
            InitializeComponent();
        }
        //private string strConn = "server=localhost;database=pro;integrated security=SSPI";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void RuLuYuannLiao_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void watermarkTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void watermarkTextBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private YuanLiao YL;

        internal YuanLiao YL1
        {
            get
            {
                return YL;
            }

            set
            {
                YL = value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text.Trim()
            //Mysql_excute sql_conn = new Mysql_excute();
            DateTime Dt;
            DateTime.TryParse("2001/01/01", out Dt);
            YL1.Datetime = Dt;
            string str = this.watermarkTextBox1.Text.Trim();
            int int_temp = -1;
            double doub_temp = 0.0;
            DateTime dt = DateTime.Now;
            //1 heat num
            int.TryParse(str, out int_temp);
            YL1.HeatNum_yl = int_temp;
            //2
            str = this.watermarkTextBox3.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.TFe1 = doub_temp;
            //combox
            str = this.comboBox1.Text.ToString();
            YL1.PingZhong = str;
            //3
            str = this.watermarkTextBox2.Text;
            if(str != "")
            {
                DateTime.TryParse(str, out dt);
                YL1.Datetime = dt;
            }  
            /*string sql11 = string.Format
                     (@"select heatNum_yl from yuanliao where heatNum_yl = '{0}' and datetime = '{1}' ", YL.HeatNum_yl, YL.Datetime);
            MySqlDataReader MDR = sql_conn.getmysqlread(sql11);
            // MDR.GetValues();
            if (MDR.HasRows)
            {
                MessageBox.Show("炉号为" + string.Format("{0}", int_temp) + "日期为" + string.Format("{0}", dt) + "的数据重复插入！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }*/
            //4
            str = this.watermarkTextBox4.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.FeO1 = doub_temp;
            //5
            str = this.watermarkTextBox5.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.SiO21 = doub_temp;

            //6
            str = this.watermarkTextBox14.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.S1 = doub_temp;
            //7
            str = this.watermarkTextBox6.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.CaO1 = doub_temp;

            //8
            str = this.watermarkTextBox7.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.MgO1 = doub_temp;

            //9
            str = this.watermarkTextBox8.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.P2O51 = doub_temp;

            //10
            str = this.watermarkTextBox9.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.MnO1 = doub_temp;

            //11
            str = this.watermarkTextBox10.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.TiO21 = doub_temp;
            //12
            str = this.watermarkTextBox11.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.R21 = doub_temp;
            //13
            str = this.watermarkTextBox12.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_A = doub_temp;
            //14
            str = this.watermarkTextBox13.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Al2O31 = doub_temp;
            //15
            str = this.watermarkTextBox14.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_S = doub_temp;
            //16
            str = this.watermarkTextBox15.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_C = doub_temp;

            //17
            str = this.watermarkTextBox16.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_P = doub_temp;

            //18
            str = this.watermarkTextBox17.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_V = doub_temp;

            //19
            str = this.watermarkTextBox18.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_H2O = doub_temp;

            //20
            str = this.watermarkTextBox20.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.JSLD_Lessthan51 = doub_temp;
            //21
            str = this.watermarkTextBox21.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.JSLD_5to101 = doub_temp;

            //22
            str = this.watermarkTextBox22.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.JSLD_10to151 = doub_temp;

            //23
            str = this.watermarkTextBox23.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.JSLD_15to251 = doub_temp;
            //24
            str = this.watermarkTextBox24.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.JSLD_25to401 = doub_temp;
            //25
            str = this.watermarkTextBox25.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.JSLD_Morethan401 = doub_temp;
            //26
            str = this.watermarkTextBox26.Text.Trim();
            double.TryParse(str, out doub_temp);
            YL1.Fuel_S = doub_temp;
            //27
            str = this.watermarkTextBox19.Text.Trim();
            YL1.GranularityTime1 = str;

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
           // DateTime low_datime;
            /* low_datime = g_l_c_z.GaoLuOperationTime1.AddHours(-4.5);

             DateTime high_datime;
             high_datime = g_l_c_z.GaoLuOperationTime1.AddHours(-3.5);


             string sql_123 = string.Format(@"select HeatNum from Project_Iron where HeatNum = '{0}' and outIronTime >='{1}' and  outIronTime<'{2}'",
                 g_l_c_z.HeatNum_gl, low_datime, high_datime);

             SqlCommand sqlCmd = new SqlCommand(sql_123, sqlCnt);
             SqlDataReader reader = sqlCmd.ExecuteReader();
             string sql = string.Format(@"insert into yuanliao values('{0}','{1}','
 {2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',
                     '{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}'
 ,'{23}','{24}','{25}','{26}')",
          YL1.HeatNum_yl,
          YL1.Datetime,
          YL1.PingZhong,
          YL1.TFe1,
          YL1.FeO1,
          YL1.S1,
          YL1.SiO21,
          YL1.CaO1,
          YL1.MgO1,
          YL1.P2O51,
          YL1.MnO1,
          YL1.TiO21,
          YL1.R21,
          YL1.Fuel_A,
          YL1.Al2O31,
          YL1.Fuel_S,
          YL1.Fuel_C,
          YL1.Fuel_P,
          YL1.Fuel_V,
          YL1.Fuel_H2O,
          YL1.GranularityTime1,
          YL1.JSLD_Lessthan51,
          YL1.JSLD_5to101,
          YL1.JSLD_10to151,
          YL1.JSLD_15to251,
          YL1.JSLD_25to401,
          YL1.JSLD_Morethan401);
             SqlConnection sqlCont = new SqlConnection(strConn);
             sqlCont.Open();*/
            /* if (sql_conn.getmysqlcom(sql))
             {
                 MessageBox.Show("插入记录成功！", "提示");

             }
             else
             {
                 MessageBox.Show("插入记录不成功！", "提示");
             }*/
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
