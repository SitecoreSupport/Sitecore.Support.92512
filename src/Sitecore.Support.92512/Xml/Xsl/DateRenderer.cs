namespace Sitecore.Support.Xml.Xsl
{
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Data.Managers;
    using Sitecore.Diagnostics;
    public class DateRenderer : Sitecore.Xml.Xsl.DateRenderer
    {
        protected override System.Globalization.CultureInfo GetCultureInfo()
        {
            System.Globalization.CultureInfo cultureInfo = Context.Language.CultureInfo;

            if (cultureInfo != null && cultureInfo.IsNeutralCulture)
            {
                try
                {
                    ID languageItemId = LanguageManager.GetLanguageItemId(Sitecore.Context.Language, Sitecore.Context.Database);
                    if (!languageItemId.IsNull)
                    {
                        Item languageItem = Sitecore.Context.Database.GetItem(languageItemId, Sitecore.Context.Language, Sitecore.Data.Version.Latest);

                        if (languageItem != null)
                        {
                            Field regionalISOCode = languageItem.Fields["{0620F810-9294-4F14-AF9F-F5772EFCA0B2}"];

                            if (regionalISOCode != null && !string.IsNullOrEmpty(regionalISOCode.Value))
                            {
                                try
                                {
                                    cultureInfo = System.Globalization.CultureInfo.GetCultureInfo(regionalISOCode.Value);
                                }
                                catch (System.Exception exception)
                                {
                                    Log.Warn(string.Format("Sitecore.Support.92512: Cannot parse cuture info from RegionalISOCode field '{0}'.", regionalISOCode.Value), exception, this);
                                }
                            }
                        }
                    }
                }
                catch (System.Exception exception)
                {
                    Log.Warn("Sitecore.Support.92512: Cannot retrieve data from RegionalISOCode field.", exception, this);
                }
            }

            string text = Parameters["culture"];
            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    cultureInfo = System.Globalization.CultureInfo.GetCultureInfo(text);
                }
                catch (System.Exception exception)
                {
                    Log.Warn(string.Format("Cannot parse cuture info '{0}'.", text), exception, this);
                }
            }
            return cultureInfo;
        }
    }
}