using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;

//url different
namespace Team_Editor_Manager_New_Generation.update
{
    public class Updated
    {
        public string verificoVersioneAggiornata()
        {
            string version = null;
            WebRequest request = WebRequest.Create("http://lagun2.altervista.org/DinoTem/version.txt");
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            //version on server
            string responseFromServer = reader.ReadToEnd();
            version = responseFromServer;
            reader.Close();
            response.Close();

            return version;
        }

        public string verificoAssembler()
        {
            //ASSEMBLY VERSION
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

            return fvi.FileVersion;
        }

    }
}
