import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader, Col } from 'reactstrap';
import { Button, Container,Form } from 'react-bootstrap';
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';

const baseUrl = "https://javerianawebdevapi.azurewebsites.net/api/concepts";
//const baseUrl = "https://localhost:44306/api/concepts";


export function ListConcepts()
{
  // Control data
  const [currentConcept, setCurrentConcept]= useState({
    id: 0, 
    pxordx: '',
    oldpxordx: '',
    codeType: '',
    concept_Class_Id: '',
    concept_Id: 0, 
    vocabulary_Id: '',
    domain_Id: '',
    track: '',
    standard_Concept	: '',
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
  });

  //Change manager for the data coming from forms.
  const handleChange=e=>{
    const {name, value}= e.target;
    setCurrentConcept({
      ...currentConcept,
      [name]: value
    })
  }

  

  const [ data, setData]=useState([]);

  //Get All
  const getConcepts=async()=>{
    await axios.get(baseUrl, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
    .then (response=>{
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }

  useEffect(()=>{
    getConcepts();
  },[]);


   // Create 
  const [showModalCreate, setShowModalCreate]= useState(false);
  const openCloseModalCreate=()=>{
  setShowModalCreate(!showModalCreate);
  } 


  const postConcept = async() => {
    delete currentConcept.id;

    //Convert to integer the data that is storage as INT in BD
    currentConcept.concept_Id = parseInt(currentConcept.concept_Id);
    currentConcept.code_Change_Year = parseInt(currentConcept.code_Change_Year);
    currentConcept.create_Dt = parseInt(currentConcept.create_Dt);

    console.log(currentConcept)
    await axios.post(baseUrl, currentConcept, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
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

  //PUT method
  const putConcept = async() => {
    //Convert to integer the data that is storage as INT in BD
    currentConcept.concept_Id = parseInt(currentConcept.concept_Id);
    currentConcept.code_Change_Year = parseInt(currentConcept.code_Change_Year);
    currentConcept.create_Dt = parseInt(currentConcept.create_Dt);
    await axios.put(baseUrl+"/"+ currentConcept.id, currentConcept, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
    .then (response=>{
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

  //DELETE method
  const deleteConcept = async() => {
    await axios.delete(baseUrl+"/"+ currentConcept.id, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
    .then (()=>{
      setData(data.filter(usr=>usr.id!==currentConcept.id));
      openCloseModalDelete();
    }).catch(error=>{
      console.log(error);
    })
  }  


  //Columns of the list
  const columns = [
    {dataField: "id", text: "Id", headerStyle: (column, colIndex) => {return { width: '6%' }; }},
    {dataField: "concept_Id", text: "Concept Id", headerStyle: (column, colIndex) => {return { width: '10%' }; }},
    {dataField: "code", text: "Code", headerStyle: (column, colIndex) => {return { width: '10%' }; }},
    {dataField: "short_Desc", text: "Short Descr.", headerStyle: (column, colIndex) => {return { width: '30%' }; }},
    {dataField: "actions", text: "Actions",headerStyle: (column, colIndex) => {return { width: '23%' }; }, formatter: (rowContent, row) => {
      return (    
        <div >
        <Button variant="outline-primary" onClick={()=>selectCurrentConcept(row, "Edit")}>Edit</Button>{"  "} 
        <Button variant="outline-warning" onClick={()=>selectCurrentConcept(row, "Details")}>Details</Button>{"  "}
        <Button variant="outline-danger" onClick={()=>selectCurrentConcept(row, "Delete")}>Delete</Button>
        </div>
      )}
    },
  ];

  //Search bar
  const { SearchBar } = Search;

return (
  <Container className="text-center text-md-left" style={{paddingTop:"15px"}}>

    {/* Create the table */}
    <ToolkitProvider 
    keyField="id"
    data= {data}
    columns={columns}
    search
    >
    {
      props => (
        <div>
          <div className="container-fluid">
            <div className="row">
              <div className="col" style={{float:"left"}}>
              <h1>Concept List</h1>
              <p>
              <Button className="left" variant="success btn-sm" onClick={()=>openCloseModalCreate()}> <Fas icon={faPlus} /> New</Button>
              </p>
              </div>
              <div className="col-xs-7" style={{float:"right", width:"35%"}}>
                <h3>Barra de búsqueda:</h3>
                <SearchBar { ...props.searchProps } />
                <hr />
              </div>
            </div>
          </div>
          <BootstrapTable
            { ...props.baseProps }
            pagination={ paginationFactory() }
          />
        </div>
      )
    }

    </ToolkitProvider>

    {/* Create */}
    <Modal isOpen={showModalCreate}  size="lg">
      <ModalHeader>Create Concept</ModalHeader>
      <ModalBody>
        <Form>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Pxordx:</Form.Label>
              <Form.Control type="email" id="txtPxordx" name="pxordx" placeholder="D" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Oldpxordx:</Form.Label>
              <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="D" onChange={handleChange} />
            </Form.Group>    
            <Form.Group as={Col}>
              <Form.Label>CodeType:</Form.Label>
              <Form.Control type="text" id="txtCodeType" name="codeType" placeholder="I09" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Concept class Id:</Form.Label>
              <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id" placeholder="3-dig nonbill" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Concept Id:</Form.Label>
              <Form.Control type="number" id="txtConceptId" name="concept_Id"   placeholder="44829696" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Vocabulary Id:</Form.Label>
              <Form.Control type="email" id="txtVocabularyId" name="vocabulary_Id" placeholder="ICD9CM" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Domain id:</Form.Label>
              <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="Condition" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Track:</Form.Label>
              <Form.Control type="text" id="txtTrack" name="track" placeholder="Medical" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Standar concept:</Form.Label>
              <Form.Control type="text" id="txtStandarConcept" name="standard_Concept" placeholder="Normal" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code:</Form.Label>
              <Form.Control type="email" id="txtCode" name="code" placeholder="1" required onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code with periods:</Form.Label>
              <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods" placeholder="1" onChange={handleChange}  />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code scheme:</Form.Label>
              <Form.Control type="text" id="txtCodeScheme" name="codeScheme" placeholder="ICD9DIAG" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Long desc.:</Form.Label>
              <Form.Control type="text" id="txtLongDesc" name="long_Desc"  placeholder="Cholera due to vibrio cholerae" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Short desc.:</Form.Label>
              <Form.Control type="email" id="txtShortDesc" name="short_Desc" placeholder="Cholera" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code status:</Form.Label>
              <Form.Control type="text" id="txtCodeStatus" name="code_Status" placeholder="I" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code change:</Form.Label>
              <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="Deleted" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code change year:</Form.Label>
              <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="2015" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code planned type:</Form.Label>
              <Form.Control type="email" id="txtCodePlannedType" name="code_Planned_Type" placeholder="UP" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code billing status:</Form.Label>
              <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status" placeholder="Y" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code Cms claim status:</Form.Label>
              <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="Y" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Sex cd:</Form.Label>
              <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="M" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Anat or Cond:</Form.Label>
              <Form.Control type="email" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="C" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Poa code status:</Form.Label>
              <Form.Control type="text" id="txtCodeStatus" name="poa_Code_Status" placeholder="N" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Poa code change:</Form.Label>
              <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="No change" onChange={handleChange} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Poa code change Year:</Form.Label>
              <Form.Control type="text" id="txtCodeChangeYear" name="poa_Code_Change_Year" placeholder="2015" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Valid start date:</Form.Label>
              <Form.Control type="email" id="txtValidStartDate" name="valid_Start_Date" placeholder="19700101" onChange={handleChange} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Valid end date:</Form.Label>
              <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="20991231" onChange={handleChange}/>
            </Form.Group>
          </Form.Row>
          <Form.Row >
              <Form.Group as={Col}>
              <Form.Label>invalid reason:</Form.Label>
              <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="None" onChange={handleChange}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Create dateTime:</Form.Label>
              <Form.Control type="number" id="txtCreateDt" name="create_Dt" placeholder="42005" onChange={handleChange}/>
            </Form.Group>
          </Form.Row>
        </Form>
      </ModalBody>
      <ModalFooter>
        <Button variant="primary" onClick={()=>postConcept()}>Create</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
      </ModalFooter>
    </Modal>

    {/* Update */}
    <Modal isOpen={showModalUpdate}  size="lg">
      <ModalHeader>Edit Concept</ModalHeader>
      <ModalBody>
      <Form>
          <Form.Group>
            <Form.Label>Id:</Form.Label>
            <Form.Control type="text" id="txtId" name="id" readOnly value={currentConcept && currentConcept.id}/>
          </Form.Group>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Pxordx:</Form.Label>
              <Form.Control type="email" id="txtPxordx" name="pxordx" placeholder="D" required onChange={handleChange} value={currentConcept && currentConcept.pxordx}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Oldpxordx:</Form.Label>
              <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="D" required onChange={handleChange} value={currentConcept && currentConcept.oldpxordx}/>
            </Form.Group>    
            <Form.Group as={Col}>
              <Form.Label>CodeType:</Form.Label>
              <Form.Control type="text" id="txtCodeType" name="codeType" placeholder="I09" required onChange={handleChange} value={currentConcept && currentConcept.codeType}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Concept class Id:</Form.Label>
              <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id" placeholder="3-dig nonbill" required onChange={handleChange} value={currentConcept && currentConcept.concept_Class_Id}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Concept Id:</Form.Label>
              <Form.Control type="number" id="txtConceptId" name="concept_Id"   placeholder="44829696" required onChange={handleChange} value={currentConcept && currentConcept.concept_Id}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Vocabulary Id:</Form.Label>
              <Form.Control type="email" id="txtVocabularyId" name="vocabulary_Id" placeholder="ICD9CM" required onChange={handleChange} value={currentConcept && currentConcept.vocabulary_Id}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Domain id:</Form.Label>
              <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="Condition" required onChange={handleChange} value={currentConcept && currentConcept.domain_Id}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Track:</Form.Label>
              <Form.Control type="text" id="txtTrack" name="track" placeholder="Medical" required onChange={handleChange} value={currentConcept && currentConcept.track}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Standar concept:</Form.Label>
              <Form.Control type="text" id="txtStandarConcept" name="standard_Concept" placeholder="Normal" required onChange={handleChange} value={currentConcept && currentConcept.standard_Concept}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code:</Form.Label>
              <Form.Control type="email" id="txtCode" name="code" placeholder="1" required onChange={handleChange} value={currentConcept && currentConcept.code}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code with periods:</Form.Label>
              <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods" placeholder="1" required onChange={handleChange} value={currentConcept && currentConcept.codeWithPeriods} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code scheme:</Form.Label>
              <Form.Control type="text" id="txtCodeScheme" name="codeScheme" placeholder="ICD9DIAG" required onChange={handleChange} value={currentConcept && currentConcept.codeScheme}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Long desc.:</Form.Label>
              <Form.Control type="text" id="txtLongDesc" name="long_Desc"  placeholder="Cholera due to vibrio cholerae" required onChange={handleChange} value={currentConcept && currentConcept.long_Desc}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Short desc.:</Form.Label>
              <Form.Control type="email" id="txtShortDesc" name="short_Desc" placeholder="Cholera" required onChange={handleChange} value={currentConcept && currentConcept.short_Desc}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code status:</Form.Label>
              <Form.Control type="text" id="txtCodeStatus" name="code_Status" placeholder="I" required onChange={handleChange} value={currentConcept && currentConcept.code_Status} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code change:</Form.Label>
              <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="Deleted" required onChange={handleChange} value={currentConcept && currentConcept.code_Change}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code change year:</Form.Label>
              <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="2015" required onChange={handleChange} value={currentConcept && currentConcept.code_Change_Year}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code planned type:</Form.Label>
              <Form.Control type="email" id="txtCodePlannedType" name="code_Planned_Type" placeholder="UP" required onChange={handleChange} value={currentConcept && currentConcept.code_Planned_Type}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code billing status:</Form.Label>
              <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status" placeholder="Y" required onChange={handleChange} value={currentConcept && currentConcept.code_Billing_Status}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code Cms claim status:</Form.Label>
              <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="Y" required onChange={handleChange} value={currentConcept && currentConcept.code_Cms_Claim_Status}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Sex cd:</Form.Label>
              <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="M" required onChange={handleChange} value={currentConcept && currentConcept.sex_Cd}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Anat or Cond:</Form.Label>
              <Form.Control type="email" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="C" required onChange={handleChange} value={currentConcept && currentConcept.anat_Or_Cond}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Poa code status:</Form.Label>
              <Form.Control type="text" id="txtCodeStatus" name="poa_Code_Status" placeholder="N" required onChange={handleChange} value={currentConcept && currentConcept.poa_Code_Status}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Poa code change:</Form.Label>
              <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="No change" required onChange={handleChange} value={currentConcept && currentConcept.poa_Code_Change}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Poa code change Year:</Form.Label>
              <Form.Control type="text" id="txtCodeChangeYear" name="poa_Code_Change_Year" placeholder="2015" required onChange={handleChange} value={currentConcept && currentConcept.poa_Code_Change_Year}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Valid start date:</Form.Label>
              <Form.Control type="email" id="txtValidStartDate" name="valid_Start_Date" placeholder="19700101" required onChange={handleChange} value={currentConcept && currentConcept.valid_Start_Date}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Valid end date:</Form.Label>
              <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="20991231" required onChange={handleChange} value={currentConcept && currentConcept.valid_End_Date}/>
            </Form.Group>
          </Form.Row>
          <Form.Row >
              <Form.Group as={Col}>
              <Form.Label>invalid reason:</Form.Label>
              <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="None" required onChange={handleChange} value={currentConcept && currentConcept.invalid_Reason}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Create dateTime:</Form.Label>
              <Form.Control type="number" id="txtCreateDt" name="create_Dt" placeholder="42005" required onChange={handleChange} value={currentConcept && currentConcept.create_Dt}/>
            </Form.Group>
          </Form.Row>
        </Form>
      </ModalBody>
      <ModalFooter>
        <Button variant="primary" onClick={()=>putConcept()}>Save</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalUpdate()}>Back</Button>
      </ModalFooter>
    </Modal>

    {/* Details */}
    <Modal isOpen={showModalDetails} size="lg">
      <ModalHeader>Details Concept</ModalHeader>
      <ModalBody>
        <Form>
          <Form.Group>
            <Form.Label>Id:</Form.Label>
            <Form.Control type="text" id="txtId" name="id" readOnly value={currentConcept && currentConcept.id}/>
          </Form.Group>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Pxordx:</Form.Label>
              <Form.Control type="email" id="txtPxordx" name="pxordx" placeholder="D" readOnly value={currentConcept && currentConcept.pxordx}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Oldpxordx:</Form.Label>
              <Form.Control type="text" id="txtOldPxordx" name="oldpxordx" placeholder="D" readOnly value={currentConcept && currentConcept.oldpxordx}/>
            </Form.Group>    
            <Form.Group as={Col}>
              <Form.Label>CodeType:</Form.Label>
              <Form.Control type="text" id="txtCodeType" name="codeType" placeholder="I09" readOnly value={currentConcept && currentConcept.codeType}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Concept class Id:</Form.Label>
              <Form.Control type="text" id="txtConceptClassId" name="concept_Class_Id" placeholder="3-dig nonbill" readOnly value={currentConcept && currentConcept.concept_Class_Id}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Concept Id:</Form.Label>
              <Form.Control type="number" id="txtConceptId" name="concept_Id"   placeholder="44829696" readOnly value={currentConcept && currentConcept.concept_Id}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Vocabulary Id:</Form.Label>
              <Form.Control type="email" id="txtVocabularyId" name="vocabulary_Id" placeholder="ICD9CM" readOnly value={currentConcept && currentConcept.vocabulary_Id}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Domain id:</Form.Label>
              <Form.Control type="text" id="txtDomainId" name="domain_Id" placeholder="Condition" readOnly value={currentConcept && currentConcept.domain_Id}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Track:</Form.Label>
              <Form.Control type="text" id="txtTrack" name="track" placeholder="Medical" readOnly value={currentConcept && currentConcept.track}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Standar concept:</Form.Label>
              <Form.Control type="text" id="txtStandarConcept" name="standard_Concept" placeholder="Normal" readOnly value={currentConcept && currentConcept.standard_Concept}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code:</Form.Label>
              <Form.Control type="email" id="txtCode" name="code" placeholder="1" readOnly value={currentConcept && currentConcept.code}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code with periods:</Form.Label>
              <Form.Control type="text" id="txtCodeWithPeriods" name="codeWithPeriods" placeholder="1" readOnly value={currentConcept && currentConcept.codeWithPeriods} />
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code scheme:</Form.Label>
              <Form.Control type="text" id="txtCodeScheme" name="codeScheme" placeholder="ICD9DIAG" readOnly value={currentConcept && currentConcept.codeScheme}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Long desc.:</Form.Label>
              <Form.Control type="text" id="txtLongDesc" name="long_Desc"  placeholder="Cholera due to vibrio cholerae" readOnly value={currentConcept && currentConcept.long_Desc}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Short desc.:</Form.Label>
              <Form.Control type="email" id="txtShortDesc" name="short_Desc" placeholder="Cholera" readOnly value={currentConcept && currentConcept.short_Desc}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code status:</Form.Label>
              <Form.Control type="text" id="txtCodeStatus" name="code_Status" placeholder="I" readOnly value={currentConcept && currentConcept.code_Status} />
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code change:</Form.Label>
              <Form.Control type="text" id="txtCodeChange" name="code_Change" placeholder="Deleted" readOnly value={currentConcept && currentConcept.code_Change}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code change year:</Form.Label>
              <Form.Control type="number" id="txtCodeChangeYear" name="code_Change_Year" placeholder="2015" readOnly value={currentConcept && currentConcept.code_Change_Year}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code planned type:</Form.Label>
              <Form.Control type="email" id="txtCodePlannedType" name="code_Planned_Type" placeholder="UP" readOnly value={currentConcept && currentConcept.code_Planned_Type}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Code billing status:</Form.Label>
              <Form.Control type="text" id="txtCodeBillingStatus" name="code_Billing_Status" placeholder="Y" readOnly value={currentConcept && currentConcept.code_Billing_Status}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Code Cms claim status:</Form.Label>
              <Form.Control type="text" id="txtCodeCmsClaimStatus" name="code_Cms_Claim_Status" placeholder="Y" readOnly value={currentConcept && currentConcept.code_Cms_Claim_Status}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Sex cd:</Form.Label>
              <Form.Control type="text" id="txtSexCd" name="sex_Cd" placeholder="M" readOnly value={currentConcept && currentConcept.sex_Cd}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Anat or Cond:</Form.Label>
              <Form.Control type="email" id="txtAnatOrCond" name="anat_Or_Cond" placeholder="C" readOnly value={currentConcept && currentConcept.anat_Or_Cond}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Poa code status:</Form.Label>
              <Form.Control type="text" id="txtCodeStatus" name="poa_Code_Status" placeholder="N" readOnly value={currentConcept && currentConcept.poa_Code_Status}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Poa code change:</Form.Label>
              <Form.Control type="text" id="txtPoaCodeChange" name="poa_Code_Change" placeholder="No change" readOnly value={currentConcept && currentConcept.poa_Code_Change}/>
            </Form.Group>
          </Form.Row>
          <Form.Row>
            <Form.Group as={Col}>
              <Form.Label>Poa code change Year:</Form.Label>
              <Form.Control type="text" id="txtCodeChangeYear" name="poa_Code_Change_Year" placeholder="2015" readOnly value={currentConcept && currentConcept.poa_Code_Change_Year}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Valid start date:</Form.Label>
              <Form.Control type="email" id="txtValidStartDate" name="valid_Start_Date" placeholder="19700101" readOnly value={currentConcept && currentConcept.valid_Start_Date}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Valid end date:</Form.Label>
              <Form.Control type="text" id="txtValidEndDate" name="valid_End_Date" placeholder="20991231" readOnly value={currentConcept && currentConcept.valid_End_Date}/>
            </Form.Group>
          </Form.Row>
          <Form.Row >
              <Form.Group as={Col}>
              <Form.Label>invalid reason:</Form.Label>
              <Form.Control type="text" id="txtInvalidReason" name="invalid_Reason" placeholder="None" readOnly value={currentConcept && currentConcept.invalid_Reason}/>
            </Form.Group>
            <Form.Group as={Col}>
              <Form.Label>Create dateTime:</Form.Label>
              <Form.Control type="number" id="txtCreateDt" name="create_Dt" placeholder="42005" readOnly value={currentConcept && currentConcept.create_Dt}/>
            </Form.Group>
          </Form.Row>
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
            <Form.Label><b>Id:</b></Form.Label>
            <Form.Label>{currentConcept && currentConcept.id}</Form.Label><br/>
            <Form.Label><b>Concept Id:</b></Form.Label>
            <Form.Label>{currentConcept && currentConcept.concept_Id}</Form.Label><br/>
            <Form.Label><b>Short desc.:</b></Form.Label>
            <Form.Label>{currentConcept && currentConcept.short_Desc}</Form.Label><br/>
  
            
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