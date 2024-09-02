using RepoPatternAsgn.Models;

namespace RepoPatternAsgn.Repository
{
    public interface IHotel
    {
        public IEnumerable<Hotel> getAll();

        public Hotel AddHotel(Hotel hotel);

    }
}
