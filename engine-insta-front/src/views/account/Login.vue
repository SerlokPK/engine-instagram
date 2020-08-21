<template>
  <div>
    <div>
      <h3 class="pb-5">
        {{ $t('login.title') }}
      </h3>
    </div>
    <b-form
      @submit.prevent="onSubmit"
    >
      <b-form-group
        :label="$t('login.emailLabel')"
        label-for="email"
      >
        <b-form-input
          id="email"
          v-model="$v.form.email.$model"
          type="email"
          :placeholder="$t('login.emailPlaceholder')"
          :state="!$v.form.email.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getEmailValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
        :label="$t('login.passwordLabel')"
        label-for="password"
      >
        <b-form-input
          id="password"
          v-model="$v.form.password.$model"
          :placeholder="$t('login.passwordPlaceholder')"
          type="password"
          :state="!$v.form.password.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getPasswordValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <div class="d-flex justify-content-between align-items-center">
        <b-button
          type="submit"
          variant="primary"
        >
          {{ $t('login.submitButton') }}
        </b-button>
        <router-link to="/account/register">
          {{ $t('login.redirectButton') }}
        </router-link>
      </div>
    </b-form>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { validationMixin } from "vuelidate";
import { required, minLength, email } from "vuelidate/lib/validators";
import { passwordValidation } from '../../helpers/validator';

export default {
    mixins: [validationMixin],
    data() {
      return {
        form: {
          email: '',
          password: '',
        }
      };
    },
    validations: {
      form: {
        email: {
          required,
          email
        },
        password: {
          required,
          minLength: minLength(8),
          passwordValidation
        }
      }
    },
    computed: {
      getPasswordValidationMessage() {
        if(!this.$v.form.password.required) {
          return "login.passwordRequired";
        } else if(!this.$v.form.password.passwordValidation) {
          return "login.passwordFormat";
        }else {
          return "login.passwordLength";
        }
      },
      getEmailValidationMessage() {
        if(!this.$v.form.email.required) {
          return "login.emailRequired";
        } else {
          return "login.emailFormat";
        }
      }
    },
    methods: {
      ...mapActions({
        logIn: "logIn"
      }),
      async onSubmit() {
        try {
          this.$v.form.$touch();
          if (!this.$v.form.$anyError) {
            await this.logIn(this.form);
            this.$router.push('/');
          }
        } catch(error) {
          //
        }
      },
    }
};
</script>

<style>

</style>