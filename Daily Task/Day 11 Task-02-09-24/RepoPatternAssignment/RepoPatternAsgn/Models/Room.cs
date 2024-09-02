using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RepoPatternAsgn.Models
{
    public class Room
    {
        [Key]
        [Column("RoomID")]
        public int RoomID { get; set; }
        public int RoomNo { get; set; }
        public string? RoomType { get; set; }
        public decimal Price { get; set; }
        public int HotelID { get; set; }
        [ForeignKey("HotelID")]

        public Hotel? hotel { get; set; }

    }
}
