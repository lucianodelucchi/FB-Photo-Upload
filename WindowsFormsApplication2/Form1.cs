using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Facebook;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private FacebookApp _fbApp;

        public FacebookApp FbApp
        {
            get { return _fbApp; }
            set { _fbApp = value; }
        }
        public Form1()
        {
            InitializeComponent();
            this.permissions.Items.AddRange(ExtendedPermissions.Permissions);
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
        }

        private IFacebookSettings GetSettings()
        {
            IFacebookSettings facebookSettings;
            if (string.IsNullOrEmpty("a"))
            {
                facebookSettings = FacebookSettings.Current;
            }
            else
            {
                facebookSettings = new FacebookSettings
                {
                    AppId = "114304635248288",
                    //ApiKey = "60c58b702e8fd38d950620b2324a2e32",
                    AppSecret = "68ca0d69a2ce76eed1ab73e36f10dc21",
                };
            }
            return facebookSettings;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //testEntities context = new testEntities();
            //var query = context.CreateQuery<product>("SELECT VALUE p FROM category_product AS cp INNER JOIN product AS p ON cp.product_id = p.id WHERE TestModel.Store.test(1)=1.0");

            //MessageBox.Show(query.Where(c => c.id == 1).FirstOrDefault().name);

        }

        void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //if (e.Url.Fragment.Contains("access_token"))
            //{
            //    NameValueCollection queryString = new NameValueCollection();
            //    string[] parts = e.Url.Fragment.Substring(1, e.Url.Fragment.Length - 1).Split('&');
            //    foreach (var part in parts)
            //    {
            //        var nameValue = part.Split('=');
            //        queryString.Add(nameValue[0], nameValue[1]);
            //    }
            //    this.txtAccessToken.Text = Uri.UnescapeDataString(queryString["access_token"]);
            //}
            FacebookAuthenticationResult authResult;
            if (FacebookAuthenticationResult.TryParse(e.Url, out authResult))
            {
                this.txtAccessToken.Text = authResult.AccessToken;
            }
        }

        public bool IsOne(int number)
        {
            return number == 1;
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            MessageBox.Show(e.Name);
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            MessageBox.Show(e.Name);
        }

        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            MessageBox.Show(e.Name);
        }

        private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            MessageBox.Show(e.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //114304635248288|36fcb5248ba9f1c82f5ba2d8-644258346|ErmR82vAet0355kukHX8Dogn9ds
            //FacebookAPI api = new FacebookAPI("114304635248288|36fcb5248ba9f1c82f5ba2d8-644258346|ErmR82vAet0355kukHX8Dogn9ds");
            //var result = api.Get("/me/");
            
            //var args = new Dictionary<string, string>();
            //args.Add("message", "test photo");
            //args.Add("photo", "");
            //args.Add("source", @"@c:\vcredist.bmp");
            

            //try
            //{
            //    result = api.Post("/me/photos", args);
            //    MessageBox.Show(result.Dictionary["name"].ToDisplayableString());
            //}
            //catch (Exception ex)
            //{

            //}

            //byte[] photo = File.ReadAllBytes(@"c:\vcredist.jpg");
            //FacebookApp app = new FacebookApp();
            ////app.AccessToken = "114304635248288|36fcb5248ba9f1c82f5ba2d8-644258346|ErmR82vAet0355kukHX8Dogn9ds";
            //var s = new FacebookSession();
            //s.AccessToken = "114304635248288|36fcb5248ba9f1c82f5ba2d8-644258346|ErmR82vAet0355kukHX8Dogn9ds";
            //app.Session = s;
            ////var a = app.Api("me");
            //Dictionary<string, object> parameters = new Dictionary<string, object>();
            ////parameters.Add("caption", "Test Photo");
            ////parameters.Add("method", "facebook.photos.upload");
            ////parameters.Add("uid", 644258346);
            ////parameters.Add("fileUpload", true);
            

            //var mediaObject = new FacebookMediaObject
            //{
            //    FileName = "monkey.jpg",
            //    ContentType = "image/jpeg",
            //};
            //mediaObject.SetValue(photo);
            ////parameters.Add("source", mediaObject);

            ////parameters.Add("aid", "257841");
            //parameters.Add("method", "delete");
            ////parameters.Add("description", "description test");

            //try
            //{
            //    //JsonObject obj = (JsonObject)app.Api("me/photos", parameters, HttpMethod.Post);
            //    JsonObject obj = (JsonObject)app.Api("257841", parameters, HttpMethod.Post);
            //    //MessageBox.Show(obj.id);
            //    //app.ApiAsync((ar) =>
            //    //{
            //    //    var postId = (string)ar.Result;
            //    //}, null, parameters);
            //}
            //catch (Exception ex)
            //{

                
            //}
            this.FbApp = new FacebookApp(this.txtAccessToken.Text);
            var fbUpl = new Facebook.FacebookMediaObject
            {
                FileName = @"vcredist.jpg",
                ContentType = "image/jpeg"
            };
            var bytes = System.IO.File.ReadAllBytes(@"C:\" + fbUpl.FileName);
            fbUpl.SetValue(bytes);

            var photoDetails = new Dictionary<string, object>();
            photoDetails.Add("message", "test photo"); // this will appear on the wall
            photoDetails.Add("image", fbUpl); // the name of this parameter does not matter

            try
            {
                //var fbResult = this.FbApp.Post(@"/257841/photos", photoDetails);
                this.FbApp.PostAsync(@"/644258346/photos", photoDetails, (fbResult) => { this.ShowResults((IDictionary<string, object>)fbResult.Result); });
                //var result = (IDictionary<string, object>)fbResult; // Or we could use dynamic.. only the photo "id"(s) come back
            }
            catch (Exception)
            {
                
                throw;
            }
            

            //using (WebClient client = new WebClient())
            //{
                

            //    byte[] responseArray = client.UploadFile("http://graph.facebook.com/me/photos&message=Test&access_token=114304635248288|36fcb5248ba9f1c82f5ba2d8-644258346|ErmR82vAet0355kukHX8Dogn9ds", @"c:\vcredist.bmp");
                
            //    Debug.WriteLine(Encoding.ASCII.GetString(responseArray));
            //}



        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.FbApp = new FacebookApp(this.GetSettings());

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("type", "user_agent");

            StringBuilder perms = new StringBuilder();
            foreach (var permission in permissions.CheckedItems)
            {
                perms.Append(permission);
                perms.Append(",");
            }
            parameters.Add("scope", perms.ToString());

            //Uri loginUrl = app.GetOAuthLoginUrl(parameters);
            Uri loginUrl = this.FbApp.GetLoginUrl(parameters);

            webBrowser1.Navigate(loginUrl);
        }

        private void ShowResults(IDictionary<string, object> result)
        {
            MessageBox.Show(result.First().Value.ToString());
        }
    }
}
