using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndroidRepro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcquireTokenPage : ContentPage
    {
        public AcquireTokenPage()
        {
            InitializeComponent();
        }
        public PublicClientApplication PublicClientApplication { get; set; }
        private const string EmptyResult = "Result:";

        public void InitPublicClient()
        {
            var builder = PublicClientApplicationBuilder
                .Create(App.ClientId)
                .WithAuthority(new Uri(App.DefaultAuthority));

                builder = builder.WithRedirectUri(App.s_redirectUriOnAndroid);

                builder.Build();
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs args)
        {
            var selectedTest = (Picker)sender;
            int selectedIndex = selectedTest.SelectedIndex;

            switch (selectedIndex)
            {
                case 0: // AT Interactive
                    AcquireTokenInteractiveAsync(Prompt.ForceLogin).ConfigureAwait(false);
                    break;
            }
        }

        private async Task AcquireTokenInteractiveAsync(Prompt prompt)
        {
            try
            {
                AcquireTokenInteractiveParameterBuilder request = PublicClientApplication.AcquireTokenInteractive(App.s_defaultScopes)
                    .WithPrompt(prompt)
                    .WithParentActivityOrWindow(App.AndroidActivity)
                    .WithUseEmbeddedWebView(true);

                AuthenticationResult result = await
                    request.ExecuteAsync().ConfigureAwait(true);

                var resText = GetResultDescription(result);

                acquireResponseLabel.Text = resText;
            }
            catch (Exception exception)
            {
               
            }
        }

        private static string GetResultDescription(AuthenticationResult result)
        {
            var sb = new StringBuilder();

            sb.AppendLine("AccessToken : " + result.AccessToken);
            sb.AppendLine("IdToken : " + result.IdToken);
            sb.AppendLine("ExpiresOn : " + result.ExpiresOn);
            sb.AppendLine("TenantId : " + result.TenantId);
            sb.AppendLine("Scope : " + string.Join(",", result.Scopes));
            sb.AppendLine("User :");

            return sb.ToString();
        }
    }
}