import axios from "axios";
import { Invoice } from "@/types/Invoice";
/**
 * Invoice Service
 * Invoice UI business logic associated with invoice
 */
export default class InvoiceService {
  API_URL = process.env.VUE_APP_API_URL;

  public async makeNewInvoice(invoice: Invoice): Promise<boolean> {
    console.log("makeNewInvoice", this.API_URL + "/invoice/");
    const now = new Date();
    invoice.createdOn = now;
    invoice.updatedOn = now;
    const response = await axios.post(`${this.API_URL}/invoice/`, invoice);
    return response.data;
  }
}
