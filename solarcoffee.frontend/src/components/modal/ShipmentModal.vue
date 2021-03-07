<template>
  <solar-modal>
    <template v-slot:header>Receive Shipment</template>
    <template v-slot:body>
      <label for="product">Product Received:</label>
      <select id="product" class="shipmentItems" v-model="selectedProduct">
        <option disabled value="">Please select one</option>
        <option v-for="item in inventory" :value="item" :key="item.Id">
          {{ item.Product.Name }}
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
import SolarButton from "@/components/SolarButton";
import SolarModal from "@/components/modal/SolarModal";
import { ProductInventory, Product } from "@/types/Product";
import { Shipment } from "@/types/Shipment";

@Component({
  name: "ShipmentModal",
  components: { SolarButton, SolarModal }
})
export default class ShipmentModal extends Vue {
  @Prop({ required: true, type: Array as () => ProductInventory[] })
  inventory!: ProductInventory[];

  selectedProduct: Product = {
    CreatedOn: new Date(),
    UpdatedOn: new Date(),
    Id: 0,
    Description: "",
    IsTaxable: false,
    Name: "",
    Price: 0,
    IsArchived: false
  };

  qtyReceived = 0;
  public save(event: Event) {
    const shipment: Shipment = {
      productId: this.selectedProduct.Id,
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
