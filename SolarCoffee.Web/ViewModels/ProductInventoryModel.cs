namespace SolarCoffee.Web.ViewModels {
  public class ProductInventoryModel {
    public int id { get; set; }
    public int QuantityOnHand { get; set; }
    public int IdealQuantity { get; set; }
    public ProductModel Product { get; set; }
  }
}
