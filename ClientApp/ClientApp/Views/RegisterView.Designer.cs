namespace ClientApp;

partial class RegisterView
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
        lblPassword = new Label();
        lblConfirmPassword = new Label();
        lblFirstName = new Label();
        lblLastName = new Label();
        lblError1 = new Label();
        lblError2 = new Label();
        lblError3 = new Label();
        lblError4 = new Label();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        txtConfirmPassword = new TextBox();
        txtFirstName = new TextBox();
        txtLastName = new TextBox();
        btnRegister = new Button();
        lblTitle = new Label();
        loginLink = new Label();
        SuspendLayout();
        // 
        // lblUsername
        // 
        lblUsername.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblUsername.Location = new Point(0, 98);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(236, 30);
        lblUsername.TabIndex = 1;
        lblUsername.Text = "Username";
        lblUsername.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblPassword
        // 
        lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblPassword.Location = new Point(0, 142);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(236, 30);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Password";
        lblPassword.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblConfirmPassword
        // 
        lblConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblConfirmPassword.Location = new Point(0, 188);
        lblConfirmPassword.Name = "lblConfirmPassword";
        lblConfirmPassword.Size = new Size(236, 30);
        lblConfirmPassword.TabIndex = 5;
        lblConfirmPassword.Text = "Confirm Password";
        lblConfirmPassword.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblFirstName
        // 
        lblFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblFirstName.Location = new Point(0, 232);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(236, 30);
        lblFirstName.TabIndex = 7;
        lblFirstName.Text = "First Name";
        lblFirstName.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblLastName
        // 
        lblLastName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
        lblLastName.Location = new Point(0, 278);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(236, 30);
        lblLastName.TabIndex = 9;
        lblLastName.Text = "Last Name";
        lblLastName.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblError1
        // 
        lblError1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblError1.ForeColor = Color.Red;
        lblError1.Location = new Point(0, 375);
        lblError1.Name = "lblError1";
        lblError1.Size = new Size(569, 17);
        lblError1.TabIndex = 12;
        lblError1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblError2
        // 
        lblError2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblError2.ForeColor = Color.Red;
        lblError2.Location = new Point(0, 395);
        lblError2.Name = "lblError2";
        lblError2.Size = new Size(569, 17);
        lblError2.TabIndex = 13;
        lblError2.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblError3
        // 
        lblError3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblError3.ForeColor = Color.Red;
        lblError3.Location = new Point(0, 416);
        lblError3.Name = "lblError3";
        lblError3.Size = new Size(569, 17);
        lblError3.TabIndex = 14;
        lblError3.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblError4
        // 
        lblError4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        lblError4.ForeColor = Color.Red;
        lblError4.Location = new Point(0, 436);
        lblError4.Name = "lblError4";
        lblError4.Size = new Size(569, 17);
        lblError4.TabIndex = 15;
        lblError4.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtUsername.Location = new Point(248, 100);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(200, 29);
        txtUsername.TabIndex = 2;
        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtPassword.Location = new Point(247, 145);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(200, 29);
        txtPassword.TabIndex = 4;
        // 
        // txtConfirmPassword
        // 
        txtConfirmPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtConfirmPassword.Location = new Point(247, 190);
        txtConfirmPassword.Name = "txtConfirmPassword";
        txtConfirmPassword.PasswordChar = '*';
        txtConfirmPassword.Size = new Size(200, 29);
        txtConfirmPassword.TabIndex = 6;
        // 
        // txtFirstName
        // 
        txtFirstName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtFirstName.Location = new Point(247, 235);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(200, 29);
        txtFirstName.TabIndex = 8;
        // 
        // txtLastName
        // 
        txtLastName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        txtLastName.Location = new Point(247, 280);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(200, 29);
        txtLastName.TabIndex = 10;
        // 
        // btnRegister
        // 
        btnRegister.Cursor = Cursors.Hand;
        btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        btnRegister.Location = new Point(238, 326);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(100, 40);
        btnRegister.TabIndex = 11;
        btnRegister.Text = "Register";
        btnRegister.Click += btnRegister_Click;
        // 
        // lblTitle
        // 
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitle.Location = new Point(0, 40);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(600, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Chat app - Register";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // loginLink
        // 
        loginLink.AutoSize = true;
        loginLink.Cursor = Cursors.Hand;
        loginLink.Location = new Point(165, 464);
        loginLink.Name = "loginLink";
        loginLink.Size = new Size(244, 15);
        loginLink.TabIndex = 16;
        loginLink.Text = "Already have an account? Click here to log in";
        loginLink.Click += loginLink_Click;
        // 
        // RegisterView
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(569, 488);
        Controls.Add(loginLink);
        Controls.Add(lblUsername);
        Controls.Add(txtUsername);
        Controls.Add(lblPassword);
        Controls.Add(txtPassword);
        Controls.Add(lblConfirmPassword);
        Controls.Add(txtConfirmPassword);
        Controls.Add(lblFirstName);
        Controls.Add(txtFirstName);
        Controls.Add(lblLastName);
        Controls.Add(txtLastName);
        Controls.Add(btnRegister);
        Controls.Add(lblTitle);
        Controls.Add(lblError1);
        Controls.Add(lblError2);
        Controls.Add(lblError3);
        Controls.Add(lblError4);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Name = "RegisterView";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Chat app - Register";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblUsername;
    private Label lblPassword;
    private Label lblConfirmPassword;
    private Label lblFirstName;
    private Label lblLastName;
    private Label lblTitle;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private TextBox txtConfirmPassword;
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private Label lblError1;
    private Label lblError2;
    private Label lblError3;
    private Label lblError4;
    private Button btnRegister;
    private Label loginLink;
}