using System;
using System.Collections.Generic;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Locators
{

    public sealed class FluidBranchLocator : IBranchLocator
    {

        #region Constructors

        public FluidBranchLocator()
            : base()
        {
        }

        #endregion

        #region Properties

        public string Name
        {
            get;
            private set;
        }

        public BranchLocatorFlag? Default
        {
            get;
            private set;
        }

        public BranchLocatorFlag? Unspecified
        {
            get;
            private set;
        }

        public BranchLocatorFlag? Branched
        {
            get;
            private set;
        }

        #endregion

        #region Fluid Methods

        public static FluidBranchLocator WithDimensions(string name = null, BranchLocatorFlag? @default = null, BranchLocatorFlag? unspecified = null, BranchLocatorFlag? branched = null)
        {
            var locator = new FluidBranchLocator();
            locator.Name = name;
            locator.Default = @default;
            locator.Unspecified = unspecified;
            locator.Branched = branched;
            return locator;
        }

        public FluidBranchLocator WithName(string name)
        {
            var clone = (FluidBranchLocator)this.MemberwiseClone();
            clone.Name = name;
            return clone;
        }

        public FluidBranchLocator WithDefault(BranchLocatorFlag? @default)
        {
            var clone = (FluidBranchLocator)this.MemberwiseClone();
            clone.Default = @default;
            return clone;
        }

        public FluidBranchLocator WithUnspecified(BranchLocatorFlag? unspecified)
        {
            var clone = (FluidBranchLocator)this.MemberwiseClone();
            clone.Unspecified = unspecified;
            return clone;
        }

        public FluidBranchLocator WithBranched(BranchLocatorFlag? branched)
        {
            var clone = (FluidBranchLocator)this.MemberwiseClone();
            clone.Branched = branched;
            return clone;
        }

        #endregion

        public override string ToString()
        {

            var dimensions = new List<string>();
            
            if (!string.IsNullOrEmpty(this.Name))
            {
                dimensions.Add("name:" + this.Name);
            }
            
            if (this.Default.HasValue)
            {
                dimensions.Add("default:" + this.Default.ToString().ToLowerInvariant());
            }
            
            if (this.Unspecified.HasValue)
            {
                dimensions.Add("unspecified:" + this.Unspecified.ToString().ToLowerInvariant());
            }
            
            if (this.Branched.HasValue)
            {
                dimensions.Add("branched:" + this.Branched.ToString().ToLowerInvariant());
            }

            return string.Join(",", dimensions.ToArray());

        }

    }

}
