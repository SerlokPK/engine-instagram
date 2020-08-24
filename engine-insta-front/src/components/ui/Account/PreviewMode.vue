<template>
  <div class="d-flex flex-column align-items-center">
    <b-form-group
      :label="$t('account.emailLabel')"
      label-for="email"
      class="w-50"
    >
      <b-form-input
        id="email"
        v-model="user.email"
        disabled
      />
    </b-form-group>

    <b-form-group
      :label="$t('account.usernameLabel')"
      label-for="username"
      class="w-50"
    >
      <b-form-input
        id="username"
        v-model="user.username"
        disabled
      />
    </b-form-group>

    <b-form-group
      v-if="user.description"
      :label="$t('account.descriptionLabel')"
      label-for="textarea"
      class="w-50"
    >
      <b-form-textarea
        id="textarea"
        v-model="user.description"
        rows="3"
        disabled
        max-rows="6"
      />
    </b-form-group>

    <div class="d-flex justify-content-between w-50 mt-3">
      <b-button
        variant="info"
      >
        {{ $t('account.editButton') }}
      </b-button>
      <b-button
        variant="danger"
      >
        {{ $t('account.deleteButton') }}
      </b-button>
    </div>
  </div>
</template>

<script>
export default {
    props: {
        user: {
            type: Object,
            default: () => {}
        }
    }
};
</script>

<style>

</style>