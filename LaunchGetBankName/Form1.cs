using System;
using System.Windows.Forms;
using GetBankNameLibrary;

namespace LaunchGetBankName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myFunc = new GetBankName();
            var fdatas = "APLIKACJA=LaunchGetBankName";
            var fpars = paramsMemo.Text;
            string fRes = "";
            myFunc.Execute(fdatas, fpars, ref fRes);
            resultMemo.Text = fRes;
        }
    }
}
