import React, { Component } from 'react';
import './App.css';
import axios from 'axios';
import Cookie from 'universal-cookie';

const api = axios.create({
    baseURL: `https://javerianawebdevapi.azurewebsites.net/api/Concepts`
})
class Concept extends Component{
    constructor(props) {
        super(props);
        this.state = { form:{
            pxordx: props.location.concepto.pxordx,
            oldpxordx: props.location.concepto.oldpxordx,
            codeType: props.location.concepto.codeType,
            concept_Class_Id: props.location.concepto.concept_Class_Id,
            concept_Id: parseInt(props.location.concepto.concept_Id, 10),
            vocabulary_Id: props.location.concepto.vocabulary_Id,
            domain_Id: props.location.concepto.domain_Id,
            track: props.location.concepto.track,
            standard_Concept: props.location.concepto.standard_Concept,
            code: props.location.concepto.code,
            codeWithPeriods: props.location.concepto.codeWithPeriods,
            codeScheme: props.location.concepto.codeScheme,
            long_Desc: props.location.concepto.long_Desc,
            short_Desc: props.location.concepto.short_Desc,
            code_Status: props.location.concepto.code_Status,
            code_Change: props.location.concepto.code_Change,
            code_Change_Year: parseInt(props.location.concepto.code_Change_Year, 10),
            code_Planned_Type: props.location.concepto.code_Planned_Type,
            code_Billing_Status: props.location.concepto.code_Billing_Status,
            code_Cms_Claim_Status: props.location.concepto.code_Cms_Claim_Status,
            sex_Cd: props.location.concepto.sex_Cd,
            anat_Or_Cond: props.location.concepto.anat_Or_Cond,
            poa_Code_Status: props.location.concepto.poa_Code_Status,
            poa_Code_Change: props.location.concepto.poa_Code_Change,
            poa_Code_Change_Year: props.location.concepto.poa_Code_Change_Year,
            valid_Start_Date: props.location.concepto.valid_Start_Date,
            valid_End_Date: props.location.concepto.valid_End_Date,
            invalid_Reason: props.location.concepto.invalid_Reason,
            create_Dt:  parseInt(props.location.concepto.create_Dt, 10)
        } };
    }

    handleChange=async e=>{
        await this.setState({
            form:{
                ...this.state.form,
                [e.target.name] : e.target.value
            }
        });
    }

    updateConcept = async () =>{
        var cookie = new Cookie();
        const headers = {
            'Authorization' : cookie.get('Authorization')
        }
        const urlId = '/' + this.props.location.concepto.id;
        try{
            let res = await api.put(urlId, {
                id : this.props.location.concepto.id,
                pxordx: this.state.form.pxordx,
                oldpxordx: this.state.form.oldpxordx,
                codeType: this.state.form.codeType,
                concept_Class_Id: this.state.form.concept_Class_Id,
                concept_Id: parseInt(this.state.form.concept_Id, 10),
                vocabulary_Id: this.state.form.vocabulary_Id,
                domain_Id: this.state.form.domain_Id,
                track: this.state.form.track,
                standard_Concept: this.state.form.standard_Concept,
                code: this.state.form.code,
                codeWithPeriods: this.state.form.codeWithPeriods,
                codeScheme: this.state.form.codeScheme,
                long_Desc: this.state.form.long_Desc,
                short_Desc: this.state.form.short_Desc,
                code_Status: this.state.form.code_Status,
                code_Change: this.state.form.code_Change,
                code_Change_Year: parseInt(this.state.form.code_Change_Year, 10),
                code_Planned_Type: this.state.form.code_Planned_Type,
                code_Billing_Status: this.state.form.code_Billing_Status,
                code_Cms_Claim_Status: this.state.form.code_Cms_Claim_Status,
                sex_Cd: this.state.form.sex_Cd,
                anat_Or_Cond: this.state.form.anat_Or_Cond,
                poa_Code_Status: this.state.form.poa_Code_Status,
                poa_Code_Change: this.state.form.poa_Code_Change,
                poa_Code_Change_Year: this.state.form.poa_Code_Change_Year,
                valid_Start_Date: this.state.form.valid_Start_Date,
                valid_End_Date: this.state.form.valid_End_Date,
                invalid_Reason: this.state.form.invalid_Reason,
                create_Dt: parseInt(this.state.form.create_Dt, 10)
            }, { headers : headers })
            console.log(res.data);
            window.location.href = "http://localhost:3000/concepts";
        } catch (err) {
            console.log(err);
        }
    }

    render(){
        return (
            <div className="gradient-bg">
                <div className="create-concept-container">
                    <h1>Crear concepto</h1>
                    <form>
                        <input type="string" name="pxordx" placeholder={this.props.location.concepto.pxordx} onChange={this.handleChange}></input>
                        <input type="string" name="oldpxordx" placeholder={this.props.location.concepto.oldpxordx} onChange={this.handleChange}></input>
                        <input type="string" name="codeType" placeholder={this.props.location.concepto.codeType} onChange={this.handleChange}></input>
                        <input type="string" name="concept_Class_Id" placeholder={this.props.location.concepto.concept_Class_Id} onChange={this.handleChange}></input>
                        <input type="number" name="concept_Id" placeholder={this.props.location.concepto.concept_Id} onChange={this.handleChange}></input>
                        <input type="string" name="vocabulary_Id" placeholder={this.props.location.concepto.vocabulary_Id} onChange={this.handleChange}></input>
                        <input type="string" name="domain_Id" placeholder={this.props.location.concepto.domain_Id} onChange={this.handleChange}></input>
                        <input type="string" name="track" placeholder={this.props.location.concepto.track} onChange={this.handleChange}></input>
                        <input type="string" name="standard_Concept" placeholder={this.props.location.concepto.standard_Concept} onChange={this.handleChange}></input>
                        <input type="string" name="code" placeholder={this.props.location.concepto.code} onChange={this.handleChange}></input>
                        <input type="string" name="codeWithPeriods" placeholder={this.props.location.concepto.codeWithPeriods} onChange={this.handleChange}></input>
                        <input type="string" name="codeScheme" placeholder={this.props.location.concepto.codeScheme} onChange={this.handleChange}></input>
                        <input type="string" name="long_Desc" placeholder={this.props.location.concepto.long_Desc} onChange={this.handleChange}></input>
                        <input type="string" name="short_Desc" placeholder={this.props.location.concepto.short_Desc} onChange={this.handleChange}></input>
                        <input type="string" name="code_Status" placeholder={this.props.location.concepto.code_Status} onChange={this.handleChange}></input>
                        <input type="string" name="code_Change" placeholder={this.props.location.concepto.code_Change} onChange={this.handleChange}></input>
                        <input type="number" name="code_Change_Year" placeholder={this.props.location.concepto.code_Change_Year} onChange={this.handleChange}></input>
                        <input type="string" name="code_Planned_Type" placeholder={this.props.location.concepto.code_Planned_Type} onChange={this.handleChange}></input>
                        <input type="string" name="code_Billing_Status" placeholder={this.props.location.concepto.code_Billing_Status} onChange={this.handleChange}></input>
                        <input type="string" name="code_Cms_Claim_Status" placeholder={this.props.location.concepto.code_Cms_Claim_Status} onChange={this.handleChange}></input>
                        <input type="string" name="sex_Cd" placeholder={this.props.location.concepto.sex_Cd} onChange={this.handleChange}></input>
                        <input type="string" name="anat_Or_Cond" placeholder={this.props.location.concepto.anat_Or_Cond} onChange={this.handleChange}></input>
                        <input type="string" name="poa_Code_Status" placeholder={this.props.location.concepto.poa_Code_Status} onChange={this.handleChange}></input>
                        <input type="string" name="poa_Code_Change" placeholder={this.props.location.concepto.poa_Code_Change} onChange={this.handleChange}></input>
                        <input type="string" name="poa_Code_Change_Year" placeholder={this.props.location.concepto.poa_Code_Change_Year} onChange={this.handleChange}></input>
                        <input type="string" name="valid_Start_Date" placeholder={this.props.location.concepto.valid_Start_Date} onChange={this.handleChange}></input>
                        <input type="string" name="valid_End_Date" placeholder={this.props.location.concepto.valid_End_Date} onChange={this.handleChange}></input>
                        <input type="string" name="invalid_Reason" placeholder={this.props.location.concepto.invalid_Reason} onChange={this.handleChange}></input>
                        <input type="number" name="create_Dt" placeholder={this.props.location.concepto.create_Dt} onChange={this.handleChange}></input>
                        <input type="button" value=" " onClick={ this.updateConcept }></input>
                    </form>
                </div>
            </div>
          );
    }
}
export default Concept;

