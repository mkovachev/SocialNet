using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNet.Models
{
    public class UserProfile
    {
        private ICollection<FriendShip> friendShips;
        private ICollection<Post> posts;
        private ICollection<Message> massages;
        private ICollection<Image> images;

        public UserProfile()
        {
            this.friendShips = new HashSet<FriendShip>();
            this.posts = new HashSet<Post>();
            this.massages = new HashSet<Message>();
            this.images = new HashSet<Image>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        [Index("Username", 1, IsUnique = true)]
        public string Username { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegisteredOn { get; set; }


        public virtual ICollection<FriendShip> FriendShips
        {
            get => this.friendShips;
            set => this.friendShips = value;
        }


        public virtual ICollection<Post> Posts
        {
            get => this.posts;
            set => this.posts = value;
        }


        public virtual ICollection<Message> Massages
        {
            get => this.massages;
            set => this.massages = value;
        }


        public virtual ICollection<Image> Images
        {
            get => this.images;
            set => this.images = value;
        }
    }
}
