using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace GetBankNameLibrary
{
    [ComVisible(true)]
    public class GetBankName
    {
        private string inputParams, bodyHtml;
        private string GetTextParameter(string parName)
        {
            foreach (string line in inputParams.Split(new char[] { '\n', '\r' }))
                if (line.IndexOf(parName + "=", StringComparison.OrdinalIgnoreCase) == 0)
                    return line.Substring(parName.Length + 1);
            return "";
        }
        private string TextBetweenDelimiters(string startDel, string endDel)
        {
            var result = bodyHtml.Split(new string[] { startDel }, StringSplitOptions.None);
            if (result.Length < 2) return string.Empty;
            result = result[1].Split(new string[] { endDel }, StringSplitOptions.None);
            return result[0];
        }
        public int Execute(string fdatas, string fpars, ref string fouts)
        {
            int res = -1;
            try
            {
                inputParams = fpars;
                var account = GetTextParameter("BankKonto").Trim();
                if (string.IsNullOrEmpty(account)) return 1;
                if (char.IsDigit(account[0])) account = "PL" + account;
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    bodyHtml = client.DownloadString($"https://jakitobank.pl/konto/{account}");
                }
                bodyHtml = WebUtility.HtmlDecode(bodyHtml);
                var bankName = TextBetweenDelimiters("<tr><td>Nazwa Banku:</td><td>", "</td></tr>");
                bankName = bankName.Replace("\r", string.Empty).Replace("\n", string.Empty).Trim();
                fouts = "BankNazwa=" + bankName;
                res = string.IsNullOrEmpty(bankName) ? 1 : 0;
            }
            catch (System.Exception ex)
            {
                fouts = "ErrorMessage=" + ex.Message;
            }
            return res;
        }
    }
}