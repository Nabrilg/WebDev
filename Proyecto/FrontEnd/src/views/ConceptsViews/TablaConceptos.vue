<!-- Componente de la Tabla de Listado de Conceptos -->
<template>
	<vx-card>
		<vs-table v-model="selected" @selected="mostrarDetalles" :data="concepts" max-items="8" pagination search noDataText="No hay conceptos en tu búsqueda" stripe>
			<!-- Cabecera de la Tabla -->
            <template slot="thead">
				<vs-th sort-key="id">Id</vs-th>
				<vs-th sort-key="concept_Id">Concept Id</vs-th>
                <vs-th sort-key="concept_Class_Id">Concept Class Id</vs-th>
				<vs-th sort-key="track">Track</vs-th>
                <vs-th sort-key="standard_Concept">Standard Concept</vs-th>
                <vs-th sort-key="short_Desc">Short Description</vs-th>
                <vs-th sort-key="codeScheme">Code Scheme </vs-th>
				<vs-th sort-key="sex_Cd">Sex Cond</vs-th>
				<vs-th>Acciones</vs-th>
			</template>
            <!-- Cuerpo de la tabla -->
			<template slot-scope="{data}">
				<vs-tr :data="tr" :key="i" v-for="(tr, i) in data">
					<vs-td :data="data[i].id">
						{{data[i].id}}
					</vs-td>
					<vs-td :data="data[i].concept_Id">
						{{data[i].concept_Id}}
					</vs-td>
                    <vs-td :data="data[i].concept_Class_Id">
						{{data[i].concept_Class_Id}}
					</vs-td>
					<vs-td :data="data[i].track">
						{{data[i].track}}
					</vs-td>
                    <vs-td :data="data[i].standard_Concept">
						{{data[i].standard_Concept}}
					</vs-td>
                    <vs-td :data="data[i].short_Desc">
						{{data[i].short_Desc}}
					</vs-td>
                    <vs-td :data="data[i].codeScheme">
						{{data[i].codeScheme}}
					</vs-td>
					<vs-td :data="data[i].sex_Cd">
						{{data[i].sex_Cd}}
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

        <!-- Modal Para Editar un Concepto -->
        <vs-popup title="Editar Concepto" :active.sync="modalCambios" fullscreen>
            <form>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="D" name="pxordx" v-model="tmpA.pxordx" class="w-full" icon-pack="feather" icon-no-border label="Pxordx" />
                            <span class="text-danger text-sm" v-show="errors.has('pxordx')">{{ errors.first('pxordx') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="D" name="Oldpxordx" v-model="tmpA.oldpxordx" class="w-full" icon-pack="feather" icon-no-border label="Oldpxordx" />
                            <span class="text-danger text-sm" v-show="errors.has('Oldpxordx')">{{ errors.first('oldpxordx') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="I09" name="codeType" v-model="tmpA.codeType" class="w-full" icon-pack="feather" icon-no-border label="Code Type" />
                            <span class="text-danger text-sm" v-show="errors.has('codeType')">{{ errors.first('codeType') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:100'" placeholder="3-dig nonbill" name="concept_Class_Id" v-model="tmpA.concept_Class_Id" class="w-full" icon-pack="feather" icon-no-border label="Concept Class Id" />
                            <span class="text-danger text-sm" v-show="errors.has('concept_Class_Id')">{{ errors.first('concept_Class_Id') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'required|integer|max:10'" placeholder="44829696" name="concept_Id" v-model="tmpA.concept_Id" class="w-full" icon-pack="feather" icon-no-border label="Concept Id" />
                            <span class="text-danger text-sm" v-show="errors.has('concept_Id')">{{ errors.first('concept_Id') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:100'" placeholder="ICD9CM" name="vocabulary_Id" v-model="tmpA.vocabulary_Id" class="w-full" icon-pack="feather" icon-no-border label="Vocabulary Id" />
                            <span class="text-danger text-sm" v-show="errors.has('vocabulary_Id')">{{ errors.first('vocabulary_Id') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:100'" placeholder="Condition" name="domain_Id" v-model="tmpA.domain_Id" class="w-full" icon-pack="feather" icon-no-border label="Domain Id" />
                            <span class="text-danger text-sm" v-show="errors.has('domain_Id')">{{ errors.first('domain_Id') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:100'" placeholder="Medical" name="track" v-model="tmpA.track" class="w-full" icon-pack="feather" icon-no-border label="Track" />
                            <span class="text-danger text-sm" v-show="errors.has('track')">{{ errors.first('track') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="Normal" name="standard_Concept" v-model="tmpA.standard_Concept" class="w-full" icon-pack="feather" icon-no-border label="Standard Concept" />
                            <span class="text-danger text-sm" v-show="errors.has('standard_Concept')">{{ errors.first('standard_Concept') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'required|max:10'" placeholder="1" name="code" v-model="tmpA.code" class="w-full" icon-pack="feather" icon-no-border label="code" />
                            <span class="text-danger text-sm" v-show="errors.has('code')">{{ errors.first('code') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="1" name="codeWithPeriods" v-model="tmpA.codeWithPeriods" class="w-full" icon-pack="feather" icon-no-border label="Code With Periods" />
                            <span class="text-danger text-sm" v-show="errors.has('codeWithPeriods')">{{ errors.first('codeWithPeriods') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="ICD9DIAG" name="codeScheme" v-model="tmpA.codeScheme" class="w-full" icon-pack="feather" icon-no-border label="Code Scheme" />
                            <span class="text-danger text-sm" v-show="errors.has('codeScheme')">{{ errors.first('codeScheme') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:500'" placeholder="Cholera" name="long_Desc" v-model="tmpA.long_Desc" class="w-full" icon-pack="feather" icon-no-border label="Long Desc" />
                            <span class="text-danger text-sm" v-show="errors.has('long_Desc')">{{ errors.first('long_Desc') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:255'" placeholder="Cholera 1" name="short_Desc" v-model="tmpA.short_Desc" class="w-full" icon-pack="feather" icon-no-border label="Short Desc" />
                            <span class="text-danger text-sm" v-show="errors.has('short_Desc')">{{ errors.first('short_Desc') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="I" name="code_Status" v-model="tmpA.code_Status" class="w-full" icon-pack="feather" icon-no-border label="Code Status" />
                            <span class="text-danger text-sm" v-show="errors.has('code_Status')">{{ errors.first('code_Status') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="Deleted" name="code_Change" v-model="tmpA.code_Change" class="w-full" icon-pack="feather" icon-no-border label="Code Change" />
                            <span class="text-danger text-sm" v-show="errors.has('code_Change')">{{ errors.first('code_Change') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'required|integer|max:5'" placeholder="2015" name="code_Change_Year" v-model="tmpA.code_Change_Year" class="w-full" icon-pack="feather" icon-no-border label="Code Change Year" />
                            <span class="text-danger text-sm" v-show="errors.has('code_Change_Year')">{{ errors.first('code_Change_Year') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="UP" name="code_Planned_Type" v-model="tmpA.code_Planned_Type" class="w-full" icon-pack="feather" icon-no-border label="Code Planned Type" />
                            <span class="text-danger text-sm" v-show="errors.has('code_Planned_Type')">{{ errors.first('code_Planned_Type') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="Y" name="code_Billing_Status" v-model="tmpA.code_Billing_Status" class="w-full" icon-pack="feather" icon-no-border label="Code Billing Status" />
                            <span class="text-danger text-sm" v-show="errors.has('code_Billing_Status')">{{ errors.first('code_Billing_Status') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="Y" name="code_Cms_Claim_Status" v-model="tmpA.code_Cms_Claim_Status" class="w-full" icon-pack="feather" icon-no-border label="Code Cms Claim Status" />
                            <span class="text-danger text-sm" v-show="errors.has('code_Cms_Claim_Status')">{{ errors.first('code_Cms_Claim_Status') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="F" name="sex_Cd" v-model="tmpA.sex_Cd" class="w-full" icon-pack="feather" icon-no-border label="Sex Cd" />
                            <span class="text-danger text-sm" v-show="errors.has('sex_Cd')">{{ errors.first('sex_Cd') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="C" name="anat_Or_Cond" v-model="tmpA.anat_Or_Cond" class="w-full" icon-pack="feather" icon-no-border label="Anat Or Cond" />
                            <span class="text-danger text-sm" v-show="errors.has('anat_Or_Cond')">{{ errors.first('anat_Or_Cond') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:100'" placeholder="N" name="poa_Code_Status" v-model="tmpA.poa_Code_Status" class="w-full" icon-pack="feather" icon-no-border label="Poa Code Status" />
                            <span class="text-danger text-sm" v-show="errors.has('poa_Code_Status')">{{ errors.first('poa_Code_Status') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="No change" name="poa_Code_Change" v-model="tmpA.poa_Code_Change" class="w-full" icon-pack="feather" icon-no-border label="Poa Code Change" />
                            <span class="text-danger text-sm" v-show="errors.has('poa_Code_Change')">{{ errors.first('poa_Code_Change') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:100'" placeholder="2015" name="poa_Code_Change_Year" v-model="tmpA.poa_Code_Change_Year" class="w-full" icon-pack="feather" icon-no-border label="Poa Code Change Year" />
                            <span class="text-danger text-sm" v-show="errors.has('poa_Code_Change_Year')">{{ errors.first('poa_Code_Change_Year') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="19700101" name="valid_Start_Date" v-model="tmpA.valid_Start_Date" class="w-full" icon-pack="feather" icon-no-border label="Valid Start Date" />
                            <span class="text-danger text-sm" v-show="errors.has('valid_Start_Date')">{{ errors.first('valid_Start_Date') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:20'" placeholder="20991231" name="valid_End_Date" v-model="tmpA.valid_End_Date" class="w-full" icon-pack="feather" icon-no-border label="Valid End Date" />
                            <span class="text-danger text-sm" v-show="errors.has('valid_End_Date')">{{ errors.first('valid_End_Date') }}</span>
                        </div>
                    </vs-col>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'max:5'" placeholder="None" name="invalid_Reason" v-model="tmpA.invalid_Reason" class="w-full" icon-pack="feather" icon-no-border label="Invalid Reason" />
                            <span class="text-danger text-sm" v-show="errors.has('invalid_Reason')">{{ errors.first('invalid_Reason') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col class="details2" vs-type="flex" vs-justify="center" vs-align="center" vs-w="3">
                        <div class="vx-col w-full details">
                            <vs-input v-validate="'required|integer|max:10'" placeholder="42005" name="create_Dt" v-model="tmpA.create_Dt" class="w-full" icon-pack="feather" icon-no-border label="Create Dt" />
                            <span class="text-danger text-sm" v-show="errors.has('create_Dt')">{{ errors.first('create_Dt') }}</span>
                        </div>
                    </vs-col>
                </vs-row>
                <vs-row>
                    <vs-col vs-type="flex" vs-w="3" class="details2">
                        <vs-button color="primary" type="border" @click="modalCambios=false; aceptarCambios()">Guardar Cambios</vs-button>
                    </vs-col>
                    <vs-col vs-type="flex" vs-w="8" class="details2">
                        <vs-button color="success" type="border" @click="modalCambios=false; cancelarCambios()">Cancelar</vs-button>
                    </vs-col>
                </vs-row>
            </form>
        </vs-popup>

        <!-- Modal para Detalles de un Concepto -->
        <vs-popup title="Detalles de un Concepto" :active.sync="modalDetalles" fullscreen>
            <vs-row>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>Id</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.id}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>pxordx</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.pxordx}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>oldpxordx</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.oldpxordx}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>codeType</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.codeType}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>concept_Class_Id</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.concept_Class_Id}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>concept_Id</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.concept_Id}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>vocabulary_Id</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.vocabulary_Id}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>domain_Id</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.domain_Id}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>track</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.track}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>standard_Concept</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.standard_Concept}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>codeWithPeriods</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.codeWithPeriods}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>codeScheme</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.codeScheme}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>long_Desc</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.long_Desc}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>short_Desc</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.short_Desc}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code_Status</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code_Status}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code_Change</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code_Change}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code_Change_Year</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code_Change_Year}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code_Planned_Type</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code_Planned_Type}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code_Billing_Status</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code_Billing_Status}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>code_Cms_Claim_Status</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.code_Cms_Claim_Status}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>sex_Cd</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.sex_Cd}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>anat_Or_Cond</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.anat_Or_Cond}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>poa_Code_Status</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.poa_Code_Status}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>poa_Code_Change</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.poa_Code_Change}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>poa_Code_Change_Year</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.poa_Code_Change_Year}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>valid_Start_Date</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.valid_Start_Date}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>valid_End_Date</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.valid_End_Date}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>invalid_Reason</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.invalid_Reason}}</vs-col>
                <vs-col vs-type="flex" vs-w="2" class="details"><strong>create_Dt</strong></vs-col><vs-col vs-type="flex" vs-w="2" class="details">{{tmpA.create_Dt}}</vs-col>
                <vs-col vs-type="flex" vs-w="4" class="details">
                    <vs-button color="primary" type="border" @click="modalDetalles=false; modalCambios=true">Editar Concepto</vs-button>
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
			@cancel="cancelarCambios"
			@accept="confirmarBorrado"
			@close="cancelarCambios"
			:active.sync="modalBorrar">
			<div class="con-exemple-prompt">
                <vs-row>
                    <p>¿Estas seguro de borrar el concepto con id {{tmpA.id}}?</p><br><br> 
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
			},
			concepts: [
				{
                    id: '',
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
                },
            ],
		}
	},
	methods: {
		editarUsuario(i){
            for(var j=0; j < this.concepts.length; j++){
				if( i == this.concepts[j].id ){
                    this.modalCambios = true;
                    this.tmpI = j;
                    this.tmpA.id = this.concepts[j].id;
                    this.tmpA.pxordx = this.concepts[j].pxordx;
                    this.tmpA.oldpxordx = this.concepts[j].oldpxordx;
                    this.tmpA.codeType = this.concepts[j].codeType;
                    this.tmpA.concept_Class_Id = this.concepts[j].concept_Class_Id;
                    this.tmpA.concept_Id = this.concepts[j].concept_Id;
                    this.tmpA.vocabulary_Id = this.concepts[j].vocabulary_Id;
                    this.tmpA.domain_Id = this.concepts[j].domain_Id;
                    this.tmpA.track = this.concepts[j].track;
                    this.tmpA.standard_Concept = this.concepts[j].standard_Concept;
                    this.tmpA.code = this.concepts[j].code;
                    this.tmpA.codeWithPeriods = this.concepts[j].codeWithPeriods;
                    this.tmpA.codeScheme = this.concepts[j].codeScheme;
                    this.tmpA.long_Desc = this.concepts[j].long_Desc;
                    this.tmpA.short_Desc = this.concepts[j].short_Desc;
                    this.tmpA.code_Status = this.concepts[j].code_Status;
                    this.tmpA.code_Change = this.concepts[j].code_Change;
                    this.tmpA.code_Change_Year = this.concepts[j].code_Change_Year;
                    this.tmpA.code_Planned_Type = this.concepts[j].code_Planned_Type;
                    this.tmpA.code_Billing_Status = this.concepts[j].code_Billing_Status;
                    this.tmpA.code_Cms_Claim_Status = this.concepts[j].code_Cms_Claim_Status;
                    this.tmpA.sex_Cd = this.concepts[j].sex_Cd;
                    this.tmpA.anat_Or_Cond = this.concepts[j].anat_Or_Cond;
                    this.tmpA.poa_Code_Status = this.concepts[j].poa_Code_Status;
                    this.tmpA.poa_Code_Change = this.concepts[j].poa_Code_Change;
                    this.tmpA.poa_Code_Change_Year = this.concepts[j].poa_Code_Change_Year;
                    this.tmpA.valid_Start_Date = this.concepts[j].valid_Start_Date;
                    this.tmpA.valid_End_Date = this.concepts[j].valid_End_Date;
                    this.tmpA.invalid_Reason = this.concepts[j].invalid_Reason;
                    this.tmpA.create_Dt = this.concepts[j].create_Dt;
				}
			}
		},
		mostrarDetalles(tr) {
            if(!this.modalCambios && !this.modalBorrar){
                this.$vs.notify({
                    title: `Seleccionado Concepto ${tr.id}`,
                    text: `Descripción: ${tr.short_Desc}`
                });
                this.tmpA = tr
                this.modalDetalles = true;
            }
		},
		aceptarCambios(){
            this.$validator.validateAll().then(result => {
                if(result) {
                    this.modalCambios = false;
                    this.$vs.dialog({
                        type: 'confirm',
                        color: 'warning',
                        title: `Confirmar Cambios`,
                        text: `¿Estas seguro de actualizar los datos para ${this.tmpA.short_Desc}?`,
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
            this.concepts[this.tmpI].pxordx = this.tmpA.pxordx;
            this.concepts[this.tmpI].oldpxordx = this.tmpA.oldpxordx;
            this.concepts[this.tmpI].codeType = this.tmpA.codeType;
            this.concepts[this.tmpI].concept_Class_Id = this.tmpA.concept_Class_Id;
            this.concepts[this.tmpI].concept_Id = this.tmpA.concept_Id;
            this.concepts[this.tmpI].vocabulary_Id = this.tmpA.vocabulary_Id;
            this.concepts[this.tmpI].domain_Id = this.tmpA.domain_Id;
            this.concepts[this.tmpI].track = this.tmpA.track;
            this.concepts[this.tmpI].standard_Concept = this.tmpA.standard_Concept;
            this.concepts[this.tmpI].code = this.tmpA.code;
            this.concepts[this.tmpI].codeWithPeriods = this.tmpA.codeWithPeriods;
            this.concepts[this.tmpI].codeScheme = this.tmpA.codeScheme;
            this.concepts[this.tmpI].long_Desc = this.tmpA.long_Desc;
            this.concepts[this.tmpI].short_Desc = this.tmpA.short_Desc;
            this.concepts[this.tmpI].code_Status = this.tmpA.code_Status;
            this.concepts[this.tmpI].code_Change = this.tmpA.code_Change;
            this.concepts[this.tmpI].code_Change_Year = this.tmpA.code_Change_Year;
            this.concepts[this.tmpI].code_Planned_Type = this.tmpA.code_Planned_Type;
            this.concepts[this.tmpI].code_Billing_Status = this.tmpA.code_Billing_Status;
            this.concepts[this.tmpI].code_Cms_Claim_Status = this.tmpA.code_Cms_Claim_Status;
            this.concepts[this.tmpI].sex_Cd = this.tmpA.sex_Cd;
            this.concepts[this.tmpI].anat_Or_Cond = this.tmpA.anat_Or_Cond;
            this.concepts[this.tmpI].poa_Code_Status = this.tmpA.poa_Code_Status;
            this.concepts[this.tmpI].poa_Code_Change = this.tmpA.poa_Code_Change;
            this.concepts[this.tmpI].poa_Code_Change_Year = this.tmpA.poa_Code_Change_Year;
            this.concepts[this.tmpI].valid_Start_Date = this.tmpA.valid_Start_Date;
            this.concepts[this.tmpI].valid_End_Date = this.tmpA.valid_End_Date;
            this.concepts[this.tmpI].invalid_Reason = this.tmpA.invalid_Reason;
            this.concepts[this.tmpI].create_Dt = this.tmpA.create_Dt;
            axios.put(this.url.concepts + `/${this.tmpA.id}`, {
                    "id": this.tmpA.id,
                    "pxordx": this.tmpA.pxordx,
                    "oldpxordx": this.tmpA.oldpxordx,
                    "codeType": this.tmpA.codeType,
                    "concept_Class_Id": this.tmpA.concept_Class_Id,
                    "concept_Id": parseInt(this.tmpA.concept_Id),
                    "vocabulary_Id": this.tmpA.vocabulary_Id,
                    "domain_Id": this.tmpA.domain_Id,
                    "track": this.tmpA.track,
                    "standard_Concept": this.tmpA.standard_Concept,
                    "code": this.tmpA.code,
                    "codeWithPeriods": this.tmpA.codeWithPeriods,
                    "codeScheme": this.tmpA.codeScheme,
                    "long_Desc": this.tmpA.long_Desc,
                    "short_Desc": this.tmpA.short_Desc,
                    "code_Status": this.tmpA.code_Status,
                    "code_Change": this.tmpA.code_Change,
                    "code_Change_Year": parseInt(this.tmpA.code_Change_Year),
                    "code_Planned_Type": this.tmpA.code_Planned_Type,
                    "code_Billing_Status": this.tmpA.code_Billing_Status,
                    "code_Cms_Claim_Status": this.tmpA.code_Cms_Claim_Status,
                    "sex_Cd": this.tmpA.sex_Cd,
                    "anat_Or_Cond": this.tmpA.anat_Or_Cond,
                    "poa_Code_Status": this.tmpA.poa_Code_Status,
                    "poa_Code_Change": this.tmpA.poa_Code_Change,
                    "poa_Code_Change_Year": this.tmpA.poa_Code_Change_Year,
                    "valid_Start_Date": this.tmpA.valid_Start_Date,
                    "valid_End_Date": this.tmpA.valid_End_Date,
                    "invalid_Reason": this.tmpA.invalid_Reason,
                    "create_Dt": parseInt(this.tmpA.create_Dt)
                }, { headers: { 'Authorization': this.infoUser.token }
                }).then((res) => {
                    this.$vs.notify({
                        color:'success',
                        title:'Concepto Actualizado Correctamente',
                        iconPack: 'feather', icon:'icon-check'
                    });
                }).catch((error) => {
                    this.$vs.notify({
                        color:'danger',
                        title: 'Error al Actualizar',
                        text: `No se pudo actualizar los Datos de ${this.tmpA.short_Desc}. Error en la API`,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
            });
        },
		cancelarCambios() {
            this.$vs.notify({
				color:'danger',
                title:'Cambios Cancelados',
                iconPack: 'feather', icon:'icon-alert-circle'
			});
        },
        borrarUsuario(i){
            for(var j=0; j < this.concepts.length; j++){
				if( i == this.concepts[j].id ){
                    this.modalBorrar = true;
                    this.tmpI = j;
					this.tmpA.id = this.concepts[j].id;
			        this.tmpA.name = this.concepts[j].name;
                    this.tmpA.email = this.concepts[j].email;
                    this.tmpA.username = this.concepts[j].username;
                    this.tmpA.password = this.concepts[j].password;
				}
			}
        },
        confirmarBorrado(){
            axios.delete(this.url.concepts + `/${this.tmpA.id}`, {
                headers: {
                    'Authorization': this.infoUser.token
                }
                }).then((res) => {
                    this.$vs.notify({
                        color:'success',
                        title:'Usuario Borrado Correctamente',
                        iconPack: 'feather', icon:'icon-check'
                    });
                    delete this.concepts.splice(parseInt(this.tmpI), 1);
                }).catch((error) => {
                    console.log(error);
                    this.$vs.notify({
                        color:'danger',
                        title:'Error al Borrar',
                        text: `No se pudo borrar el usuario ${this.tmpA.short_Desc}. Error en la API`,
                        iconPack: 'feather', icon:'icon-alert-circle'
                    });
            })
        },
        cargarUsuarios(){
            axios.get(this.url.concepts, {
                headers: {
                    'Authorization': this.infoUser.token
                }
                }).then((res) => {
                    this.concepts = res.data;
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


<style scoped>
    .details{
        padding: 10px;
    }
    .details2{
        padding: 0px;
    }
</style>