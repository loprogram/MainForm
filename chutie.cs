using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ShiTiLei;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{ 
    public partial class chutie : Form
    {
        //private string strConn = "server=localhost;database=pro;integrated security=SSPI";
        public chutie()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        public DataGridView chutie_retu()
        {
            return dataGridView1;
        }
        private chu_tie_qingkuang c_t_qk;

        internal chu_tie_qingkuang C_t_qk
        {
            get
            {
                return c_t_qk;
            }

            set
            {
                c_t_qk = value;
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
          //  Mysql_excute sql_conn = new Mysql_excute();
            //chu_tie_qingkuang c_t_qk = new chu_tie_qingkuang();

           // sql_conn.getmysqlcon();
            int count_row = dataGridView1.RowCount;     //代表当前总计有效行数,多余一行空白行

           /* SqlConnection sqlCont = new SqlConnection(strConn);
            sqlCont.Open();*/

            int Int_=-1;
            Double Double_;
            string str_;
            DateTime Dt;
           // c_t_qk.outIronTime_ = DateTime.MinValue;
           for(int i=0;i<count_row -1;++i)
            {
                if (dataGridView1.Rows[i].Cells[0].Value != null)   //0
                {
                   int.TryParse(dataGridView1.Rows[i].
                        Cells[0].Value.ToString(),out Int_);
                 
                    c_t_qk.HeatNum1 = Int_;
                }
                if (dataGridView1.Rows[i].Cells[1].EditedFormattedValue != null)
                {
                    string str = dataGridView1.Rows[i].
                         Cells[1].EditedFormattedValue.ToString();
                    DateTime.TryParse(dataGridView1.Rows[i].
                         Cells[1].EditedFormattedValue.ToString(), out Dt);
                    DateTime.TryParse(Dt.ToString("yyyy/MM/dd HH:mm:ss"), out Dt);

                  /*  string sql11 = string.Format
                        (@"select HeatNum from chutie_qingkuang where HeatNum = '{0}' and outIronTime = '{1}' ", Int_,Dt);
                    MySqlDataReader MDR = sql_conn.getmysqlread(sql11);
                    // MDR.GetValues();
                    if (MDR.HasRows)
                    {
                        MessageBox.Show("炉号为" + string.Format("{0}", Int_)+"日期为"+string.Format("{0}",Dt) + "的数据重复插入！", "提示");
                        continue;
                    }*/
                    c_t_qk.outIronTime_ = Dt;
                }
                if (dataGridView1.Rows[i].Cells[2].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[2].Value.ToString(), out Int_);
                    c_t_qk.meterialBatch_ = Int_;
                }
                if (dataGridView1.Rows[i].Cells[3].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[3].Value.ToString(), out Int_);
                    c_t_qk.theoryYield_ = Int_;
                }
                if (dataGridView1.Rows[i].Cells[4].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[4].Value.ToString(), out Double_);
                    c_t_qk.yield_1_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[5].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[5].Value.ToString(), out Double_);
                    c_t_qk.yield_2_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[6].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[6].Value.ToString(), out Int_);
                    c_t_qk.difference_ = Int_;
                }
                if (dataGridView1.Rows[i].Cells[7].Value != null)
                {
                    c_t_qk.type_1_ = dataGridView1.Rows[i].Cells[7].Value.ToString();
         
                }
                if (dataGridView1.Rows[i].Cells[8].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[8].Value.ToString(), out Double_);
                    c_t_qk.type_1_Si_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[9].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[9].Value.ToString(), out Double_);
                    c_t_qk.type_1_S_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[10].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[10].Value.ToString(), out Double_);
                    c_t_qk.type_1_Mn_ = Double_;

                }
                if (dataGridView1.Rows[i].Cells[11].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[11].Value.ToString(), out Double_);
                    c_t_qk.type_1_P_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[12].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[12].Value.ToString(), out Double_);
                    c_t_qk.type_1_Ti_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[13].Value != null)
                {
                    c_t_qk.type_2_ = dataGridView1.Rows[i].Cells[13].Value.ToString();
                }
                if (dataGridView1.Rows[i].Cells[14].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[14].Value.ToString(), out Double_);
                    c_t_qk.type_2_Si_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[15].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[15].Value.ToString(), out Double_);
                    c_t_qk.type_2_S_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[16].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[16].Value.ToString(), out Double_);
                    c_t_qk.type_2_Ti_ = Double_;
                }
                if (dataGridView1.Rows[i].Cells[17].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[17].Value.ToString(), out Int_);
                    c_t_qk.ironDeep_ = Int_;
                }
                if (dataGridView1.Rows[i].Cells[18].Value != null)
                {
                    str_=dataGridView1.Rows[i].
                         Cells[18].Value.ToString();
                    c_t_qk.ZhaYang = str_;
                }

                //扩展的
                //sql语句
               /* string sql_123 = string.Format(@"select HeatNum,outIronTime from Project_Iron where HeatNum ='{0}'", c_t_qk.HeatNum1);
                SqlCommand sqlCmd = new SqlCommand(sql_123, sqlCont);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if(reader.Read())   //查询到值得话，进行更行
                {
                    DateTime dd;
                    DateTime.TryParse(reader[1].ToString(), out dd);
                    string sql_update = string.Format(@"UPDATE Project_Iron SET HeatNum='{0}',outIronTime = '{1}',meterialBatch='{2}',theoryYield='{3}',
yield_1='{4}' ,yield_2='{5}',difference='{6}',type_1='{7}',type_1_Si='{8}',type_1_S='{9}',type_1_Mn='{10}',type_1_P='{11}',type_1_Ti='{12}',
type_2='{13}',type_2_Si='{14}',type_2_S='{15}',type_2_Ti='{16}',ironDeep='{17}',zhaYang='{18}',FlagChuTie='{19}' where 
outIronTime='{20}' and HeatNum='{21}'",c_t_qk.HeatNum1, c_t_qk.outIronTime_, c_t_qk.meterialBatch_, c_t_qk.theoryYield_, 
                    c_t_qk.yield_1_,c_t_qk.yield_2_, c_t_qk.difference_, c_t_qk.type_1_, 
                    c_t_qk.type_1_Si_, c_t_qk.type_1_S_,c_t_qk.type_1_Mn_,c_t_qk.type_1_P_,
                    c_t_qk.type_1_Ti_,
                    c_t_qk.type_2_, c_t_qk.type_2_Si_, c_t_qk.type_2_S_, c_t_qk.type_2_Ti_,
                    c_t_qk.ironDeep_,c_t_qk.ZhaYang,1,dd,c_t_qk.HeatNum1);

                    SqlConnection sqlCnt1 = new SqlConnection(strConn);
                    sqlCnt1.Open();
                    SqlCommand sqlCmd1 = new SqlCommand(sql_update, sqlCnt1);

                    if (sqlCmd1.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("插入成功！");
                    }
                    sqlCnt1.Close();
                }
                else//插入
                {
                    string sql = string.Format(@"insert into 
                Project_Iron(HeatNum,outIronTime,meterialBatch,theoryYield,
yield_1 ,yield_2,difference,type_1,type_1_Si,type_1_S,type_1_Mn,type_1_P,type_1_Ti,
type_2,type_2_Si,type_2_S,type_2_Ti,ironDeep,zhaYang,FlagChuTie)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}',{19})", 
c_t_qk.HeatNum1,c_t_qk.outIronTime_, c_t_qk.meterialBatch_, c_t_qk.theoryYield_,
                  c_t_qk.yield_1_, c_t_qk.yield_2_, c_t_qk.difference_, c_t_qk.type_1_,
                  c_t_qk.type_1_Si_, c_t_qk.type_1_S_, c_t_qk.type_1_Mn_, c_t_qk.type_1_P_,
                  c_t_qk.type_1_Ti_,
                  c_t_qk.type_2_, c_t_qk.type_2_Si_, c_t_qk.type_2_S_, c_t_qk.type_2_Ti_,
                  c_t_qk.ironDeep_, c_t_qk.ZhaYang, 1);
                    SqlConnection sqlCnt2 = new SqlConnection(strConn);
                    sqlCnt2.Open();
                    SqlCommand sqlCmd_Insert = new SqlCommand(sql, sqlCnt2);
                    if (sqlCmd_Insert.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("插入成功！");
                    }
                    sqlCnt2.Close();
                }
                reader.Close();
                sqlCont.Close();  */
            }
            dataGridView1.Rows.Clear();
            this.Close();
            //sqlConnection.Close();
        }
    }
}
