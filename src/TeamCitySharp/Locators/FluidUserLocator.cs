namespace TeamCitySharp.Locators
{

    public class FluidUserLocator : IUserLocator
    {

        #region Constructors

        private FluidUserLocator()
            : base()
        {
        }

        #endregion

        #region Properties

        public string Id
        {
            get;
            private set;
        }

        public string UserName
        { 
            get; 
            private set; 
        }

        #endregion

        #region Fluid Methods

        public static FluidUserLocator WithId(string id)
        {
            return new FluidUserLocator { Id = id };
        }

        public static FluidUserLocator WithUserName(string userName)
        {
            return new FluidUserLocator { UserName = userName };
        }

        #endregion

        #region Object Methods

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return "id:" + Id;
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                return "username:" + UserName;
            }
            return string.Empty;
        }

        #endregion

    }

}
