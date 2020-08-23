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
              width="65"
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
            size="lg"
            variant="dual"
            class="header-wrapper__dropdown"
            menu-class="p-0 border-0 font-size-lg"
            right
            no-caret
          >
            <template #button-content>
              <span class="d-none d-sm-inline-block ml-1">Adam</span>
              <font-awesome-icon
                class="ml-1 pt-1"
                icon="angle-down"
              />
            </template>
            <li class="header-wrapper__dropdown-items">
              <div class="p-3 text-center bg-primary">
                <img
                  class="img-avatar img-avatar48 img-avatar-thumb"
                  src="img/avatars/avatar10.jpg"
                  alt="Avatar"
                >
              </div>
              <div class="p-2">
                <dropdown-group
                  v-for="(group, index) in dropdownGroups"
                  :key="group.title"
                  :title="group.title"
                  :items="group.items"
                  :add-separator="!index"
                />
              </div>
            </li>
          </b-dropdown>
        </div>
      </div>
    </div>
  </header>
</template>

<script>
import DropdownGroup from '../ui/add-ons/dropdown-group';

export default {
    components: {
        DropdownGroup
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
                            route: '/'
                        },
                    ]
                }
            ]
        };
    }
};
</script>

<style>

</style>