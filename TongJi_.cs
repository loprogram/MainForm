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
    public partial class TongJi_ : Form
    {
        public TongJi_()
        {
            InitializeComponent();
        }
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";
        private void button1_Click(object sender, EventArgs e)
        {
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();
            DateTime dt1 = dateEdit1.DateTime;
            DateTime dt2 = dateEdit2.DateTime;

            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            sqlCnt1.Open();
            string sql = string.Format(@"select * from Project_Iron where outIronTime >= '{0}' and
outIronTime<='{1}' order by outIronTime asc", dt1.ToString(), dt2.ToString());

            SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
            SqlDataReader read = sqlCmd1.ExecuteReader();
            string date_time;
            chartControl1.Titles.Add(new ChartTitle());
            chartControl1.Titles[0].Text = "Si,S,Mn,P,Ti百分比变化趋势";

            //折线图
            Series _lineSeries_Si = new Series("Si", ViewType.Line);
            _lineSeries_Si.Label.TextPattern = "alksjflaksjflafl";
            // _lineSeries_Si.Colorizer = Color.Green;
            Series _lineSeries_S = new Series("S", ViewType.Line);
            Series _lineSeries_Mn = new Series("Mn", ViewType.Line);
            Series _lineSeries_P = new Series("P", ViewType.Line);
            Series _lineSeries_Ti = new Series("Ti", ViewType.Line);

            while (read.Read())
            {
                date_time = read[1].ToString();
                decimal temp;
                DateTime t_d;
                //Si
                decimal.TryParse(read[8].ToString(), out temp);
                DateTime.TryParse(date_time, out t_d);
                t_d.ToShortTimeString();
                _lineSeries_Si.Points.Add(new SeriesPoint(t_d, temp));
                //  _lineSeries_Si1.Points.Add(new SeriesPoint(t_d, temp));
                //S
                decimal.TryParse(read[9].ToString(), out temp);
                DateTime.TryParse(date_time, out t_d);
                t_d.ToShortTimeString();
                _lineSeries_S.Points.Add(new SeriesPoint(t_d, temp));
                //   _lineSeries_S1.Points.Add(new SeriesPoint(t_d, temp));
                //Mn
                decimal.TryParse(read[10].ToString(), out temp);
                DateTime.TryParse(date_time, out t_d);
                t_d.ToShortTimeString();
                _lineSeries_Mn.Points.Add(new SeriesPoint(t_d, temp));
                //     _lineSeries_Mn1.Points.Add(new SeriesPoint(t_d, temp));
                //P
                decimal.TryParse(read[11].ToString(), out temp);
                DateTime.TryParse(date_time, out t_d);
                t_d.ToShortTimeString();
                _lineSeries_P.Points.Add(new SeriesPoint(t_d, temp));
                //     _lineSeries_P1.Points.Add(new SeriesPoint(t_d, temp));
                //Ti
                decimal.TryParse(read[12].ToString(), out temp);
                DateTime.TryParse(date_time, out t_d);
                t_d.ToShortTimeString();
                _lineSeries_Ti.Points.Add(new SeriesPoint(t_d, temp));
                //       _lineSeries_Ti1.Points.Add(new SeriesPoint(t_d, temp));
            }
            _lineSeries_Si.ArgumentScaleType = ScaleType.DateTime;
            _lineSeries_S.ArgumentScaleType = ScaleType.DateTime;
            _lineSeries_Mn.ArgumentScaleType = ScaleType.DateTime;
            _lineSeries_P.ArgumentScaleType = ScaleType.DateTime;
            _lineSeries_Ti.ArgumentScaleType = ScaleType.DateTime;


            //ArgumentDataMember = "Si含量变化";
            //series1.ArgumentDataMember = "StatisticsTime";
            chartControl1.Series.Add(_lineSeries_Si);
            chartControl1.Series.Add(_lineSeries_S);
            chartControl1.Series.Add(_lineSeries_Mn);
            chartControl1.Series.Add(_lineSeries_P);
            chartControl1.Series.Add(_lineSeries_Ti);

            XYDiagram diagram = this.chartControl1.Diagram as XYDiagram;
            diagram.AxisY.VisualRange.MaxValue = 2.5;
            diagram.AxisY.VisualRange.MinValue = 0.0;
            diagram.EnableAxisXScrolling = true;
            diagram.EnableAxisYScrolling = true;
            //开启滚动条必须设置未false                   
            //diagram.EnableScrolling = true;//启用滚动条
            sqlCnt1.Close();
        }
    }
}
