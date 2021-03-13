<template>
  <solar-modal>
    <template v-slot:header>Add New Item</template>
    <template v-slot:body>
      <ul class="newProduct">
        <li>
          <label for="isTaxable">Is this product taxable?</label>
          <input
            id="isTaxable"
            type="checkbox"
            v-model="newProduct.isTaxable"
          />
        </li>
        <li>
          <label for="productName">Name</label>
          <input id="productName" type="text" v-model="newProduct.name" />
        </li>
        <li>
          <label for="productDesc">Description</label>
          <input
            id="productDesc"
            type="text"
            v-model="newProduct.description"
          />
        </li>
        <li>
          <label for="productPrice">Price (USD)</label>
          <input id="productPrice" type="text" v-model="newProduct.price" />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <solar-button
        type="button"
        @click.native="save"
        aria-label="save new item"
        >Save Product</solar-button
      >
      <solar-button type="button" @click.native="close" aria-label="Close modal"
        >Close</solar-button
      >
    </template>
  </solar-modal>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import SolarButton from "@/components/SolarButton.vue";
import SolarModal from "@/components/modal/SolarModal.vue";
import { Product } from "@/types/Product";

@Component({
  name: "NewProductModal",
  components: { SolarButton, SolarModal }
})
export default class NewProductModal extends Vue {
  newProduct: Product = {
    id: 0,
    createdOn: new Date(),
    updatedOn: new Date(),
    name: "",
    description: "",
    price: 0,
    isTaxable: false,
    isArchived: false
  };

  close(event: Event) {
    this.$emit("close");
  }

  save(event: Event) {
    this.$emit("save:product", this.newProduct);
  }
}
</script>

<style scoped lang="scss">
.newProduct {
  list-style: none;
  padding: 0;
  margin: 0;

  input {
    width: 100%;
    height: 1.8rem;
    margin-bottom: 1.2rem;
    font-size: 1.1rem;
    line-height: 1.3rem;
    padding: 0.2rem;
    color: #555;
  }

  label {
    font-width: bold;
    display: block;
    margin-bottom: 0.3rem;
  }
}
</style>
