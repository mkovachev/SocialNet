using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNet.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime SentOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? SeenOn { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public virtual UserProfile Author { get; set; }

        public int FriendShipId { get; set; }
        public virtual FriendShip FriendShip { get; set; }
    }
}