<template>
  <b-dropdown
    size="lg"
    variant="dual"
    class="header-wrapper__dropdown"
    menu-class="p-0 border-0 font-size-lg"
    right
    no-caret
  >
    <template #button-content>
      <span class="d-none d-sm-inline-block ml-1">Adam</span>
      <font-awesome-icon
        class="ml-1 pt-1"
        icon="angle-down"
      />
    </template>
    <li class="header-wrapper__dropdown-items">
      <div class="p-3 text-center bg-primary">
        <img
          class="img-avatar img-avatar48 img-avatar-thumb"
          src="@/assets/images/itenginee.jpg"
          width="50px"
          alt="Avatar"
        >
      </div>
      <div class="p-2">
        <dropdown-group
          v-for="(group, index) in groups"
          :key="group.title"
          :title="group.title"
          :items="group.items"
          :add-separator="!index"
        />
      </div>
    </li>
  </b-dropdown>
</template>

<script>
import DropdownGroup from '../ui/add-ons/dropdown-group';

export default {
    components: {
        DropdownGroup
    },
    props: {
      groups: {
        type: Array,
        required: true
      }
    }
};
</script>

<style>

</style>