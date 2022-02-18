
using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Security;
//using System.Text;
//using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using System.Security;
using System.IO;

namespace SharePointToSharedDrive
{
    class Program
    {
        static void Main(string[] args)
        {


            //    string username = "sharepoint_user";
            //    string password = "sharepoint_password";
            //    var securePassword = new SecureString();
            //    foreach (char c in password)
            //    {
            //        securePassword.AppendChar(c);
            //    }
            //    var onlineCredentials = new NetworkCredential(username, password, "domain");
            //    ClientContext clientContext = new ClientContext(filePath);
            //    var url = string.Format("{0}", filePath);
            //    string userRoot = System.Environment.GetEnvironmentVariable("USERPROFILE");
            //    string downloadFolder = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%"), "Downloads");
            //    WebRequest request = WebRequest.Create(new Uri(url, UriKind.Absolute));
            //    request.Credentials = onlineCredentials;
            //    WebResponse response = request.GetResponse();
            //    Stream fs = response.GetResponseStream() as Stream;
            //    using (FileStream localfs = System.IO.File.OpenWrite(Server.MapPath("~/Claim_Documents/") + "/" + Path.GetFileName(filePath)))
            //    {
            //        CopyStream(fs, localfs);
            //    }
            //    string filename = Path.GetFileName(filePath);
            //    Response.ContentType = "application/octet-stream";
            //    Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename);
            //    string aaa = Server.MapPath("~/Claim_Documents/" + filename);
            //    Response.TransmitFile(Server.MapPath("~/Claim_Documents/" + filename));
            //    Response.End();
            //} catch private static void CopyStream(Stream fs, FileStream localfs)
            //{
            //    throw new NotImplementedException();
            //}

            //(Exception ex) {  
            ////lblmsg.Text = ex.Message;  
            //}

            //Microsoft.SharePoint.Client.ClientContext context = new Microsoft.SharePoint.Client.ClientContext("https://cargill2--sit.my.salesforce.com");

            //// The SharePoint web at the URL.
            //Web web = context.Web;

            //// We want to retrieve the web's properties.
            //context.Load(web);

            //// Execute the query to the server.
            //context.ExecuteQuery();

            //// Now, the web's properties are available and we could display
            //// web properties, such as title.
            //Console.WriteLine(web.Title);

            //string siteUrl = "https://sharepoint.wsx.sg/sites/op";
            //string fileRelativePath = @"/sites/op/files/config/conf.json";
            //string downloadFilePath = "c:\\temp\\conf.json";


            string siteUrl = "https://sharepoint.wsx.sg/sites/op";
            string fileRelativePath = @"/sites/op/files/config/conf.json";
            string downloadFilePath = "c:\\temp\\conf.json";

        

            var login = "seraju_rehman@crgl-thirdparty.com.cargill2.sit";
            var password = "METALS123";

            ClientContext context = new ClientContext(siteUrl);
            var securePassword = new SecureString();
            foreach (char c in password.ToCharArray()) securePassword.AppendChar(c);
            context.Credentials = new SharePointOnlineCredentials(login, securePassword);
            var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, fileRelativePath);
            using (Stream destination = System.IO.File.Create(downloadFilePath))
            {
                for (int a = fileInfo.Stream.ReadByte(); a != -1; a = fileInfo.Stream.ReadByte())
                    destination.WriteByte((byte)a);
            }
        }
    }
}
    
