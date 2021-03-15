import axios from "axios";
import { ProductInventory } from "@/types/Product";
import { Shipment } from "@/types/Shipment";
import { InventoryTimeline } from "@/types/InventoryGraph";

/**
 * Inventory Service.
 * Provides UI business logic associated with product inventory
 */
export default class InventoryService {
  API_URL = process.env.VUE_APP_API_URL;

  public async getInventory(): Promise<ProductInventory[]> {
    console.log("getInventory", this.API_URL + "/inventory/");
    const { data } = await axios.get(`${this.API_URL}/inventory/`);
    return data;
  }

  public async updateInventoryQuantity(
    shipment: Shipment
  ): Promise<ProductInventory[]> {
    console.log("updateInventoryQuantity", this.API_URL, "/inventory/");
    const { data } = await axios.patch(`${this.API_URL}/inventory/`, shipment);
    return data;
  }

  public async getSnapshotHistory(): Promise<InventoryTimeline> {
    console.log("getSnapshotHistory", this.API_URL, "/inventory/snapshot");
    const { data } = await axios.get(`${this.API_URL}/inventory/snapshot`);
    return data;
  }
}
