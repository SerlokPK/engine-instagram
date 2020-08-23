<template>
  <div>
    <div>
      <h3 class="pb-5">
        {{ $t('resetPassword.title') }}
      </h3>
    </div>
    <b-form
      @submit.prevent="onSubmit"
    >
      <b-form-group
        :label="$t('resetPassword.passwordLabel')"
        label-for="password"
      >
        <b-form-input
          id="password"
          v-model="$v.form.password.$model"
          :placeholder="$t('resetPassword.passwordPlaceholder')"
          type="password"
          :state="!$v.form.password.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getPasswordValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
        :label="$t('resetPassword.confirmPasswordLabel')"
        label-for="confirmpassword"
      >
        <b-form-input
          id="confirmpassword"
          v-model="$v.form.confirmPassword.$model"
          :placeholder="$t('resetPassword.confirmPasswordPlaceholder')"
          type="password"
          :state="!$v.form.confirmPassword.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getConfirmPasswordValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <div class="d-flex justify-content-between align-items-center">
        <b-button
          type="submit"
          variant="primary"
        >
          {{ $t('resetPassword.submitButton') }}
        </b-button>
      </div>
    </b-form>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { validationMixin } from "vuelidate";
import { required, sameAs, minLength } from "vuelidate/lib/validators";
import { passwordValidation } from '../../helpers/validator';

export default {
    mixins: [validationMixin],
    data() {
      return {
        form: {
          password: '',
          confirmPassword: ''
        }
      };
    },
    validations: {
      form: {
        password: {
          required,
          minLength: minLength(8),
          passwordValidation
        },
        confirmPassword: {
          required,
          sameAs: sameAs('password')
        }
      }
    },
    computed: {
      getConfirmPasswordValidationMessage() {
        if(!this.$v.form.confirmPassword.required) {
          return "resetPassword.confirmPasswordRequired";
        }else {
          return "resetPassword.confirmPasswordNotSame";
        }
      },
      getPasswordValidationMessage() {
        if(!this.$v.form.password.required) {
          return "resetPassword.passwordRequired";
        } else if(!this.$v.form.password.passwordValidation) {
          return "resetPassword.passwordFormat";
        }else {
          return "resetPassword.passwordLength";
        }
      },
    },
    methods: {
      ...mapActions({
        resetPassword: "resetPassword"
      }),
      async onSubmit() {
        try {
          this.$v.form.$touch();
          if (!this.$v.form.$anyError) {
            this.form = {
                ...this.form,
                resetKey: this.$route.params?.resetKey
            };
            await this.resetPassword(this.form);
            this.$router.push('/account/login');
          }
        } catch(error) {
          // 
        }
      }
    }
};
</script>

<style>

</style>