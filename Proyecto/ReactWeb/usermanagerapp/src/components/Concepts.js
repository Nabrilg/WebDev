import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Table, Form, Col, Row } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import _ from 'lodash';


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

  const configCreate = {
    headers: {
      accept: 'application/json',
      authorization: sessionStorage.getItem('jwtToken')
    }
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

  const [searchWord, setSearchWord]= useState('');

   // Control data
  const [currentConcept, setCurrentConcept]= useState({
    id: '',
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
    create_Dt: 0,
  }); 

  const handleChange=e=>{
    const {name, value}= e.target;
    setCurrentConcept({
      ...currentConcept,
      [name]: value
    })
  }

  const handleChangeSearchWord=e=>{
   setSearchWord(e.target.value)
  }

    // Create 
  const [showModalCreate, setShowModalCreate]= useState(false);
   const openCloseModalCreate=()=>{
   setShowModalCreate(!showModalCreate);
  }  

  const postConcept=async() => {
    delete currentConcept.id;
    currentConcept.concept_Id = parseInt(currentConcept.concept_Id);
    currentConcept.code_Change_Year = parseInt(currentConcept.code_Change_Year);
    currentConcept.create_Dt = parseInt(currentConcept.create_Dt);
    debugger
    await axios.post(baseUrl, currentConcept, configCreate)
    .then (response=>{
      getConcepts();
      debugger
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

  const selectCurrentConcept=(concept, action)=>{
    setCurrentConcept(concept);
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
    currentConcept.concept_Id = parseInt(currentConcept.concept_Id);
    currentConcept.code_Change_Year = parseInt(currentConcept.code_Change_Year);
    currentConcept.create_Dt = parseInt(currentConcept.create_Dt);
    await axios.put(baseUrl+"/"+ currentConcept.id, currentConcept, config)
    .then (response=>{
      var result = response.data;
      var updatedData = data;
      console.log(updatedData);
      updatedData.map(concept=>{
        if(concept.id===currentConcept.id){
          concept.id = result.id;
          concept.pxordx = result.pxordx;
          concept.oldpxordx = result.oldpxordx;
          concept.codeType = result.codeType;
          concept.concept_Class_Id = result.concept_Class_Id;
          concept.concept_Id = result.concept_Id;
          concept.vocabulary_Id = result.vocabulary_Id;
          concept.domain_Id = result.domain_Id;
          concept.track = result.track;
          concept.standard_Concept = result.standard_Concept;
          concept.code = result.code;
          concept.codeWithPeriods = result.codeWithPeriods;
          concept.codeScheme = result.codeScheme;
          concept.long_Desc = result.long_Desc;
          concept.short_Desc = result.short_Desc;
          concept.code_Status = result.code_Status;
          concept.code_Change = result.code_Change;
          concept.code_Change_Year = result.code_Change_Year;
          concept.code_Planned_Type = result.code_Planned_Type;
          concept.code_Billing_Status = result.code_Billing_Status;
          concept.code_Cms_Claim_Status = result.code_Cms_Claim_Status;
          concept.sex_Cd = result.sex_Cd;
          concept.anat_Or_Cond = result.anat_Or_Cond;
          concept.poa_Code_Status = result.poa_Code_Status;
          concept.poa_Code_Change = result.poa_Code_Change;
          concept.poa_Code_Change_Year = result.poa_Code_Change_Year;
          concept.valid_Start_Date = result.valid_Start_Date;
          concept.valid_End_Date = result.valid_End_Date;
          concept.invalid_Reason = result.invalid_Reason;
          concept.create_Dt = result.create_Dt;
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

  function filterData(localData = [], searchString = '') {
    return _.filter(localData, obj => {
      // Go through each set and see if any of the value contains the search string
      return Object.values(obj).some(value => {
        // Stringify the value (so that we can search numbers, boolean, etc.)
        return `${value}`.toLowerCase().includes(searchString.toLowerCase());
      });
    });
  }
  
  return (
    <Container className="text-center text-md-left">
      <h1>Concepts List</h1>
      <p>
      <Form>
        <Row>
          <Col>
          <Button className="left" variant="success btn-sm" onClick={()=>openCloseModalCreate()}> <Fas icon={faPlus} /> New</Button>
          </Col>
          <Col>
          <Form.Control type="text" id="txtSearchWord" name="searchword" placeholder="Search Here"  onChange={handleChangeSearchWord}/>
          </Col>
        </Row>
      </Form>
      </p>
      <Table id="ConceptsTable">
        <thead>
            <tr>
                <th>Id</th>
                <th>ConceptId</th>
                <th>VocabularyId</th>
                <th>DomainId</th>
                <th>ShortDesc</th>
                <th>Actions</th>

            </tr>
          </thead>
        <tbody>
          {filterData(data,searchWord).map(concept=>(
            <tr key={concept.id}>
              <td>{concept.id}</td>
              <td>{concept.concept_Id}</td>
              <td>{concept.vocabulary_Id}</td>
              <td>{concept.domain_Id}</td>
              <td>{concept.short_Desc}</td>
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
                  <Form.Control type="text" id="txtPxordx" name="pxordx" placeholder="A"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>OldPxordx:</Form.Label>
                  <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="B"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Codetype:</Form.Label>
                  <Form.Control type="text" id="txtCodetype" name="codeType" placeholder="I09"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ConceptClassId:</Form.Label>
                  <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id" placeholder="" onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ConceptId:</Form.Label>
                  <Form.Control type="number" id="txtConceptId" name="concept_Id" placeholder="123456" required onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>VocabularyId:</Form.Label>
                  <Form.Control type="text" id="txtName" name="vocabulary_Id" placeholder="ICD9CM"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>DomainId:</Form.Label>
                  <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="Condition"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Track:</Form.Label>
                  <Form.Control type="text" id="txtTrack" name="track"placeholder="Medical"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>StandardConcept:</Form.Label>
                  <Form.Control type="text" id="txtStandardConcept" name="standard_Concept" placeholder="Normal"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Code:</Form.Label>
                  <Form.Control type="text" id="txtCode" name="code" placeholder="1234" required onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeWithPeriods:</Form.Label>
                  <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods" placeholder="1.234"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Codescheme:</Form.Label>
                  <Form.Control type="email" id="txtCodescheme" name="codeScheme" placeholder="abcd"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>LongDesc:</Form.Label>
                  <Form.Control type="text" id="txtLongDesc" name="long_Desc"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ShortDesc:</Form.Label>
                  <Form.Control type="text" id="txtShortDesc" name="short_Desc"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeStatus" name="code_Status"  placeholder="A" onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeChange:</Form.Label>
                  <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="Change"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeChangeYear:</Form.Label>
                  <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="2020"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodePlannedType:</Form.Label>
                  <Form.Control type="text" id="txtCodePlannedType" name="code_Planned_Type"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeBillingStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status"  placeholder="A"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeCmsClaimStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="A"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>SexCd:</Form.Label>
                  <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="F"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>AnatOrCond:</Form.Label>
                  <Form.Control type="text" id="txtAnatOrCond" name="anat_Or_Cond" placeholder=""  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeStatus:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeStatus" name="poa_Code_Status" placeholder="A" onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeChange:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="A"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeChangeYear:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeChangeYear" name="poa_Code_Change_Year" placeholder="2020"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ValidStartDate:</Form.Label>
                  <Form.Control type="text" id="txtValidStartDate" name="valid_Start_Date" placeholder="19990101" onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ValidEndDate:</Form.Label>
                  <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="20201231"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>InvalidReason:</Form.Label>
                  <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="None"  onChange={handleChange}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CreateDt:</Form.Label>
                  <Form.Control type="number" id="txtCreateDt" name="create_Dt" placeholder="12345"  onChange={handleChange}/>
              </Form.Group>
          </Form>
      </ModalBody>
      <ModalFooter>
          <Button variant="primary" onClick={()=>postConcept()}>Create</Button>
          <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
      </ModalFooter>
      </Modal>


      {/* Update */}
      <Modal isOpen={showModalUpdate}>
        <ModalHeader>Edit Concept</ModalHeader>
        <ModalBody>
          <Form>
          <Form.Group>
                  <Form.Label>Pxordx:</Form.Label>
                  <Form.Control type="text" id="txtPxordx" name="pxordx" placeholder="A"   onChange={handleChange} value={currentConcept && currentConcept.pxordx}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>OldPxordx:</Form.Label>
                  <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="A"   onChange={handleChange} value={currentConcept && currentConcept.oldpxordx}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Codetype:</Form.Label>
                  <Form.Control type="text" id="txtCodetype" name="codeType" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.codeType}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ConceptClassId:</Form.Label>
                  <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id"   onChange={handleChange} value={currentConcept && currentConcept.concept_Class_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ConceptId:</Form.Label>
                  <Form.Control type="number" id="txtConceptId" name="concept_Id" onChange={handleChange} value={currentConcept && currentConcept.concept_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>VocabularyId:</Form.Label>
                  <Form.Control type="text" id="txtName" name="vocabulary_Id" placeholder="B"   onChange={handleChange} value={currentConcept && currentConcept.vocabulary_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>DomainId:</Form.Label>
                  <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.domain_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Track:</Form.Label>
                  <Form.Control type="text" id="txtTrack" name="track"   onChange={handleChange} value={currentConcept && currentConcept.track}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>StandardConcept:</Form.Label>
                  <Form.Control type="text" id="txtStandardConcept" name="standard_Concept" placeholder="A"   onChange={handleChange} value={currentConcept && currentConcept.standard_Concept}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Code:</Form.Label>
                  <Form.Control type="text" id="txtCode" name="code" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.code}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeWithPeriods:</Form.Label>
                  <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods"   onChange={handleChange} value={currentConcept && currentConcept.codeWithPeriods}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Codescheme:</Form.Label>
                  <Form.Control type="email" id="txtCodescheme" name="codeScheme" placeholder="abcd"   onChange={handleChange} value={currentConcept && currentConcept.codeScheme}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>LongDesc:</Form.Label>
                  <Form.Control type="text" id="txtLongDesc" name="long_Desc" placeholder="B"   onChange={handleChange} value={currentConcept && currentConcept.long_Desc}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ShortDesc:</Form.Label>
                  <Form.Control type="text" id="txtShortDesc" name="short_Desc" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.short_Desc}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeStatus" name="code_Status"   onChange={handleChange} value={currentConcept && currentConcept.code_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeChange:</Form.Label>
                  <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="A"   onChange={handleChange} value={currentConcept && currentConcept.code_Change}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeChangeYear:</Form.Label>
                  <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="A"   onChange={handleChange} value={currentConcept && currentConcept.code_Change_Year}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodePlannedType:</Form.Label>
                  <Form.Control type="text" id="txtCodePlannedType" name="code_Planned_Type" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.code_Planned_Type}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeBillingStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status"   onChange={handleChange} value={currentConcept && currentConcept.code_Billing_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeCmsClaimStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="abcd"   onChange={handleChange} value={currentConcept && currentConcept.code_Cms_Claim_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>SexCd:</Form.Label>
                  <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="B"   onChange={handleChange} value={currentConcept && currentConcept.sex_Cd}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>AnatOrCond:</Form.Label>
                  <Form.Control type="text" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.anat_Or_Cond}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeStatus:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeStatus" name="poa_Code_Status"   onChange={handleChange} value={currentConcept && currentConcept.poa_Code_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeChange:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="A"   onChange={handleChange} value={currentConcept && currentConcept.poa_Code_Change}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeChangeYear:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeChangeYear" name="poa_Code_Change_Year" placeholder="username"   onChange={handleChange} value={currentConcept && currentConcept.poa_Code_Change_Year}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ValidStartDate:</Form.Label>
                  <Form.Control type="text" id="txtValidStartDate" name="valid_Start_Date"   onChange={handleChange} value={currentConcept && currentConcept.valid_Start_Date}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ValidEndDate:</Form.Label>
                  <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="abcd"   onChange={handleChange} value={currentConcept && currentConcept.valid_End_Date}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>InvalidReason:</Form.Label>
                  <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="B" onChange={handleChange} value={currentConcept && currentConcept.invalid_Reason}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CreateDt:</Form.Label>
                  <Form.Control type="number" id="txtCreateDt" name="create_Dt" placeholder="username" onChange={handleChange} value={currentConcept && currentConcept.create_Dt}/>
              </Form.Group>
          </Form>
        </ModalBody>
        <ModalFooter>
          <Button variant="primary" onClick={()=>putConcept()}>Save</Button>
          <Button variant="outline-info" onClick={()=>openCloseModalUpdate()}>Back</Button>
        </ModalFooter>
      </Modal>

      {/* Details */}
      <Modal isOpen={showModalDetails}>
          <ModalHeader>Details Concept</ModalHeader>
          <ModalBody>
            <Form>
            <Form.Group>
                  <Form.Label>Pxordx:</Form.Label>
                  <Form.Control type="text" id="txtPxordx" name="pxordx" placeholder="A"   readOnly value={currentConcept && currentConcept.pxordx}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>OldPxordx:</Form.Label>
                  <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="A"   readOnly value={currentConcept && currentConcept.oldpxordx}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Codetype:</Form.Label>
                  <Form.Control type="text" id="txtCodetype" name="codeType" placeholder="username"   readOnly value={currentConcept && currentConcept.codeType}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ConceptClassId:</Form.Label>
                  <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id"   readOnly value={currentConcept && currentConcept.concept_Class_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>VocabularyId:</Form.Label>
                  <Form.Control type="text" id="txtName" name="vocabulary_Id" placeholder="B"   readOnly value={currentConcept && currentConcept.vocabulary_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>DomainId:</Form.Label>
                  <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="username"   readOnly value={currentConcept && currentConcept.domain_Id}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Track:</Form.Label>
                  <Form.Control type="text" id="txtTrack" name="track"   readOnly value={currentConcept && currentConcept.track}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>StandardConcept:</Form.Label>
                  <Form.Control type="text" id="txtStandardConcept" name="standard_Concept" placeholder="A"   readOnly value={currentConcept && currentConcept.standard_Concept}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Code:</Form.Label>
                  <Form.Control type="text" id="txtCode" name="code" placeholder="username"   readOnly value={currentConcept && currentConcept.code}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeWithPeriods:</Form.Label>
                  <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods"   readOnly value={currentConcept && currentConcept.codeWithPeriods}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>Codescheme:</Form.Label>
                  <Form.Control type="email" id="txtCodescheme" name="codeScheme" placeholder="abcd"   readOnly value={currentConcept && currentConcept.codeScheme}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>LongDesc:</Form.Label>
                  <Form.Control type="text" id="txtLongDesc" name="long_Desc" placeholder="B"   readOnly value={currentConcept && currentConcept.long_Desc}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ShortDesc:</Form.Label>
                  <Form.Control type="text" id="txtShortDesc" name="short_Desc" placeholder="username"   readOnly value={currentConcept && currentConcept.short_Desc}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeStatus" name="code_Status"   readOnly value={currentConcept && currentConcept.code_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeChange:</Form.Label>
                  <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="A"   readOnly value={currentConcept && currentConcept.code_Change}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeChangeYear:</Form.Label>
                  <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="A"   readOnly value={currentConcept && currentConcept.code_Change_Year}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodePlannedType:</Form.Label>
                  <Form.Control type="text" id="txtCodePlannedType" name="code_Planned_Type" placeholder="username"   readOnly value={currentConcept && currentConcept.code_Planned_Type}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeBillingStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status"   readOnly value={currentConcept && currentConcept.code_Billing_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CodeCmsClaimStatus:</Form.Label>
                  <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="abcd"   readOnly value={currentConcept && currentConcept.code_Cms_Claim_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>SexCd:</Form.Label>
                  <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="B"   readOnly value={currentConcept && currentConcept.sex_Cd}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>AnatOrCond:</Form.Label>
                  <Form.Control type="text" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="username"   readOnly value={currentConcept && currentConcept.anat_Or_Cond}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeStatus:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeStatus" name="poa_Code_Status"   readOnly value={currentConcept && currentConcept.poa_Code_Status}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeChange:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="A"   readOnly value={currentConcept && currentConcept.poa_Code_Change}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>PoaCodeChangeYear:</Form.Label>
                  <Form.Control type="text" id="txtPoaCodeChangeYear" name="poa_Code_Change_Year" placeholder="username"   readOnly value={currentConcept && currentConcept.poa_Code_Change_Year}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ValidStartDate:</Form.Label>
                  <Form.Control type="text" id="txtValidStartDate" name="valid_Start_Date"   readOnly value={currentConcept && currentConcept.valid_Start_Date}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>ValidEndDate:</Form.Label>
                  <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="abcd"   readOnly value={currentConcept && currentConcept.valid_End_Date}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>InvalidReason:</Form.Label>
                  <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="B" readOnly value={currentConcept && currentConcept.invalid_Reason}/>
              </Form.Group>
              <Form.Group>
                  <Form.Label>CreateDt:</Form.Label>
                  <Form.Control type="number" id="txtCreateDt" name="create_Dt" placeholder="username" readOnly value={currentConcept && currentConcept.create_Dt}/>
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
              <Table id="ConceptsTable">
              <thead>
                  <tr>
                      <th>Name</th>
                      <th>Value</th>

                  </tr>
                </thead>
              <tbody>
              <tr><td><b>Pxordx:</b></td>
                  <td>{currentConcept && currentConcept.pxordx}</td></tr>
                  <tr>
                    <td><b>OldPxordx:</b></td>
                    <td>{currentConcept && currentConcept.oldpxordx}</td>
                    </tr>
                  <tr>
                    <td><b>Codetype:</b></td>
                    <td>{currentConcept && currentConcept.codeType}</td>
                  </tr> 
                  <tr>
                    <td><b>ConceptClassId:</b></td>
                    <td>{currentConcept && currentConcept.concept_Class_Id}</td>
                  </tr>
                  <tr>
                    <td><b>VocabularyId:</b></td>
                    <td>{currentConcept && currentConcept.vocabulary_Id}</td>
                  </tr>
                  <tr>
                    <td><b>DomainId:</b></td>
                    <td>{currentConcept && currentConcept.domain_Id}</td>
                  </tr>
                  <tr>
                    <td><b>Track:</b></td>
                    <td>{currentConcept && currentConcept.track}</td>
                  </tr>
                  <tr>
                    <td><b>StandardConcept:</b></td>
                    <td>{currentConcept && currentConcept.standard_Concept}</td>
                  </tr>
                  <tr>
                    <td><b>Code:</b></td>
                    <td>{currentConcept && currentConcept.code}</td>
                  </tr>
                  <tr>
                    <td><b>CodeWithPeriods:</b></td>
                    <td>{currentConcept && currentConcept.codeWithPeriods}</td>
                    </tr>
                  <tr>
                    <td><b>Codescheme:</b></td>
                    <td>{currentConcept && currentConcept.codeScheme}</td>
                    </tr>
                  <tr>
                    <td><b>LongDesc:</b></td>
                    <td>{currentConcept && currentConcept.long_Desc}</td>
                  </tr>
                  <tr>
                    <td><b>ShortDesc:</b></td>
                  <td>{currentConcept && currentConcept.short_Desc}</td>
                  </tr>
                  <tr>
                    <td><b>CodeStatus:</b></td>
                    <td>{currentConcept && currentConcept.code_Status}</td>
                  </tr>
                  <tr>
                    <td><b>CodeChange:</b></td>
                    <td>{currentConcept && currentConcept.code_Change}</td>
                  </tr>
                  <tr>
                    <td><b>CodeChangeYear:</b></td>
                    <td>{currentConcept && currentConcept.code_Change_Year}</td>
                  </tr>
                  <tr>
                    <td><b>CodePlannedType:</b></td>
                    <td>{currentConcept && currentConcept.code_Planned_Type}</td>
                  </tr>
                  <tr>
                    <td><b>CodeBillingStatus:</b></td>
                    <td>{currentConcept && currentConcept.code_Billing_Status}</td>
                  </tr>
                  <tr>
                    <td><b>CodeCmsClaimStatus:</b></td>
                    <td>{currentConcept && currentConcept.code_Cms_Claim_Status}</td>
                  </tr>
                  <tr>
                    <td><b>SexCd:</b></td>
                    <td>{currentConcept && currentConcept.sex_Cd}</td>
                  </tr>
                  <tr>
                    <td><b>AnatOrCond:</b></td>
                    <td>{currentConcept && currentConcept.anat_Or_Cond}</td>
                  </tr>
                  <tr>
                    <td><b>PoaCodeStatus:</b></td>
                    <td>{currentConcept && currentConcept.poa_Code_Status}</td>
                  </tr>
                  <tr>
                    <td><b>PoaCodeChange:</b></td>
                    <td>{currentConcept && currentConcept.poa_Code_Change}</td>
                  </tr>
                  <tr>
                    <td><b>PoaCodeChangeYear:</b></td>
                    <td>{currentConcept && currentConcept.poa_Code_Change_Year}</td>
                  </tr>
                  <tr>
                    <td><b>ValidStartDate:</b></td>
                    <td>{currentConcept && currentConcept.valid_Start_Date}</td>
                  </tr>
                  <tr>
                    <td><b>ValidEndDate:</b></td>
                    <td>{currentConcept && currentConcept.valid_End_Date}</td>
                  </tr>
                  <tr>
                    <td><b>InvalidReason:</b></td>
                    <td>{currentConcept && currentConcept.invalid_Reason}</td>
                  </tr>
                  <tr>
                    <td><b>CreateDt:</b></td>
                    <td>{currentConcept && currentConcept.create_Dt}</td>
                  </tr>
              </tbody>
              </Table>
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