<template>
  <header
    class="header-wrapper"
  >
    <div class="container-xl">
      <div class="row align-items-center justify-content-between">
        <router-link to="/">
          <figure>
            <img
              src="@/assets/images/itenginee.jpg"
              alt="IT engine logo"
              width="65"
              class="rounded-circle"
            >
          </figure>
        </router-link>
        <div
          class="d-flex align-items-center w-75 justify-content-between"
        >
          <div class="content w-50">
            <autocomplete :search="search" />
          </div>
          <dropdown-with-actions :groups="dropdownGroups" />
        </div>
      </div>
    </div>
  </header>
</template>

<script>
import { mapActions } from 'vuex';
import DropdownWithActions from '../ui/DropdownWithActions';
import Autocomplete from '@trevoreyre/autocomplete-vue';

export default {
    components: {
        DropdownWithActions,
        Autocomplete
    },
    data() {
        return {
            dropdownGroups: [
                {
                    title: 'Pages',
                    items: [
                        {
                            text: 'Home',
                            route: '/'
                        },
                        {
                            text: 'Profile',
                            route: '/member/profile'
                        },
                    ]
                },
                {
                    title: 'Actions',
                    items: [
                        {
                            text: 'Post a new photo',
                            route: '/'
                        },
                        {
                            text: 'Log out',
                            action: this.logOutAction
                        },
                    ]
                }
            ]
        };
    },
    methods: {
      ...mapActions({
        logOut: 'logOut'
      }),
      logOutAction() {
        this.logOut();
        this.$router.push('/account/login');
      },
      search() {
          return ['prvi', 'drugi', 'treci'];
      }
    }
};
</script>

<style>

</style>