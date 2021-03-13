<template>
  <solar-modal>
    <template v-slot:header>Add New Customer</template>
    <template v-slot:body>
      <ul class="newCustomer">
        <li>
          <label for="firstName">First Name</label>
          <input id="firstName" type="text" v-model="newCustomer.firstName" />
        </li>
        <li>
          <label for="lastName">Last Name</label>
          <input id="lastName" type="text" v-model="newCustomer.lastName" />
        </li>
        <li>
          <label for="address1">Address Line 1</label>
          <input
            id="address1"
            type="text"
            v-model="newCustomer.primaryAddress.addressLine1"
          />
        </li>
        <li>
          <label for="address2">Address Line 2</label>
          <input
            id="address2"
            type="text"
            v-model="newCustomer.primaryAddress.addressLine2"
          />
        </li>
        <li>
          <label for="city">City</label>
          <input
            id="city"
            type="text"
            v-model="newCustomer.primaryAddress.city"
          />
        </li>
        <li>
          <label for="state">State</label>
          <input
            id="state"
            type="text"
            v-model="newCustomer.primaryAddress.state"
          />
        </li>
        <li>
          <label for="country">Country</label>
          <input
            id="country"
            type="text"
            v-model="newCustomer.primaryAddress.country"
          />
        </li>
        <li>
          <label for="postal">Postal Code</label>
          <input
            id="postal"
            type="text"
            v-model="newCustomer.primaryAddress.postalCode"
          />
        </li>
      </ul>
    </template>
    <template v-slot:footer>
      <solar-button
        type="button"
        @click.native="save"
        aria-label="save new customer"
        >Add New Customer</solar-button
      >
      <solar-button type="button" @click.native="close" aria-label="Close modal"
        >Close</solar-button
      >
    </template>
  </solar-modal>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { SolarButton } from "@/components";
import SolarModal from "@/components/modal/SolarModal.vue";
import { Customer } from "@/types/Customer";
@Component({
  name: "NewCustomerModal",
  components: { SolarModal, SolarButton }
})
export default class NewCustomerModal extends Vue {
  newCustomer: Customer = {
    firstName: "",
    lastName: "",
    primaryAddress: {
      addressLine1: "",
      addressLine2: "",
      city: "",
      state: "",
      postalCode: "",
      country: ""
    }
  };
  close(event: Event) {
    this.$emit("close");
  }

  save(event: Event) {
    this.$emit("save:customer", this.newCustomer);
  }
}
</script>

<style scoped lang="scss">
.newCustomer {
  display: flex;
  flex-wrap: wrap;
  list-style: none;
  padding: 0;
  margin: 0;
}
input {
  width: 80%;
  height: 1.8rem;
  //margin: 0.8rem 2rem 0.8rem 0.8rem;
  margin-right: 1rem;
  font-size: 1.1rem;
  line-height: 1.3rem;
  padding: 0.2rem;
  color: #555;
}
label {
  font-weight: bold;
  //margin: 0.8rem;
  //display: block;
}
</style>
