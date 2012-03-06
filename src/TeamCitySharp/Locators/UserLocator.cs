namespace TeamCitySharp.Locators
{
    public class UserLocator
    {
        public static UserLocator WithId(string id)
        {
            return new UserLocator { Id = id };
        }

        public static UserLocator WithUserName(string userName)
        {
            return new UserLocator { UserName = userName };
        }

        public string Id { get; private set; }
        public string UserName { get; private set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return "id:" + Id;
            }
            return "username:" + UserName;
        }
    }
}
