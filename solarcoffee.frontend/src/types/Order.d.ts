import { Customer } from "@/types/Customer";
import { LineItem } from "@/types/Invoice";

export interface SalesOrder {
  id: number;
  createdOn: Date;
  updatedOn?: Date;
  customer: Customer;
  salesOrderItems: LineItem[];
  isPaid: boolean;
}
