<template>
  <div class="customers-container">
    <h1 id="customersTitle">Manage Customers</h1>
    <hr />
    <div class="customer-actions">
      <solar-button
        type="button"
        @button:click="showNewCustomerModal"
        id="newCustomer"
        >Add Customer</solar-button
      >
    </div>
    <table id="customers" class="table">
      <tr>
        <th>Customer</th>
        <th>Address</th>
        <th>City</th>
        <th>State</th>
        <th>Created On</th>
        <th>Delete</th>
      </tr>
      <tr v-for="user in customers" :key="user.id">
        <td>{{ user.lastName + " " + user.firstName }}</td>
        <td>
          {{
            user.primaryAddress.addressLine1 +
              " " +
              user.primaryAddress.addressLine2
          }}
        </td>
        <td>{{ user.primaryAddress.city }}</td>
        <td>{{ user.primaryAddress.state }}</td>
        <td>
          {{ user.createdOn | humanizeDate }}
        </td>
        <td>
          <i
            @click="deleteUser(user.id)"
            class="lni lni-cross-circle user-delete"
          ></i>
        </td>
      </tr>
    </table>

    <new-customer-modal
      v-if="isNewCustomerVisible"
      @close="showNewCustomerModal"
      @save:customer="addNewCustomer"
    >
    </new-customer-modal>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { SolarButton } from "@/components/";
import { Customer } from "@/types/Customer";
import { CustomerService } from "@/services";
import { NewCustomerModal } from "@/components/modal";

const _customerService = new CustomerService();
@Component({
  name: "Customers",
  components: { NewCustomerModal, SolarButton }
})
export default class Customers extends Vue {
  customers: Customer[] = [];
  isNewCustomerVisible = false;
  public showNewCustomerModal() {
    this.isNewCustomerVisible = !this.isNewCustomerVisible;
  }
  async deleteUser(id: number) {
    await _customerService.deleteCustomer(id);
    await this.initialize();
  }
  async addNewCustomer(newCustomer: Customer) {
    await _customerService.addCustomer(newCustomer);
    this.isNewCustomerVisible = false;
    await this.initialize();
  }
  async initialize() {
    this.customers = await _customerService.getCustomers();
  }
  async created() {
    await this.initialize();
  }
}
</script>

<style scoped lang="scss">
@import "src/scss/global.scss";
.user-delete {
  cursor: pointer;
  font-weight: bold;
  font-size: 1.2rem;
  color: $solar-red;
}
</style>
