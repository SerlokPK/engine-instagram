<template>
  <div class="member-wrapper">
    <app-header />
    <div class="container-xl pt-5">
      <div class="member-wrapper__content-wrapper">
        <router-view class="member-wrapper__content-wrapper-router-view" />
      </div>
    </div>
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