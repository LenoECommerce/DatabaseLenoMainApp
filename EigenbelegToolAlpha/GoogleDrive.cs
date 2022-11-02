using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EigenbelegToolAlpha
{
    public partial class GoogleDrive : Form
    {
        private const string PathToServiceAccountKeyFile = @"C:\Users\lenna\Desktop\credentials.json";
        static string[] Scopes = { DriveService.Scope.Drive };
        static string ApplicationName = "DriveAccessLeno";
        public GoogleDrive()
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
        }
        private static void UploadBasicImage(string path, DriveService service)
        {
            //Objektfile von Google Drive
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            fileMetadata.Name = Path.GetFileName(path);
            fileMetadata.MimeType = "image/jpeg";
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                request.Fields = "webViewLink";
                request.Fields = "PermissionsIds";
                request.Upload();
            }
            Permission permission = new Permission();
            permission.Role = "reader";
            permission.Type = "anyone";
            var file = request.ResponseBody;
            var permissionId = file.PermissionIds.FirstOrDefault();
            service.Permissions.Update(permission, file.Id, permissionId.ToString()).Execute();
            Console.WriteLine("File ID: " + file.Id + file.WebViewLink);
        }

        private static UserCredential GetCredentials()
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
        private void GoogleDrive_Load(object sender, EventArgs e)
        {

        }
    }
}
