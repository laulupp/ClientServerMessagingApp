using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp.Views;

public partial class CreateNewRoomView : Form
{
    private TextBox txtRoomName;
    private Button btnConfirm;
    private Label lblPrompt;

    public string RoomName => txtRoomName.Text;

    public CreateNewRoomView()
    {
        InitializeComponent();

        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(280, 160);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.AutoSize = false;
        this.MaximizeBox = false;

        lblPrompt = new Label();
        lblPrompt.Text = "Please insert a room name";
        lblPrompt.Location = new Point(40, 10);
        lblPrompt.Size = new Size(220, 20);

        txtRoomName = new TextBox();
        txtRoomName.Location = new Point(20, 40);
        txtRoomName.Size = new Size(220, 20);

        btnConfirm = new Button();
        btnConfirm.Text = "Confirm";
        btnConfirm.Location = new Point(20, 70);
        btnConfirm.Size = new Size(220, 25);
        btnConfirm.Cursor = Cursors.Hand;
        btnConfirm.Click += new EventHandler(btnConfirm_Click);

        this.Controls.Add(lblPrompt);
        this.Controls.Add(txtRoomName);
        this.Controls.Add(btnConfirm);
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
    }
}
