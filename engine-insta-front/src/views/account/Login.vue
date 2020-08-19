<template>
  <div>
    <b-form
      @submit.prevent="onSubmit"
    >
      <b-form-group
        label="Email address:"
        label-for="input-1"
      >
        <b-form-input
          id="email"
          v-model="$v.form.email.$model"
          type="email"
          placeholder="Enter email"
          :state="!$v.form.email.$error && null"
        />
        <b-form-invalid-feedback>
          {{ getEmailValidationMessage }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-form-group
        label="Your password:"
        label-for="input-2"
      >
        <b-form-input
          id="password"
          v-model="$v.form.password.$model"
          placeholder="Enter password"
          type="password"
          :state="!$v.form.password.$error && null"
        />
        <b-form-invalid-feedback>
          {{ getPasswordValidationMessage }}
        </b-form-invalid-feedback>
      </b-form-group>

      <b-button
        type="submit"
        variant="primary"
      >
        Submit
      </b-button>
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
          return "Password is required";
        } else if(!this.$v.form.password.passwordValidation) {
          return "Password must have 1 dig...";
        }else {
          return "Password must be 8 char long";
        }
      },
      getEmailValidationMessage() {
        if(!this.$v.form.email.required) {
          return "Email is required";
        } else {
          return "Email format invalid";
        }
      }
    },
    methods: {
      ...mapActions({
        logIn: "logIn"
      }),
      async onSubmit() {
        try {
          console.log(this.$v.form.password);
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