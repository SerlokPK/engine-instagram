<template>
  <router-link
    class="dropdown-item d-flex align-items-center justify-content-between"
    :to="item.route"
  >
    <span>{{ item.text }}</span>
  </router-link>
</template>

<script>
export default {
    props: {
        item: {
            type: Object,
            required: true
        }
    }
};
</script>

<style>

</style>