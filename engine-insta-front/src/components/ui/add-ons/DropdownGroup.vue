<template>
  <div>
    <h5
      v-if="title"
      class="dropdown-header text-uppercase"
    >
      {{ $t(title) }}
    </h5>
    <dropdown-item
      v-for="(item, index) in items"
      :key="index"
      :item="item"
    />
    <div
      v-if="addSeparator"
      role="separator"
      class="dropdown-divider"
    />
  </div>
</template>

<script>
import DropdownItem from './DropdownItem';

export default {
    components: {
        DropdownItem
    },
    props: {
        title: {
            type: String,
            default: ''
        },
        items: {
            type: Array,
            required: true
        },
        addSeparator: {
            type: Boolean,
            default: false
        }
    }
};
</script>

<style>

</style>