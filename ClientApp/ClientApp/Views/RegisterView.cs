using ClientApp.Clients;
using ClientApp.Models;
using ClientApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class RegisterView : Form
    {
        public RegisterView()
        {
            InitializeComponent();
            this.FormClosing += (sender, e) => Application.Exit();
            this.MaximizeBox = false;
        }

        private void loginLink_Click(object sender, EventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
            Hide();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtConfirmPassword.Text.Length == 0)
            {
                lblError1.Text = "Please complete all fields";
                return;
            }
            
            if(txtConfirmPassword.Text != txtPassword.Text)
            {
                lblError1.Text = "The passwords don't match";
                return;
            }

            btnRegister.Enabled = false;
            loginLink.Enabled = false;
            AuthRequest a = new AuthRequest { Username = txtUsername.Text, Password = txtPassword.Text, FirstName = txtFirstName.Text, LastName = txtLastName.Text};
            var response = await AuthClient.RegisterAsync(a);

            lblError1.Text = string.Empty;
            lblError2.Text = string.Empty;

            btnRegister.Enabled = true;
            loginLink.Enabled = true;

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
            if (errors.Count >= 2)
            {
                lblError1.Text = "Please complete all fields";
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
    }
}
