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

public partial class RoomCodeForm : Form
{
    private TextBox txtRoomCode;
    private Button btnConfirm;
    private Label lblPrompt;

    public string RoomCode => txtRoomCode.Text;

    public RoomCodeForm()
    {
        InitializeComponent();

        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new Size(280, 150);
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.AutoSize = false;
        this.MaximizeBox = false;

        lblPrompt = new Label();
        lblPrompt.Text = "Please insert a room code";
        lblPrompt.Location = new Point(40, 10);
        lblPrompt.Size = new Size(220, 20);

        txtRoomCode = new TextBox();
        txtRoomCode.Location = new Point(20, 40);
        txtRoomCode.Size = new Size(220, 20);

        btnConfirm = new Button();
        btnConfirm.Text = "Confirm";
        btnConfirm.Location = new Point(20, 70);
        btnConfirm.Size = new Size(220, 25);
        btnConfirm.Cursor = Cursors.Hand;
        btnConfirm.Click += new EventHandler(btnConfirm_Click);

        this.Controls.Add(lblPrompt);
        this.Controls.Add(txtRoomCode);
        this.Controls.Add(btnConfirm);
    }

    private void btnConfirm_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
    }
}
