export interface Customer {
  id?: number;
  firstName: string;
  lastName: string;
  primaryAddress: CustomerAddress;
  createdOn?: Date;
  updatedOn?: Date;
}

export interface CustomerAddress {
  id?: number;
  createdOn?: Date;
  updatedOn?: Date;
  addressLine1: string;
  addressLine2: string;
  city: string;
  state: string;
  postalCode: string;
  country: string;
}
