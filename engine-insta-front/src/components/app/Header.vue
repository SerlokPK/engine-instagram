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
          class="header-wrapper__search"
        >
          <div class="content w-50">
            <autocomplete
              :search="search"
              :placeholder="$t('header.searchPlaceholder')"
              @submit="goToProfile"
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
                            text: 'header.accountPage',
                            route: '/member/account'
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
        return username?.length > 2 ? await this.searchUsers(username) : [];
      },
      goToProfile(username) {
        this.$router.push(`/member/profile/${username}`);
      }
    }
};
</script>

<style>

</style>