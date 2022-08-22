using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LSKR_Launcher
{
    internal class HttpManager
    {
        public static string GetRequest(string szURL)
        {
            string result = "";
            WebRequest request = null;
            WebResponse response = null;

            Stream resStream = null;
            StreamReader resReader = null;

            try
            {
                request = WebRequest.Create(szURL.Trim());

                response = request.GetResponse();

                resStream = response.GetResponseStream();
                resReader = new StreamReader(resStream);

                result = resReader.ReadToEnd();
            }
            catch
            {
                result = "error";
            }
            finally
            {
                if (resReader != null)
                {
                    resReader.Close();
                }
                if (response != null)
                {
                    response.Close();
                }
            }

            return result;
        }
    }
}
