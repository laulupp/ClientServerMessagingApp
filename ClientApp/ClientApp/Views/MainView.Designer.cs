using ClientApp.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClientApp;

partial class MainView : Form
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
        lblFullName = new Label();
        btnAddRoom = new Button();
        pnlChatRooms = new Panel();
        txtMessage = new TextBox();
        btnSend = new Button();
        btnLogout = new Button();
        flpChat = new FlowLayoutPanel();
        SuspendLayout();
        // 
        // lblFullName
        // 
        lblFullName.AutoSize = true;
        lblFullName.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
        lblFullName.Location = new Point(26, 15);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new Size(0, 32);
        lblFullName.TabIndex = 0;
        lblFullName.Text = UserDetails.FirstName + " " + UserDetails.LastName ?? "Firstname Lastname";
        // 
        // btnAddRoom
        // 
        btnAddRoom.Location = new Point(56, 541);
        btnAddRoom.Margin = new Padding(3, 4, 3, 4);
        btnAddRoom.Name = "btnAddRoom";
        btnAddRoom.Size = new Size(144, 43);
        btnAddRoom.TabIndex = 1;
        btnAddRoom.Text = "Add a Room";
        btnAddRoom.UseVisualStyleBackColor = true;
        btnAddRoom.Click += btnAddRoom_Click;
        btnAddRoom.Visible = UserDetails.Level == 0;
        btnAddRoom.Cursor = Cursors.Hand;
        // 
        // pnlChatRooms
        // 
        pnlChatRooms.AutoScroll = true;
        pnlChatRooms.BackColor = SystemColors.ControlLight;
        pnlChatRooms.BorderStyle = BorderStyle.FixedSingle;
        pnlChatRooms.Location = new Point(13, 75);
        pnlChatRooms.Margin = new Padding(3, 4, 3, 4);
        pnlChatRooms.Name = "pnlChatRooms";
        pnlChatRooms.Size = new Size(228, 458);
        pnlChatRooms.TabIndex = 2;
        // 
        // txtMessage
        // 
        txtMessage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
        txtMessage.Location = new Point(249, 541);
        txtMessage.Margin = new Padding(3, 4, 3, 4);
        txtMessage.Name = "txtMessage";
        txtMessage.Size = new Size(621, 39);
        txtMessage.Enabled = UserDetails.ConnectedRoomCode != "";
        txtMessage.TabIndex = 3;
        //
        // btnGenerateRoom
        //
        btnGenerateRoom = new Button();
        btnGenerateRoom.Location = new Point(43, 541);
        btnGenerateRoom.Size = new Size(170, 43);
        btnGenerateRoom.Text = "Generate New Room";
        btnGenerateRoom.UseVisualStyleBackColor = true;
        btnGenerateRoom.Click += btnGenerateRoom_Click;
        btnGenerateRoom.Cursor = Cursors.Hand;
        btnGenerateRoom.Visible = UserDetails.Level == 1;
        // 
        // btnSend
        // 
        btnSend.Location = new Point(878, 541);
        btnSend.Margin = new Padding(3, 4, 3, 4);
        btnSend.Name = "btnSend";
        btnSend.Size = new Size(109, 43);
        btnSend.TabIndex = 4;
        btnSend.Text = "Send";
        btnSend.UseVisualStyleBackColor = true;
        btnSend.Cursor = Cursors.Hand;
        btnSend.Click += btnSend_Click;
        // 
        // btnLogout
        // 
        btnLogout.Location = new Point(878, 12);
        btnLogout.Margin = new Padding(3, 4, 3, 4);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(109, 47);
        btnLogout.TabIndex = 6;
        btnLogout.Text = "Logout";
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // flpChat
        // 
        flpChat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
        flpChat.AutoScroll = true;
        flpChat.BackColor = SystemColors.ControlLightLight;
        flpChat.BorderStyle = BorderStyle.FixedSingle;
        flpChat.FlowDirection = FlowDirection.TopDown;
        flpChat.Location = new Point(249, 75);
        flpChat.Margin = new Padding(3, 4, 3, 4);
        flpChat.Name = "flpChat";
        flpChat.Size = new Size(737, 458);
        flpChat.TabIndex = 7;
        flpChat.WrapContents = false;
        // 
        // MainView
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 600);
        Controls.Add(btnGenerateRoom);
        Controls.Add(btnLogout);
        Controls.Add(txtMessage);
        Controls.Add(btnSend);
        Controls.Add(flpChat);
        Controls.Add(pnlChatRooms);
        Controls.Add(btnAddRoom);
        Controls.Add(lblFullName);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Margin = new Padding(3, 4, 3, 4);
        Name = "MainView";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Chat Application";
        Load += MainView_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private Button btnGenerateRoom;
    private Label lblFullName;
    private Button btnAddRoom;
    private Panel pnlChatRooms;
    private TextBox txtMessage;
    private Button btnSend;
    private FlowLayoutPanel flpChat;
    private Button btnLogout;
}
