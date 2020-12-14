<template>
</template>
<script>
export default {
    methods:{
        cerrarSesion(){
            window.localStorage.removeItem('_token');
            window.localStorage.removeItem('_userId');
            window.localStorage.removeItem('_name');
            /* this.$router.push({ name: 'home' }); */
            location.reload();
        }
    },
    mounted(){
        this.cerrarSesion();
    }
}
</script>