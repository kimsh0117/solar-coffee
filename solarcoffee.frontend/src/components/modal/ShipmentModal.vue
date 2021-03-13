<template>
  <solar-modal>
    <template v-slot:header>Receive Shipment</template>
    <template v-slot:body>
      <label for="product">Product Received:</label>
      <select id="product" class="shipmentItems" v-model="selectedProduct">
        <option disabled value="">Please select one</option>
        <option v-for="item in inventory" :value="item" :key="item.id">
          {{ item.product.name }}
        </option>
      </select>
      <label for="qtyReceived">Quantity Received:</label>
      <input type="number" id="qtyReceived" v-model="qtyReceived" />
    </template>
    <template v-slot:footer>
      <solar-button
        type="button"
        @button:click="save"
        aria-label="save new shipment"
        >Save Received Shipment</solar-button
      >
      <solar-button type="button" @button:click="close" aria-label="Close modal"
        >Close</solar-button
      >
    </template>
  </solar-modal>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import SolarButton from "@/components/SolarButton.vue";
import SolarModal from "@/components/modal/SolarModal.vue";
import { Shipment } from "@/types/Shipment";
import { Product, ProductInventory } from "@/types/Product";

@Component({
  name: "ShipmentModal",
  components: { SolarButton, SolarModal }
})
export default class ShipmentModal extends Vue {
  @Prop({ required: true, type: Array as () => ProductInventory[] })
  inventory!: ProductInventory[];

  selectedProduct: Product = {
    createdOn: new Date(),
    updatedOn: new Date(),
    id: 0,
    description: "",
    isTaxable: false,
    name: "",
    price: 0,
    isArchived: false
  };

  qtyReceived = 0;
  public save(event: Event) {
    const shipment: Shipment = {
      productId: this.selectedProduct.id,
      adjustment: this.qtyReceived
    };
    this.$emit("save:shipment", shipment);
  }
  public close(event: Event) {
    this.$emit("close");
  }
}
</script>

<style scoped></style>
