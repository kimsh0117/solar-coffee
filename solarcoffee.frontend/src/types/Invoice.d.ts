import { Product } from "@/types/Product";

export interface Invoice {
  createdOn: Date;
  updatedOn: Date;
  customerId: number;
  lineItems: LineItem[];
}

export interface LineItem {
  product?: Product;
  quantity: number;
}
