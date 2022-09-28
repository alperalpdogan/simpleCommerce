namespace SimCom.Web.Models
{
    public class ProductSummaryModel
    {
        public string Name { get; set; }

        public Guid ProductIdentifier { get; set; }

        public decimal SalePrice { get; set; }

        public decimal? ListPrice { get; set; }

        public ProductPictureModel MainPicture { get; set; }
    }

    public class ProductPictureModel
    {
        public string Url { get; set; }
    }
}
