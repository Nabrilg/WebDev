import React from "react";

function InputForm({ handleChangeConcepts, handleChangeMenu, concept_info, isEdit }) {
  const initInputsText = concept_info.data;
  const [inputsText, setInputs] = React.useState(initInputsText);

  const onSubmit = () => {
    console.log(inputsText);
    if(isEdit) handleChangeConcepts(inputsText, concept_info.index);
    else handleChangeConcepts(inputsText);
    setInputs(initInputsText);
  }

  const handleChange = event => {
    inputsText[event.target.name] = event.target.value;
    setInputs({...inputsText});
  };

  return (
    <div className="card shadow-sm p-3 mb-5 rounded">
      <div className="card-header bg-white text-center">
        <div className="container-fluid d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap">
          <strong className="text-uppercase">Añadir concepto</strong>
          <button className="btn btn-outline-secondary" onClick={() => handleChangeMenu(0)}>Back</button>
        </div>
      </div>
      <div className="card-body">
        <div className="form-group">
          {Object.keys(concept_info.data).map((key, index) => {
            if(index !== 0) {
              return (<div key={key} className="row my-1 px-5">
                <label className="col" id={`lbl${key}`}>{key}</label>
                <input
                  className="col"
                  name={key}
                  type="text"
                  value={inputsText[key]}
                  onChange={handleChange}
                />
              </div>);
            }
          })}
          <div className="text-center mt-3">
            <button className="btn btn-outline-success" onClick={onSubmit}>Añadir</button>
          </div>
        </div>
      </div>
    </div>
  );
}
export default InputForm;
