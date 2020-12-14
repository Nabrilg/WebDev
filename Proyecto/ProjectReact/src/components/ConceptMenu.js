import React, { useState } from "react";
import InputForm from './InputForm';
import EditForm from './EditForm';
import List from "./List";
import Details from "./Details";
import Concept from "./models/Concept"
import ConceptService from "./services/conceptsService"

function ConceptMenu({AuthState}) {
  const [concepts, setConcepts] = useState([]);
  const [concept, setConcept] = useState(new Concept());
  const [state, setState] = useState(0);
  var conceptService = new ConceptService(AuthState);
  function getConcepts(){
    conceptService.get()
    .then(response => {
      if(!response.ok) throw new Error("Server connection error");
      return response.json();
    })
    .then(response => {
      setConcepts(response);
      console.log(response);
    })
    .catch(err => {
      console.log(err);
    })
  }

  const handleChangeConcept = con => {
    conceptService.post()
    .then(response => {
      if(!response.ok) throw new Error("Server connection error");
      return response.json();
    })
    .then(response => {
      setConcepts([...concepts, con]);
      console.log("Concept has added");
      console.log(response);
    })
    .catch(err => {
      console.log(err);
    })
  };
  const handleEditConcept = (con,index) => {
    conceptService.put()
    .then(response => {
      if(!response.ok) throw new Error("Server connection error");
      return response.json();
    })
    .then(response => {
      var newConcepts = concepts;
      newConcepts[index]=con;
      setConcepts(newConcepts);
      console.log(response);
    })
    .catch(err => {
      console.log(err);
    })
  };
  const handleDeleteConcept = (con,index) => {
    conceptService.delete()
    .then(response => {
      if(!response.ok) throw new Error("Server connection error");
      return response.json();
    })
    .then(response => {
      setConcepts(concepts.filter((concept,i) => i!==index));
      console.log(response);
    })
    .catch(err => {
      console.log(err);
    })
  };
  const handleChangeState = (newState) => {
    setState(newState);
  };
  const handleChangeEditableState = (newState,selectConcept,index) => {
    setConcept(selectConcept);
    setState(newState);
  };

  getConcepts();
  return (
    <div className="container justify-content-center">
      <div className="row">

        {state===0 &&<div className="col justify-content-center align-items-center">
          <List concepts={concepts} backBtn={handleChangeState} backSelectBtn={handleChangeEditableState} DeleteBtn={handleDeleteConcept}  />
        </div>}

        {state===1 &&<div className="col justify-content-center align-items-center">
          <InputForm backBtn={handleChangeState} handleChangeConcepts={handleChangeConcept} />
        </div>}

        {state===2 &&<div className="col justify-content-center align-items-center">
          <EditForm backBtn={handleChangeState} handleChangeConcepts={handleEditConcept} initInputsText={concept} />
        </div>}

        {state===3 &&<div className="col justify-content-center align-items-center">
          <Details backBtn={handleChangeState} concept={concept} />
        </div>}


      </div>
    </div>
  );
}

export default ConceptMenu;
