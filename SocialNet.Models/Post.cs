using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNet.Models
{
    public class Post
    {
        private ICollection<UserProfile> taggedUsers;

        public Post()
        {
            this.taggedUsers = new HashSet<UserProfile>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(10)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PostedOn { get; set; }

        public ICollection<UserProfile> TaggedUsers
        {
            get => this.taggedUsers;
            set => this.taggedUsers = value;
        }
    }
}