using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;

namespace SignalRChat.Hubs
{
    public class UserHub : Hub
    {

        private readonly ChatTicker ticker;

        public UserHub()
        {
            ticker = ChatTicker.Instance;
        }

        public void GetAllUser()
        {
            Clients.All.getAll(ticker.LoadInit());
        }

        public void AddOrUpdate(Models.User user)
        {
            //注册到全局  
            ticker.GlobalContext.Groups.Add(Context.ConnectionId, user.Code);
            ticker.Save(user);
            GetAllUser();
        }
    }

    public class ChatTicker
    {
        private static readonly ChatTicker _instance =
            new ChatTicker(GlobalHost.ConnectionManager.GetHubContext<ChatHub>());

        private static ConcurrentDictionary<string, Models.User> list = new ConcurrentDictionary<string, Models.User>();

        private readonly IHubContext _context;

        private ChatTicker(IHubContext context)
        {
            _context = context;
            Task.Run(() => Sender());
        }

        public IHubContext GlobalContext
        {
            get { return _context; }
        }
        
        public static ChatTicker Instance
        {
            get { return _instance; }
        }

        public void Sender()
        {
            int count = 0;
            while (true)
            {
                Thread.Sleep(500);
                _context.Clients.Group(count.ToString()).getAll(list.Values);
                count++;
            }
        }

        public List<Models.User> LoadInit()
        {
            return list.Values.ToList();
        }

        public void Save(Models.User user)
        {
            list.AddOrUpdate(user.Code, user, (key, oldValue) => user);
            //Models.User value;
            //if (list.TryGetValue(user.Code, out value))
            //{
            //    list.TryUpdate(user.Code, user, value);
            //}
            //else
            //{
            //   list.TryAdd(user.Code, user);
            //}
        }
    }
}