namespace DKCoreShop.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { set; get; }
        string SeoAlias { get; set; }
        string SeoKeywords { get; set; }
        string SeoDescription { get; set; }
    }
}