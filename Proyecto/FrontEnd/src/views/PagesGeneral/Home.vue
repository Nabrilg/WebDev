<template>
	<div>
		<div class="vx-row">

		<!-- CARD 1: NOMBRE -->
		<div class="vx-col w-full lg:w-1/2 mb-base">
			<vx-card slot="no-body" class="text-center bg-primary-gradient greet-user">
				<feather-icon icon="AwardIcon" class="p-6 mb-8 bg-primary inline-flex rounded-full text-white shadow" svgClasses="h-8 w-8"></feather-icon>
				<h1 class="mb-6 text-white">Hola {{infoUser.name}}</h1>
				<p class="xl:w-3/4 lg:w-4/5 md:w-2/3 w-4/5 mx-auto text-white">Bienvenido a la Plataforma de <strong>Conceptos Médicos</strong> y Gestión de <strong>Usuarios</strong></p>
			</vx-card>
		</div>
		<!-- CARD 2: SUBSCRIBERS GAINED -->
      <div v-for="item in estadisticas" :key="item.icono" class="vx-col w-full sm:w-1/2 md:w-1/2 lg:w-1/4 xl:w-1/4 mb-base">
				<statistics-card-line
					:icon="item.icono"
					:statistic="item.numero"
					:statisticTitle="item.titulo"
					:chartData="item.datos"
					:color="item.color"
					type='area' />
			</div>

      

    </div>
		<div class="vx-row">
			<div v-for="item in botones" :key="item.icono" class="vx-col w-full md:w-1/2 lg:w-1/2 xl:w-1/2">
               	<router-link :to="item.url">
					<statistics-card-line
						hideChart
						class="mb-base"
						:icon="item.icono"
						:statistic="item.titulo"
						:statisticTitle="item.subtitulo" />
               	</router-link>
            </div>
		</div>
	</div>
</template>

<script>
import StatisticsCardLine from '@/components/statistics-cards/StatisticsCardLine.vue'
import axios from 'axios'

export default {
  	components: {
		StatisticsCardLine
	},
	computed:{
        url() {
			return this.$store.state.urlsAPI;
		},
		infoUser(){
			return this.$store.state.loginInfo;
		}
    }, 
  	data() {
		return {
			botones:[
				{
					icono:"UsersIcon",
					titulo:"Listado de Usuarios",
					color:"primary",
					subtitulo:"",
					url:"/listadoUsuarios",
				},
				{
					icono:"UserIcon",
					titulo:"Crear Nuevo Usuario",
					color:"primary",
					subtitulo:"",
					url:"/crearUsuario",
				},
				{
					icono:"ListIcon",
					titulo:"Listado de Conceptos",
					color:"primary",
					subtitulo:"",
					url:"/listadoConceptos",
				},
				{
					icono:"PlusCircleIcon",
					titulo:"Crear Nuevo Concepto",
					color:"primary",
					subtitulo:"",
					url:"/crearConcepto",
				},
			],
			estadisticas:[
				{
					icono: "UsersIcon",
					numero: 20,
					titulo: "Usuarios Registrados",
					color: "success",
					datos: [{
						name: 'Usuarios',
						data: [28, 40, 36, 52, 38, 60, 55]
					}]
				},
				{
					icono: "ListIcon",
					numero: 995,
					titulo: "Conceptos Creados",
					color: "warning",
					datos: [{
						name: 'Conceptos',
						data: [600, 400, 599, 359, 927, 600, 995]
					}]
				}
			],
		}
	},
	methods: {
		cargarUsuarios(){
			axios.get(this.url.users, {
                headers: { 'Authorization': this.infoUser.token }
                }).then((res) => {
					this.estadisticas[0].numero = res.data.length;
                }).catch((error) => {
                    this.$vs.notify({
                        color:'danger',
                        title:'No se pudo conectar a la API users',
                        text: error,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
                    console.error(error);
            })
		},
		cargarConceptos(){
			axios.get(this.url.concepts, {
                headers: { 'Authorization': this.infoUser.token }
                }).then((res) => {
                    this.estadisticas[1].numero = res.data.length;
                }).catch((error) => {
                    this.$vs.notify({
                        color:'danger',
                        title:'No se pudo conectar a la API concepts',
                        text: error,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
                    console.error(error);
            })
		}
	},
	mounted() {
		this.cargarUsuarios();
		this.cargarConceptos();
	}
}
</script>