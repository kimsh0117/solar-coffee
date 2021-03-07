<template>
  <div class="inventory-container">
    <h1 id="inventoryTitle">Inventory Dashboard</h1>
    <hr />

    <div class="inventory-actions">
      <solar-button @click.native="showNewProductModal" id="addNewBtn"
        >Add New Item</solar-button
      >
      <solar-button @click.native="showShipmentModal" id="receiveShipmentBtn"
        >Receive Shipment</solar-button
      >
    </div>

    <table id="inventoryTable" class="table">
      <tr>
        <th>Item</th>
        <th>Quantity On-Hand</th>
        <th>Unit Price</th>
        <th>Taxable</th>
        <th>Delete</th>
      </tr>

      <tr v-for="item in inventory" :key="item.Id">
        <td>{{ item.Product.Name }}</td>
        <td>{{ item.QuantityOnHand }}</td>
        <td>{{ item.Product.Price | price }}</td>
        <td>
          <span v-if="item.Product.IsTaxable">Yes</span>
          <span v-else>No</span>
        </td>
        <td><div>X</div></td>
      </tr>
    </table>

    <new-product-modal
      v-if="isNewProductVisible"
      @close="showNewProductModal"
      @save:product="saveNewProduct"
    ></new-product-modal>
    <shipment-modal
      v-if="isShipmentVisible"
      :inventory="inventory"
      @close="showShipmentModal"
      @save:shipment="saveNewShipment"
    ></shipment-modal>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { Product, ProductInventory } from "@/types/Product";
import { Shipment } from "@/types/Shipment";
import SolarButton from "@/components/SolarButton.vue";
import NewProductModal from "@/components/modal/NewProductModal.vue";
import ShipmentModal from "@/components/modal/ShipmentModal";

@Component({
  name: "Inventory",
  components: { SolarButton, NewProductModal, ShipmentModal }
})
export default class Inventory extends Vue {
  isNewProductVisible = false;
  isShipmentVisible = false;
  inventory: ProductInventory[] = [
    {
      Id: 1,
      Product: {
        Id: 1,
        CreatedOn: new Date(),
        UpdatedOn: new Date(),
        Name: "Some Product",
        Description: "blabla",
        Price: 500,
        IsTaxable: true,
        IsArchived: true
      },
      IdealQuantity: 5,
      QuantityOnHand: 100
    },
    {
      Id: 2,
      Product: {
        Id: 2,
        CreatedOn: new Date(),
        UpdatedOn: new Date(),
        Name: "Another Product",
        Description: "blabla",
        Price: 300,
        IsTaxable: false,
        IsArchived: true
      },
      IdealQuantity: 5,
      QuantityOnHand: 40
    }
  ];
  public showNewProductModal(): void {
    this.isNewProductVisible = !this.isNewProductVisible;
  }
  public showShipmentModal() {
    this.isShipmentVisible = !this.isShipmentVisible;
  }
  public saveNewProduct(product: Product) {
    console.log(product);
    return;
  }
  public saveNewShipment(shipment: Shipment) {
    console.log(shipment);
    return;
  }
}
</script>

<style scoped lang="scss"></style>
