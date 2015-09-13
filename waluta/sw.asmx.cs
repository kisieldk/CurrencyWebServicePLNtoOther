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

        [WebMethod]
        public double ZwrocPLN(double GBP)
        {
            double _GBP = GBP;
            double kurs = 0.0000;
            double PLN = 0.00;
            DataSet ds = new DataSet();

            ds.ReadXml("http://www.nbp.pl/kursy/xml/LastA.xml");
            foreach (DataRow item in ds.Tables[1].Rows)
            {
                if (item["kod_waluty"].ToString() == "GBP")
                {
                    kurs = Convert.ToDouble(item["kurs_sredni"].ToString());
                }

            }
            PLN = _GBP * kurs * 100.00;
            PLN = Math.Round(PLN,2);
            return PLN;
        }
    }
}
