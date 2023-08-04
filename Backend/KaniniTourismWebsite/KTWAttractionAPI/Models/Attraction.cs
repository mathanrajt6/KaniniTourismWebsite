using KTWAttractionAPI.Models.StaticTable;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTWAttractionAPI.Models
{
    public class Attraction
    {
        public int AttractionId { get; set; }
        public int SpecialityId { get; set; }
        [ForeignKey("SpecialityId")]
        public Speciality? Speciality { get; set; }
        public string? ImgUrl { get; set; }
        public int? UserId { get; set; }
        public string? AttractionDescription { get; set; }
        public string? address { get; set; }
        public int CityId  { get; set; }
        [ForeignKey("CityId")]
        public City? City { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public State? State { get; set; }
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Likes { get; set; } 
    }
}
