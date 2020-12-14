<!-- Página Donde se muestra la Lista de Conceptos-->
<template>
	<div id="ag-grid-demo">
		<vx-card>
			<div id="titulo">
				<h1><strong>Listado de Conceptos</strong></h1>
			</div>
		</vx-card>

		<!-- Componente de la Tabla de Listado de Usuarias -->
		<div class="vx-row">
			<div class="vx-col w-full">
				<tabla-listado></tabla-listado>				
			</div>
		</div>
  	</div>
</template>

<script>
import TablaListado from './TablaConceptos.vue';

export default {
	components:{
		TablaListado,
	},
	data(){
		return{
		}
	},
}
</script>