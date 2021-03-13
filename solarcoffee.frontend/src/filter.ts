import Vue from "vue";
import moment from "moment";

Vue.filter("price", (number: number) =>
  isNaN(number) ? "-" : "$ " + number.toFixed(2)
);

Vue.filter("humanizeDate", (date: Date) => moment(date).format("MMMM Do YYYY"));
