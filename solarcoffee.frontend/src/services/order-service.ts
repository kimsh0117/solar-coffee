import axios from "axios";
import { SalesOrder } from "@/types/Order";
/**
 * Order Service
 * Order UI business logic associated with order
 */

export default class OrderService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getAllOrders(): Promise<SalesOrder[]> {
    console.log("getAllOrders", this.API_URL + "/order");
    const response = await axios.get(`${this.API_URL}/order`);
    return response.data;
  }

  public async markOrderComplete(id: number): Promise<any> {
    const response = await axios.patch(`${this.API_URL}/order/complete/${id}`);
    return response.data;
  }
}
