<template>
  <div>
    <div>
      <h3 class="pb-5">
        {{ $t('register.title') }}
      </h3>
    </div>
    <b-form
      @submit.prevent="onSubmit"
    >
      <b-form-group
        :label="$t('register.emailLabel')"
        label-for="email"
      >
        <b-form-input
          id="email"
          v-model="$v.form.email.$model"
          type="email"
          :placeholder="$t('register.emailPlaceholder')"
          :state="!$v.form.email.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getEmailValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
        :label="$t('register.usernameLabel')"
        label-for="username"
      >
        <b-form-input
          id="username"
          v-model="$v.form.username.$model"
          :placeholder="$t('register.usernamePlaceholder')"
          :state="!$v.form.username.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getUsernameValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
        :label="$t('register.passwordLabel')"
        label-for="password"
      >
        <b-form-input
          id="password"
          v-model="$v.form.password.$model"
          :placeholder="$t('register.passwordPlaceholder')"
          type="password"
          :state="!$v.form.password.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getPasswordValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
        :label="$t('register.confirmPasswordLabel')"
        label-for="confirmpassword"
      >
        <b-form-input
          id="confirmpassword"
          v-model="$v.form.confirmPassword.$model"
          :placeholder="$t('register.confirmPasswordPlaceholder')"
          type="password"
          :state="!$v.form.confirmPassword.$error && null"
        />
        <b-form-invalid-feedback>
          {{ $t(getConfirmPasswordValidationMessage) }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-button
        class="mb-2"
        type="submit"
        variant="primary"
      >
        {{ $t('register.submitButton') }}
      </b-button>
    </b-form>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import { validationMixin } from "vuelidate";
import { required, minLength, email, sameAs } from "vuelidate/lib/validators";
import { passwordValidation, noWhitespaceValidation } from '../../helpers/validator';
export default {
mixins: [validationMixin],
    data() {
      return {
        form: {
          email: '',
          username: '',
          password: '',
          confirmPassword: ''
        }
      };
    },
    validations: {
      form: {
        email: {
          required,
          email
        },
        username: {
          required,
          noWhitespaceValidation
        },
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
          return "register.confirmPasswordRequired";
        }else {
          return "register.confirmPasswordNotSame";
        }
      },
      getPasswordValidationMessage() {
        if(!this.$v.form.password.required) {
          return "register.passwordRequired";
        } else if(!this.$v.form.password.passwordValidation) {
          return "register.passwordFormat";
        }else {
          return "register.passwordLength";
        }
      },
      getEmailValidationMessage() {
        if(!this.$v.form.email.required) {
          return "register.emailRequired";
        } else {
          return "register.emailFormat";
        }
      },
      getUsernameValidationMessage() {
        if(!this.$v.form.username.required) {
          return "register.usernameRequired";
        } else {
          return "register.usernameNoWhitespace";
        }
      }
    },
    methods: {
      ...mapActions({
        register: 'register'
      }),
      async onSubmit() {
        try {
          this.$v.form.$touch();
          if (!this.$v.form.$anyError) {
            await this.register(this.form);
            this.$router.push('/login');
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