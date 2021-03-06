using System;
using System.ComponentModel.DataAnnotations;

namespace SolarCoffee.Web.ViewModels {
  public class CustomerModel {
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    [MaxLength(32)] public string FirstName { get; set; }
    [MaxLength(32)] public string LastName { get; set; }
    public CustomerAddressModel PrimaryAddress { get; set; }
  }

  public class CustomerAddressModel {
    public int Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    [MaxLength(100)] public string AddressLine1 { get; set; }
    [MaxLength(100)] public string AddressLine2 { get; set; }
    [MaxLength(100)] public string City { get; set; }
    [MaxLength(2)] public string State { get; set; }
    [MaxLength(10)] public string PostalCode { get; set; }
    [MaxLength(32)] public string Country { get; set; }
  }
}
