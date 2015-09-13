using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace waluta
{
    /// <summary>
    /// Summary description for sw
    /// </summary>
    [WebService(Namespace = "http://webserv-1.apphb.com/sw.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class sw : System.Web.Services.WebService
    {
        private string url = "http://www.nbp.pl/kursy/xml/LastA.xml";
        [WebMethod]
        public double ZwrocPLN(double GBP)
        {
          
            double kurs = 0;
            double PLN = 0;
            DataSet ds = new DataSet();

            ds.ReadXml("http://www.nbp.pl/kursy/xml/LastA.xml");
            var s = ds.Tables[1].Select("kod_waluty = 'GBP'");
            kurs = Double.Parse(s[0]["kurs_sredni"].ToString());
            PLN = GBP * kurs;
            PLN = Math.Round(PLN,2);
            return PLN;
        }

        [WebMethod]
        public double ZamienWalute(double kwota, string waluta)
        {
        
            double kurs = 0;
            double nowaKwota = 0;
            DataSet ds = new DataSet();

            ds.ReadXml(url);
            var s = ds.Tables[1].Select(string.Format("kod_waluty = '{0}'",waluta));
            kurs = Double.Parse(s[0]["kurs_sredni"].ToString());

            nowaKwota = kwota / kurs;
            return nowaKwota;
        }
    }
}
