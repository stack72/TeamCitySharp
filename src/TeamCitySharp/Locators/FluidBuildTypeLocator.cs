using System;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Locators
{

    public class FluidBuildTypeLocator : IBuildTypeLocator
    {

        #region Constructors

        private FluidBuildTypeLocator()
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

        public string Name
        {
            get;
            private set;
        }

        #endregion

        #region Fluid Methods

        public static FluidBuildTypeLocator WithId(string id)
        {
            return new FluidBuildTypeLocator { Id = id };
        }

        public static FluidBuildTypeLocator WithName(string name)
        {
            return new FluidBuildTypeLocator { Name = name };
        }

        #endregion

        #region Object Interface

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                return "id:" + Id;
            }
            if (!string.IsNullOrEmpty(Name))
            {
                return "name:" + Name;
            }
            return string.Empty;
        }

        #endregion

    }

}