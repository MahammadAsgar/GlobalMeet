

using GlobalMeet.DataAccess.Entities.Main;

namespace GlobalMeet.Business.Dtos.User.Post
{
    public class UserReserveMeetDto
    {
        public ICollection<int> ReservedMeetIds { get; set; }
    }
}
