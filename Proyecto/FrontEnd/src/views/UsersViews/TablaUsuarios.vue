<!-- Componente de la Tabla de Listado de Usuarias -->
<template>
	<vx-card>
		<vs-table v-model="selected" @selected="mostrarDetalles" :data="users" max-items="8" pagination search noDataText="No hay usuarios en tu búsqueda" stripe>
			<!-- Cabecera de la Tabla -->
            <template slot="thead">
				<vs-th sort-key="id">Id</vs-th>
				<vs-th sort-key="email">Correo Electrónico</vs-th>
				<vs-th sort-key="name">Nombre</vs-th>
                <vs-th sort-key="username">Nombre de Usuario</vs-th>
				<vs-th sort-key="password">Contraseña</vs-th>
				<vs-th>Acciones</vs-th>
			</template>
            <!-- Cuerpo de la tabla -->
			<template slot-scope="{data}">
				<vs-tr :data="tr" :key="i" v-for="(tr, i) in data">
					<vs-td :data="data[i].id">
						{{data[i].id}}
					</vs-td>
					<vs-td :data="data[i].email">
						{{data[i].email}}
					</vs-td>
					<vs-td :data="data[i].name">
						{{data[i].name}}
					</vs-td>
                    <vs-td :data="data[i].username">
						{{data[i].username}}
					</vs-td>
					<vs-td :data="data[i].password">
						{{data[i].password}}
					</vs-td>
					<vs-td style="padding-left:0px; padding-right:0px;" :data="data[i].id">
						<center>
						<span class="inline-flex relative">
							<span class="p-1 inline-flex rounded-full feather-icon select-none relative text-primary mb-4" style="background: rgba(var(--vs-success),0.15);" @click="editarUsuario(data[i].id); modalDetalles=false">
								<vs-icon icon="mood" size="25px" color="success"></vs-icon>
								<p style="color:rgba(var(--vs-success)); font-size:10px;">Editar</p>
							</span>
							<span class="p-1 inline-flex rounded-full feather-icon select-none relative text-primary mb-4" style="background: rgba(var(--vs-danger),0.15);" @click="borrarUsuario(data[i].id); modelDetalles=false">
								<vs-icon icon="check_circle" size="25px" color="danger"></vs-icon>
								<p style="color:rgba(var(--vs-danger)); font-size:10px">Eliminar</p>
							</span>
						</span>
						</center>
					</vs-td>
				</vs-tr>
			</template>
		</vs-table>

        <!-- Modal Para Editar un Usuario -->
		<vs-prompt
			title="Editar Usuarios"
			accept-text="Guardar Cambios"
			cancel-text="Cancelar"
			:is-valid="validEdit"
			@cancel="cancelarCambios"
			@accept="aceptarCambios"
			@close="cancelarCambios"
			:active.sync="modalCambios">
			<div class="con-exemple-prompt">
                <form>
                    <vx-input-group class="mb-base">
                        <vs-input v-validate="'required|email'" name="email" icon-pack="feather" icon="icon-mail" label-placeholder="Correo Electrónico" v-model="tmpA.email" />
                        <span class="text-danger text-sm" v-show="errors.has('email')">{{ errors.first('email') }}</span>
                    </vx-input-group>
                    <vx-input-group class="mb-base">
                        <vs-input v-validate="'required|max:30'" name="name" icon-pack="feather" icon="icon-user" label-placeholder="Nombre" v-model="tmpA.name" />
                        <span class="text-danger text-sm" v-show="errors.has('name')">{{ errors.first('name') }}</span>
                    </vx-input-group>
                    <vx-input-group class="mb-base">
                        <vs-input v-validate="'required|alpha_dash|max:30'" name="username" icon-pack="feather" icon="icon-users" label-placeholder="Nombre de Usuario" v-model="tmpA.username" />
                        <span class="text-danger text-sm" v-show="errors.has('username')">{{ errors.first('username') }}</span>
                    </vx-input-group>
                    <vx-input-group class="mb-base">
                        <vs-input v-validate="'required|min:6|max:15'" name="password" icon-pack="feather" icon="icon-lock" label-placeholder="Contraseña" v-model="tmpA.password" />
                        <span class="text-danger text-sm" v-show="errors.has('password')">{{ errors.first('password') }}</span>
                    </vx-input-group>
                </form>         
			</div>
		</vs-prompt>

        <!-- Modal para Detalles de un Usuario -->
        <vs-popup title="Detalles de Usuario" :active.sync="modalDetalles">
            <vs-row>
                <vs-col vs-type="flex" vs-w="4" class="details"><strong>Id</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.id}}</vs-col>
                <vs-col vs-type="flex" vs-w="4" class="details"><strong>Correo Electrónico</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.email}}</vs-col>
                <vs-col vs-type="flex" vs-w="4" class="details"><strong>Nombre</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.name}}</vs-col>
                <vs-col vs-type="flex" vs-w="4" class="details"><strong>Nombre de Usuario</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.username}}</vs-col>
                <vs-col vs-type="flex" vs-w="4" class="details"><strong>Contraseña</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.password}}</vs-col>
                <vs-col vs-type="flex" vs-w="4" class="details">
                    <vs-button color="primary" type="border" @click="modalDetalles=false; modalCambios=true">Editar Usuario</vs-button>
                </vs-col>
                <vs-col vs-type="flex" vs-w="8" class="details">
                    <vs-button color="success" type="border" @click="modalDetalles=false">Volver atrás</vs-button>
                </vs-col>
            </vs-row>
        </vs-popup>

        <!-- Modal para Borrar de un Usuario -->
        <vs-prompt
			title="¿Borrar Usuario?"
			accept-text="Borrar"
			cancel-text="Cancelar"
			:is-valid="validEdit"
			@cancel="cancelarCambios"
			@accept="confirmarBorrado"
			@close="cancelarCambios"
			:active.sync="modalBorrar">
			<div class="con-exemple-prompt">
                <vs-row>
                    <p>¿Estas seguro de borrar el siguiente usuario?</p><br><br> 
                    <vs-col vs-type="flex" vs-w="4" class="details"><strong>Id</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.id}}</vs-col>
                    <vs-col vs-type="flex" vs-w="4" class="details"><strong>Correo Electrónico</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.email}}</vs-col>
                    <vs-col vs-type="flex" vs-w="4" class="details"><strong>Nombre</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.name}}</vs-col>
                    <vs-col vs-type="flex" vs-w="4" class="details"><strong>Nombre de Usuario</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.username}}</vs-col>
                    <vs-col vs-type="flex" vs-w="4" class="details"><strong>Contraseña</strong></vs-col><vs-col vs-type="flex" vs-w="8" class="details">{{tmpA.password}}</vs-col>
                </vs-row>             
			</div>
		</vs-prompt>
	</vx-card>
</template>

<script>
import axios from 'axios'

export default {
	data () {
		return {
            modalCambios: false,
            modalDetalles: false,
            modalConfirmarCambios: false,
            modalBorrar: false,
            selected: [],
			tmpI: 0,
			tmpA: {
			    id: '',
                email: '',
                name: '',
                password: '',
                username: '',
			},
			users: [
				{
                    id: '',
                    email: '',
                    name: '',
                    password: '',
                    username: '',
                },
            ],
		}
	},
	methods: {
		editarUsuario(i){
            for(var j=0; j < this.users.length; j++){
				if( i == this.users[j].id ){
                    this.modalCambios = true;
                    this.tmpI = j;
					this.tmpA.id = this.users[j].id;
			        this.tmpA.name = this.users[j].name;
                    this.tmpA.email = this.users[j].email;
                    this.tmpA.username = this.users[j].username;
                    this.tmpA.password = this.users[j].password;
				}
			}
		},
		mostrarDetalles(tr) {
            if(!this.modalCambios && !this.modalBorrar){
                this.$vs.notify({
                    title: `Seleccionado Usuarios ${tr.id}`,
                    text: `Nombre: ${tr.name}`
                });
                this.tmpA = tr
                this.modalDetalles = true;
            }
		},
		aceptarCambios(){
            this.$validator.validateAll().then(result => {
                if(result) {
                    this.$vs.dialog({
                        type: 'confirm',
                        color: 'warning',
                        title: `Confirmar Cambios`,
                        text: `¿Estas seguro de actualizar los datos para ${this.tmpA.name}?`,
                        accept: this.confirmarCambios,
                    });
                }else{
                    this.$vs.notify({
						color:'danger',
						title:'Campos Incorrectos',
                        text:'Debes llenar los campos correctamente',
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
                    this.modalCambios = true;
                }
            })
        },
        confirmarCambios(){
            this.users[this.tmpI].name = this.tmpA.name;
            this.users[this.tmpI].username = this.tmpA.username;
            this.users[this.tmpI].email = this.tmpA.email;
            this.users[this.tmpI].password = this.tmpA.password;
            axios.put(this.url.users + `/${this.tmpA.id}`, {
                    "id": this.tmpA.id,
                    "email": this.tmpA.email,
                    "name": this.tmpA.name,
                    "password": this.tmpA.password,
                    "username": this.tmpA.username
                }, { headers: { 'Authorization': this.infoUser.token }
                }).then((res) => {
                    this.$vs.notify({
                        color:'success',
                        title:'Usuario Actualizado Correctamente',
                        iconPack: 'feather', icon:'icon-check'
                    });
                }).catch((error) => {
                    this.$vs.notify({
                        color:'danger',
                        title: 'Error al Actualizar',
                        text: `No se pudo actualizar los Datos de ${this.tmpA.name}. Error en la API`,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
            });
        },
		cancelarCambios() {
            this.$vs.notify({
				color:'danger',
				title:'Cambios Cancelados',
			});
        },
        borrarUsuario(i){
            for(var j=0; j < this.users.length; j++){
				if( i == this.users[j].id ){
                    this.modalBorrar = true;
                    this.tmpI = j;
					this.tmpA.id = this.users[j].id;
			        this.tmpA.name = this.users[j].name;
                    this.tmpA.email = this.users[j].email;
                    this.tmpA.username = this.users[j].username;
                    this.tmpA.password = this.users[j].password;
				}
			}
        },
        confirmarBorrado(){
            axios.delete(this.url.users + `/${this.tmpA.id}`, {
                headers: {
                    'Authorization': this.infoUser.token
                }
                }).then((res) => {
                    this.$vs.notify({
                        color:'success',
                        title:'Usuario Borrado Correctamente',
                        iconPack: 'feather', icon:'icon-check'
                    });
                    delete this.users.splice(parseInt(this.tmpI), 1);
                }).catch((error) => {
                    console.log(error);
                    this.$vs.notify({
                        color:'danger',
                        title:'Error al Borrar',
                        text: `No se pudo borrar el usuario ${this.tmpA.name}. Error en la API`,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
            })
        },
        cargarUsuarios(){
            axios.get(this.url.users, {
                headers: {
                    'Authorization': this.infoUser.token
                }
                }).then((res) => {
                    this.users = res.data;
                }).catch((error) => {
                    this.$vs.notify({
                        color:'danger',
                        title:'No se puede cargar la Tabla. Error en la API',
                        text: error,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
                    console.error(error);
            })
        },
	},
	computed:{
		validEdit(){
            return (this.tmpA.name.length > 0 && 
                    this.tmpA.password.length > 0 && 
                    this.tmpA.username.length > 0 && 
                    this.tmpA.email.length > 0)
        },
        url() {
			return this.$store.state.urlsAPI;
		},
		infoUser(){
			return this.$store.state.loginInfo;
		}
    },
    mounted() {
        this.cargarUsuarios();
    },
}
</script>


<style lang="scss">
    .details{
        padding: 10px;
    }
</style>