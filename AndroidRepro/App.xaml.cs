using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidRepro
{
    public partial class App : Application
    {
        public static object AndroidActivity { get; set; }

        public const string ClientId = "4b0db8c2-9f26-4417-8bde-3f0e3656f8e0";
        public static string s_redirectUriOnAndroid = "urn:ietf:wg:oauth:2.0:oob";

        public const string DefaultAuthority = "https://login.microsoftonline.com/common";
        public static string[] s_defaultScopes = { "User.Read" };

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
