using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Models;

[Table("rooms", Schema = "server_schema")]
class Room
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
}
