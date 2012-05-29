using System.Web.Mvc;

namespace BuildMonitor.Models
{
    public static class FeatureSwitchExtension
    {
        public static bool FeatureSwitchEnabled(this HtmlHelper helper, string featureName)
        {
            var featureManager = new FeatureManager();

            return featureManager.GetSwitchSetting<bool>(featureName);
        }
    }

    public static class MessageExtension
    {
        public static string GetMessage(this HtmlHelper helper, string messageName)
        {
            var featureManager = new FeatureManager();

            return featureManager.GetSwitchSetting(messageName);
        }
    }

}