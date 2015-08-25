using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading;

namespace SignalRChat.Hubs
{
    [HubName("timeHub")]
    public class TimeHub : Hub
    {
        private Timer _timer;
        private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(100);

        public void TimeUpdate()
        {
            _timer = new Timer(UpdateSpan, null, _updateInterval, _updateInterval);
        }

        private void UpdateSpan(object obj)
        {
            Clients.All.timeupdate(DateTime.Now.ToString());
        }
    }
}