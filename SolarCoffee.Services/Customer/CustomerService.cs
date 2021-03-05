using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SolarCoffee.Data;

namespace SolarCoffee.Services.Customer {
  public class CustomerService : ICustomerService {
    private readonly SolarDbContext _db;

    public CustomerService(SolarDbContext dbContext) {
      _db = dbContext;
    }
    /// <summary>
    /// Return a list of Customers from the database
    /// </summary>
    /// <returns>List<Customer></returns>
    public List<Data.Models.Customer> GetAllCustomers() {
       return _db.Customers
         .Include(customer => customer.PrimaryAddress)
         .OrderBy(customer => customer.LastName)
         .ToList();
    }
    /// <summary>
    /// Adds a new Customer record
    /// </summary>
    /// <param name="customer"></param>
    /// <returns>ServiceResponse<Customer></returns>
    /// <exception cref=""></exception>
    public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer) {
      try {
        _db.Customers.Add(customer);
        _db.SaveChanges();
        return new ServiceResponse<Data.Models.Customer> {
          Data = customer,
          Time = DateTime.UtcNow,
          Message = "new customer added",
          IsSuccess = true
        };
      } catch (Exception e) {
        return new ServiceResponse<Data.Models.Customer> {
          Data = customer,
          Time = DateTime.UtcNow,
          Message = e.StackTrace,
          IsSuccess = false,
        };
      }
    }
    /// <summary>
    /// Deletes a customer record
    /// </summary>
    /// <param name="id"></param>
    /// <returns>ServiceResponse<bool></returns>
    /// <exception cref="NotImplementedException"></exception>
    public ServiceResponse<bool> DeleteCustomer(int id) {
      var customer = _db.Customers.Find(id);
      var now = DateTime.UtcNow;
      if (customer == null) {
        return new ServiceResponse<bool> {
          Time = now,
          IsSuccess = false,
          Message = "Customer to delete no found!",
          Data = false,
        };
      }

      try {
        _db.Customers.Remove(customer);
        _db.SaveChanges();
        return new ServiceResponse<bool> {
          Time = now,
          IsSuccess = true,
          Message = "Customer deleted!",
          Data = true,
        };
      }
      catch (Exception e) {
        return new ServiceResponse<bool> {
          Time = now,
          IsSuccess = false,
          Message = e.StackTrace,
          Data = false,
        };
      }
    }
    /// <summary>
    /// Gets a customers record by primary key
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Customer</returns>
    /// <exception cref="NotImplementedException"></exception>
    public Data.Models.Customer GetById(int id) {
      return _db.Customers.FirstOrDefault(c => c.Id == id);
    }
  }
}
