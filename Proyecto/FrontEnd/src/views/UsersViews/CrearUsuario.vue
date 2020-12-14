<template>
<div id="ag-grid-demo">
	<vx-card>
		<div id="titulo">
			<h1><strong>Crear Nuevo Usuario</strong></h1>
		</div>
	</vx-card>

	<vx-card>
		<template>
			<!-- Formulario de Nuevo Cliente -->
			<form>
				<vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="6">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|email'" placeholder="william@gmail.com" name="email" v-model="email" class="w-full" icon-pack="feather" icon="icon-mail" icon-no-border label="Correo Electrónico" />
							<span class="text-danger text-sm" v-show="errors.has('email')">{{ errors.first('email') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="6">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|max:30'" placeholder="William Aguirre" name="name" v-model="name" class="w-full" icon-pack="feather" icon="icon-user" icon-no-border label="Nombre" />
							<span class="text-danger text-sm" v-show="errors.has('name')">{{ errors.first('name') }}</span>
						</div>
					</vs-col>
				</vs-row>
				<vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="6">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|alpha_dash|max:30'" placeholder="monowilliam" name="username" v-model="username" class="w-full" icon-pack="feather" icon="icon-users" icon-no-border label="Nombre de Usuario" />
							<span class="text-danger text-sm" v-show="errors.has('username')">{{ errors.first('username') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="6">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|min:6|max:15'" placeholder="Contraseña" name="password" v-model="password" class="w-full" icon-pack="feather" icon="icon-lock" icon-no-border label="Contraseña" />
							<span class="text-danger text-sm" v-show="errors.has('password')">{{ errors.first('password') }}</span>
						</div>
					</vs-col>
				</vs-row>
				<vs-row>
					<vs-col class="details" vs-w="2">
						<vs-button type="filled" @click.prevent="submitForm">Crear</vs-button>
					</vs-col>
					<vs-col class="details" vs-w="10">
						<vs-button color="success" type="filled" class="details" to="/listadoUsuarios">Volver a la lista</vs-button>
					</vs-col>
				</vs-row>
			</form>
		</template>
	</vx-card>
</div>
</template>

<script>
import axios from 'axios'

export default {
	data() {
		return {
			name: '',
			password: '',
			username: '',
			email: '',
		}
	},
	methods: {
		submitForm() {
			this.$validator.validateAll().then(result => {
				if(result) {
					axios.post(this.url.users, {
						"id": 0,
						"email": this.email,
						"name": this.name,
						"password": this.password,
						"username": this.username
						}, { headers: { 'Authorization': this.infoUser.token }
						}).then((res) => {
							this.$vs.notify({
								color:'success',
								title:'Usuario Creado Correctamente',
								iconPack: 'feather', icon:'icon-check'
							});
							this.$router.push({ name: 'listadoUsuarios' });
						}).catch((error) => {
							this.$vs.notify({
								color:'danger',
								title:'No se pudo crear el Usuario. Error en la API',
								text: error,
								iconPack: 'feather', icon:'icon-alert-circle'
						});
					});
				}else{
					this.$vs.notify({
						color:'danger',
						title:'Campos Incorrectos',
						text:'Debes llenar los campos correctamente',
						iconPack: 'feather', icon:'icon-alert-circle'
					});
				}
			})
    	}
	},
	computed: {
		url() {
			return this.$store.state.urlsAPI;
		},
		infoUser(){
			return this.$store.state.loginInfo;
		}
	}
}
</script>

<style scoped>
	.details{
		padding: 10px;
	}
</style>