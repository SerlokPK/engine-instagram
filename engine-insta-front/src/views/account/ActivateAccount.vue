<template>
  <div />
</template>

<script>
import { mapActions } from 'vuex';

export default {
    async created() {
        await this.activateAccount(this.$route.params.userKey);
        this.$router.push('/account/login');
    },
    methods: {
        ...mapActions({
            activateAccount: 'activateAccount' 
        })
    }
};
</script>

<style>

</style>