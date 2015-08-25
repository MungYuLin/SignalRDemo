using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Models
{
    public class Message
    {
        [Newtonsoft.Json.JsonIgnore]
        public string ConnectionId { get; set; }

        public string name { get; set; }

        public string message { get; set; }
    }
}