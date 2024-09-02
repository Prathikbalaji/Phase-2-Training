using RepoPatternAsgn.Models;

namespace RepoPatternAsgn.Repository
{
    public interface IRoom
    {
        IEnumerable<Room> getAllRooms();

        public Room AddRoom(Room rm);

    }
}
