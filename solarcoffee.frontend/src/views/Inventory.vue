<template>
  <div class="inventory-container">
    <h1 id="inventoryTitle">Inventory Dashboard</h1>
    <hr />

    <div class="inventory-actions">
      <solar-button @button:click="showNewProductModal" id="addNewBtn"
        >Add New Item</solar-button
      >
      <solar-button @button:click="showShipmentModal" id="receiveShipmentBtn"
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

      <tr v-for="item in inventory" :key="item.id">
        <td>{{ item.product.name }}</td>
        <td :class="`${applyColor(item.quantityOnHand, item.idealQuantity)}`">
          {{ item.quantityOnHand }}
        </td>
        <td>{{ item.product.price | price }}</td>
        <td>
          <span v-if="item.product.isTaxable">Yes</span>
          <span v-else>No</span>
        </td>
        <td>
          <i
            @click="archiveProduct(item.product.id)"
            class="lni lni-cross-circle product-archive"
          ></i>
        </td>
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
import { InventoryService, ProductService } from "@/services";
import ShipmentModal from "@/components/modal/ShipmentModal.vue";

const inventoryService = new InventoryService();
const productService = new ProductService();

@Component({
  name: "Inventory",
  components: { SolarButton, NewProductModal, ShipmentModal }
})
export default class Inventory extends Vue {
  isNewProductVisible = false;
  isShipmentVisible = false;
  inventory: ProductInventory[] = [];
  public applyColor(current: number, target: number) {
    return current <= 0
      ? "red"
      : Math.abs(target - current) > 8
      ? "yellow"
      : "green";
  }
  async archiveProduct(productId: number) {
    await productService.archive(productId);
    await this.initialize();
  }
  public showNewProductModal(): void {
    this.isNewProductVisible = !this.isNewProductVisible;
  }
  public showShipmentModal() {
    this.isShipmentVisible = !this.isShipmentVisible;
  }
  async saveNewProduct(product: Product) {
    await productService.save(product);
    this.isNewProductVisible = false;
    await this.initialize();
  }
  async saveNewShipment(shipment: Shipment) {
    await inventoryService.updateInventoryQuantity(shipment);
    this.isShipmentVisible = false;
    await this.initialize();
  }
  async initialize() {
    this.inventory = await inventoryService.getInventory();
  }
  async created() {
    await this.initialize();
  }
}
</script>

<style scoped lang="scss">
@import "src/scss/global.scss";

.green {
  font-weight: bold;
  color: $solar-green;
}
.yellow {
  font-weight: bold;
  color: $solar-yellow;
}
.red {
  font-width: bold;
  color: $solar-red;
}
.inventory-actions {
  display: flex;
  margin-bottom: 0.8rem;
}
.product-archive {
  cursor: pointer;
  font-weight: bold;
  font-size: 1.2rem;
  color: $solar-red;
}
</style>
