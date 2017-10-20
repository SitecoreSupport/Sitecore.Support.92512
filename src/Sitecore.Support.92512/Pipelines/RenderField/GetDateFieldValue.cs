namespace Sitecore.Support.Pipelines.RenderField
{
    public class GetDateFieldValue : Sitecore.Pipelines.RenderField.GetDateFieldValue
    {
        protected override Sitecore.Xml.Xsl.DateRenderer CreateRenderer()
        {
            return new Sitecore.Support.Xml.Xsl.DateRenderer();
        }
    }
}