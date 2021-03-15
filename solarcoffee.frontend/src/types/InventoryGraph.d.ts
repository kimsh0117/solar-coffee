export interface InventoryTimeline {
  productInventorySnapshots: Snapshot[];
  timeline: Data[];
}

export interface Snapshot {
  productId: number;
  quantityOnHand: number[];
}
