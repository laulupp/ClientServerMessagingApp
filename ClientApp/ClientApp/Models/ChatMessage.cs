using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Models;

class ChatMessage
{
    public string? Message { get; set; }
    public string? Username { get; set; }
    public DateTime? CreatedTime { get; set; }
    public Label SentLabel { get; set; }

}
