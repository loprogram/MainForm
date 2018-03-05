using DevExpress.XtraCharts;
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

namespace WindowsFormsApplication1.Tongji
{
    public partial class Class_Compare : Form
    {
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";
        public Class_Compare()
        {
            InitializeComponent();
        }

        private void Class_Compare_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“proDataSet.Project_Iron”中。您可以根据需要移动或删除它。      

        }
        private DataTable GetClassCount(ref DataTable dt,string banzu)
        {           
            int start_ = 40;
            double Sum = 0.0;
            /*
            统计产量的范围：
              <40,40-46,46-52,52-58,58-64,64-70,>70
            */
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            sqlCnt1.Open();
            //<40的sql语句
            string sql = string.Format(@"SELECT sum(yield_1) from 
Project_Iron where outIronTime >='{0}' and outIronTime <'{1}' and banZu 
='{2}' and yield_1 <{3} and HeatNum ={4}", dateEdit1.DateTime.ToString(), dateEdit2.DateTime.ToString(),
banzu, start_, comboBox1.Text.ToString());
            SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
            SqlDataReader read = sqlCmd1.ExecuteReader();
            if(read.Read())
            {
                double.TryParse(read[0].ToString(),out Sum);
                dt.Rows.Add("<40", Sum);
            }
            int buchang = 6;
            for(int i=start_;i<=70;i+= buchang)
            {
                SqlConnection sqlCnt2 = new SqlConnection(strConn);
                sqlCnt2.Open();
                //<40的sql语句
               
                string sql_ = string.Format(@"SELECT sum(yield_1) from 
Project_Iron where outIronTime >='{0}' and outIronTime <'{1}' and banZu 
='{2}' and yield_1 >={3} and yield_1<{4} and HeatNum ={5}", dateEdit1.DateTime.ToString(), dateEdit2.DateTime.ToString(),
   banzu, i, i+buchang,comboBox1.Text.ToString());
                SqlCommand sqlCmd2 = new SqlCommand(sql_, sqlCnt2);
                SqlDataReader read_ = sqlCmd2.ExecuteReader();
                if (read_.Read())
                {
                    double.TryParse(read_[0].ToString(), out Sum);
                    dt.Rows.Add(i.ToString() + "-" + (i + buchang).ToString(), Sum);
                }
                sqlCnt2.Close();
            }
            sqlCnt1.Close();

            SqlConnection sqlCnt3 = new SqlConnection(strConn);
            sqlCnt3.Open();
            //<40的sql语句

            string sql3 = string.Format(@"SELECT sum(yield_1) from 
Project_Iron where outIronTime >='{0}' and outIronTime <'{1}' and banZu 
='{2}' and yield_1 >={3} and HeatNum ={4}", dateEdit1.DateTime.ToString(), dateEdit2.DateTime.ToString(),
banzu, 70, comboBox1.Text.ToString());
            SqlCommand sqlCmd3 = new SqlCommand(sql3, sqlCnt3);
            SqlDataReader read3 = sqlCmd3.ExecuteReader();
            if (read3.Read())
            {
                double.TryParse(read3[0].ToString(), out Sum);
                dt.Rows.Add(">76", Sum);
            }
            sqlCnt3.Close();
            return dt;
        }
        private void ClassHebing(string zuobiao_x,string banzu)        //某班产量（拼接一下）
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(zuobiao_x, typeof(string));//范围  
            dt.Columns.Add("count", typeof(double));   //数量  
            Series s1 = new Series(banzu, ViewType.Bar);
            s1.DataSource = GetClassCount(ref dt, banzu);//设置实例对象s1的数据源  
            s1.ArgumentDataMember = zuobiao_x;//绑定图表的横坐标  
            s1.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
            s1.LegendText = banzu + "产量";//设置图例文字 就是右上方的小框框  
            chartControl1.Series.Add(s1);
        }
        private void CalClassSumYield(LinkLabel LinkLa,string banzu)
        {
            SqlConnection sqlCnt23 = new SqlConnection(strConn);
            sqlCnt23.Open();
            //<40的sql语句
            string sql = string.Format(@"SELECT sum(yield_1) from 
Project_Iron where outIronTime >='{0}' and outIronTime <'{1}' and banZu 
='{2}' and HeatNum ={3}", dateEdit1.DateTime.ToString(), dateEdit2.DateTime.ToString(),
banzu, comboBox1.Text.ToString());
            SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt23);
            SqlDataReader read = sqlCmd1.ExecuteReader();
            double sum = 0.0;
            if (read.Read())
            {
                double.TryParse(read[0].ToString(), out sum);
                //dt.Rows.Add("<40", Sum);
                LinkLa.Text = sum.ToString();
            }
            sqlCnt23.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //统计甲乙丙丁班的产量，目前只统计第一罐的产量       
            CalClassSumYield(linkLabel1, "甲班");
            CalClassSumYield(linkLabel2, "乙班");
            CalClassSumYield(linkLabel3, "丙班");
            CalClassSumYield(linkLabel4, "丁班");

            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new ChartTitle());
            chartControl1.Titles[0].Text = "班组产量对比图";
           
            //条形图
            switch (comboBox2.Text.ToString())
            {
                case "甲、乙比较":
                    ClassHebing("甲", "甲班");
                    //乙班
                    ClassHebing("乙", "乙班");
                    break;
                case "甲、丙比较":
                    ClassHebing("甲", "甲班");
                    ClassHebing("丙", "丙班");
                    break;
                case "甲、丁比较":
                    ClassHebing("甲", "甲班");
                    ClassHebing("丁", "丁班");
                    break;
                case "乙、丙比较":
                    ClassHebing("乙", "乙班");
                    ClassHebing("丙", "丙班");
                    break;
                case "乙、丁比较":
                    ClassHebing("乙", "乙班");
                    ClassHebing("丁", "丁班");
                    break;
                case "丙、丁比较":
                    ClassHebing("丙", "丙班");
                    ClassHebing("丁", "丁班");
                    break;
                case "甲乙丙比较":
                    ClassHebing("甲", "甲班");
                    //乙班
                    ClassHebing("乙", "乙班");
                    ClassHebing("丙", "丙班");
                    break;
                case "甲乙丁比较":
                    ClassHebing("甲", "甲班");
                    //乙班
                    ClassHebing("乙", "乙班");
                    ClassHebing("丁", "丁班");
                    break;
                case "甲丙丁比较":
                    ClassHebing("甲", "甲班");
                    ClassHebing("丙", "丙班");
                    ClassHebing("丁", "丁班");
                    break;
                case "乙丙丁比较":
                    ClassHebing("乙", "乙班");
                    ClassHebing("丙", "丙班");
                    ClassHebing("丁", "丁班");
                    break;
                case "甲乙丙丁比较":
                    ClassHebing("甲", "甲班");
                    //乙班
                    ClassHebing("乙", "乙班");
                    ClassHebing("丙", "丙班");
                    ClassHebing("丁", "丁班");
                    break;
                default:
                    break;
            }               
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
