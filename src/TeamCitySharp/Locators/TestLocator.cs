using System;

namespace TeamCitySharp.Locators
{
    public class TestLocator
    {
        public static TestLocator WithId(string id)
        {
            return new TestLocator { Id = id };
        }

        public static TestLocator WithName(string number)
        {
            return new TestLocator { Name = number };
        }

        public string Id { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return string.Format("id:{0}", Id);
            }
            if (!string.IsNullOrEmpty(Name))
            {
                return string.Format("name:{0}", Name);
            }        

            throw new Exception("TestLocator properties are not initialized");
        }
    }
}