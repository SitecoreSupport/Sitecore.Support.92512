namespace Sitecore.Support.Xml.Xsl
{
    using Sitecore.Diagnostics;
    public class DateRenderer : Sitecore.Xml.Xsl.DateRenderer
    {
        protected override System.Globalization.CultureInfo GetCultureInfo()
        {
            System.Globalization.CultureInfo cultureInfo = Context.Language.CultureInfo;
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