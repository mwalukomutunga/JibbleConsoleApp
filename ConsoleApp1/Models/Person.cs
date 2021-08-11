namespace JibbleConsoleClient.Models
{
    public class Person
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object MiddleName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string[] Emails { get; set; }
        public string FavoriteFeature { get; set; }
        public object[] Features { get; set; }
        public AddressInfo[] AddressInfo { get; set; }
        public object HomeAddress { get; set; }
    }

}
