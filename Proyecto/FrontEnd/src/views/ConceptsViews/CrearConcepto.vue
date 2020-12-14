<template>
<div id="ag-grid-demo">
	<vx-card>
		<div id="titulo">
			<h1><strong>Crear Nuevo Concepto</strong></h1>
		</div>
	</vx-card>

	<vx-card>
		<template>
			<!-- Formulario de Nuevo Cliente -->
			<form>
				<vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="D" name="pxordx" v-model="pxordx" class="w-full" icon-pack="feather" icon-no-border label="Pxordx" />
							<span class="text-danger text-sm" v-show="errors.has('pxordx')">{{ errors.first('pxordx') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="D" name="Oldpxordx" v-model="oldpxordx" class="w-full" icon-pack="feather" icon-no-border label="Oldpxordx" />
							<span class="text-danger text-sm" v-show="errors.has('Oldpxordx')">{{ errors.first('oldpxordx') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="I09" name="codeType" v-model="codeType" class="w-full" icon-pack="feather" icon-no-border label="Code Type" />
							<span class="text-danger text-sm" v-show="errors.has('codeType')">{{ errors.first('codeType') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:100'" placeholder="3-dig nonbill" name="concept_Class_Id" v-model="concept_Class_Id" class="w-full" icon-pack="feather" icon-no-border label="Concept Class Id" />
							<span class="text-danger text-sm" v-show="errors.has('concept_Class_Id')">{{ errors.first('concept_Class_Id') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|integer|max:10'" placeholder="44829696" name="concept_Id" v-model="concept_Id" class="w-full" icon-pack="feather" icon-no-border label="Concept Id" />
							<span class="text-danger text-sm" v-show="errors.has('concept_Id')">{{ errors.first('concept_Id') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:100'" placeholder="ICD9CM" name="vocabulary_Id" v-model="vocabulary_Id" class="w-full" icon-pack="feather" icon-no-border label="Vocabulary Id" />
							<span class="text-danger text-sm" v-show="errors.has('vocabulary_Id')">{{ errors.first('vocabulary_Id') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:100'" placeholder="Condition" name="domain_Id" v-model="domain_Id" class="w-full" icon-pack="feather" icon-no-border label="Domain Id" />
							<span class="text-danger text-sm" v-show="errors.has('domain_Id')">{{ errors.first('domain_Id') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:100'" placeholder="Medical" name="track" v-model="track" class="w-full" icon-pack="feather" icon-no-border label="Track" />
							<span class="text-danger text-sm" v-show="errors.has('track')">{{ errors.first('track') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="Normal" name="standard_Concept" v-model="standard_Concept" class="w-full" icon-pack="feather" icon-no-border label="Standard Concept" />
							<span class="text-danger text-sm" v-show="errors.has('standard_Concept')">{{ errors.first('standard_Concept') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|max:10'" placeholder="1" name="code" v-model="code" class="w-full" icon-pack="feather" icon-no-border label="code" />
							<span class="text-danger text-sm" v-show="errors.has('code')">{{ errors.first('code') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="1" name="codeWithPeriods" v-model="codeWithPeriods" class="w-full" icon-pack="feather" icon-no-border label="Code With Periods" />
							<span class="text-danger text-sm" v-show="errors.has('codeWithPeriods')">{{ errors.first('codeWithPeriods') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="ICD9DIAG" name="codeScheme" v-model="codeScheme" class="w-full" icon-pack="feather" icon-no-border label="Code Scheme" />
							<span class="text-danger text-sm" v-show="errors.has('codeScheme')">{{ errors.first('codeScheme') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:500'" placeholder="Cholera" name="long_Desc" v-model="long_Desc" class="w-full" icon-pack="feather" icon-no-border label="Long Desc" />
							<span class="text-danger text-sm" v-show="errors.has('long_Desc')">{{ errors.first('long_Desc') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:255'" placeholder="Cholera 1" name="short_Desc" v-model="short_Desc" class="w-full" icon-pack="feather" icon-no-border label="Short Desc" />
							<span class="text-danger text-sm" v-show="errors.has('short_Desc')">{{ errors.first('short_Desc') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="I" name="code_Status" v-model="code_Status" class="w-full" icon-pack="feather" icon-no-border label="Code Status" />
							<span class="text-danger text-sm" v-show="errors.has('code_Status')">{{ errors.first('code_Status') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="Deleted" name="code_Change" v-model="code_Change" class="w-full" icon-pack="feather" icon-no-border label="Code Change" />
							<span class="text-danger text-sm" v-show="errors.has('code_Change')">{{ errors.first('code_Change') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|integer|max:5'" placeholder="2015" name="code_Change_Year" v-model="code_Change_Year" class="w-full" icon-pack="feather" icon-no-border label="Code Change Year" />
							<span class="text-danger text-sm" v-show="errors.has('code_Change_Year')">{{ errors.first('code_Change_Year') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="UP" name="code_Planned_Type" v-model="code_Planned_Type" class="w-full" icon-pack="feather" icon-no-border label="Code Planned Type" />
							<span class="text-danger text-sm" v-show="errors.has('code_Planned_Type')">{{ errors.first('code_Planned_Type') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="Y" name="code_Billing_Status" v-model="code_Billing_Status" class="w-full" icon-pack="feather" icon-no-border label="Code Billing Status" />
							<span class="text-danger text-sm" v-show="errors.has('code_Billing_Status')">{{ errors.first('code_Billing_Status') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="Y" name="code_Cms_Claim_Status" v-model="code_Cms_Claim_Status" class="w-full" icon-pack="feather" icon-no-border label="Code Cms Claim Status" />
							<span class="text-danger text-sm" v-show="errors.has('code_Cms_Claim_Status')">{{ errors.first('code_Cms_Claim_Status') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="F" name="sex_Cd" v-model="sex_Cd" class="w-full" icon-pack="feather" icon-no-border label="Sex Cd" />
							<span class="text-danger text-sm" v-show="errors.has('sex_Cd')">{{ errors.first('sex_Cd') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="C" name="anat_Or_Cond" v-model="anat_Or_Cond" class="w-full" icon-pack="feather" icon-no-border label="Anat Or Cond" />
							<span class="text-danger text-sm" v-show="errors.has('anat_Or_Cond')">{{ errors.first('anat_Or_Cond') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:100'" placeholder="N" name="poa_Code_Status" v-model="poa_Code_Status" class="w-full" icon-pack="feather" icon-no-border label="Poa Code Status" />
							<span class="text-danger text-sm" v-show="errors.has('poa_Code_Status')">{{ errors.first('poa_Code_Status') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="No change" name="poa_Code_Change" v-model="poa_Code_Change" class="w-full" icon-pack="feather" icon-no-border label="Poa Code Change" />
							<span class="text-danger text-sm" v-show="errors.has('poa_Code_Change')">{{ errors.first('poa_Code_Change') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:100'" placeholder="2015" name="poa_Code_Change_Year" v-model="poa_Code_Change_Year" class="w-full" icon-pack="feather" icon-no-border label="Poa Code Change Year" />
							<span class="text-danger text-sm" v-show="errors.has('poa_Code_Change_Year')">{{ errors.first('poa_Code_Change_Year') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="19700101" name="valid_Start_Date" v-model="valid_Start_Date" class="w-full" icon-pack="feather" icon-no-border label="Valid Start Date" />
							<span class="text-danger text-sm" v-show="errors.has('valid_Start_Date')">{{ errors.first('valid_Start_Date') }}</span>
						</div>
					</vs-col>
                    <vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:20'" placeholder="20991231" name="valid_End_Date" v-model="valid_End_Date" class="w-full" icon-pack="feather" icon-no-border label="Valid End Date" />
							<span class="text-danger text-sm" v-show="errors.has('valid_End_Date')">{{ errors.first('valid_End_Date') }}</span>
						</div>
					</vs-col>
				</vs-row>
                <vs-row>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'max:5'" placeholder="None" name="invalid_Reason" v-model="invalid_Reason" class="w-full" icon-pack="feather" icon-no-border label="Invalid Reason" />
							<span class="text-danger text-sm" v-show="errors.has('invalid_Reason')">{{ errors.first('invalid_Reason') }}</span>
						</div>
					</vs-col>
					<vs-col class="details" vs-type="flex" vs-justify="center" vs-align="center" vs-w="4">
						<div class="vx-col w-full details">
							<vs-input v-validate="'required|integer|max:10'" placeholder="42005" name="create_Dt" v-model="create_Dt" class="w-full" icon-pack="feather" icon-no-border label="Create Dt" />
							<span class="text-danger text-sm" v-show="errors.has('create_Dt')">{{ errors.first('create_Dt') }}</span>
						</div>
					</vs-col>
				</vs-row>
				<vs-row>
					<vs-col class="details" vs-w="2">
						<vs-button type="filled" @click.prevent="submitForm">Crear</vs-button>
					</vs-col>
					<vs-col class="details" vs-w="10">
						<vs-button color="success" type="filled" class="details" to="/listadoConceptos">Volver a la lista</vs-button>
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
            pxordx: '',
            oldpxordx: '',
            codeType: '',
            concept_Class_Id: '',
            concept_Id: '',
            vocabulary_Id: '',
            domain_Id: '',
            track: '',
            standard_Concept: '',
            code: '',
            codeWithPeriods: '',
            codeScheme: '',
            long_Desc: '',
            short_Desc: '',
            code_Status: '',
            code_Change: '',
            code_Change_Year: '',
            code_Planned_Type: '',
            code_Billing_Status: '',
            code_Cms_Claim_Status: '',
            sex_Cd: '',
            anat_Or_Cond: '',
            poa_Code_Status: '',
            poa_Code_Change: '',
            poa_Code_Change_Year: '',
            valid_Start_Date: '',
            valid_End_Date: '',
            invalid_Reason: '',
            create_Dt:  '',
		}
	},
	methods: {
		submitForm() {
			this.$validator.validateAll().then(result => {
				if(result) {
					axios.post(this.url.concepts, {
                        "pxordx": this.pxordx,
                        "oldpxordx": this.oldpxordx,
                        "codeType": this.codeType,
                        "concept_Class_Id": this.concept_Class_Id,
                        "concept_Id": parseInt(this.concept_Id),
                        "vocabulary_Id": this.vocabulary_Id,
                        "domain_Id": this.domain_Id,
                        "track": this.track,
                        "standard_Concept": this.standard_Concept,
                        "code": this.code,
                        "codeWithPeriods": this.codeWithPeriods,
                        "codeScheme": this.codeScheme,
                        "long_Desc": this.long_Desc,
                        "short_Desc": this.short_Desc,
                        "code_Status": this.code_Status,
                        "code_Change": this.code_Change,
                        "code_Change_Year": parseInt(this.code_Change_Year),
                        "code_Planned_Type": this.code_Planned_Type,
                        "code_Billing_Status": this.code_Billing_Status,
                        "code_Cms_Claim_Status": this.code_Cms_Claim_Status,
                        "sex_Cd": this.sex_Cd,
                        "anat_Or_Cond": this.anat_Or_Cond,
                        "poa_Code_Status": this.poa_Code_Status,
                        "poa_Code_Change": this.poa_Code_Change,
                        "poa_Code_Change_Year": this.poa_Code_Change_Year,
                        "valid_Start_Date": this.valid_Start_Date,
                        "valid_End_Date": this.valid_End_Date,
                        "invalid_Reason": this.invalid_Reason,
                        "create_Dt": parseInt(this.create_Dt)
						}, { headers: { 'Authorization': this.infoUser.token }
						}).then((res) => {
							this.$vs.notify({
								color:'success',
								title:'Concepto Creado Correctamente',
								iconPack: 'feather', icon:'icon-check'
							});
							this.$router.push({ name: 'listadoConceptos' });
						}).catch((error) => {
                            console.log('errorW: ', error)
							this.$vs.notify({
								color:'danger',
								title:'No se pudo crear el Concepto. Error en la API',
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
		padding: 5px;
	}
</style>