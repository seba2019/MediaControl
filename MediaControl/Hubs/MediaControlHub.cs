using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaControl.Hubs
{
    public class MediaControlHub : Hub
    {
        public async Task SendAction(int mediaAction)
        {
            await Clients.Others.SendAsync("MediaAction", mediaAction);
        }
    }
}
