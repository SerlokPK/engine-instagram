<template>
  <div>
    <preview-mode :user="user" />
    <!-- <b-tabs
      class="block"
      nav-class="nav-tabs-block"
      content-class="block-content overflow-hidden"
    >
      <b-tab
        class="fade-left"
        title="Change username"
      >
        <p>Testcina1</p><p>Testcin1a</p><p>Testci1na</p><p>Test1cina</p><p>Testcina</p>
      </b-tab>
      <b-tab
        class="fade-left"
        title="Title dobnar 2"
      >
        <p>Testcina</p><p>Testcina</p><p>Testcina</p><p>Testcina</p><p>Testcina</p>
      </b-tab>
    </b-tabs> -->
  </div>
</template>

<script>
import PreviewMode from '../../components/ui/Account/PreviewMode';

export default {
  components: {
    PreviewMode
  },
  data() {
    return {
      user: {}
    };
  }
};
</script>

<style>

</style>