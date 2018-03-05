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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class GaoLu : Form
    {
       
        public GaoLu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
        public DataGridView retu_()
        {
            return dataGridView1;
        }
        //插入高炉数据
        private GaoLuCaoZuo g_l_c_z;

        internal GaoLuCaoZuo G_l_c_z
        {
            get
            {
                return g_l_c_z;
            }

            set
            {
                g_l_c_z = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Mysql_excute sql_conn = new Mysql_excute();
        

            // sql_conn.getmysqlcon();
            int count_row = dataGridView1.RowCount;     //代表当前总计有效行数,多余一行空白行     
            int Int_ = -1;
            Double Double_;
            string str = null;
            DateTime Dt;
            DateTime.TryParse("2001/01/01", out Dt);
            G_l_c_z.GaoLuOperationTime1 =Dt;
            for (int i = 0; i < count_row - 1; ++i)
            {
                //放在这里，以防多条输入，无法关闭数据库对象
                /*string strConn = "server=localhost;database=pro;integrated security=SSPI";
                SqlConnection sqlCnt = new SqlConnection(strConn);
                sqlCnt.Open();*/
                if (dataGridView1.Rows[i].Cells[0].Value != null)   //0
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[0].Value.ToString(), out Int_);

                    G_l_c_z.HeatNum_gl = Int_;
                }
              /*  if (dataGridView1.Rows[i].Cells[1].Value != null)   //0
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[1].Value.ToString(), out Int_);

                    g_l_c_z.VirtualHeatNum1 = Int_;
                }*/
                if (dataGridView1.Rows[i].Cells[1].EditedFormattedValue != null)
                {
                    DateTime.TryParse(dataGridView1.Rows[i].
                         Cells[1].EditedFormattedValue.ToString(), out Dt);

                 /*   string sql11 = string.Format
                        (@"select heatNum from gaolu_caozuo_qingkuang where heatNum = '{0}' and operationTime = '{1}' ", Int_, Dt);
                    MySqlDataReader MDR = sql_conn.getmysqlread(sql11);
                    // MDR.GetValues();
                    if (MDR.HasRows)
                    {
                        MessageBox.Show("炉号为" + string.Format("{0}", Int_) + "日期为" + string.Format("{0}", Dt) + "的数据重复插入！", "提示");
                        continue;

                    }*/
                    G_l_c_z.GaoLuOperationTime1 = Dt;
                }
                if (dataGridView1.Rows[i].Cells[2].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[2].Value.ToString(), out Int_);
                    G_l_c_z.WaistEastTemp = Int_;
                }
                if (dataGridView1.Rows[i].Cells[3].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[3].Value.ToString(), out Int_);
                    G_l_c_z.WaitSouthTemp = Int_;
                }
                if (dataGridView1.Rows[i].Cells[4].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[4].Value.ToString(), out Int_);
                    G_l_c_z.WaistWestTemp = Int_;
                }
                if (dataGridView1.Rows[i].Cells[5].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[5].Value.ToString(), out Int_);
                    G_l_c_z.WaistNorthTemp = Int_;
                }
                if (dataGridView1.Rows[i].Cells[6].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[6].Value.ToString(), out Int_);
                    G_l_c_z.HearthEastTemp1 = Int_;
                }
                if (dataGridView1.Rows[i].Cells[7].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                                            Cells[7].Value.ToString(), out Int_);
                    G_l_c_z.HearthSouthTemp1 = Int_;
                }
                if (dataGridView1.Rows[i].Cells[8].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[8].Value.ToString(), out Int_);
                    G_l_c_z.HearthWestTemp1 = Int_;
                }
                if (dataGridView1.Rows[i].Cells[9].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[9].Value.ToString(), out Int_);
                    G_l_c_z.HearthNorthTemp1 = Int_;
                }
                if (dataGridView1.Rows[i].Cells[10].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[10].Value.ToString(), out Double_);
                    G_l_c_z.BatchNum = Double_;

                }
                if (dataGridView1.Rows[i].Cells[11].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[11].Value.ToString(), out Int_);
                    G_l_c_z.AirtightTemp = Int_;
                }
                if (dataGridView1.Rows[i].Cells[12].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[12].Value.ToString(), out Int_);
                    G_l_c_z.FuelRatio = Int_;
                }
                if (dataGridView1.Rows[i].Cells[13].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[13].Value.ToString(), out Int_);
                    G_l_c_z.WindVolume = Int_;
                }
                if (dataGridView1.Rows[i].Cells[14].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[14].Value.ToString(), out Int_);
                    G_l_c_z.HotWindpress = Int_;
                }
                if (dataGridView1.Rows[i].Cells[15].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[15].Value.ToString(), out Int_);
                    G_l_c_z.ColdWindpress = Int_;
                }
                if (dataGridView1.Rows[i].Cells[16].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[16].Value.ToString(), out Int_);
                    G_l_c_z.WindTemp = Int_;
                }
                if (dataGridView1.Rows[i].Cells[17].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[17].Value.ToString(), out Int_);
                    G_l_c_z.ToptempSoutheast = Int_;
                }
                if (dataGridView1.Rows[i].Cells[18].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[18].Value.ToString(), out Int_);
                    G_l_c_z.ToptempSouthwest = Int_;
                }
                if (dataGridView1.Rows[i].Cells[19].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[19].Value.ToString(), out Int_);
                    G_l_c_z.ToptempNorthwest = Int_;
                }
                if (dataGridView1.Rows[i].Cells[20].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[20].Value.ToString(), out Int_);
                    G_l_c_z.ToptempNortheast = Int_;
                }
                if (dataGridView1.Rows[i].Cells[21].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[21].Value.ToString(), out Int_);
                    G_l_c_z.TopPress = Int_;
                }
                if (dataGridView1.Rows[i].Cells[22].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[22].Value.ToString(), out Int_);
                    G_l_c_z.BreathIndex = Int_;

                }
                if (dataGridView1.Rows[i].Cells[23].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[23].Value.ToString(), out Int_);
                    G_l_c_z.OVolume1 = Int_;
                }
                if (dataGridView1.Rows[i].Cells[24].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[24].Value.ToString(), out Double_);
                    G_l_c_z.RequiresCoal = Double_;
                }
                if (dataGridView1.Rows[i].Cells[25].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[25].Value.ToString(), out Double_);
                    G_l_c_z.ActualCoal = Double_;
                }
                if (dataGridView1.Rows[i].Cells[26].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[26].Value.ToString(), out Double_);
                    G_l_c_z.Load = Double_;
                }
                if (dataGridView1.Rows[i].Cells[27].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[27].Value.ToString(), out Double_);
                    G_l_c_z.Vj1 = Double_;
                }
                if (dataGridView1.Rows[i].Cells[28].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[28].Value.ToString(), out Double_);
                    G_l_c_z.Vk1 = Double_;
                }
                if (dataGridView1.Rows[i].Cells[29].Value != null)
                {
                    int.TryParse(dataGridView1.Rows[i].
                         Cells[29].Value.ToString(), out Int_);
                    G_l_c_z.CoalRatio = Int_;
                }
                if (dataGridView1.Rows[i].Cells[30].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[30].Value.ToString(), out Double_);
                    G_l_c_z.COutilization1 = Double_;
                }
                if (dataGridView1.Rows[i].Cells[31].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[31].Value.ToString(), out Double_);
                    G_l_c_z.BlastIndex = Double_;

                }
                if (dataGridView1.Rows[i].Cells[32].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[32].Value.ToString(), out Double_);
                    G_l_c_z.BlastCokeRatio = Double_;

                }
                ///////////////////////****
               if (dataGridView1.Rows[i].Cells[33].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[33].Value.ToString(), out Double_);
                    G_l_c_z.BlastCoalRatio = Double_;
                }
                if (dataGridView1.Rows[i].Cells[34].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[34].Value.ToString(), out Double_);
                    G_l_c_z.BlastMineRatio = Double_;
                }
                if (dataGridView1.Rows[i].Cells[35].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[35].Value.ToString(), out Double_);
                    G_l_c_z.CombustionRatio = Double_;
                }
                if (dataGridView1.Rows[i].Cells[36].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].
                         Cells[36].Value.ToString(), out Double_);
                    G_l_c_z.JiaoDing1 = Double_;
                }

                //
                if (dataGridView1.Rows[i].Cells[37].Value != null)
                {
                    str=dataGridView1.Rows[i].
                           Cells[37].Value.ToString();
                    G_l_c_z.Banzu = str;
                }
                if (dataGridView1.Rows[i].Cells[38].Value != null)
                {
                    str = dataGridView1.Rows[i].
                        Cells[38].Value.ToString();
                    G_l_c_z.Zhibanren = str;
                }
                if (dataGridView1.Rows[i].Cells[39].Value != null)
                {
                    str = dataGridView1.Rows[i].
                        Cells[39].Value.ToString();
                    G_l_c_z.Jiluren = str;
                }
                if (dataGridView1.Rows[i].Cells[40].Value != null)
                {
                    str = dataGridView1.Rows[i].
                          Cells[40].Value.ToString();
                    G_l_c_z.Beizhu = str;
                }

                
                /*DateTime low_ct_datime;
                DateTime hgih_ct_datime;
                DateTime low_yl_datime;
                DateTime high_yl_datime;
                low_ct_datime = G_l_c_z.GaoLuOperationTime1.AddHours(-4.5);      
                hgih_ct_datime = G_l_c_z.GaoLuOperationTime1.AddHours(-3.5) ;

                low_yl_datime = G_l_c_z.GaoLuOperationTime1.AddHours(-2.5);
                high_yl_datime = G_l_c_z.GaoLuOperationTime1.AddHours(-1.5);

                //设计时间范围，来确定数据是否更新 GaoLuOperationTime（有主键)
                string sql_123 = string.Format(@"select HeatNum ,outIronTime,YuanLiaoTime,
VirtualHeatNum from Project_Iron where HeatNum = '{0}' and 
 ((outIronTime>='{1}' and  outIronTime<'{2}') or (YuanLiaoTime >='{3}'and YuanLiaoTime <'{4}') )",
                    G_l_c_z.HeatNum_gl, low_ct_datime, hgih_ct_datime, low_yl_datime, high_yl_datime);

                SqlCommand sqlCmd = new SqlCommand(sql_123, sqlCnt);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                DateTime temp =DateTime.Now;
                if (reader.Read())
                {
                    //选择不空的值，作为参考指标进行更新    
                    string str_temp = null;
                    if(reader[1] != null)
                    {                 
                        DateTime.TryParse(reader[1].ToString(), out temp);
                        str_temp = reader[1].ToString();
                    }
                    else if(reader[2] !=null)
                    {
                        DateTime.TryParse(reader[2].ToString(), out temp);
                        str_temp = reader[2].ToString();
                    }
                    else if(reader[3] != null)
                    {
                        DateTime.TryParse(reader[3].ToString(), out temp);
                        str_temp = reader[3].ToString();
                    }
                    if(reader[0].ToString() != null)        //主键的不为空，那就更新高炉的数据  if有点多余
                    {
                        string sql_temp1 = string.Format(@"UPDATE Project_Iron SET GaoLuOperationTime ='{0}',waistEastTemp = '{1}', waistSouthTemp ='{2}',
waistWestTemp ='{3}',waistNorthTemp ='{4}',HearthEastTemp ='{5}',HearthSouthTemp='{6}',HearthWestTemp ='{7}',HearthNorthTemp = '{8}',batchNum ='{9}',
airtightTemp ='{10}',fuelRatio='{11}',windVolume ='{12}',hotWindpress ='{13}',coldWindpress ='{14}',windTemp ='{15}',toptempSoutheast='{16}',
toptempSouthwest ='{17}',toptempNorthwest ='{18}',toptempNortheast='{19}',topPress='{20}',breathIndex='{21}',OVolume='{22}',requiresCoal='{23}',
actualCoal='{24}',load='{25}',Vj='{26}' ,Vk='{27}',coalRatio='{28}',COutilization='{29}',blastIndex='{30}',blastCokeRatio='{31}',blastCoalRatio='{32}',
blastMineRatio='{33}',combustionRatio='{34}',JiaoDing='{35}',banZu='{36}',zhibanren='{37}',jiluren='{38}',beizhu ='{39}',FlagGaoLu='{40}',
WHERE HeatNum = '{42}' and '{43}' = '{44}'",
  G_l_c_z.GaoLuOperationTime1,
        G_l_c_z.WaistEastTemp,
        G_l_c_z.WaitSouthTemp,
        G_l_c_z.WaistWestTemp,
        G_l_c_z.WaistNorthTemp,
        G_l_c_z.HearthEastTemp1,
        G_l_c_z.HearthSouthTemp1,
        G_l_c_z.HearthWestTemp1,
        G_l_c_z.HearthNorthTemp1,
        G_l_c_z.BatchNum,
        G_l_c_z.AirtightTemp,
        G_l_c_z.FuelRatio,
        G_l_c_z.WindVolume,
        G_l_c_z.HotWindpress,
        G_l_c_z.ColdWindpress,
        G_l_c_z.WindTemp,
        G_l_c_z.ToptempSoutheast,
        G_l_c_z.ToptempSouthwest,
        G_l_c_z.ToptempNorthwest,
        G_l_c_z.ToptempNortheast,
        G_l_c_z.TopPress,
        G_l_c_z.BreathIndex,
        G_l_c_z.OVolume1,
        G_l_c_z.RequiresCoal,
        G_l_c_z.ActualCoal,
        G_l_c_z.Load,
        G_l_c_z.Vj1,
        G_l_c_z.Vk1,
        G_l_c_z.CoalRatio,
        G_l_c_z.COutilization1,
        G_l_c_z.BlastIndex,
        G_l_c_z.BlastCokeRatio,
        G_l_c_z.BlastCoalRatio,
        G_l_c_z.BlastMineRatio,
        G_l_c_z.CombustionRatio,
        G_l_c_z.JiaoDing1,
        G_l_c_z.Banzu,
        G_l_c_z.Zhibanren,
        G_l_c_z.Jiluren,
        G_l_c_z.Beizhu,
        1,
        G_l_c_z.HeatNum_gl,
        str_temp,
        temp);
                        SqlConnection sqlCnt1 = new SqlConnection(strConn);
                        sqlCnt1.Open();
                        SqlCommand sqlCmd1 = new SqlCommand(sql_temp1,sqlCnt1);
                      
                        if (sqlCmd1.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("插入成功！");
                        }
                        sqlCnt1.Close();
                    }
                    //只匹配到一条数
                    reader.Close();
                    sqlCnt.Close();
                }
                else//主键为空
                {
                    string sql_temp = string.Format(@"insert into Project_Iron (GaoLuOperationTime ,waistEastTemp , waistSouthTemp,
waistWestTemp,waistNorthTemp ,HearthEastTemp,HearthSouthTemp,HearthWestTemp ,HearthNorthTemp,batchNum ,
airtightTemp ,fuelRatio,windVolume ,hotWindpress ,coldWindpress ,windTemp ,toptempSoutheast,
toptempSouthwest,toptempNorthwest,toptempNortheast,topPress,breathIndex,OVolume,requiresCoal,
actualCoal,load,Vj ,Vk,coalRatio,COutilization,blastIndex,blastCokeRatio,blastCoalRatio,
blastMineRatio,combustionRatio,JiaoDing,banZu,zhibanren,jiluren,beizhu ,FlagGaoLu,HeatNum)
values('{0}', '{1}' ,'{2}' ,'{3}','{4}' ,'{5}','{6}','{7}' ,'{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',
'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}',
'{35}','{36}','{37}','{38}','{39}','{40}','{41}')",
G_l_c_z.GaoLuOperationTime1,
    G_l_c_z.WaistEastTemp,
    G_l_c_z.WaitSouthTemp,
    G_l_c_z.WaistWestTemp,
    G_l_c_z.WaistNorthTemp,
    G_l_c_z.HearthEastTemp1,
    G_l_c_z.HearthSouthTemp1,
    G_l_c_z.HearthWestTemp1,
    G_l_c_z.HearthNorthTemp1,
    G_l_c_z.BatchNum,
    G_l_c_z.AirtightTemp,
    G_l_c_z.FuelRatio,
    G_l_c_z.WindVolume,
    G_l_c_z.HotWindpress,
    G_l_c_z.ColdWindpress,
    G_l_c_z.WindTemp,
    G_l_c_z.ToptempSoutheast,
    G_l_c_z.ToptempSouthwest,
    G_l_c_z.ToptempNorthwest,
    G_l_c_z.ToptempNortheast,
    G_l_c_z.TopPress,
    G_l_c_z.BreathIndex,
    G_l_c_z.OVolume1,
    G_l_c_z.RequiresCoal,
    G_l_c_z.ActualCoal,
    G_l_c_z.Load,
    G_l_c_z.Vj1,
    G_l_c_z.Vk1,
    G_l_c_z.CoalRatio,
    G_l_c_z.COutilization1,
    G_l_c_z.BlastIndex,
    G_l_c_z.BlastCokeRatio,
    G_l_c_z.BlastCoalRatio,
    G_l_c_z.BlastMineRatio,
    G_l_c_z.CombustionRatio,
    G_l_c_z.JiaoDing1,
    G_l_c_z.Banzu,
    G_l_c_z.Zhibanren,
    G_l_c_z.Jiluren,
    G_l_c_z.Beizhu,
    1,
    G_l_c_z.HeatNum_gl
    );
                    /*SqlConnection sqlCnt2 = new SqlConnection(strConn);
                    sqlCnt2.Open();
                    SqlCommand sqlCmd2 = new SqlCommand(sql_temp, sqlCnt2);
                              
                    if (sqlCmd2.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("插入成功！");
                    }
                    sqlCnt2.Close();
                }*/
            }
         
            dataGridView1.Rows.Clear();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
