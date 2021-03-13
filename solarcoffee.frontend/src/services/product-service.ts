import axios from "axios";
import { Product } from "@/types/Product";

/**
 * Product Service.
 * Provides UI business logic associated with product
 */
export default class ProductService {
  API_URL = process.env.VUE_APP_API_URL;

  public async archive(productId: number): Promise<Product[]> {
    console.log("patch archive", this.API_URL);
    const { data } = await axios.patch(`${this.API_URL}/product/${productId}`);
    return data;
  }
  public async save(product: Product): Promise<Product> {
    console.log("new Product");
    const { data } = await axios.post(`${this.API_URL}/product/`, product);
    return data;
  }
}
