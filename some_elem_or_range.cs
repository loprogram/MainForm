//using DevExpress.Charts.Model;
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
using WindowsFormsApplication1.K_value;

namespace WindowsFormsApplication1.Tongji
{
    public partial class some_elem_or_range : Form
    {
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";
        public some_elem_or_range()
        {
            InitializeComponent();
        }

        public void LoadAll(string[] str_ArrChoiced)       //传递选中的参数
        {   //Series  对象表示数据系列，并且存储在 SeriesCollection 类中。  
            //Series _lineSeries_Si = new Series("Si", ViewType.Bar);
            for (int i = 0; i < str_ArrChoiced.Length; i++)
            {
                switch (str_ArrChoiced[i])
                {
                    case "理论产量":
                        Series s1 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        s1.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        s1.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        s1.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        s1.LegendText = "理论产量";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(s1);                    
                        break;
                    case "第一罐产量":
                        Series s2 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        s2.DataSource = GetClassCount(str_ArrChoiced[i]);  
                        s2.ArgumentDataMember = "llcl";  
                        s2.ValueDataMembers[0] = "count";   
                        s2.LegendText = "第一罐产量";  
                        chartControl1.Series.Add(s2);
                        break;
                    case "第二罐产量":
                        Series s3 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        s3.DataSource = GetClassCount(str_ArrChoiced[i]);  
                        s3.ArgumentDataMember = "llcl"; 
                        s3.ValueDataMembers[0] = "count";
                        s3.LegendText = "第二罐产量";
                        chartControl1.Series.Add(s3);
                        break;
                    case "Si_1":
                        Series Si_ = new Series(str_ArrChoiced[i], ViewType.Bar);
                        Si_.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        Si_.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        Si_.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        Si_.LegendText = "Si_1";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(Si_);
                        break;
                    case "S_1":
                        Series S_1 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        S_1.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        S_1.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        S_1.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        S_1.LegendText = "S_1";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(S_1);
                        break;
                    case "Mn_1":
                        Series Mn_1 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        Mn_1.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        Mn_1.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        Mn_1.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        Mn_1.LegendText = "Mn_1";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(Mn_1);
                        break;
                    case "P_1":
                        Series P_1 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        P_1.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        P_1.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        P_1.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        P_1.LegendText = "P_1";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(P_1);
                        break;
                    case "Ti_1":
                        Series Ti_1 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        Ti_1.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        Ti_1.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        Ti_1.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        Ti_1.LegendText = "Ti_1";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(Ti_1);
                        break;
                    case "Si_2":
                        Series Si_2 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        Si_2.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        Si_2.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        Si_2.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        Si_2.LegendText = "Si_2";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(Si_2);
                        break;
                    case "S_2":
                        Series S_2 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        S_2.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        S_2.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        S_2.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        S_2.LegendText = "S_2";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(S_2);
                        break;
                    case "Ti_2":
                        Series Ti_2 = new Series(str_ArrChoiced[i], ViewType.Bar);
                        Ti_2.DataSource = GetClassCount(str_ArrChoiced[i]);//设置实例对象s1的数据源  
                        Ti_2.ArgumentDataMember = "llcl";//绑定图表的横坐标  
                        Ti_2.ValueDataMembers[0] = "count"; //绑定图表的纵坐标坐标  
                        Ti_2.LegendText = "Ti_2";//设置图例文字 就是右上方的小框框  
                        chartControl1.Series.Add(Ti_2);
                        break;
                    default:
                        break;
                }
            }          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> temp = new List<string>();
            //得到复选框的值，存储到temp的list中
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    temp.Add(checkedListBox1.GetItemText(checkedListBox1.Items[i]));
                }
            }
            //转化为数组
            string[] str_checkListBox = temp.ToArray();
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();        
            /*
             _lineSeries_Si.ArgumentScaleType = ScaleType.DateTime;
             _lineSeries_S.ArgumentScaleType = ScaleType.DateTime;
             _lineSeries_Mn.ArgumentScaleType = ScaleType.DateTime;
             _lineSeries_P.ArgumentScaleType = ScaleType.DateTime;
             _lineSeries_Ti.ArgumentScaleType = ScaleType.DateTime;

             XYDiagram diagram = this.chartControl1.Diagram as XYDiagram;
             diagram.AxisY.VisualRange.MaxValue = 2.5;
             diagram.AxisY.VisualRange.MinValue = 0.0;
             diagram.EnableAxisXScrolling = true;
             diagram.EnableAxisYScrolling = true;
             //开启滚动条必须设置未false                   
             //diagram.EnableScrolling = true;//启用滚动条
             sqlCnt1.Close();*/
            LoadAll(str_checkListBox);
        }

        private void some_elem_or_range_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }
        private void Fengzhuang(string str, LinkLabel LinkLabel_start, LinkLabel LinkLabel2_end)
        {
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            SqlConnection sqlCnt2 = new SqlConnection(strConn);
            sqlCnt1.Open();
            sqlCnt2.Open();
            string sql = string.Format(@"select max({0}) from Project_Iron where 
outIronTime >= '{1}' and outIronTime < '{2}'", str, dateEdit1.DateTime, dateEdit2.DateTime);
            string sql_1 = string.Format(@"select min({0}) from Project_Iron where 
outIronTime >= '{1}' and outIronTime < '{2}'", str, dateEdit1.DateTime, dateEdit2.DateTime);

            SqlCommand sqlCmd1 = new SqlCommand(sql_1, sqlCnt1);
            SqlCommand sqlCmd2 = new SqlCommand(sql, sqlCnt2);

            SqlDataReader reader = sqlCmd1.ExecuteReader();
            SqlDataReader reader2 = sqlCmd2.ExecuteReader();
            while (reader.Read() && reader2.Read())
            {
                LinkLabel_start.Text = reader[0].ToString();
                LinkLabel2_end.Text = reader2[0].ToString();
                break;
            }
            sqlCnt1.Close();
            sqlCnt2.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int i = 0;
            string sttt = checkedListBox1.SelectedItem.ToString();
            Key_Value kv = new Key_Value();
            switch (sttt)
            {
                case "理论产量":
                    i = 0;
                    break;
                case "第一罐产量":
                    i = 1;
                    break;
                case "第二罐产量":
                    i = 2;
                    break;
                case "Si_1":
                    i = 3;
                    break;
                case "S_1":
                    i = 4;
                    break;
                case "Mn_1":
                    i = 5;
                    break;
                case "P_1":
                    i = 6;
                    break;
                case "Ti_1":
                    i = 7;
                    break;
                case "Si_2":
                    i = 8;
                    break;
                case "S_2":
                    i = 9;
                    break;
                case "Ti_2":
                    i = 10;
                    break;
                default:
                    break;
            }
            string str = null;
            // str = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
            kv.MyDictionary.TryGetValue(sttt, out str);       //1 style                                                 
                                                              //str = kv.MyDictionary[str];   2 style   
            switch (i)
            {
                case 0:
                    Fengzhuang(str, linkLabel1, linkLabel2);
                    break;
                case 1:
                    Fengzhuang(str, linkLabel3, linkLabel4);
                    break;
                case 2:
                    Fengzhuang(str, linkLabel5, linkLabel6);
                    break;
                case 3:
                    Fengzhuang(str, linkLabel7, linkLabel8);
                    break;
                case 4:
                    Fengzhuang(str, linkLabel9, linkLabel10);
                    break;
                case 5:
                    Fengzhuang(str, linkLabel11, linkLabel12);
                    break;
                case 6:
                    Fengzhuang(str, linkLabel13, linkLabel14);
                    break;
                case 7:
                    Fengzhuang(str, linkLabel15, linkLabel16);
                    break;
                case 8:
                    Fengzhuang(str, linkLabel17, linkLabel18);
                    break;
                case 9:
                    Fengzhuang(str, linkLabel19, linkLabel20);
                    break;
                case 10:
                    Fengzhuang(str, linkLabel21, linkLabel22);
                    break;
                default:
                    break;
            }
        }
        private void fenzhuang_GetClassC(ref DataTable dt, Key_Value kv ,
            string strConn,string str_choiced,float buchang_llcl,string text_box)
        {
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            SqlConnection sqlCnt2 = new SqlConnection(strConn);
            sqlCnt1.Open();
            sqlCnt2.Open();
            dt.Columns.Add("llcl", typeof(string));//产量  
            dt.Columns.Add("count", typeof(double));   //产量范围的个数 
            string sql = string.Format(@"select max({0}) from Project_Iron", kv.MyDictionary[str_choiced]);
            string sql_1 = string.Format(@"select min({0}) from Project_Iron", kv.MyDictionary[str_choiced]);

            SqlCommand sqlCmd1 = new SqlCommand(sql_1, sqlCnt1);
            SqlCommand sqlCmd2 = new SqlCommand(sql, sqlCnt2);

            SqlDataReader reader = sqlCmd1.ExecuteReader();
            SqlDataReader reader2 = sqlCmd2.ExecuteReader();
            //
            float min = 0F;
            float max = 0F;
            int count = 0;  //统计出来的个数
            while (reader.Read() && reader2.Read())
            {
                float.TryParse(reader[0].ToString(), out min);
                float.TryParse(reader2[0].ToString(), out max);
                break;
            }
            sqlCnt1.Close();
            sqlCnt2.Close();
            //默认的步长
            //float buchang_llcl = 15F;
            if (text_box == string.Empty)    //默认为固定的步长
            {
                for (float j = min; j <= max; j += buchang_llcl)
                {
                    //计算个数的sql语句
                    SqlConnection sqlCnt3 = new SqlConnection(strConn);
                    sqlCnt3.Open();
                    string sql_ = string.Format(@"select count({0}) from Project_Iron where 
{1} >={2} and {3} <{4}", kv.MyDictionary[str_choiced], kv.MyDictionary[str_choiced], j, kv.MyDictionary[str_choiced],
j + buchang_llcl);
                    SqlCommand sqlCmd3 = new SqlCommand(sql_, sqlCnt3);
                    SqlDataReader reader3 = sqlCmd3.ExecuteReader();
                    if (reader3.Read())
                    {
                        int.TryParse(reader3[0].ToString(), out count);
                        dt.Rows.Add(j.ToString() + "-" + (j + buchang_llcl).ToString(), count);
                    }
                    sqlCnt3.Close();
                }
            }
            else
            {
                float temp = 0;
                float.TryParse(text_box, out temp);   //temp为输入的步长
                for (float j = min; j <= max; j += temp)
                {
                    //计算个数的sql语句
                    SqlConnection sqlCnt3 = new SqlConnection(strConn);
                    sqlCnt3.Open();
                    string sql_ = string.Format(@"select count({0}) from Project_Iron where 
{1} >={2} and {3} <{4}", kv.MyDictionary[str_choiced], kv.MyDictionary[str_choiced], j, kv.MyDictionary[str_choiced],
j + temp);
                    SqlCommand sqlCmd3 = new SqlCommand(sql_, sqlCnt3);
                    SqlDataReader reader3 = sqlCmd3.ExecuteReader();
                    if (reader3.Read())
                    {
                        int.TryParse(reader3[0].ToString(), out count);
                        dt.Rows.Add(j.ToString() + "-" + (j + temp).ToString(), count);
                    }
                    sqlCnt3.Close();
                }
            }
        }
        public  DataTable GetClassCount(string str_choiced)
        {
            DataTable dt = new DataTable();           
            Key_Value kv = new Key_Value();

            if (str_choiced == "理论产量")
            {
                float buchang_llcl = 15F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl,textBox1.Text.Trim());
            }
            if(str_choiced == "第一罐产量")
            {
                //默认的步长
                float buchang_llcl = 15F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox2.Text.Trim());
            }
            if(str_choiced == "第二罐产量")
            {
                float buchang_llcl = 15F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox3.Text.Trim());
            }
            if(str_choiced == "Si_1")
            {
                float buchang_llcl = 0.3F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox4.Text.Trim());
            }        
            if(str_choiced == "S_1")
            {
                float buchang_llcl = 0.008F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox5.Text.Trim());
            }
            if(str_choiced == "Mn_1")
            {
                float buchang_llcl = 0.15F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox6.Text.Trim());
            }
            if (str_choiced == "P_1")
            {
                float buchang_llcl = 0.05F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox7.Text.Trim());
            }
            if (str_choiced == "Ti_1")
            {
                float buchang_llcl = 0.003F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox8.Text.Trim());
            }
            if (str_choiced == "Si_2")
            {
                float buchang_llcl = 0.07F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox9.Text.Trim());
            }
            if (str_choiced == "S_2")
            {
                float buchang_llcl = 3F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox10.Text.Trim());
            }
            if (str_choiced == "Ti_2")
            {
                float buchang_llcl = 3F;
                fenzhuang_GetClassC(ref dt, kv, strConn, str_choiced, buchang_llcl, textBox11.Text.Trim());
            }
            return dt;
        }
    }
}
