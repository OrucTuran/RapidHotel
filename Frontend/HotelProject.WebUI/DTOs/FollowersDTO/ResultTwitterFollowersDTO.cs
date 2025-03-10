namespace HotelProject.WebUI.DTOs.FollowersDTO
{
    public class ResultTwitterFollowersDTO
    {
        public Data data { get; set; }
        public class Data
        {
            public User_Info user_info { get; set; }
        }
        public class User_Info
        {
            public int followers_count { get; set; }
            public int friends_count { get; set; }
        }
    }
}
