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

namespace WindowsFormsApplication1
{
    public partial class LuZhaFenXi : Form
    {
        public LuZhaFenXi()
        {
            InitializeComponent();
        }
      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        public DataGridView luzhan_retu()
        {
            return dataGridView1;
        }
        private LuZha Luzha;

        internal LuZha Luzha1
        {
            get
            {
                return Luzha;
            }

            set
            {
                Luzha = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            //Mysql_excute sql_conn = new Mysql_excute();
           // sql_conn.getmysqlcon();
            int count_row = dataGridView1.RowCount;     //多余一行空白行
            int str1 = -1;
            DateTime Dt;
            DateTime.TryParse("2001/01/01", out Dt);
            DateTime dt = DateTime.MaxValue;
            Luzha.Datetiem = Dt;
            double str2 = -1.0, str3 = -1.0, str4 = -1.0, str5 = -1.0, str6 = -1.0;
            String str7 =null;
            for (int i = 0; i < count_row-1; i++)
            {
                if(dataGridView1.Rows[i].Cells[0].Value != null)
                {  
                    int.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out str1);
                    Luzha.VirtualHeatNum1 = str1;
                }
                if (dataGridView1.Rows[i].Cells[1].EditedFormattedValue != null)
                {
                    DateTime.TryParse(dataGridView1.Rows[i].Cells[1].EditedFormattedValue.ToString(),out dt);
                    Luzha.Datetiem = dt;
                }
                if(dataGridView1.Rows[i].Cells[2].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out str3);
                    Luzha.Slag_SiO2 = str3;
                   // str3 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                }
                if(dataGridView1.Rows[i].Cells[3].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].Cells[3].Value.ToString(), out str4);
                    Luzha.Slag_CaO = str4;
                    //str4 = dataGridView1.Rows[i].Cells[3].Value.ToString();
                }
                if(dataGridView1.Rows[i].Cells[4].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].Cells[4].Value.ToString(), out str5);
                    Luzha.Slag_MgO = str5;
                    //str5 = dataGridView1.Rows[i].Cells[4].Value.ToString();
                }
                if(dataGridView1.Rows[i].Cells[5].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].Cells[5].Value.ToString(), out str6);
                    Luzha.Slag_Al2O3 = str6;
                    //str6 = dataGridView1.Rows[i].Cells[5].Value.ToString();
                }
                if (dataGridView1.Rows[i].Cells[6].Value != null)
                {
                    double.TryParse(dataGridView1.Rows[i].Cells[6].Value.ToString(), out str2);
                    Luzha.Slag_R2 = str2;
                  
                }
                if (dataGridView1.Rows[i].Cells[7].Value != null)
                {
                    str7 = dataGridView1.Rows[i].Cells[7].Value.ToString();
                    Luzha.Slag_R3 = str7;
                }
               /* string sql = string.Format(@"insert ignore into luzha_huaxue_fenxi(HeatNum_lz,datetime,
slag_SiO2,slag_CaO,slag_MgO,slag_Al2O3 ,slag_R2, slag_R3) values('{0}','{1}',
'{2}','{3}','{4}','{5}','{6}','{7}')", str1, dt, str3, str4, str5, str6,str2,str7);*/
                //sql_conn.getmysqlcom(sql);
            }
            dataGridView1.Rows.Clear();
            this.Close();
        }

        private void LuZhaFenXi_Load(object sender, EventArgs e)
        {

        }
    }
}
