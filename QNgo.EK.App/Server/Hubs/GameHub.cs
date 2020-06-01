using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QNgo.EK.App.Server.Hubs
{
    public class GameHub : Hub
    {
        public async void Send()
        {
            await Clients.All.SendAsync("Test", DateTime.Now.ToString());
        }
    }
}
