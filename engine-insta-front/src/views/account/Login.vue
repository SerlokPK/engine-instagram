<template>
  <div>
    <b-form
      @submit.prevent="onSubmit"
    >
      <b-form-group
        id="input-group-1"
        label="Email address:"
        label-for="input-1"
      >
        <b-form-input
          id="input-1"
          v-model="form.email"
          type="email"
          required
          placeholder="Enter email"
        />
      </b-form-group>

      <b-form-group
        id="input-group-2"
        label="Your password:"
        label-for="input-2"
      >
        <b-form-input
          id="input-2"
          v-model="form.password"
          required
          placeholder="Enter password"
          type="password"
        />
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
          minLength: minLength(8)
        }
      }
    },
    methods: {
      ...mapActions({
        logIn: "logIn"
      }),
      async onSubmit() {
        try {
          await this.logIn(this.form);
          this.$router.push('/');
        } catch(error) {
          // 
        }
      },
    }
};
</script>

<style>

</style>