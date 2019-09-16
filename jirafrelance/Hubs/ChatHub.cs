using jirafrelance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jirafrelance.Hubs
{
    public class ChatHub:Hub
    {
        private readonly UserManager<ApplicationUser> _usermanager;

        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            _usermanager = userManager;
        }
        public async Task SendMessage(Massage message)
        {
            await Clients.All.SendAsync("Recievemessages",new massageContent
            {
                MessageId = message.MessageId,
                sender_id = message.sender_id,
                reciever_id = message.reciever_id,
                message = message.message,
                created_at = message.created_at,
                Recievername = _usermanager.Users.SingleOrDefault(x => x.Id==message.reciever_id)?.UserName,
                Sendername = _usermanager.Users.SingleOrDefault(x => x.Id==message.sender_id)?.UserName,
            });
        }
    }

    public class massageContent
    {
        public int MessageId { get; set; }
        public  string sender_id { get; set; }
        public  string reciever_id { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public string Sendername { get; set; }
        public string Recievername { get; set; }
    }
}
