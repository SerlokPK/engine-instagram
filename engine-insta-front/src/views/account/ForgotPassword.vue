<template>
  <div>
    <div>
      <h3 class="pb-5">
        {{ $t('forgotPassword.title') }}
      </h3>
    </div>
    <div class="pb-2">
      <router-link to="/account/register">
        {{ $t('forgotPassword.registerButton') }}
      </router-link>
    </div>
    <b-form
      @submit.prevent="onSubmit"
    >
      <b-form-group
        :label="$t('forgotPassword.emailLabel')"
        label-for="email"
      >
        <b-form-input
          id="email"
          v-model="$v.form.email.$model"
          type="email"
          :placeholder="$t('forgotPassword.emailPlaceholder')"
          :state="!$v.form.email.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getEmailValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <div class="d-flex justify-content-between align-items-center">
        <b-button
          type="submit"
          variant="primary"
        >
          {{ $t('forgotPassword.submitButton') }}
        </b-button>
        <router-link to="/account/login">
          {{ $t('forgotPassword.loginButton') }}
        </router-link>
      </div>
    </b-form>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { validationMixin } from "vuelidate";
import { required, email } from "vuelidate/lib/validators";

export default {
    mixins: [validationMixin],
    data() {
      return {
        form: {
          email: '',
        }
      };
    },
    validations: {
      form: {
        email: {
          required,
          email
        }
      }
    },
    computed: {
      getEmailValidationMessage() {
        if(!this.$v.form.email.required) {
          return "forgotPassword.emailRequired";
        } else {
          return "forgotPassword.emailFormat";
        }
      }
    },
    methods: {
      ...mapActions({
        forgotPassword: "forgotPassword"
      }),
      async onSubmit() {
        this.$v.form.$touch();
          if (!this.$v.form.$anyError) {
            await this.forgotPassword(this.form);
          }
      },
    }
};
</script>

<style>

</style>