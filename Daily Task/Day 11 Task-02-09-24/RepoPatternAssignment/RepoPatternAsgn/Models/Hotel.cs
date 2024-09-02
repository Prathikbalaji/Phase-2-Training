using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepoPatternAsgn.Models
{
    public class Hotel
    {
        [Key]
        [Column("HotelID")]
        public int HotelId { get; set; }
        [StringLength(20,ErrorMessage ="Invalid Name",MinimumLength = 5)]
        public string HotelName { get; set; }

        public ICollection<Room>? Rooms { get; set; }

    }
}
