using System.ComponentModel.DataAnnotations;

namespace SocialNet.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}