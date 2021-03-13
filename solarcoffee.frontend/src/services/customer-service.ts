import axios from "axios";
import { Customer } from "@/types/Customer";
import { ServiceResponse } from "@/types/ServiceResponse";
/* Customer Service.
 * Provides UI business logic associated with customers
 */
export default class CustomerService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getCustomers(): Promise<Customer[]> {
    console.log("getCustomers", this.API_URL + "/customer/");
    const { data } = await axios.get(`${this.API_URL}/customer/`);
    return data;
  }
  public async addCustomer(
    newCustomer: Customer
  ): Promise<ServiceResponse<Customer>> {
    console.log("addCustomer", this.API_URL + "/customer");
    const { data } = await axios.post(`${this.API_URL}/customer`, newCustomer);
    return data;
  }
  public async deleteCustomer(id: number): Promise<ServiceResponse<boolean>> {
    console.log("deleteCustomer", this.API_URL + `/customer/${id}`);
    const { data } = await axios.delete(`${this.API_URL}/customer/${id}`);
    return data;
  }
}
