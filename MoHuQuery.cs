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
using WindowsFormsApplication1.ShiTiLei;
using WindowsFormsApplication1.K_value;

namespace WindowsFormsApplication1
{
    public partial class MoHuQuery : Form
    {
        private int index_of;
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";
        public MoHuQuery()
        {
            InitializeComponent();          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void child_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void search_fengzhuang(DataGridView dgw,string sql, ref SqlConnection sqlCnt1, string input_2_element)
        {
            SqlCommand sqlCmd3 = new SqlCommand(sql, sqlCnt1);
            SqlDataReader DataSet = sqlCmd3.ExecuteReader();
            int col_len = dgw.ColumnCount;       //改变
            //零时de   
            //查出出铁查询的表头
            string[] str_ = new string[col_len];
            for (int i = 0; i < col_len; ++i)
            {
                str_[i] = dgw.Columns[i].HeaderText;           //改变的
            }
           
            //设置列标题
            for (int i = 0; i < col_len; ++i)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = str_[i];
                this.listView1.Columns.Add(ch);
            }
            while (DataSet.Read())
            {
                ListViewItem lt = new ListViewItem();
                // string stt = DataSet[0].ToString() ;
                // string stt1 = DataSet[1].ToString();
                lt.Text = DataSet[0].ToString();
                lt.UseItemStyleForSubItems = false;
                for (int i = 1; i < col_len; ++i)
                {
                    lt.SubItems.Add(DataSet[i].ToString());
                }
                if(input_2_element != comboBox1.Text)
                {
                    lt.SubItems[str_.ToList().IndexOf(input_2_element)].BackColor = Color.Red;
                    lt.SubItems[str_.ToList().IndexOf(input_2_element)].ForeColor = Color.Blue;
                }
               
                listView1.Items.Add(lt);
            }
            sqlCnt1.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            string str = comboBox1.Text;
            string str_item;
           // Mysql_excute conn = new Mysql_excute();

            DateTime input_1_to;
            DateTime input_1_from;
          
            //获取输入的时间
            DateTime.TryParse(watermarkTextBox1.Text, out input_1_from);
            DateTime.TryParse(watermarkTextBox2.Text, out input_1_to);

            SqlConnection sqlCnt1 = new SqlConnection(strConn);       
            sqlCnt1.Open();     
         
            //获取原料表 表头的记录
            string [] str_yuanliao_header = {"炉号","入炉原料化学分析时间","品种","TFe","FeO","S","SiO2","CaO","MgO","Al2O3","P2O5","MnO","TiO2","R2","H2O",
            "A","V","fuel_S","C固","P","机烧粒度时间","<5","5-10","10-15","15-25", "25-40",">40"};
           
            //创建高炉操作的查询表头，动态创建
            if (str =="")
            {    
                List<string> list =  new List<string>(); 
                Key_Value kv = new Key_Value();
                int count = 0;
                foreach (var item in kv.MyDictionary)
                {
                    count++;
                    list.Add(item.Key);
                }
                string[] str123 = new string[count];
                str123 = list.ToArray();
                //设置列标题
                for (int i = 0; i < count; ++i)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = str123[i];
                    this.listView1.Columns.Add(ch);
                }
                //总表以出铁时间为基准
                //chutie ,
                string sql = string.Format(@"select HeatNum,outIronTime,meterialBatch,theoryYield,yield_1 ,yield_2,difference,type_1,type_1_Si,
type_1_S, type_1_Mn, type_1_P, type_1_Ti, type_2, type_2_Si, type_2_S, type_2_Ti, ironDeep, zhaYang ,
GaoLuOperationTime,waistEastTemp,waistSouthTemp,waistWestTemp,waistNorthTemp ,HearthEastTemp,HearthSouthTemp,
HearthWestTemp,HearthNorthTemp,batchNum ,airtightTemp ,fuelRatio,windVolume ,hotWindpress ,coldWindpress,
windTemp ,toptempSoutheast,toptempSouthwest,toptempNorthwest,toptempNortheast,topPress,breathIndex,OVolume,
requiresCoal,actualCoal,load,Vj ,Vk,coalRatio,COutilization,blastIndex,blastCokeRatio,blastCoalRatio,
blastMineRatio,combustionRatio,JiaoDing,banZu,zhibanren,jiluren,beizhu, 
YuanLiaoTime, pingZhong, TFe, FeO, S, SiO2, CaO, MgO, Al2O3, P2O5, MnO, TiO2, R2, fuel_H2O,
fuel_A, fuel_V, fuel_S, fuel_C, fuel_P, granularityTime, JSLD_Lessthan5, JSLD_5to10, JSLD_10to15,
JSLD_15to25, JSLD_25to40, JSLD_Morethan40 ,VirtualHeatNum, LuZhaTime, slag_SiO2, slag_CaO, slag_MgO, 
slag_Al2O3, slag_R2, slag_R3 from Project_Iron where outIronTime >= '{0}' 
and outIronTime <= '{1}'", input_1_from, input_1_to);

                SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
                SqlDataReader reader = sqlCmd1.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    lt.Text = reader[0].ToString();
                    for (int i = 1; i < count; ++i)
                    {
                        lt.SubItems.Add(reader[i].ToString());
                    }
                    listView1.Items.Add(lt);
                }
                sqlCnt1.Close();
            }
            else if (str == "原料记录")
            {
                //str_item = "yuanliao";
                string sql = string.Format(@"select HeatNum,YuanLiaoTime, pingZhong,TFe,FeO,S,SiO2,CaO,MgO,Al2O3,P2O5,
MnO,TiO2,R2,fuel_H2O,fuel_A,fuel_V,fuel_S,fuel_C,fuel_P,granularityTime,JSLD_Lessthan5,JSLD_5to10,JSLD_10to15,JSLD_15to25,
JSLD_25to40,JSLD_Morethan40 from Project_Iron where YuanLiaoTime >= '{0}' 
and YuanLiaoTime <= '{1}'", input_1_from, input_1_to);
              
                SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
                SqlDataReader reader = sqlCmd1.ExecuteReader();

                for (int i =0;i< str_yuanliao_header.Length; ++i)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = str_yuanliao_header[i];   //设置列标题
                    this.listView1.Columns.Add(ch);
                }
                while (reader.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    lt.Text = reader[0].ToString();
                    for(int i=1;i<str_yuanliao_header.Length; ++i)
                    {
                        lt.SubItems.Add(reader[i].ToString());
                    }
                    listView1.Items.Add(lt);
                }
                sqlCnt1.Close();
            }
            else if(str == "高炉操作记录")
            {
                str_item = "gaolu_caozuo_qingkuang";
                string sql = string.Format(@"select HeatNum,GaoLuOperationTime,waistEastTemp,waistSouthTemp,waistWestTemp,waistNorthTemp ,HearthEastTemp,HearthSouthTemp,
HearthWestTemp,HearthNorthTemp,batchNum ,airtightTemp ,fuelRatio,windVolume ,hotWindpress ,coldWindpress,
windTemp ,toptempSoutheast,toptempSouthwest,toptempNorthwest,toptempNortheast,topPress,breathIndex,OVolume,
requiresCoal,actualCoal,load,Vj ,Vk,coalRatio,COutilization,blastIndex,blastCokeRatio,blastCoalRatio,
blastMineRatio,combustionRatio,JiaoDing,banZu,zhibanren,jiluren,beizhu from Project_Iron where GaoLuOperationTime >= '{0}' 
and GaoLuOperationTime <= '{1}'", input_1_from, input_1_to);
                DataGridView lg_gaolu = new GaoLu().retu_();
                search_fengzhuang(lg_gaolu, sql,ref sqlCnt1, comboBox1.Text);
                sqlCnt1.Close();
            }
            else if(str == "出铁记录")
            {
                str_item = "chutie_qingkuang";
                string sql = string.Format(@"select HeatNum,outIronTime,meterialBatch,theoryYield,yield_1 ,yield_2,difference,type_1,type_1_Si,
type_1_S,type_1_Mn,type_1_P,type_1_Ti,type_2,type_2_Si,type_2_S,type_2_Ti,ironDeep,zhaYang from Project_Iron where outIronTime >= '{0}' 
and outIronTime <= '{1}'", input_1_from, input_1_to);
                //MySqlDataReader DataSet = conn.getmysqlread(sql);
               // SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
                //SqlDataReader reader = sqlCmd1.ExecuteReader();

                DataGridView chutie_dgw = new chutie().chutie_retu();
                search_fengzhuang(chutie_dgw,sql, ref sqlCnt1, comboBox1.Text);
                sqlCnt1.Close();
            }
            else if(str == "炉渣记录")
            {
                str_item = "luzha_huaxue_fenxi";
                //创建炉渣查询的表头t
                DataGridView str_lz = new LuZhaFenXi().luzhan_retu();       //改变的

                string sql = string.Format(@"select HeatNum,VirtualHeatNum,LuZhaTime,slag_SiO2,slag_CaO,slag_MgO,slag_Al2O3 ,slag_R2, slag_R3 from Project_Iron where outIronTime >= '{0}' 
and outIronTime <= '{1}'", input_1_from, input_1_to);
                //search_fengzhuang(str_lz, sql, ref sqlCnt1, comboBox1.Text);

                SqlCommand sqlCmd3 = new SqlCommand(sql, sqlCnt1);
                SqlDataReader DataSet = sqlCmd3.ExecuteReader();
                int col_len = str_lz.ColumnCount;       //改变
                                                     //零时de   
                                                     //查出出铁查询的表头
                string[] str_ = new string[col_len+1];
                str_[0] = "炉号";
                for (int i = 1; i < col_len+1; ++i)
                {
                    str_[i] = str_lz.Columns[i-1].HeaderText;           //改变的
                }

                //设置列标题
                for (int i = 0; i < col_len+1; ++i)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = str_[i];
                    this.listView1.Columns.Add(ch);
                }
                while (DataSet.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    // string stt = DataSet[0].ToString() ;
                    // string stt1 = DataSet[1].ToString();
                    lt.Text = DataSet[0].ToString();
                    lt.UseItemStyleForSubItems = false;
                    for (int i = 1; i < col_len; ++i)
                    {
                        lt.SubItems.Add(DataSet[i].ToString());
                    }
                    listView1.Items.Add(lt);
                }
                //sqlCnt1.Close();

                sqlCnt1.Close();
            }
            sqlCnt1.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count != 0)
            {
                ExportToExcel exp = new ExportToExcel();
                exp.ExportToExecl(this.listView1);
            }
            else
            {
                MessageBox.Show("没有可导出的数据！");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            double input_2_to;
            double input_2_from;
            string input_2_element;
           
            listView1.Clear();
            string str = comboBox1.Text;
           // Mysql_excute conn = new Mysql_excute();

            double.TryParse(watermarkTextBox3.Text, out input_2_from);
            double.TryParse(watermarkTextBox4.Text, out input_2_to);
            input_2_element =  comboBox2.Text.ToString();
           // MySqlDataReader DataSet;
            //获取原料表 表头的记录
            string[] str_yuanliao_header = {"炉号","入炉原料化学分析时间","TFe","FeO","SiO2","CaO","MgO","P2O5","MnO","TiO2","R2","A",
            "Al2O3","S","C固","P","V","入炉原料化学分析时间","机烧粒度时间","<5","5-10","10-15","15-25",
                "25-40",">40"};
            //SqlConnection sqlCnt2 = new SqlConnection(strConn);
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            SqlConnection sqlCnt2 = new SqlConnection(strConn);
            sqlCnt1.Open();
            sqlCnt2.Open();
            Key_Value kv = new Key_Value();
            string str_tt = comboBox2.Text.ToString();
            //kv.MyDictionary.ContainsKey();
            str_tt = kv.MyDictionary[str_tt];
           
            //创建高炉操作的查询表头，动态创建
            if(str =="")
            {
                List<string> list = new List<string>();
                Key_Value kv1 = new Key_Value();
                int count = 0;
                foreach (var item in kv1.MyDictionary)
                {
                    count++;
                    list.Add(item.Key);
                }
                string[] str123 = new string[count];
                str123 = list.ToArray();
                //设置列标题
                for (int i = 0; i < count; ++i)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = str123[i];
                    this.listView1.Columns.Add(ch);
                }
                //总表以出铁时间为基准
                //chutie ,
                string sql = string.Format(@"select HeatNum,outIronTime,meterialBatch,theoryYield,yield_1 ,yield_2,difference,type_1,type_1_Si,
type_1_S, type_1_Mn, type_1_P, type_1_Ti, type_2, type_2_Si, type_2_S, type_2_Ti, ironDeep, zhaYang ,
GaoLuOperationTime,waistEastTemp,waistSouthTemp,waistWestTemp,waistNorthTemp ,HearthEastTemp,HearthSouthTemp,
HearthWestTemp,HearthNorthTemp,batchNum ,airtightTemp ,fuelRatio,windVolume ,hotWindpress ,coldWindpress,
windTemp ,toptempSoutheast,toptempSouthwest,toptempNorthwest,toptempNortheast,topPress,breathIndex,OVolume,
requiresCoal,actualCoal,load,Vj ,Vk,coalRatio,COutilization,blastIndex,blastCokeRatio,blastCoalRatio,
blastMineRatio,combustionRatio,JiaoDing,banZu,zhibanren,jiluren,beizhu, 
YuanLiaoTime, pingZhong, TFe, FeO, S, SiO2, CaO, MgO, Al2O3, P2O5, MnO, TiO2, R2, fuel_H2O,
fuel_A, fuel_V, fuel_S, fuel_C, fuel_P, granularityTime, JSLD_Lessthan5, JSLD_5to10, JSLD_10to15,
JSLD_15to25, JSLD_25to40, JSLD_Morethan40 ,VirtualHeatNum, LuZhaTime, slag_SiO2, slag_CaO, slag_MgO, 
slag_Al2O3, slag_R2, slag_R3 from Project_Iron where {0} >= {1} 
and {2} <= {3}", kv.MyDictionary[input_2_element],input_2_from, kv.MyDictionary[input_2_element],input_2_to);

                SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
                SqlDataReader reader = sqlCmd1.ExecuteReader();

                while (reader.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    lt.Text = reader[0].ToString();
                    for (int i = 1; i < count; ++i)
                    {
                        lt.SubItems.Add(reader[i].ToString());
                    }
                    listView1.Items.Add(lt);
                }
                sqlCnt1.Close();
            }
            else if (str == "原料记录")
            {
                
                index_of = Array.IndexOf(str_yuanliao_header, input_2_element);
                /*string sql1 = string.Format(@"SELECT column_name FROM 
INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME= Project_Iron LIMIT {1},1", index_of);
                // DataSet = conn.getmysqlread(sql1);
              
                while (DataSet.Read())
                    Text = DataSet[0].ToString();*/
                // SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCnt1);
                //SqlDataReader DataSet = sqlCmd1.ExecuteReader();
                
                string sql = string.Format(@"select HeatNum,YuanLiaoTime,pingZhong,TFe,FeO,S,SiO2,CaO,MgO,Al2O3,P2O5,MnO,TiO2,R2,fuel_H2O,
fuel_A,fuel_V,fuel_S,fuel_C,fuel_P,granularityTime,JSLD_Lessthan5,JSLD_5to10,JSLD_10to15,
JSLD_15to25,JSLD_25to40,JSLD_Morethan40 from Project_Iron where {0} >= {1} 
and {2} <={3}", str_tt, input_2_from, str_tt, input_2_to);
                SqlCommand sqlCmd2 = new SqlCommand(sql, sqlCnt1);
                SqlDataReader DataSet = sqlCmd2.ExecuteReader();
                for (int i = 0; i < str_yuanliao_header.Length; ++i)
                {
                    ColumnHeader ch = new ColumnHeader();
                    ch.Text = str_yuanliao_header[i];   //设置列标题
                    this.listView1.Columns.Add(ch);
                }
                while (DataSet.Read())
                {
                    ListViewItem lt = new ListViewItem();
                    // string stt = DataSet[0].ToString() ;
                    // string stt1 = DataSet[1].ToString();
                    lt.Text = DataSet[0].ToString();
                    lt.UseItemStyleForSubItems = false;
                    for (int i = 1; i < str_yuanliao_header.Length; ++i)
                    {
                        lt.SubItems.Add(DataSet[i].ToString());        
                    }
                   // lt.SubItems[str_yuanliao_header.ToList().IndexOf(input_2_element)].BackColor = Color.Red;
                   // lt.SubItems[str_yuanliao_header.ToList().IndexOf(input_2_element)].ForeColor = Color.Blue;

                    //listView1.Items[j++].SubItems[2].BackColor = Color.Red;
                    listView1.Items.Add(lt);
                }
            }
            else if (str == "高炉操作记录")
            {            
                DataGridView dgw = new GaoLu().retu_();
                int col_len = dgw.ColumnCount;       //改变         
                //查出出铁查询的表头
                string[] str_ = new string[col_len];
                for (int i = 0; i < col_len; ++i)
                {
                    str_[i] = dgw.Columns[i].HeaderText;           //改变的
                }
                index_of = Array.IndexOf(str_, input_2_element);
               /* string sql1 = string.Format(@"SELECT column_name FROM 
INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME= '{0}' LIMIT {1},1", str_item,index_of);

                //DataSet = conn.getmysqlread(sql1);
                SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCnt1);
                SqlDataReader DataSet = sqlCmd1.ExecuteReader();
                while (DataSet.Read())
                    Text = DataSet[0].ToString();*/
                string sql = string.Format(@"select GaoLuOperationTime,waistEastTemp,waistSouthTemp,waistWestTemp,waistNorthTemp ,HearthEastTemp,HearthSouthTemp,
HearthWestTemp,HearthNorthTemp,batchNum ,airtightTemp ,fuelRatio,windVolume ,hotWindpress ,coldWindpress,
windTemp ,toptempSoutheast,toptempSouthwest,toptempNorthwest,toptempNortheast,topPress,breathIndex,OVolume,
requiresCoal,actualCoal,load,Vj ,Vk,coalRatio,COutilization,blastIndex,blastCokeRatio,blastCoalRatio,
blastMineRatio,combustionRatio,JiaoDing,banZu,zhibanren,jiluren,beizhu from Project_Iron where {0} >= {1} 
and {2} <= {3}",str_tt, input_2_from, str_tt, input_2_to);

                DataGridView lg_gaolu = new GaoLu().retu_();
                search_fengzhuang(lg_gaolu, sql, ref sqlCnt2, comboBox2.Text);
                sqlCnt2.Close();
            }
            else if (str == "出铁记录")
            {
               // str_item = "chutie_qingkuang";
                DataGridView dgw = new chutie().chutie_retu();
                int col_len = dgw.ColumnCount;       //改变

                //查出出铁查询的表头
                string[] str_ = new string[col_len];
                for (int i = 0; i < col_len; ++i)
                {
                    str_[i] = dgw.Columns[i].HeaderText;           //改变的
                }
               /* index_of = Array.IndexOf(str_, input_2_element);
                string sql1 = string.Format(@"SELECT column_name FROM 
INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME= '{0}' LIMIT {1},1",str_item,index_of);
                SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCnt1);
                SqlDataReader DataSet = sqlCmd1.ExecuteReader();
                while (DataSet.Read())
                    Text = DataSet[0].ToString();*/

                string sql = string.Format(@"select HeatNum,outIronTime,meterialBatch,theoryYield,yield_1 ,yield_2,difference,type_1,type_1_Si,
type_1_S,type_1_Mn,type_1_P,type_1_Ti,type_2,type_2_Si,type_2_S,type_2_Ti,ironDeep,zhaYang from Project_Iron where {0} >= {1}
and {2} <= {3}", str_tt, input_2_from, str_tt, input_2_to);
                //SqlCommand sqlCmd2 = new SqlCommand(sql, sqlCnt2);
               // SqlDataReader DataSet = sqlCmd2.ExecuteReader();
                //DataSet = conn.getmysqlread(sql);
                DataGridView chutie_dgw = new chutie().chutie_retu();
                search_fengzhuang(chutie_dgw, sql, ref sqlCnt2,input_2_element);
                sqlCnt2.Close();
            }
            else if (str == "炉渣记录")
            {
                //str_item = "luzha_huaxue_fenxi";
                DataGridView dgw = new LuZhaFenXi().luzhan_retu();
                int col_len = dgw.ColumnCount;       //改变

                //查出出铁查询的表头
                string[] str_ = new string[col_len];
                for (int i = 0; i < col_len; ++i)
                {
                    str_[i] = dgw.Columns[i].HeaderText;           //改变的
                }
               /* index_of = Array.IndexOf(str_, input_2_element);
                string sql1 = string.Format(@"SELECT column_name FROM 
INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME= '{0}' LIMIT {1},1",str_item,index_of);
                SqlCommand sqlCmd1 = new SqlCommand(sql1, sqlCnt1);
                SqlDataReader DataSet = sqlCmd1.ExecuteReader();
                // DataSet = conn.getmysqlread(sql1);
                while (DataSet.Read())
                    Text = DataSet[0].ToString();*/
                //创建炉渣查询的表头
                DataGridView str_lz = new LuZhaFenXi().luzhan_retu();       //改变的

                string sql = string.Format(@"select VirtualHeatNum,LuZhaTime,slag_SiO2,slag_CaO,slag_MgO,slag_Al2O3 ,slag_R2, slag_R3 from Project_Iron where {0} >= {1} 
and {2} <= {3}", str_tt, input_2_from, str_tt, input_2_to);
                search_fengzhuang(str_lz, sql, ref sqlCnt2,input_2_element); 
            }
            sqlCnt1.Close();
            sqlCnt2.Close();
        }
        private void temp_fun()
        {
            string str = comboBox1.Text;
            comboBox2.Items.Clear();
            int col_len = 0;
            //原料
            string[] str_yuanliao_header = {"炉号","入炉原料化学分析时间","TFe","FeO","SiO2","CaO","MgO","P2O5","MnO","TiO2","R2","A",
            "Al2O3","S","C固","P","V","入炉原料化学分析时间","机烧粒度时间","<5","5-10","10-15","15-25",
                "25-40",">40"};
            if(str =="")
            {
                List<string> list = new List<string>();
                Key_Value kv1 = new Key_Value();
                int count = 0;
                foreach (var item in kv1.MyDictionary)
                {
                    count++;
                    list.Add(item.Key);
                }
                string[] str123 = new string[count];
                str123 = list.ToArray();

                for(int i=0;i< count;++i)
                {
                    comboBox2.Items.Add(str123[i]);
                }
            }
            else if (str == "原料记录")
            {
                for (int i = 0; i < str_yuanliao_header.Length; ++i)
                {
                    comboBox2.Items.Add(str_yuanliao_header[i]);
                }
            }
            else if (str == "高炉操作记录")
            {
                DataGridView dgw = new GaoLu().retu_();
                col_len = dgw.ColumnCount;       //改变

                //查出出铁查询的表头
                string[] str_gl = new string[col_len];
                for (int i = 0; i < col_len; ++i)
                {
                    str_gl[i] = dgw.Columns[i].HeaderText;           //改变的
                    comboBox2.Items.Add(str_gl[i]);
                }
            }
            else if (str == "出铁记录")
            {
                DataGridView dgw = new chutie().chutie_retu();
                col_len = dgw.ColumnCount;       //改变

                //查出出铁查询的表头
                string[] str_gl = new string[col_len];
                for (int i = 0; i < col_len; ++i)
                {
                    str_gl[i] = dgw.Columns[i].HeaderText;           //改变的
                    comboBox2.Items.Add(str_gl[i]);
                }
            }
            else if (str == "炉渣记录")
            {
                DataGridView dgw = new LuZhaFenXi().luzhan_retu();
                col_len = dgw.ColumnCount;       //改变

                //查出出铁查询的表头
                string[] str_gl = new string[col_len];
                for (int i = 0; i < col_len; ++i)
                {
                    str_gl[i] = dgw.Columns[i].HeaderText;           //改变的
                    comboBox2.Items.Add(str_gl[i]);
                }
            }
            //comboBox2.Text = comboBox2.SelectedItem.ToString();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //每次选择触动相应的动态填加的combox的选项
            this.temp_fun();
        }

        private void watermarkTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_MouseLeave(object sender, EventArgs e)
        {
            string str = comboBox2.Text.ToString();
            Key_Value kv1 = new Key_Value();
            str=kv1.MyDictionary[str];
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            SqlConnection sqlCnt2 = new SqlConnection(strConn);
            sqlCnt1.Open();
            sqlCnt2.Open();
            string sql = string.Format(@"select max({0}) from Project_Iron",str);
            string sql_1 = string.Format(@"select min({0}) from Project_Iron", str);

            SqlCommand sqlCmd1 = new SqlCommand(sql_1, sqlCnt1);
            SqlCommand sqlCmd2 = new SqlCommand(sql, sqlCnt2);

            SqlDataReader reader = sqlCmd1.ExecuteReader();
            SqlDataReader reader2 = sqlCmd2.ExecuteReader();
            while (reader.Read() && reader2.Read())
            {
                linkLabel1.Text = reader[0].ToString();
                linkLabel2.Text = reader2[0].ToString();
                break;
            }
            sqlCnt1.Close();
            sqlCnt2.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
