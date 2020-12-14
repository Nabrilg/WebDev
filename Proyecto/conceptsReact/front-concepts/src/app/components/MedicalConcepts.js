import React, { useState } from "react";
import ConceptService from "../services/conceptsService"
import Concept from "../models/Concept"
import List from "./List";
import InputForm from "./InputForm";
import Details from "./Details";

export default function MedicalConcepts({ AuthState }) {
  const [concepts, setConcepts] = useState([]);
  const [concept, setConcept] = useState({ data: new Concept(), index: 0 });
  var conceptService = new ConceptService(AuthState);
  const [menu, setMenu] = useState(0);

  function getConcepts() {
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

  const addConcept = new_concept => {
    console.log("concept", new_concept);
    conceptService.post(new_concept)
    .then(response => {
      if(!response.ok) throw new Error("Server connection error");
      return response.json();
    })
    .then(response => {
      setConcepts([...concepts, new_concept]);
      console.log("Concepto añadido!");
      console.log(response);
    })
    .catch(err => {
      console.log(err);
    })
  };
  const editConcept = (new_concept, index) => {
    console.log("concept", new_concept);
    conceptService.put(new_concept)
    .then(response => {
      if(response.ok || response.status===204) {
        let tmpConcepts = concepts;
        tmpConcepts[index] = new_concept;
        setConcepts(tmpConcepts);
        setMenu(0);
        console.log(response);
      } else throw new Error("Server connection error");
    })
    .catch(err => {
      console.log(err);
    })
  };
  const deleteConcept = (concept_id, index) => {
    conceptService.delete(concept_id)
    .then(response => {
      if(response.ok || response.status===204) {
        setConcepts(concepts.filter((value, i) => i!==index));
        setMenu(0);
        console.log(response);
      } else throw new Error("Server connection error");
    })
    .catch(err => {
      console.log(err);
    })
  };

  React.useEffect(() => {
    getConcepts();
  }, []);

  return (
    <div className="container justify-content-center">
      <div className="row">
        
        {menu===0 && <div className="col justify-content-center align-items-center">
          <List 
            concepts={concepts} 
            handleChangeMenu={setMenu} 
            handleEditConcept={(new_concept, index) => {
              setMenu(2);
              setConcept({ data: new_concept, index });
            }} 
            handleDeleteConcept={deleteConcept} 
            handleDetailsConcept={index => {
              setConcept({data: concepts[index], index});
              setMenu(3);
            }} 
          />
        </div>}

        {menu===1 && <div className="col justify-content-center align-items-center">
          <InputForm handleChangeMenu={setMenu} handleChangeConcepts={addConcept} concept_info={{data: new Concept(), index: 0}} />
        </div>}

        {menu===2 && <div className="col justify-content-center align-items-center">
          <InputForm handleChangeMenu={setMenu} handleChangeConcepts={editConcept} concept_info={concept} isEdit={true} />
        </div>}

        {menu===3 && <div className="col justify-content-center align-items-center">
          <Details handleChangeMenu={setMenu} concept={concept.data} />
        </div>}

      </div>
    </div>
  );
}