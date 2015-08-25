using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public void Add(Models.Message data)
        {
            //Call the add method to update clients.
            Clients.All.add(data.name, data.message);
        }

        public void Update(Models.Message data)
        {
            // Update the shape model within our broadcaster
            data.ConnectionId = Context.ConnectionId;
            Clients.AllExcept(data.name, data.message).update(data.name, data.message);
        }
    }
}