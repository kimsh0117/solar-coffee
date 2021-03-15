<template>
  <div v-if="timelineBuilt">
    <apexchart
      type="area"
      :width="`100%`"
      height="300"
      :options="options"
      :series="series"
    >
    </apexchart>
  </div>
</template>

<script lang="ts">
import { Vue, Component } from "vue-property-decorator";
import { InventoryTimeline } from "@/types/InventoryGraph";
import { Sync, Get } from "vuex-pathify";
import moment from "moment";
import VueApexCharts from "vue-apexcharts";

Vue.component("apexchart", VueApexCharts);
@Component({ name: "InventoryChart", components: {} })
export default class InventoryChart extends Vue {
  @Sync("snapshotTimeline")
  snapshotTimeline: InventoryTimeline;

  @Get("isTimelineBuilt")
  timelineBuilt?: boolean;
  get options() {
    return {
      dataLabels: { enabled: false },
      fill: {
        type: "gradient"
      },
      stroke: {
        curve: "smooth"
      },
      xaxis: {
        // categories: this.snapshotTimeline.timeline,
        categories: this.snapshotTimeline.timeline.map(t =>
          moment(t).format("dd HHMMss")
        ),
        type: "datetime"
      }
    };
  }
  get series() {
    return this.snapshotTimeline.productInventorySnapshots.map(snapshot => ({
      name: snapshot.productId,
      data: snapshot.quantityOnHand
    }));
  }
  async created() {
    await this.$store.dispatch("assignSnapshots");
  }
}
</script>

<style scoped lang="scss"></style>
