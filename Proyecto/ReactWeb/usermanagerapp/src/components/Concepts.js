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
    codetype: '',
    conceptClassId: '',
    conceptId: '',
    vocabularyId: '',
    domainId: '',
    track: '',
    standardConcept: '',
    code: '',
    codewithperiods: '',
    codescheme: '',
    longDesc: '',
    shortDesc: '',
    codeStatus: '',
    codeChange: '',
    codeChangeYear: '',
    codePlannedType: '',
    codeBillingStatus: '',
    codeCmsClaimStatus: '',
    sexCd: '',
    anatOrCond: '',
    poaCodeStatus: '',
    poaCodeChange: '',
    poaCodeChangeYear: '',
    validStartDate: '',
    validEndDate: '',
    invalidReason: '',
    createDt: ''
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
              <Button variant="outline-primary btn-sm">Edit</Button> 
              <Button variant="outline-warning btn-sm">Details</Button> 
              <Button variant="outline-danger btn-sm">Delete</Button> 
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
                <Form.Control type="text" id="txtConceptname" name="username" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ConceptClassId:</Form.Label>
                <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ConceptId:</Form.Label>
                <Form.Control type="email" id="txtEmail" name="email" placeholder="username@domain.com" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>VocabularyId:</Form.Label>
                <Form.Control type="text" id="txtName" name="name" placeholder="Julio Robles" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>DomainId:</Form.Label>
                <Form.Control type="text" id="txtConceptname" name="username" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Track:</Form.Label>
                <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>StandardConcept:</Form.Label>
                <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="A" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Code:</Form.Label>
                <Form.Control type="text" id="txtConceptname" name="username" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Codewithperiods:</Form.Label>
                <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>Codescheme:</Form.Label>
                <Form.Control type="email" id="txtEmail" name="email" placeholder="username@domain.com" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>LongDesc:</Form.Label>
                <Form.Control type="text" id="txtName" name="name" placeholder="Julio Robles" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>ShortDesc:</Form.Label>
                <Form.Control type="text" id="txtConceptname" name="username" placeholder="username" required onChange={handleChange}/>
            </Form.Group>
            <Form.Group>
                <Form.Label>CodeStatus:</Form.Label>
                <Form.Control type="text" id="txtPassword" name="password"  onChange={handleChange}/>
            </Form.Group>
        </Form>
    </ModalBody>
    <ModalFooter>
        <Button variant="primary" onClick={()=>postConcept()}>Create</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
    </ModalFooter>
    </Modal>

  </Container>
);
}