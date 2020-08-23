<template>
  <router-link
    v-if="item.route"
    class="dropdown-item bg-white text-dark router"
    :to="item.route"
  >
    <span>{{ item.text }}</span>
  </router-link>
  <div
    v-else
    class="dropdown-item bg-white text-dark router"
    @click="item.action"
  >
    <span>{{ item.text }}</span>
  </div>
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