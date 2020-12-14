import React, { useState } from "react";
import Concept from "./models/Concept"

function InputForm({ handleChangeConcepts, backBtn }) {
  const initInputsText = new Concept();
  const [inputsText, setInputs] = useState(initInputsText);

  const onSubmit = () => {
    console.log(inputsText);
    handleChangeConcepts(inputsText);
    setInputs(initInputsText);
    backBtn(0);
  }

  const handleChange = event => {
    inputsText[event.target.name] = event.target.value;
    setInputs({...inputsText});
  };

  return (
    <div className="card shadow-sm p-3 mb-5 rounded">
      <button className="btn btn-outline-success" onClick={() => backBtn(0)}>Back</button>
      <div className="card-header bg-white text-center">
        <strong className="text-uppercase">Add Concept</strong>
      </div>
      <div className="card-body">
        <div className="form-group">
          <div className="row my-1">
            <label className="col" id="lblName">pxordx</label>
            <input
              className="col"
              name="pxordx"
              type="text"
              value={inputsText.pxordx}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">oldpxordx</label>
            <input
              className="col"
              name="oldpxordx"
              type="text"
              value={inputsText.oldpxordx}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">codeType</label>
            <input
              className="col"
              name="codeType"
              type="text"
              value={inputsText.codeType}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">concept_Class_Id</label>
            <input
              className="col"
              name="concept_Class_Id"
              type="text"
              value={inputsText.concept_Class_Id}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">concept_Id</label>
            <input
              className="col"
              name="concept_Id"
              type="text"
              value={inputsText.concept_Id}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">vocabulary_Id</label>
            <input
              className="col"
              name="vocabulary_Id"
              type="text"
              value={inputsText.vocabulary_Id}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">domain_Id</label>
            <input
              className="col"
              name="domain_Id"
              type="text"
              value={inputsText.domain_Id}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">track</label>
            <input
              className="col"
              name="track"
              type="text"
              value={inputsText.track}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">standard_Concept</label>
            <input
              className="col"
              name="standard_Concept"
              type="text"
              value={inputsText.standard_Concept}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code</label>
            <input
              className="col"
              name="code"
              type="text"
              value={inputsText.code}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">codeWithPeriods</label>
            <input
              className="col"
              name="codeWithPeriods"
              type="text"
              value={inputsText.codeWithPeriods}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">codeScheme</label>
            <input
              className="col"
              name="codeScheme"
              type="text"
              value={inputsText.codeScheme}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">long_Desc</label>
            <input
              className="col"
              name="long_Desc"
              type="text"
              value={inputsText.long_Desc}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">short_Desc</label>
            <input
              className="col"
              name="short_Desc"
              type="text"
              value={inputsText.short_Desc}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code_Status</label>
            <input
              className="col"
              name="code_Status"
              type="text"
              value={inputsText.code_Status}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code_Change</label>
            <input
              className="col"
              name="code_Change"
              type="text"
              value={inputsText.code_Change}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code_Change_Year</label>
            <input
              className="col"
              name="code_Change_Year"
              type="text"
              value={inputsText.code_Change_Year}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code_Planned_Type</label>
            <input
              className="col"
              name="code_Planned_Type"
              type="text"
              value={inputsText.code_Planned_Type}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code_Billing_Status</label>
            <input
              className="col"
              name="code_Billing_Status"
              type="text"
              value={inputsText.code_Billing_Status}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">code_Cms_Claim_Status</label>
            <input
              className="col"
              name="code_Cms_Claim_Status"
              type="text"
              value={inputsText.code_Cms_Claim_Status}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">sex_Cd</label>
            <input
              className="col"
              name="sex_Cd"
              type="text"
              value={inputsText.sex_Cd}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">anat_Or_Cond</label>
            <input
              className="col"
              name="anat_Or_Cond"
              type="text"
              value={inputsText.anat_Or_Cond}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">poa_Code_Status</label>
            <input
              className="col"
              name="poa_Code_Status"
              type="text"
              value={inputsText.poa_Code_Status}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">poa_Code_Change</label>
            <input
              className="col"
              name="poa_Code_Change"
              type="text"
              value={inputsText.poa_Code_Change}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">poa_Code_Change_Year</label>
            <input
              className="col"
              name="poa_Code_Change_Year"
              type="text"
              value={inputsText.poa_Code_Change_Year}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">valid_Start_Date</label>
            <input
              className="col"
              name="valid_Start_Date"
              type="text"
              value={inputsText.valid_Start_Date}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">valid_End_Date</label>
            <input
              className="col"
              name="valid_End_Date"
              type="text"
              value={inputsText.valid_End_Date}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">invalid_Reason</label>
            <input
              className="col"
              name="invalid_Reason"
              type="text"
              value={inputsText.invalid_Reason}
              onChange={handleChange}
            />
          </div>
          <div className="row my-1">
            <label className="col" id="lblName">create_Dt</label>
            <input
              className="col"
              name="create_Dt"
              type="text"
              value={inputsText.create_Dt}
              onChange={handleChange}
            />
          </div>
          <div className="text-center mt-3">
            <button className="btn btn-outline-success" onClick={onSubmit}>Añadir</button>
          </div>
        </div>
      </div>
    </div>
  );
}
export default InputForm;
