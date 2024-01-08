using System.Drawing;
namespace ClientApp;

partial class LoginView
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblUsername = new Label();
        lblError1 = new Label();
        lblError2 = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        btnLogin = new Button();
        lblTitle = new Label();
        registerLink = new Label();
        SuspendLayout();
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblUsername.Location = new Point(137, 138);
        lblUsername.Margin = new Padding(2, 0, 2, 0);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(91, 32);
        lblUsername.TabIndex = 0;
        lblUsername.Text = "Username";
        lblUsername.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblError1
        // 
        lblError1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblError1.ForeColor = Color.Red;
        lblError1.Location = new Point(0, 320);
        lblError1.Margin = new Padding(2, 0, 2, 0);
        lblError1.Name = "lblError1";
        lblError1.Size = new Size(520, 18);
        lblError1.TabIndex = 6;
        lblError1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblError2
        // 
        lblError2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblError2.ForeColor = Color.Red;
        lblError2.Location = new Point(0, 342);
        lblError2.Margin = new Padding(2, 0, 2, 0);
        lblError2.Name = "lblError2";
        lblError2.Size = new Size(520, 18);
        lblError2.TabIndex = 7;
        lblError2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtUsername.Location = new Point(226, 141);
        txtUsername.Margin = new Padding(2, 3, 2, 3);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(183, 29);
        txtUsername.TabIndex = 1;
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblPassword.Location = new Point(137, 192);
        lblPassword.Margin = new Padding(2, 0, 2, 0);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(83, 32);
        lblPassword.TabIndex = 2;
        lblPassword.Text = "Password";
        lblPassword.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtPassword.Location = new Point(226, 193);
        txtPassword.Margin = new Padding(2, 3, 2, 3);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(183, 29);
        txtPassword.TabIndex = 3;
        // 
        // btnLogin
        // 
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        btnLogin.Location = new Point(218, 259);
        btnLogin.Margin = new Padding(2, 3, 2, 3);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(91, 42);
        btnLogin.TabIndex = 4;
        btnLogin.Text = "Login";
        btnLogin.Click += btnLogin_Click;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.Location = new Point(0, 42);
        lblTitle.Margin = new Padding(2, 0, 2, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(549, 42);
        lblTitle.TabIndex = 5;
        lblTitle.Text = "Chat app - Login";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // registerLink
        // 
        registerLink.AutoSize = true;
        registerLink.Cursor = Cursors.Hand;
        registerLink.Location = new Point(146, 376);
        registerLink.Name = "registerLink";
        registerLink.Size = new Size(253, 15);
        registerLink.TabIndex = 8;
        registerLink.Text = "Not registered? Click here to create an account";
        registerLink.Click += registerLink_Click;
        // 
        // LoginView
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(520, 400);
        Controls.Add(registerLink);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(btnLogin);
        Controls.Add(lblTitle);
        Controls.Add(lblError1);
        Controls.Add(lblError2);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(2, 3, 2, 3);
        Name = "LoginView";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Chat app - Login";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblUsername;
    private Label lblPassword;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnLogin;
    private Label lblTitle;
    private Label lblError1;
    private Label lblError2;
    private Label registerLink;
}