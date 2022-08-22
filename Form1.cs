using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSKR_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (userID.Text.Length == 0 || userPWD.Text.Length == 0)
            {
                MessageBox.Show("아이디 또는 비밀번호를 입력 하세요.");
                return;
            }

            string result = HttpManager.GetRequest("http://lostsaga.co.kr:660/login.aspx?userID=" + userID.Text + "&userPWD=" + userPWD.Text);
            if (result == "errorcode1")
            {
                MessageBox.Show("아이디 또는 비밀번호가 비어있습니다.");
            }
            else if (result == "errorcode2")
            {
                MessageBox.Show("존재하지 않는 아이디 입니다.");
            }
            else if (result.StartsWith("lostsaga") == true)
            {
                StartProcess.OnCmdStart("start " + result);
                //StartProcess.OnStart("C:\\Program Files\\LostSaga\\lswebbroker.exe", result);
                //MessageBox.Show(result);
            }
            else
            {
                MessageBox.Show("알수 없는 오류.");
            }
        }
    }
}
