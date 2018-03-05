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
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{

    public partial class Login : Form
    {
        ValidCode validCode = new ValidCode(5, ValidCode.CodeType.Numbers);
        private string strConn = "server=192.168.191.1;database=pro;uid=11223344;pwd=123456";

        public Login()
        {
            InitializeComponent();
            //解决picturebox开始不显示图片的问题，那我们就先调用一次
            this.picValidCode_Click(null,null);
                //picValidCode_Click;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            //刷新
            //validCode = new ValidCode(5, ValidCode.CodeType.Numbers);
            //picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }

        private void button1_Click(object sender, EventArgs e)      //确认注册按钮
        {
            //ValidCode validCode = new ValidCode(5, ValidCode.CodeType.Numbers);
            string str1 = watermarkTextBox1.Text.ToString();
            string str2 = watermarkTextBox2.Text.ToString();
            string str3 = watermarkTextBox3.Text.ToString();
            //Mysql_excute mysql_e = new Mysql_excute();
            //mysql_e.getmysqlcon();
            SqlConnection sqlCnt1 = new SqlConnection(strConn);
            sqlCnt1.Open();
            if (!this.watermarkTextBox3.Text.Equals(validCode.CheckCode))
            {
                MessageBox.Show(" 请输入正确的验证码!", this.Text);
                this.watermarkTextBox3.Focus();
                return;
            }
            string sql = String.Format(@"select *from Login where usrId='{0}' 
and usrPwd = '{1}'",str1,str2);
            //MySqlDataReader MDR = mysql_e.getmysqlread(sql);
            // MDR.GetValues();
            SqlCommand sqlCmd1 = new SqlCommand(sql, sqlCnt1);
            SqlDataReader reader = sqlCmd1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("登陆成功！", "提示");
                this.DialogResult = DialogResult.OK;        //会自动调用this.close();
                /*Form2 f = new Form2();
                f.ShowDialog();*/
               // this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误!");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
        }

        private void picValidCode_Click(object sender, EventArgs e)
        {
           // ValidCode validCode = new ValidCode(5, ValidCode.CodeType.Numbers);
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
            //picValidCode.Paint(null,null);// pictrueBox1_Paint(null,null)
            //picValidCode.Refresh();
           // picValidCode.Update();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Register().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            picValidCode.Image = Bitmap.FromStream(validCode.CreateCheckCodeImage());
        }
    }
}
