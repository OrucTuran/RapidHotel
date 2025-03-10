namespace HotelProject.WebUI.DTOs.FollowersDTO
{
    public class ResultLinkedinFollowersDTO
    {
        public Data data { get; set; }
        public class Data
        {
            public int connection_count { get; set; }
            public int follower_count { get; set; }
        }
    }
}
