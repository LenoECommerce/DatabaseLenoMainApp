using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Json;
using Google.Apis.Logging;
using Google.Apis.Util.Store;
using SautinSoft.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using iTextSharp.text;
using Google.Apis.Upload;
using Org.BouncyCastle.Asn1.Ocsp;

namespace EigenbelegToolAlpha
{
    public partial class GoogleDriveTest : Form
    {
        private const string PathToServiceAccountKeyFile = @"C:\Users\lenna\Desktop\credentials.json";
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "DriveAccessLenoNextTry";
        
        public GoogleDriveTest()
        {
            InitializeComponent();
            UserCredential credential;
            credential = GetCredentials();

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            UploadBasicImage(@"C:\Users\lenna\Desktop\test\office.jpg", service);

            // Files auflisten
            //FilesResource.ListRequest listRequest = service.Files.List();
            //listRequest.PageSize = 10;
            //listRequest.Fields = "nextPageToken, files(id, name)";

            //IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
            //    .Files;
            //Console.WriteLine("Files:");
            //if (files != null && files.Count > 0)
            //{
            //    foreach (var file in files)
            //    {
            //        Console.WriteLine("{0} ({1})", file.Name, file.Id);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No files found.");
            //}

        }

        private static void UploadBasicImage(string path, DriveService service)
        {
            //Objektfile von Google Drive
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "image/jpeg";
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(path,FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Upload();
            }
            var file = request.ResponseBody;
            Console.WriteLine("File ID: " + file.Id);
                
        }

        private static UserCredential GetCredentials ()
        {
            UserCredential credential;
            using (var stream = new FileStream(PathToServiceAccountKeyFile, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);

            }
            return credential;
        }

        private void GoogleDriveTest_Load(object sender, EventArgs e)
        {
            
        }
    }
}
