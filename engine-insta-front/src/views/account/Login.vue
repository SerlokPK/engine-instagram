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
          Invalid email format
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
          Password must have 8 characters
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