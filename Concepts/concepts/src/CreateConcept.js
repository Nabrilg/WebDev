import React, { Component } from 'react';
import './App.css';
import axios from 'axios';
import Cookie from 'universal-cookie';

const api = axios.create({
    baseURL: `https://javerianawebdevapi.azurewebsites.net/api/Concepts`
})
class CreateConcept extends Component{

    state = {
        form:{
            pxordx: '',
            oldpxordx: '',
            codeType: '',
            concept_Class_Id: '',
            concept_Id: 0,
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
            code_Change_Year: 0,
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
            create_Dt: 0
        }
    }

    handleChange=async e=>{
        await this.setState({
            form:{
                ...this.state.form,
                [e.target.name] : e.target.value
            }
        });
    }

    submitConcepts = async () =>{
        var cookie = new Cookie();
        const headers = {
            'Authorization' : cookie.get('Authorization')
        }
        try{
            let res = await api.post('/', {
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
                        <input type="string" name="pxordx" placeholder="pxordx" onChange={this.handleChange}></input>
                        <input type="string" name="oldpxordx" placeholder="oldpxordx" onChange={this.handleChange}></input>
                        <input type="string" name="codeType" placeholder="codeType" onChange={this.handleChange}></input>
                        <input type="string" name="concept_Class_Id" placeholder="concept_Class_Id" onChange={this.handleChange}></input>
                        <input type="number" name="concept_Id" placeholder="concept_Id" onChange={this.handleChange}></input>
                        <input type="string" name="vocabulary_Id" placeholder="vocabulary_Id" onChange={this.handleChange}></input>
                        <input type="string" name="domain_Id" placeholder="domain_Id" onChange={this.handleChange}></input>
                        <input type="string" name="track" placeholder="track" onChange={this.handleChange}></input>
                        <input type="string" name="standard_Concept" placeholder="standard_Concept" onChange={this.handleChange}></input>
                        <input type="string" name="code" placeholder="code" onChange={this.handleChange}></input>
                        <input type="string" name="codeWithPeriods" placeholder="codeWithPeriods" onChange={this.handleChange}></input>
                        <input type="string" name="codeScheme" placeholder="codeScheme" onChange={this.handleChange}></input>
                        <input type="string" name="long_Desc" placeholder="long_Desc" onChange={this.handleChange}></input>
                        <input type="string" name="short_Desc" placeholder="short_Desc" onChange={this.handleChange}></input>
                        <input type="string" name="code_Status" placeholder="code_Status" onChange={this.handleChange}></input>
                        <input type="string" name="code_Change" placeholder="code_Change" onChange={this.handleChange}></input>
                        <input type="number" name="code_Change_Year" placeholder="code_Change_Year" onChange={this.handleChange}></input>
                        <input type="string" name="code_Planned_Type" placeholder="code_Planned_Type" onChange={this.handleChange}></input>
                        <input type="string" name="code_Billing_Status" placeholder="code_Billing_Status" onChange={this.handleChange}></input>
                        <input type="string" name="code_Cms_Claim_Status" placeholder="code_Cms_Claim_Status" onChange={this.handleChange}></input>
                        <input type="string" name="sex_Cd" placeholder="sex_Cd" onChange={this.handleChange}></input>
                        <input type="string" name="anat_Or_Cond" placeholder="anat_Or_Cond" onChange={this.handleChange}></input>
                        <input type="string" name="poa_Code_Status" placeholder="poa_Code_Status" onChange={this.handleChange}></input>
                        <input type="string" name="poa_Code_Change" placeholder="poa_Code_Change" onChange={this.handleChange}></input>
                        <input type="string" name="poa_Code_Change_Year" placeholder="poa_Code_Change_Year" onChange={this.handleChange}></input>
                        <input type="string" name="valid_Start_Date" placeholder="valid_Start_Date" onChange={this.handleChange}></input>
                        <input type="string" name="valid_End_Date" placeholder="valid_End_Date" onChange={this.handleChange}></input>
                        <input type="string" name="invalid_Reason" placeholder="invalid_Reason" onChange={this.handleChange}></input>
                        <input type="number" name="create_Dt" placeholder="create_Dt" onChange={this.handleChange}></input>
                        <input type="button" value=" " onClick={ this.submitConcepts }></input>
                    </form>
                </div>
            </div>
          );
    }
}

export default CreateConcept;
