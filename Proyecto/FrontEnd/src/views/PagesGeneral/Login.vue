<template>
	<div class="h-screen flex w-full vx-row no-gutter items-center justify-center">
		<div class="vx-col sm:w-1/2 md:w-1/2 lg:w-3/4 xl:w-3/5 sm:m-0 m-4">
			<vx-card>
				<div slot="no-body" class="">
					<div class="vx-row no-gutter justify-center items-center">
						<div class="vx-col hidden lg:block lg:w-1/2">
							<img src="@/assets/images/pages/login.png" alt="login" class="mx-auto">
						</div>

						<div class="vx-col sm:w-full md:w-full lg:w-1/2">
							<div class="p-8 login-tabs-container" style="h">
								<div class="vx-card__title mb-4">
									<center>
										<h1 class="mb-5" style="font-weight: 900;">CONCEPTOS MÉDICOS</h1>
										<h2 class="mb-10" style="font-weight: 800;">Iniciar Sesión</h2>
									</center>
								</div>
								<div>
									<form>
										<vs-input name="email" v-validate="'required|email'" icon-no-border icon="icon icon-user" icon-pack="feather" label-placeholder="Correo Electrónico" v-model="email" class="w-full"/>
										<span class="text-danger text-sm" v-show="errors.has('email')">{{ errors.first('email') }}</span>
										<vs-input type="password" name="password" v-validate="'required|max:30'" icon-no-border icon="icon icon-lock" icon-pack="feather" label-placeholder="Contraseña" v-model="password" class="w-full mt-6" />
										<span class="text-danger text-sm" v-show="errors.has('password')">{{ errors.first('password') }}</span>
										<div class="flex flex-wrap justify-between my-5"></div>
										<center>
											<vs-button @click.prevent="submitLogin">INICIAR SESIÓN</vs-button>
										</center>
									</form>
								</div>
							</div>
						</div>
						
					</div>
				</div>
			</vx-card>
		</div>
	</div>
</template>

<script>
import axios from 'axios'

export default{
	data() {
		return {
			email: '',
			password: '',
		}
	},
	methods: {
		submitLogin(){
			this.$validator.validateAll().then(result => {
				if(result) {
					axios.post(this.url.login, {
							"email": this.email,
							"password": this.password
						}).then((res) =>{
							this.$vs.notify({
								color:'success',
								title:`Hola ${res.data.name} Bienvenido`,
								text: 'Iniciaste Sesión Correctamente',
								iconPack: 'feather', icon:'icon-check'
							});
							window.localStorage.setItem('_token', res.data.token);
							window.localStorage.setItem('_userId', res.data.userId);
							window.localStorage.setItem('_name', res.data.name);
							location.reload();
						}).catch((error) => {
							this.$vs.notify({
								color:'danger',
								title:'Error al Iniciar Sesión',
								text: 'Email y Contraseña incorrectas',
								iconPack: 'feather', icon:'icon-alert-circle'
							});
					})
				}else{
					this.$vs.notify({
						color:'danger',
						title:'Campos Incorrectos',
						text:'Debes llenar el email y la contraseña correctamnete',
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