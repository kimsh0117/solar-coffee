<template>
  <div class="orders-container">
    <h1 id="ordersTitle">Sales Orders</h1>
    <hr />
    <table class="table" id="sales-orders" v-if="orders.length">
      <thead>
        <tr>
          <th>CustomerId</th>
          <th>OrderId</th>
          <th>Order Total</th>
          <th>Order Status</th>
          <th>Mark Complete</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="lineItem in orders" :key="lineItem.id">
          <td>{{ lineItem.customer.id }}</td>
          <td>{{ lineItem.id }}</td>
          <td>{{ getTotal(lineItem) | price }}</td>
          <td :class="{ green: lineItem.isPaid }">
            {{ getStatus(lineItem.isPaid) }}
          </td>
          <td>
            <div
              v-if="!lineItem.isPaid"
              class="lni lni-checkmark-circle order-complete"
              @click="markComplete(lineItem.id)"
            ></div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { SalesOrder } from "@/types/Order";
import { LineItem } from "@/types/Invoice";
import { OrderService } from "@/services";

const _orderService = new OrderService();

@Component({
  name: "Orders",
  components: {}
})
export default class Orders extends Vue {
  orders: SalesOrder[] = [];
  getStatus(isPaid: boolean) {
    return isPaid ? "Paid in Full" : "Unpaid";
  }
  getTotal(lineItem: SalesOrder) {
    return lineItem.salesOrderItems.reduce(
      (current, item: LineItem) =>
        current + item.quantity * item.product?.price,
      0
    );
  }
  async markComplete(id: number) {
    await _orderService.markOrderComplete(id);
    await this.initialize();
  }
  async initialize(): Promise<void> {
    this.orders = await _orderService.getAllOrders();
  }
  async created() {
    await this.initialize();
  }
}
</script>

<style scoped lang="scss"></style>
