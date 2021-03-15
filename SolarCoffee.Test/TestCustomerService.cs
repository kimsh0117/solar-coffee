using FluentAssertions;
using Xunit;
using SolarCoffee.Data;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data.Models;
using SolarCoffee.Services.Customer;
using System.Linq;

namespace SolarCoffee.Test {
  public class TestCustomerService {
    [Fact]
    public void CustomerService_GetsAllCustomers_GivenTheyExist() {
      var options = new DbContextOptionsBuilder<SolarDbContext>()
        .UseInMemoryDatabase("gets_all")
        .Options;

      using var context = new SolarDbContext(options);

      var _customerService = new CustomerService(context);

      _customerService.CreateCustomer(new Customer {Id = 123123});
      _customerService.CreateCustomer(new Customer {Id = -123});

      var allCustomers = _customerService.GetAllCustomers();

      allCustomers.Count.Should().Be(2);
    }

    [Fact]
    public void CustomerService_CreatesCustomer_GivenNewCustomerObject() {
      var options = new DbContextOptionsBuilder<SolarDbContext>()
        .UseInMemoryDatabase("Add_writes_to_database")
        .Options;

      using var context = new SolarDbContext(options);

      var sut = new CustomerService(context);

      sut.CreateCustomer(new Customer {Id = 18645});
      context.Customers.Single().Id.Should().Be(18645);
    }

    [Fact]
    public void CustomerService_DeletesCustomer_GivenId() {
      var options = new DbContextOptionsBuilder<SolarDbContext>()
        .UseInMemoryDatabase("deletes_one")
        .Options;

      using var context = new SolarDbContext(options);

      var sut = new CustomerService(context);
      sut.CreateCustomer(new Customer {Id = 123});
      sut.DeleteCustomer(123);

      var allCustomers = sut.GetAllCustomers();
      allCustomers.Count.Should().Be(0);
    }
  }
}
