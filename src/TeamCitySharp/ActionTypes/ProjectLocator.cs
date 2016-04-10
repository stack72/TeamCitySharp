namespace TeamCitySharp.ActionTypes
{
    public class ProjectLocator
    {
        public string Id { get; private set; }
        public string Name { get; private set; }

        public static ProjectLocator WithId(string id)
        {
            return new ProjectLocator {Id = id};
        }

        public static ProjectLocator WithName(string name)
        {
            return new ProjectLocator {Name = name};
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return "id:" + Id;
            }
            return "name:" + Name;
        }
    }
}