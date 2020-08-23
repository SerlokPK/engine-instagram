<template>
  <div class="member-wrapper">
    <app-header />
    <router-view />
  </div>
</template>

<script>
import AppHeader from '../components/app/Header';

export default {
  components: {
    AppHeader
  }
};
</script>

<style>

</style>