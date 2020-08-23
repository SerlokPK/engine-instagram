<template>
  <div>
    Ovo je smao probno
    <b-button
      variant="danger"
      @click="logOut"
    >
      Log out
    </b-button>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  methods: {
    ...mapActions({
      logOut: 'logOut'
    })
  }
};
</script>

<style>

</style>