export interface Product {
  Id: number;
  CreatedOn: Date;
  UpdatedOn: Date;
  Name: string;
  Description: string;
  Price: number;
  IsTaxable: boolean;
  IsArchived: boolean;
}

export interface ProductInventory {
  Id: number;
  QuantityOnHand: number;
  IdealQuantity: number;
  Product: IProduct;
}
