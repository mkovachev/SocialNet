using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNet.Models
{
    public class FriendShip
    {
        private ICollection<Message> messages;

        public FriendShip()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        public int SenderId { get; set; }
        public UserProfile Sender { get; set; }

        public int ReceiverId { get; set; }
        public UserProfile Receiver { get; set; }

        public bool ApprovedStatus { get; set; }

        public DateTime? FriendsSince { get; set; }

        public virtual ICollection<Message> Messages
        {
            get => this.messages;
            set => this.messages = value;
        }
    }
}