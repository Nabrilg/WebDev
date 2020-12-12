import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Table, Form } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

/* export const Concepts = () => (
  <h1>Concepts</h1>
) */
const baseUrl = "http://localhost:64499/api/Concepts";

export function Concepts()
{
  
  const [ data, setData]=useState([]);  

  const config = {
    headers: {
      accept: 'application/json',
      authorization: sessionStorage.getItem('jwtToken'),
    },
    data: {},
  };

  const getConcepts=async()=>{
    await axios.get(baseUrl,config)
    .then (response=>{
      console.log(response.data);
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  useEffect(()=>{
    getConcepts();
  },[]);

   // Control data
 const [currentConcept, setCurrentConcept]= useState({
    id: '',
    pxordx: '',
    oldpxordx: '',
    codeType: '',
    conceptClassId: '',
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
    create_Dt: ''
 }); 

 const handleChange=e=>{
    const {name, value}= e.target;
    setCurrentConcept({
      ...currentConcept,
      [name]: value
    })
 }

    // Create 
 const [showModalCreate, setShowModalCreate]= useState(false);
   const openCloseModalCreate=()=>{
   setShowModalCreate(!showModalCreate);
 }  

 const postConcept=async() => {
    delete currentConcept.id;
    await axios.post(baseUrl, currentConcept, config)
    .then (response=>{
      getConcepts();
      openCloseModalCreate();
    }).catch(error=>{
      console.log(error);
    })
}

// Update
const [showModalUpdate, setShowModalUpdate]= useState(false);
const openCloseModalUpdate=()=>{
  setShowModalUpdate(!showModalUpdate);
}

const selectCurrentConcept=(user, action)=>{
  setCurrentConcept(user);
  switch (action) {
    case "Edit":
      openCloseModalUpdate();
      break;
    case "Details":
      openCloseModalDetails();
      break;      
    case "Delete":
      openCloseModalDelete();
      break;             
    default:
      break;
  }     
}
const putConcept = async() => {
  await axios.put(baseUrl+"/"+ currentConcept.id, currentConcept, config)
  .then (response=>{
    var result = response.data;
    var updatedData = data;
    updatedData.map(concept=>{
      if(concept.id===currentConcept.id){
        concept.email = result.email;
        concept.name = result.name;
        concept.username = result.username;
        concept.password = result.password;
      }
    });
    getConcepts();
      openCloseModalUpdate();
    }).catch(error=>{
      console.log(error);
  })
}

// Details
const [showModalDetails, setShowModalDetails]= useState(false);
const openCloseModalDetails=()=>{
  setShowModalDetails(!showModalDetails);
}

// Delete
const [showModalDelete, setShowModalDelete]= useState(false);
const openCloseModalDelete=()=>{
  setShowModalDelete(!showModalDelete);
}

const deleteConcept = async() => {
  await axios.delete(baseUrl+"/"+ currentConcept.id, config)
  .then (()=>{
    setData(data.filter(concept=>concept.id!==currentConcept.id));
    openCloseModalDelete();
  }).catch(error=>{
    console.log(error);
  })
}  

return (
  <Container className="text-center text-md-left">
    <h1>Concepts List</h1>
    <p>
    <Button className="left" variant="success btn-sm" onClick={()=>openCloseModalCreate()}> <Fas icon={faPlus} /> New</Button>
    </p>
    <Table id="ConceptsTable">
      <thead>
          <tr>
              <th>Id</th>
              <th>Pxordx</th>
              <th>Oldpxordx</th>
              <th>Codetype</th>
              <th>ConceptClassId</th>
              <th>ConceptId</th>
              <th>VocabularyId</th>
              <th>DomainId</th>
              <th>Track</th>
              <th>StandardConcept</th>
              <th>Code</th>
              <th>Codewithperiods</th>
              <th>Codescheme</th>
              <th>LongDesc</th>
              <th>ShortDesc</th>
              <th>CodeStatus</th>
              <th>CodeChange</th>
              <th>CodeChangeYear</th>
              <th>CodePlannedType</th>
              <th>CodeBillingStatus</th>
              <th>CodeCmsClaimStatus</th>
              <th>SexCd</th>
              <th>AnatOrCond</th>
              <th>PoaCodeStatus</th>
              <th>PoaCodeChange</th>
              <th>PoaCodeChangeYear</th>
              <th>ValidStartDate</th>
              <th>ValidEndDate</th>
              <th>InvalidReason</th>
              <th>CreateDt</th>
              <th>Actions</th>

          </tr>
        </thead>
      <tbody>
        {data.map(concept=>(
          <tr key={concept.id}>
            <td>{concept.id}</td>
            <td>{concept.pxordx}</td>
            <td>{concept.oldpxordx}</td>
            <td>{concept.codeType}</td>
            <td>{concept.concept_Class_Id}</td>
            <td>{concept.concept_Id}</td>
            <td>{concept.vocabulary_Id}</td>
            <td>{concept.domain_Id}</td>
            <td>{concept.track}</td>
            <td>{concept.standard_Concept}</td>
            <td>{concept.code}</td>
            <td>{concept.codeWithPeriods}</td>
            <td>{concept.codeScheme}</td>
            <td>{concept.long_Desc}</td>
            <td>{concept.short_Desc}</td>
            <td>{concept.code_Status}</td>
            <td>{concept.code_Change}</td>
            <td>{concept.code_Change_Year}</td>
            <td>{concept.code_Planned_Type}</td>
            <td>{concept.code_Billing_Status}</td>
            <td>{concept.code_Cms_Claim_Status}</td>
            <td>{concept.sex_Cd}</td>
            <td>{concept.anat_Or_Cond}</td>
            <td>{concept.poa_Code_Status}</td>
            <td>{concept.poa_Code_Change}</td>
            <td>{concept.poa_Code_Change_Year}</td>
            <td>{concept.valid_Start_Date}</td>
            <td>{concept.valid_End_Date}</td>
            <td>{concept.invalid_Reason}</td>
            <td>{concept.create_Dt}</td>
            <td>
              <Button variant="outline-primary" onClick={()=>selectCurrentConcept(concept, "Edit")}>Edit</Button>{"  "}
              <Button variant="outline-warning" onClick={()=>selectCurrentConcept(concept, "Details")}>Details</Button>{"  "}
              <Button variant="outline-danger" onClick={()=>selectCurrentConcept(concept, "Delete")}>Delete</Button> 
            </td>
          </tr>
        ))}
      </tbody>
    </Table>


    {/* Create */}
    <Modal isOpen={showModalCreate}>
    <ModalHeader>Create Concept</ModalHeader>
    <ModalBody>
        <Form>
            <Form.Group>
                <Form.Label>Pxordx:</Form.Label>
                <Form.Control type="text" id="txtPxordx" name="pxordx" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>OldPxordx:</Form.Label>
                <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Codetype:</Form.Label>
                <Form.Control type="text" id="txtCodetype" name="codeType" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ConceptClassId:</Form.Label>
                <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>VocabularyId:</Form.Label>
                <Form.Control type="text" id="txtName" name="vocabulary_Id" placeholder="Julio Robles" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>DomainId:</Form.Label>
                <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Track:</Form.Label>
                <Form.Control type="text" id="txtTrack" name="track"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>StandardConcept:</Form.Label>
                <Form.Control type="text" id="txtStandardConcept" name="standard_Concept" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Code:</Form.Label>
                <Form.Control type="text" id="txtCode" name="code" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeWithPeriods:</Form.Label>
                <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Codescheme:</Form.Label>
                <Form.Control type="email" id="txtCodescheme" name="codeScheme" placeholder="username@domain.com" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>LongDesc:</Form.Label>
                <Form.Control type="text" id="txtLongDesc" name="long_Desc" placeholder="Julio Robles" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ShortDesc:</Form.Label>
                <Form.Control type="text" id="txtShortDesc" name="short_Desc" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeStatus:</Form.Label>
                <Form.Control type="text" id="txtCodeStatus" name="code_Status"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeChange:</Form.Label>
                <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeChangeYear:</Form.Label>
                <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodePlannedType:</Form.Label>
                <Form.Control type="text" id="txtCodePlannedType" name="code_Planned_Type" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeBillingStatus:</Form.Label>
                <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeCmsClaimStatus:</Form.Label>
                <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="username@domain.com" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>SexCd:</Form.Label>
                <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="Julio Robles" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>AnatOrCond:</Form.Label>
                <Form.Control type="text" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>PoaCodeStatus:</Form.Label>
                <Form.Control type="text" id="txtPoaCodeStatus" name="poa_Code_Status"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>PoaCodeChange:</Form.Label>
                <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>PoaCodeChangeYear:</Form.Label>
                <Form.Control type="text" id="txtPoaCodeChangeYear" name="poa_Code_Change_Year" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ValidStartDate:</Form.Label>
                <Form.Control type="text" id="txtValidStartDate" name="valid_Start_Date"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ValidEndDate:</Form.Label>
                <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="username@domain.com" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>InvalidReason:</Form.Label>
                <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="Julio Robles" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CreateDt:</Form.Label>
                <Form.Control type="text" id="txtCreateDt" name="create_Dt" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
        </Form>
    </ModalBody>
    <ModalFooter>
        <Button variant="primary" onClick={()=>postConcept()}>Create</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
    </ModalFooter>
    </Modal>

    {/* Details */}
    <Modal isOpen={showModalDetails}>
        <ModalHeader>Details Concept</ModalHeader>
        <ModalBody>
          <Form>
          <Form.Group>
                <Form.Label>Pxordx:</Form.Label>
                <Form.Control type="text" id="txtPxordx" name="pxordx" placeholder="A" required  readOnly value={currentConcept && currentConcept.pxordx}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>OldPxordx:</Form.Label>
                <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="A" required  readOnly value={currentConcept && currentConcept.oldpxordx}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Codetype:</Form.Label>
                <Form.Control type="text" id="txtCodetype" name="codeType" placeholder="username" required  readOnly value={currentConcept && currentConcept.codeType}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ConceptClassId:</Form.Label>
                <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id"   readOnly value={currentConcept && currentConcept.concept_Class_Id}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>VocabularyId:</Form.Label>
                <Form.Control type="text" id="txtName" name="vocabulary_Id" placeholder="B" required  readOnly value={currentConcept && currentConcept.vocabulary_Id}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>DomainId:</Form.Label>
                <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="username" required  readOnly value={currentConcept && currentConcept.domain_Id}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Track:</Form.Label>
                <Form.Control type="text" id="txtTrack" name="track"   readOnly value={currentConcept && currentConcept.track}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>StandardConcept:</Form.Label>
                <Form.Control type="text" id="txtStandardConcept" name="standard_Concept" placeholder="A" required  readOnly value={currentConcept && currentConcept.standard_Concept}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Code:</Form.Label>
                <Form.Control type="text" id="txtCode" name="code" placeholder="username" required  readOnly value={currentConcept && currentConcept.code}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeWithPeriods:</Form.Label>
                <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods"   readOnly value={currentConcept && currentConcept.codeWithPeriods}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Codescheme:</Form.Label>
                <Form.Control type="email" id="txtCodescheme" name="codeScheme" placeholder="abcd" required  readOnly value={currentConcept && currentConcept.codeScheme}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>LongDesc:</Form.Label>
                <Form.Control type="text" id="txtLongDesc" name="long_Desc" placeholder="B" required  readOnly value={currentConcept && currentConcept.long_Desc}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ShortDesc:</Form.Label>
                <Form.Control type="text" id="txtShortDesc" name="short_Desc" placeholder="username" required  readOnly value={currentConcept && currentConcept.short_Desc}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeStatus:</Form.Label>
                <Form.Control type="text" id="txtCodeStatus" name="code_Status"   readOnly value={currentConcept && currentConcept.code_Status}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeChange:</Form.Label>
                <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="A" required  readOnly value={currentConcept && currentConcept.code_Change}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeChangeYear:</Form.Label>
                <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="A" required  readOnly value={currentConcept && currentConcept.code_Change_Year}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodePlannedType:</Form.Label>
                <Form.Control type="text" id="txtCodePlannedType" name="code_Planned_Type" placeholder="username" required  readOnly value={currentConcept && currentConcept.code_Planned_Type}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeBillingStatus:</Form.Label>
                <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status"   readOnly value={currentConcept && currentConcept.code_Billing_Status}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeCmsClaimStatus:</Form.Label>
                <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="abcd" required  readOnly value={currentConcept && currentConcept.code_Cms_Claim_Status}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>SexCd:</Form.Label>
                <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="B" required  readOnly value={currentConcept && currentConcept.sex_Cd}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>AnatOrCond:</Form.Label>
                <Form.Control type="text" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="username" required  readOnly value={currentConcept && currentConcept.anat_Or_Cond}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>PoaCodeStatus:</Form.Label>
                <Form.Control type="text" id="txtPoaCodeStatus" name="poa_Code_Status"   readOnly value={currentConcept && currentConcept.poa_Code_Status}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>PoaCodeChange:</Form.Label>
                <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="A" required  readOnly value={currentConcept && currentConcept.poa_Code_Change}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>PoaCodeChangeYear:</Form.Label>
                <Form.Control type="text" id="txtPoaCodeChangeYear" name="poa_Code_Change_Year" placeholder="username" required  readOnly value={currentConcept && currentConcept.poa_Code_Change_Year}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ValidStartDate:</Form.Label>
                <Form.Control type="text" id="txtValidStartDate" name="valid_Start_Date"   readOnly value={currentConcept && currentConcept.valid_Start_Date}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ValidEndDate:</Form.Label>
                <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="abcd" required  readOnly value={currentConcept && currentConcept.valid_End_Date}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>InvalidReason:</Form.Label>
                <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="B" readOnly value={currentConcept && currentConcept.invalid_Reason}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CreateDt:</Form.Label>
                <Form.Control type="text" id="txtCreateDt" name="create_Dt" placeholder="username" readOnly value={currentConcept && currentConcept.create_Dt}/>
            </Form.Group>
          </Form>
        </ModalBody>
        <ModalFooter>
          <Button variant="outline-info" onClick={()=>openCloseModalDetails()}>Back</Button>
        </ModalFooter>
      </Modal>

      {/* Delete */}
      <Modal isOpen={showModalDelete}>
        <ModalHeader>Are you sure to delete this concept?</ModalHeader>
        <ModalBody>
          <Form>
            <Form.Group>
            <Form.Label><b>Pxordx:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.pxordx}</Form.Label><br/>
                <Form.Label><b>OldPxordx:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.oldpxordx}</Form.Label><br/>
                <Form.Label><b>Codetype:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.codeType}</Form.Label><br/> 
                <Form.Label><b>ConceptClassId:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.concept_Class_Id}</Form.Label><br/>
                <Form.Label><b>VocabularyId:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.vocabulary_Id}</Form.Label><br/>
                <Form.Label><b>DomainId:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.domain_Id}</Form.Label><br/>
                <Form.Label><b>Track:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.track}</Form.Label><br/>
                <Form.Label><b>StandardConcept:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.standard_Concept}</Form.Label><br/>
                <Form.Label><b>Code:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code}</Form.Label><br/>
                <Form.Label><b>CodeWithPeriods:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.codeWithPeriods}</Form.Label><br/>
                <Form.Label><b>Codescheme:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.codeScheme}</Form.Label><br/>
                <Form.Label><b>LongDesc:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.long_Desc}</Form.Label><br/>
                <Form.Label><b>ShortDesc:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.short_Desc}</Form.Label><br/>
                <Form.Label><b>CodeStatus:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code_Status}</Form.Label><br/>
                <Form.Label><b>CodeChange:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code_Change}</Form.Label><br/>
                <Form.Label><b>CodeChangeYear:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code_Change_Year}</Form.Label><br/>
                <Form.Label><b>CodePlannedType:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code_Planned_Type}</Form.Label><br/>
                <Form.Label><b>CodeBillingStatus:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code_Billing_Status}</Form.Label><br/>
                <Form.Label><b>CodeCmsClaimStatus:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.code_Cms_Claim_Status}</Form.Label><br/>
                <Form.Label><b>SexCd:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.sex_Cd}</Form.Label><br/>
                <Form.Label><b>AnatOrCond:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.anat_Or_Cond}</Form.Label><br/>
                <Form.Label><b>PoaCodeStatus:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.poa_Code_Status}</Form.Label><br/>
                <Form.Label><b>PoaCodeChange:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.poa_Code_Change}</Form.Label><br/>
                <Form.Label><b>PoaCodeChangeYear:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.poa_Code_Change_Year}</Form.Label><br/>
                <Form.Label><b>ValidStartDate:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.valid_Start_Date}</Form.Label><br/>
                <Form.Label><b>ValidEndDate:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.valid_End_Date}</Form.Label><br/>
                <Form.Label><b>InvalidReason:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.invalid_Reason}</Form.Label><br/>
                <Form.Label><b>CreateDt:</b></Form.Label>
                <Form.Label>{currentConcept && currentConcept.create_Dt}</Form.Label><br/>
            </Form.Group>
          </Form>
        </ModalBody>
        <ModalFooter>
          <Button variant="danger" onClick={()=>deleteConcept(currentConcept.id)}>Delete</Button>
          <Button variant="outline-info" onClick={()=>openCloseModalDelete()}>Back</Button>
        </ModalFooter>
      </Modal>
  </Container>
);
}