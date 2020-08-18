<template>
  <div class="hero-static">
    <div class="content">
      <b-row class="justify-content-center">
        <b-col
          md="8"
          lg="6"
          xl="4"
        >
          <!-- Sign In Block -->
          <base-block
            themed
            fx-shadow
            class="mb-0"
            :title="'Login'"
          >
            <template #options>
              <router-link
                to="/account/forgotpassword"
                class="btn-block-option font-size-sm"
              >
                Forgot password
              </router-link>
              <router-link
                v-b-tooltip.hover.nofade.left="'Register'"
                to="/account/signup"
                class="btn-block-option"
              >
                <i class="fa fa-user-plus" />
              </router-link>
            </template>
            <div class="p-sm-3 px-lg-4 py-lg-5">
              <h1 class="mb-2">
                Login
              </h1>
              <p>Please login</p>

              <!-- Sign In Form -->
              <b-form @submit.stop.prevent="onSubmit">
                <div class="py-3">
                  <div class="form-group">
                    <b-form-input
                      id="email"
                      v-model="$v.form.email.$model"
                      size="lg"
                      class="form-control-alt"
                      name="email"
                      :placeholder="$t('signin.emailPlaceholder')"
                      :state="!$v.form.email.$error && null"
                      aria-describedby="username-feedback"
                    />
                    <b-form-invalid-feedback id="username-feedback">
                      {{ $t('signin.enterEmail') }}
                    </b-form-invalid-feedback>
                  </div>
                  <div class="form-group">
                    <b-form-input
                      id="password"
                      v-model="$v.form.password.$model"
                      type="password"
                      size="lg"
                      class="form-control-alt"
                      name="password"
                      :placeholder="$t('signin.PasswordPlaceholder')"
                      :state="!$v.form.password.$error && null"
                      aria-describedby="password-feedback"
                    />
                    <b-form-invalid-feedback
                      id="password-feedback"
                    >
                      {{ $t('signin.enterPassword') }}
                    </b-form-invalid-feedback>
                  </div>
                  <div class="form-group">
                    <b-form-checkbox
                      id="remember"
                      name="remember"
                    >
                      {{ $t('signin.rememberMe') }}
                    </b-form-checkbox>
                  </div>
                </div>
                <b-row class="form-group">
                  <b-col
                    md="6"
                    xl="5"
                  >
                    <b-button
                      type="submit"
                      variant="primary"
                      block
                    >
                      <i class="fa fa-fw fa-sign-in-alt mr-1" />
                      {{ $t("signin.signInButton") }}
                    </b-button>
                  </b-col>
                </b-row>
              </b-form>
              <!-- END Sign In Form -->
            </div>
          </base-block>
          <!-- END Sign In Block -->
        </b-col>
      </b-row>
    </div>
    <div class="content content-full font-size-sm text-muted text-center">
      <strong>Neki tekst</strong>
      &copy; Copyright
    </div>
  </div>
</template>

<script>
export default {

};
</script>

<style>

</style>