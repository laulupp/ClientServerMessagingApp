using ClientApp.Models;
using ClientApp.Services;
using ClientApp.Views;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class MainView : Form
    {
        private Button currentSelectedRoomButton = null;
        public MainView()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormClosing += (sender, e) =>
            {
                TcpClientProvider.Client?.CloseConnection();
                Application.Exit();
            };
            TcpClientProvider.Client.MessageReceived += OnMessageReceived;
        }

        private void AddChatRooms(List<Room> rooms)
        {
            foreach (var room in rooms)
            {
                var btnRoom = new Button
                {
                    Text = $"{room.Name} - {room.Code}",
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    Height = 45
                };
                pnlChatRooms.Controls.Add(btnRoom);
                pnlChatRooms.Controls.SetChildIndex(btnRoom, 0);
                btnRoom.Click += (sender, e) => RoomButton_Click(room.Code);
                btnRoom.Cursor = Cursors.Hand;
            }
        }

        private void RoomButton_Click(string roomCode)
        {
            if (currentSelectedRoomButton != null)
            {
                currentSelectedRoomButton.Enabled = true;
                currentSelectedRoomButton.BackColor = SystemColors.Control;
            }

            foreach (Button btn in pnlChatRooms.Controls.OfType<Button>())
            {
                if (btn.Text.Contains(roomCode))
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.Aqua;
                    currentSelectedRoomButton = btn;
                    break;
                }
            }

            TcpClientProvider.Client!.Send(new ActionMessage
            {
                Username = UserDetails.Username,
                Token = UserDetails.Token,
                Action = Models.Action.EnterRoom,
                RoomCode = roomCode
            });
        }

        private void AddMessage(ChatMessage message, bool isMessageSent)
        {
            var isCurrentUserMsg = message.Username == UserDetails.Username;
            var messageControl = CreateMessageControl(message, isCurrentUserMsg, isCurrentUserMsg && isMessageSent);
            messageControl.Tag = UserDetails.CurrentMessageId;
            flpChat.Controls.Add(messageControl);
            flpChat.ScrollControlIntoView(messageControl);
            flpChat.PerformLayout();
        }

        private Control CreateMessageControl(ChatMessage message, bool isUserMessage, bool isSentVisible)
        {
            int panelWidth = 400;
            int horizontalPadding = 20;
            int verticalPadding = 20;

            var lblSender = new Label
            {
                Text = UserDetails.GetSenderDisplayName() + " " + message.CreatedTime.Value.ToShortTimeString(),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                AutoSize = true,
                MaximumSize = new Size(panelWidth - horizontalPadding, 0)
            };

            var lblMessage = new Label
            {
                Text = message.Message,
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                MaximumSize = new Size(panelWidth - horizontalPadding, 0)
            };

            var lblSent = new Label
            {
                Name = "lblSent",
                Text = "Sent",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                AutoSize = true,
                Visible = isSentVisible
            };
            message.SentLabel = lblSent;
            lblSent.Location = new Point(panelWidth - 40, lblSender.Location.Y + 5);


            var senderHeight = lblSender.GetPreferredSize(new Size(panelWidth - horizontalPadding, 0)).Height;
            var messageHeight = lblMessage.GetPreferredSize(new Size(panelWidth - horizontalPadding, 0)).Height;

            var totalHeight = senderHeight + messageHeight + verticalPadding;

            var messagePanel = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15),
                Size = new Size(panelWidth, totalHeight)
            };

            lblSender.Location = new Point(5, 5);
            lblMessage.Location = new Point(5, senderHeight + 10);

            messagePanel.Controls.Add(lblSent);
            messagePanel.Controls.Add(lblSender);
            messagePanel.Controls.Add(lblMessage);


            var containerPanel = new Panel
            {
                Width = flpChat.ClientSize.Width - 30,
                Height = totalHeight,
            };

            if (flpChat.VerticalScroll.Visible == true)
            {
                containerPanel.Width += SystemInformation.VerticalScrollBarWidth;
            }

            containerPanel.Controls.Add(messagePanel);

            if (isUserMessage)
            {
                messagePanel.Dock = DockStyle.Right;
            }
            else
            {
                lblSender.Text = message.Username + " " + message.CreatedTime.Value.ToLocalTime().ToShortTimeString();
                messagePanel.Dock = DockStyle.Left;
            }

            return containerPanel;
        }

        private Control FindControlRecursive(Control root, string name)
        {
            if (root.Name == name) return root;

            foreach (Control c in root.Controls)
            {
                Control foundControl = FindControlRecursive(c, name);
                if (foundControl != null) return foundControl;
            }

            return null;
        }

        public void UpdateMessage(int messageId)
        {
            var messageControl = flpChat.Controls.OfType<Panel>().FirstOrDefault(p => p.Tag != null && (int)p.Tag == messageId + 1);
            if (messageControl != null)
            {
                var lblSent = FindControlRecursive(messageControl, "lblSent") as Label;
                if (lblSent != null)
                {
                    lblSent.Visible = true;
                }

            }
        }

        private void btnGenerateRoom_Click(object sender, EventArgs e)
        {
            using (var newRoomForm = new CreateNewRoomView())
            {
                if (newRoomForm.ShowDialog(this) == DialogResult.OK)
                {
                    string roomName = newRoomForm.RoomName;
                    TcpClientProvider.Client!.Send(new ActionMessage
                    {
                        Username = UserDetails.Username,
                        Token = UserDetails.Token,
                        RoomName = roomName,
                        Action = Models.Action.CreateRoom
                    });
                    btnGenerateRoom.Enabled = false;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            TcpClientProvider.Client!.Send(new ActionMessage
            {
                Username = UserDetails.Username,
                Token = UserDetails.Token,
                RoomCode = UserDetails.ConnectedRoomCode,
                MessageId = UserDetails.CurrentMessageId++,
                Action = Models.Action.SendMessage,
                Message = txtMessage.Text
            });
            AddMessage(new ChatMessage
            {
                Message = txtMessage.Text,
                Username = UserDetails.Username,
                CreatedTime = DateTime.Now
            }, false);
            txtMessage.Text = "";
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            using (var roomCodeForm = new RoomCodeForm())
            {
                if (roomCodeForm.ShowDialog(this) == DialogResult.OK)
                {
                    string roomCode = roomCodeForm.RoomCode;
                    TcpClientProvider.Client!.Send(new ActionMessage
                    {
                        Username = UserDetails.Username,
                        Token = UserDetails.Token,
                        RoomCode = roomCode,
                        Action = Models.Action.JoinRoom,
                    });
                }
                btnAddRoom.Enabled = false;
            }
        }

        private void OnMessageReceived(ResponseMessage message)
        {
            Invoke((MethodInvoker)delegate
            {
                if(message.Error != null)
                {
                    MessageBox.Show(message.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAddRoom.Enabled = true;
                }

                if(message.Confirmation != null)
                {
                    MessageBox.Show(message.Confirmation, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnGenerateRoom.Enabled = true;
                }

                if (message.ReceivedMessage != null && message.ReceivedMessage.Value && message.Message != null)
                {
                    AddMessage(new ChatMessage
                    {
                        Message = message.Message.Message,
                        Username = message.Message.Username,
                        CreatedTime = message.Message.CreatedTime
                    }, true);
                    return;
                }

                if (message.MessageId != null)
                {
                    UpdateMessage(message.MessageId.Value);
                }

                if (message.Rooms != null)
                {
                    AddChatRooms(message.Rooms);
                    btnAddRoom.Enabled = true;
                }

                if (message.Messages != null && message.RoomCode != null)
                {
                    flpChat.Controls.Clear();
                    UserDetails.ConnectedRoomCode = message.RoomCode;
                    txtMessage.Enabled = true;
                    foreach (var v in message.Messages)
                    {
                        if (v != null)
                        {
                            AddMessage(v, true);
                        }
                    }
                }
            });
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserDetails.Username = "";
            UserDetails.FirstName = "";
            UserDetails.LastName = "";
            UserDetails.Level = 0;
            UserDetails.Token = "";
            UserDetails.ConnectedRoomCode = "";
            UserDetails.CurrentMessageId = 0;
            TcpClientProvider.Client?.CloseConnection();
            LoginView loginView = new LoginView();
            this.Hide();
            loginView.Show();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            TcpClientProvider.Client!.Send(new ActionMessage
            {
                Username = UserDetails.Username,
                Token = UserDetails.Token,
                Action = Models.Action.GetRooms
            });
        }
    }
}
