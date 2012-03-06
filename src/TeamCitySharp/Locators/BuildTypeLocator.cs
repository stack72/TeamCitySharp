namespace TeamCitySharp.Locators
{
    public class BuildTypeLocator
    {
        public static BuildTypeLocator WithId(string id)
        {
            return new BuildTypeLocator { Id = id };
        }

        public static BuildTypeLocator WithName(string name)
        {
            return new BuildTypeLocator { Name = name };
        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public override string  ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return "id:" + Id;
            }
            return "name:" + Name;
        }
    }
}