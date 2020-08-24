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
            <autocomplete
              :search="search"
              :placeholder="$t('header.searchPlaceholder')"
              @submit="showUser"
            />
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
                    title: 'header.pagesTitle',
                    items: [
                        {
                            text: 'header.homePage',
                            route: '/'
                        },
                        {
                            text: 'header.profilePage',
                            route: '/member/profile'
                        },
                    ]
                },
                {
                    title: 'header.actionsTitle',
                    items: [
                        {
                            text: 'header.postPhotoAction',
                            route: '/'
                        },
                        {
                            text: 'header.logOutAction',
                            action: this.logOutAction
                        },
                    ]
                }
            ]
        };
    },
    methods: {
      ...mapActions({
        logOut: 'logOut',
        searchUsers: 'searchUsers'
      }),
      logOutAction() {
        this.logOut();
        this.$router.push('/account/login');
      },
      async search(username) {
        if(username?.length > 2) {
          return await this.searchUsers(username);
        }
        return [];
      },
      showUser(username) {
        console.log(username);
      }
    }
};
</script>

<style>

</style>