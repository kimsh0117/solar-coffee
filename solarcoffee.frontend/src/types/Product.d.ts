export interface Product {
  id: number;
  createdOn: Date;
  updatedOn: Date;
  name: string;
  description: string;
  price: number;
  isTaxable: boolean;
  isArchived: boolean;
}

export interface ProductInventory {
  id: number;
  quantityOnHand: number;
  idealQuantity: number;
  product: Product;
}
