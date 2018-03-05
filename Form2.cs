using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using WindowsFormsApplication1.Tongji;
using WindowsFormsApplication1.Regression;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
       // DataGridView dataGridView2 = new DataGridView();
        public Form2()
        {
            InitializeComponent();
           
        }

        private void 大地方的ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  child f = new child();
            //   f.ShowDialog();
            MoHuQuery f = new MoHuQuery();
            f.ShowDialog();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
       //     child qq = new child();//创建一个子窗体的实例 
         //   qq.MdiParent = this;//要求子窗体的父窗体是MDI窗体 
          //  qq.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //this.label2.Text = DateTime.Now.ToString();
           /* Login login = new Login();
            if (login.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }*/
        }

        private void 插入记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button6_Click(null,null);
        }

        private void 插入表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GaoLu f = new GaoLu();
            f.ShowDialog();

            //Todo this
        }

        private void 插入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //DataGridView dataGridView2 = new DataGridView();
            // this.Load += new EventHandler(Form1_Load);
           /* DataGridView dataGridView2 = new DataGridView();
            CalendarColumn col = new CalendarColumn();*/
           // test f = new test();
            chutie f = new chutie();
      
            f.ShowDialog();
        }

        private void 插入炉渣分析数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuZhaFenXi f = new LuZhaFenXi();
            f.ShowDialog();
        }

        private void 分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 资源统计图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 线性分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinearAnalysie f = new LinearAnalysie();
            f.ShowDialog();
        }

        private void 导入表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                //e.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void 精确查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JinQuanQuery f = new JinQuanQuery();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if(radioButton1.Checked)        //插入原料
            {
                RuLuYuannLiao f = new RuLuYuannLiao();
                f.ShowDialog();
            }
            else if(radioButton2.Checked)       //插入高炉
            {
                GaoLu gl = new GaoLu();
                gl.ShowDialog();
            }
            else if(radioButton3.Checked)       //插入出铁
            {
                chutie ct = new chutie();
                ct.ShowDialog();
            }
            else if(radioButton4.Checked)       //插入炉渣
            {
                LuZhaFenXi lzfx = new LuZhaFenXi();
                lzfx.ShowDialog();
            }*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.label2.Text = DateTime.Now.ToString();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (radioButton5.Checked)        //插入原料
            //{
            //    JinQuanQuery f = new JinQuanQuery();
            //    f.ShowDialog();
            //}
           if(radioButton6.Checked)
            {
                MoHuQuery f = new MoHuQuery();
                f.ShowDialog();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            // Process process = new Process();
            //注意路径
            process.StartInfo.FileName = "C:\\Program Files (x86)\\Tencent\\QQ\\Bin\\QQScLauncher.exe";
            process.StartInfo.Arguments = "";
            try
            {
                process.Start();
            }
            catch (System.ComponentModel.Win32Exception QQ)
            {
                Console.WriteLine("系统找不到指定的程序文件。\r{0}", QQ);
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";
        public void button6_Click(object sender, EventArgs e)
        {
            //new 出铁的
            chutie ct = new chutie();
            ct.C_t_qk = new chu_tie_qingkuang();
            ct.ShowDialog();
                //还不能关闭ct,否则后边无法进行元素的使用            

            //new 出来高炉的
            GaoLu gl = new GaoLu();
            gl.G_l_c_z = new ShiTiLei.GaoLuCaoZuo();
            gl.ShowDialog();

            //new 出来炉渣的
            LuZhaFenXi lz = new LuZhaFenXi();
            lz.Luzha1 = new ShiTiLei.LuZha();
            lz.ShowDialog();                   

            //new 出来原料的
            RuLuYuannLiao yl = new RuLuYuannLiao();
            yl.YL1 = new ShiTiLei.YuanLiao();
            yl.ShowDialog();
             
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            sqlCnt1.Open();    
            //出铁 、高炉、炉渣、原料
            string sql_temp = string.Format(@"insert into Project_Iron (
HeatNum,outIronTime,meterialBatch,theoryYield,yield_1 ,yield_2,difference,type_1,type_1_Si,
type_1_S,type_1_Mn,type_1_P,type_1_Ti,type_2,type_2_Si,type_2_S,type_2_Ti,ironDeep,zhaYang,FlagChuTie, 

GaoLuOperationTime,waistEastTemp,waistSouthTemp,waistWestTemp,waistNorthTemp ,HearthEastTemp,HearthSouthTemp,
HearthWestTemp,HearthNorthTemp,batchNum ,airtightTemp ,fuelRatio,windVolume ,hotWindpress ,coldWindpress,
windTemp ,toptempSoutheast,toptempSouthwest,toptempNorthwest,toptempNortheast,topPress,breathIndex,OVolume,
requiresCoal,actualCoal,load,Vj ,Vk,coalRatio,COutilization,blastIndex,blastCokeRatio,blastCoalRatio,
blastMineRatio,combustionRatio,JiaoDing,banZu,zhibanren,jiluren,beizhu ,FlagGaoLu,         

VirtualHeatNum,LuZhaTime,slag_SiO2,slag_CaO,slag_MgO,slag_Al2O3 ,slag_R2, slag_R3,FlagLuZha,              
YuanLiaoTime,pingZhong,TFe,FeO,S,SiO2,CaO,MgO,Al2O3,P2O5,MnO,TiO2,R2,fuel_H2O,
fuel_A,fuel_V,fuel_S,fuel_C,fuel_P,granularityTime,JSLD_Lessthan5,JSLD_5to10,JSLD_10to15,
JSLD_15to25,JSLD_25to40,JSLD_Morethan40,FlagYuanLiao)values('{0}', '{1}' ,'{2}' ,             
'{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',
'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}',
'{35}','{36}','{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}',
'{53}','{54}','{55}','{56}','{57}','{58}','{59}','{60}','{61}','{62}','{63}','{64}','{65}','{66}','{67}','{68}','{69}','{70}',
'{71}','{72}','{73}','{74}','{75}','{76}','{77}','{78}','{79}','{80}','{81}','{82}','{83}','{84}','{85}','{86}','{87}','{88}',
'{89}','{90}','{91}','{92}','{93}','{94}','{95}','{96}')",
ct.C_t_qk.HeatNum1,
ct.C_t_qk.outIronTime_, 
ct.C_t_qk.meterialBatch_, 
ct.C_t_qk.theoryYield_,
ct.C_t_qk.yield_1_,
ct.C_t_qk.yield_2_, 
ct.C_t_qk.difference_, 
ct.C_t_qk.type_1_,
ct.C_t_qk.type_1_Si_,
ct.C_t_qk.type_1_S_, 
ct.C_t_qk.type_1_Mn_, 
ct.C_t_qk.type_1_P_,
ct.C_t_qk.type_1_Ti_,
ct.C_t_qk.type_2_, 
ct.C_t_qk.type_2_Si_, 
ct.C_t_qk.type_2_S_, 
ct.C_t_qk.type_2_Ti_,
ct.C_t_qk.ironDeep_, 
ct.C_t_qk.ZhaYang, 
1,
   gl.G_l_c_z.GaoLuOperationTime1,
   gl.G_l_c_z.WaistEastTemp,
   gl.G_l_c_z.WaitSouthTemp,
   gl.G_l_c_z.WaistWestTemp,
   gl.G_l_c_z.WaistNorthTemp,
   gl.G_l_c_z.HearthEastTemp1,
   gl.G_l_c_z.HearthSouthTemp1,
   gl.G_l_c_z.HearthWestTemp1,
   gl.G_l_c_z.HearthNorthTemp1,
   gl.G_l_c_z.BatchNum,
   gl.G_l_c_z.AirtightTemp,
   gl.G_l_c_z.FuelRatio,
   gl.G_l_c_z.WindVolume,
   gl.G_l_c_z.HotWindpress,
   gl.G_l_c_z.ColdWindpress,
   gl.G_l_c_z.WindTemp,
   gl.G_l_c_z.ToptempSoutheast,
   gl.G_l_c_z.ToptempSouthwest,
   gl.G_l_c_z.ToptempNorthwest,
   gl.G_l_c_z.ToptempNortheast,
   gl.G_l_c_z.TopPress,
   gl.G_l_c_z.BreathIndex,
   gl.G_l_c_z.OVolume1,
   gl.G_l_c_z.RequiresCoal,
   gl.G_l_c_z.ActualCoal,
   gl.G_l_c_z.Load,
   gl.G_l_c_z.Vj1,
   gl.G_l_c_z.Vk1,
   gl.G_l_c_z.CoalRatio,
   gl.G_l_c_z.COutilization1,
   gl.G_l_c_z.BlastIndex,
   gl.G_l_c_z.BlastCokeRatio,
   gl.G_l_c_z.BlastCoalRatio,
   gl.G_l_c_z.BlastMineRatio,
   gl.G_l_c_z.CombustionRatio,
   gl.G_l_c_z.JiaoDing1,
   gl.G_l_c_z.Banzu,
   gl.G_l_c_z.Zhibanren,
   gl.G_l_c_z.Jiluren,
   gl.G_l_c_z.Beizhu,
   1,
lz.Luzha1.VirtualHeatNum1,
 lz.Luzha1.Datetiem,
 lz.Luzha1.Slag_SiO2, 
 lz.Luzha1.Slag_CaO, 
 lz.Luzha1.Slag_MgO, 
 lz.Luzha1.Slag_Al2O3,
 lz.Luzha1.Slag_R2, 
 lz.Luzha1.Slag_R3,
 1,
          yl.YL1.Datetime,
          yl.YL1.PingZhong,
          yl.YL1.TFe1,
          yl.YL1.FeO1,
          yl.YL1.S1,
          yl.YL1.SiO21,
          yl.YL1.CaO1,
          yl.YL1.MgO1,
          yl.YL1.Al2O31,
          yl.YL1.P2O51,
          yl.YL1.MnO1,
          yl.YL1.TiO21,
          yl.YL1.R21,
          yl.YL1.Fuel_H2O,
          yl.YL1.Fuel_A,
          yl.YL1.Fuel_V,
          yl.YL1.Fuel_S,
          yl.YL1.Fuel_C,
          yl.YL1.Fuel_P,
          yl.YL1.GranularityTime1,
          yl.YL1.JSLD_Lessthan51,
          yl.YL1.JSLD_5to101,
          yl.YL1.JSLD_10to151,
          yl.YL1.JSLD_15to251,
          yl.YL1.JSLD_25to401,
          yl.YL1.JSLD_Morethan401,
         1
   );
            SqlCommand sqlCmd1 = new SqlCommand(sql_temp, sqlCnt1);
            if (sqlCmd1.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("插入成功！");
            }
            sqlCnt1.Close();
            ct.Close();
            gl.Close();
            lz.Close();
            yl.Close();
        }

        private void 出铁SiS等元素折线趋势图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TongJi_ f = new TongJi_();
            f.ShowDialog();
        }

        private void 某些元素或范围条形图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            some_elem_or_range f = new some_elem_or_range();
            f.ShowDialog();
        }

        private void 班组条形图对比ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_Compare f = new Class_Compare();
            f.ShowDialog();
        }

        private void 回归分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regression f = new regression();
            f.ShowDialog();
        }
    }
}
