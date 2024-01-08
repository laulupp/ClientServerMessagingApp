using ClientApp.Clients;
using ClientApp.Models;
using ClientApp.Services;

namespace ClientApp
{
    public partial class LoginView : Form
    {
        public LoginView()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => Application.Exit();
            this.MaximizeBox = false;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            registerLink.Enabled = false;
            AuthRequest a = new AuthRequest { Username = txtUsername.Text, Password = txtPassword.Text };
            var response = await AuthClient.LoginAsync(a);

            lblError1.Text = string.Empty;
            lblError2.Text = string.Empty;

            btnLogin.Enabled = true;
            registerLink.Enabled = true;

            if (response == null)
            {
                lblError1.Text = "There was an error, contact the admin.";
                return;
            }

            var errors = response.GetAllErrors();
            if (errors.Count == 1)
            {
                lblError1.Text = errors[0];

                return;
            }
            if (errors.Count == 2)
            {
                lblError1.Text = errors[0];
                lblError2.Text = errors[1];

                return;
            }

            // Set user details
            UserDetails.SetUserDetails(response);

            TcpClientProvider.CreateInstance("127.0.0.1", 3000);
            var client = TcpClientProvider.Client!;
            try
            {
                client.Connect();
            }
            catch (Exception)
            {
                lblError1.Text = "Could not reach the chat server";
                return;
            }

            var mainView = new MainView();
            mainView.Show();
            Hide();
        }

        private void registerLink_Click(object sender, EventArgs e)
        {
            var registerView = new RegisterView();
            registerView.Show();
            Hide();
        }
    }
}