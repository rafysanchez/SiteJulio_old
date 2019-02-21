using area452.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace area452.Controllers
{
    public class ftpController : Controller
    {
        // GET: ftp
        public ActionResult Index()
        {
            
            
            
            
            return View();
        }

        string pegaArq()
        {

            String ftpServerIP = ConfigurationManager.AppSettings["ftpServerIP"];
            String ftpUserID = ConfigurationManager.AppSettings["ftpUserID"];
            String ftpPassword = ConfigurationManager.AppSettings["ftpPassword"];



            /* Create Object Instance */
            // ftp ftpClient = new ftp(@"ftp://10.10.10.10/", "user", "password");
            ftp ftpClient = new ftp(ftpServerIP, ftpUserID, ftpPassword);

            /* Upload a File */
            ftpClient.upload("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

            /* Download a File */
            ftpClient.download("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

            /* Delete a File */
            ftpClient.delete("etc/test.txt");

            /* Rename a File */
            ftpClient.rename("etc/test.txt", "test2.txt");

            /* Create a New Directory */
            ftpClient.createDirectory("etc/test");

            /* Get the Date/Time a File was Created */
            string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
            Console.WriteLine(fileDateTime);

            /* Get the Size of a File */
            string fileSize = ftpClient.getFileSize("etc/test.txt");
            Console.WriteLine(fileSize);

            /* Get Contents of a Directory (Names Only) */
            string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
            for (int i = 0; i < simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

            /* Get Contents of a Directory with Detailed File/Directory Info */
            string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
            for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
            /* Release Resources */
            ftpClient = null;

            return "ok";
        }
    }
}