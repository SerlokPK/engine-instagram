<template>
  <div>
    <preview-mode :user="getUser" />
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import PreviewMode from '../../components/ui/Account/PreviewMode';

export default {
  components: {
    PreviewMode
  },
  computed: {
    ...mapGetters({
      getUser: 'getUser'
    })
  }
};
</script>

<style>

</style>