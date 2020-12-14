import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Table, Form } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';

export function Concepts(){

    const baseUrl = "https://javerianawebdevapi.azurewebsites.net/api/concepts";

    const [ data, setData ] = useState([]);

    const GetConcepts = async () => {
        await axios.get(baseUrl, {
            headers: {
                'Content-Type' : 'application/json',
                'Authorization' : 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlMTU1Y2YzOC1lYzNkLTRlZjYtODY0Ny0zZWYzYWM4NDUzNjYiLCJuYW1laWQiOiI4IiwibmFtZSI6IlZpY3RvciBPc3BpbmEiLCJ1c2VybmFtZSI6IlZPc3BpbmEiLCJlbWFpbCI6IlZpY3Rvci5Pc3BpbmFAZW1haWwuY29tIiwibmJmIjoxNjA3OTU5NzcyLCJleHAiOjE2MDgwNDYxNzIsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdC9hcGkvdXNlcnMifQ.09kM13JXMoPMkSYu8Z5ckFCIKq8EVl_wMMYrKNyOVg0'
            }
        })
        .then(response => {
            setData(response.data);
        }).catch(error => {
            console.log(error);
        })
    }

    useEffect(() => {
        GetConcepts();
    },[]);

    // Control data
    const [currentConcept, setCurrentConcept]= useState({
        id: '', 
        pxordx: '',
        oldpxordx: '',
        codeType: '',
        concept_Class_Id: '',
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

    const postConcept = async() => {
        delete currentConcept.id;
        await axios.post(baseUrl, currentConcept, {
            headers: {
                'Content-Type' : 'application/json',
                'Authorization' : 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiJlMTU1Y2YzOC1lYzNkLTRlZjYtODY0Ny0zZWYzYWM4NDUzNjYiLCJuYW1laWQiOiI4IiwibmFtZSI6IlZpY3RvciBPc3BpbmEiLCJ1c2VybmFtZSI6IlZPc3BpbmEiLCJlbWFpbCI6IlZpY3Rvci5Pc3BpbmFAZW1haWwuY29tIiwibmJmIjoxNjA3OTU5NzcyLCJleHAiOjE2MDgwNDYxNzIsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdC9hcGkvdXNlcnMifQ.09kM13JXMoPMkSYu8Z5ckFCIKq8EVl_wMMYrKNyOVg0'
            }
        })
        .then (response=>{
          GetConcepts();
          openCloseModalCreate();
        }).catch(error=>{
          console.log(error);
        })
      }

    return(
    <Container className="text-center text-md-left">
    <h1>Concept List</h1>
    <p>
      <Button className="left" variant="success btn-sm" onClick={()=>openCloseModalCreate()} > <Fas icon={faPlus} /> New</Button>
    </p>
    <Table id="UsersTable">
      <thead>
          <tr>
              <th>Id</th>
              <th>PXORDX</th>
              <th>Code Type</th>
              <th>Concept Id</th>
              <th>Vocabulary Id</th>
              <th>Actions</th>
          </tr>
        </thead>
      <tbody>
        {data.map(con => (
            <tr>
                <td>{ con.id }</td>
                <td>{ con.pxordx }</td>
                <td>{ con.codeType }</td>
                <td>{ con.concept_Id }</td>
                <td>{ con.vocabulary_Id }</td>
                <td>
                    <Button variant="outline-primary btn-sm">Edit</Button> 
                    <Button variant="outline-warning btn-sm">Details</Button> 
                    <Button variant="outline-danger btn-sm">Delete</Button> 
                </td>
            </tr>
        ))}  
        
      </tbody>
    </Table>

    <Modal isOpen={showModalCreate}>
  <ModalHeader>Create User</ModalHeader>
  <ModalBody>
    <Form>
      <Form.Group>
        <Form.Label>pxordx:</Form.Label>
        <Form.Control type="text" id="txtpxordx" name="pxordx" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>oldpxordx:</Form.Label>
        <Form.Control type="text" id="txtoldpxordx" name="oldpxordx" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>Code Type:</Form.Label>
        <Form.Control type="text" id="txtcodeType" name="codeType" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>concept_Class_Id:</Form.Label>
        <Form.Control type="text" id="txtconcept_Class_Id" name="concept_Class_Id" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>concept_Id:</Form.Label>
        <Form.Control type="text" id="txtconcept_Id" name="concept_Id" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>vocabulary_Id:</Form.Label>
        <Form.Control type="text" id="txtvocabulary_Id" name="vocabulary_Id" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>domain_Id:</Form.Label>
        <Form.Control type="text" id="txtdomain_Id" name="domain_Id" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>track:</Form.Label>
        <Form.Control type="text" id="txttrack" name="track" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>standard_Concept:</Form.Label>
        <Form.Control type="text" id="txtstandard_Concept" name="standard_Concept" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code:</Form.Label>
        <Form.Control type="text" id="txtcode" name="code" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>codeWithPeriods:</Form.Label>
        <Form.Control type="text" id="txtcodeWithPeriods" name="codeWithPeriods" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>codeScheme:</Form.Label>
        <Form.Control type="text" id="txtcodeScheme" name="codeScheme" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>long_Desc:</Form.Label>
        <Form.Control type="text" id="txtlong_Desc" name="long_Desc" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>short_Desc:</Form.Label>
        <Form.Control type="text" id="txtshort_Desc" name="short_Desc" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code_Status:</Form.Label>
        <Form.Control type="text" id="txtcode_Status" name="code_Status" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code_Change:</Form.Label>
        <Form.Control type="text" id="txtcode_Change" name="code_Change" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code_Change_Year:</Form.Label>
        <Form.Control type="text" id="txtcode_Change_Year" name="code_Change_Year" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code_Planned_Type:</Form.Label>
        <Form.Control type="text" id="txtcode_Planned_Type" name="code_Planned_Type" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code_Billing_Status:</Form.Label>
        <Form.Control type="text" id="txtcode_Billing_Status" name="code_Billing_Status" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>code_Cms_Claim_Status:</Form.Label>
        <Form.Control type="text" id="txtcode_Cms_Claim_Status" name="code_Cms_Claim_Status" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>sex_Cd:</Form.Label>
        <Form.Control type="text" id="txtsex_Cd" name="sex_Cd" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>anat_Or_Cond:</Form.Label>
        <Form.Control type="text" id="txtanat_Or_Cond" name="anat_Or_Cond" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>poa_Code_Status:</Form.Label>
        <Form.Control type="text" id="txtpoa_Code_Status" name="poa_Code_Status" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>poa_Code_Change:</Form.Label>
        <Form.Control type="text" id="txtpoa_Code_Change" name="poa_Code_Change" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>poa_Code_Change_Year:</Form.Label>
        <Form.Control type="text" id="txtpoa_Code_Change_Year" name="poa_Code_Change_Year" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>valid_Start_Date:</Form.Label>
        <Form.Control type="text" id="txtvalid_Start_Date" name="valid_Start_Date" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>valid_End_Date:</Form.Label>
        <Form.Control type="text" id="txtvalid_End_Date" name="valid_End_Date" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>invalid_Reason:</Form.Label>
        <Form.Control type="text" id="txtinvalid_Reason" name="invalid_Reason" required onChange={handleChange}/>
      </Form.Group>
      <Form.Group>
        <Form.Label>create_Dt:</Form.Label>
        <Form.Control type="text" id="txtcreate_Dt" name="create_Dt" required onChange={handleChange}/>
      </Form.Group>
    </Form>
  </ModalBody>
  <ModalFooter>
    <Button variant="primary" onClick={()=>postConcept()}>Create</Button>
    <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
  </ModalFooter>
</Modal>
  </Container>
)}