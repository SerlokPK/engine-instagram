<template>
  <header
    class="header-wrapper"
  >
    <div class="container-xl">
      <div class="row align-items-center">
        <router-link to="/">
          <figure>
            <img
              src="@/assets/images/itenginee.jpg"
              alt="IT engine logo"
              width="85"
              class="rounded-circle"
            >
          </figure>
        </router-link>
        <div
          class="d-flex align-items-center"
        >
          <div>
            SEARCH
          </div>
          <b-dropdown
            id="dropdown-1"
            text="Username"
            class="m-md-2"
          >
            <b-dropdown-item>First Action</b-dropdown-item>
            <b-dropdown-item>Second Action</b-dropdown-item>
            <b-dropdown-item>Third Action</b-dropdown-item>
          </b-dropdown>
        </div>
      </div>
    </div>
  </header>
</template>

<script>
export default {

};
</script>

<style>

</style>