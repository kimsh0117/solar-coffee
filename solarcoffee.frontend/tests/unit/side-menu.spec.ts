import { mount, shallowMount } from "@vue/test-utils";
import { SideMenu } from "@/components";

describe("SideMenu.vue", () => {
  it("renders correct number of button links", () => {
    const wrapper = mount(SideMenu, {
      propsData: {},
      stubs: ["router-link"],
      slots: {}
    });
    expect(wrapper.findAll("button").length).toBe(4);
  });
});
