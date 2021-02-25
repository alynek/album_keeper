using System;

namespace Backend.Model
{
    public class UserFavoriteMusic
    {
        public Guid Id { get; set; }
        public Guid MusicId { get; set; }
        public Guid UserId { get; set; }
        public Music Music { get; set; }
        public User User { get; set; }
    }
}