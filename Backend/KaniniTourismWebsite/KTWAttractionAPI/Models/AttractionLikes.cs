using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTWAttractionAPI.Models
{
    public class AttractionLikes
    {
        [Key]
        public int AttractionLikeId { get; set; }

        public int AttractionId { get; set; }
        [ForeignKey("AttractionId")]
        public Attraction? Attraction { get; set; }

        public int UserId { get; set; }
        public DateTime? LikedDate { get; set; }
       
    }
}
