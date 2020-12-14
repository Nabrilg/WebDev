import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalFooter, ModalHeader } from 'reactstrap';
import { Button, Container, Form } from 'react-bootstrap';
import BootstrapTable from 'react-bootstrap-table-next';
import paginationFactory from 'react-bootstrap-table2-paginator';
import ToolkitProvider, { Search } from 'react-bootstrap-table2-toolkit';

const baseUrl = "https://javerianawebdevapi.azurewebsites.net/api/users";
//const baseUrl = "https://localhost:44306/api/users";


export function ListUsers()
{
  // Control data
  const [currentUser, setCurrentUser]= useState({
    id: '', 
    email: '',
    username: '',
    name: '',
    password: ''
  });

  //Change manager for the data coming from forms.
  const handleChange=e=>{
    const {name, value}= e.target;
    setCurrentUser({
      ...currentUser,
      [name]: value
    })
  }

  

  const [ data, setData]=useState([]);

  //Get All
  const getUsers=async()=>{
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
    getUsers();
  },[]);


   // Create 
  const [showModalCreate, setShowModalCreate]= useState(false);
  const openCloseModalCreate=()=>{
  setShowModalCreate(!showModalCreate);
  } 


  const postUser = async() => {
    delete currentUser.id;
    await axios.post(baseUrl, currentUser, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
    .then (response=>{
      getUsers();
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

  
  const selectCurrentUser=(user, action)=>{
    setCurrentUser(user);
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
  const putUser = async() => {
    await axios.put(baseUrl+"/"+ currentUser.id, currentUser, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
    .then (response=>{
      getUsers();
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
  const deleteUser = async() => {
    await axios.delete(baseUrl+"/"+ currentUser.id, {
      headers: {
        'Authorization': window.sessionStorage.getItem("token") 
      }
    })
    .then (()=>{
      setData(data.filter(usr=>usr.id!==currentUser.id));
      openCloseModalDelete();
    }).catch(error=>{
      console.log(error);
    })
  }  

  //Columns of the list
  const columns = [
    {dataField: "id", text: "Id", headerStyle: (column, colIndex) => {return { width: '6%' }; }},
    {dataField: "email", text: "Email", headerStyle: (column, colIndex) => {return { width: '40%' }; }},
    {dataField: "name", text: "Name", headerStyle: (column, colIndex) => {return { width: '20%' }; }},
    {dataField: "username", text: "Username", headerStyle: (column, colIndex) => {return { width: '25%' }; }},
    {dataField: "password", text: "Password", headerStyle: (column, colIndex) => {return { width: '25%' }; }},
    {dataField: "actions", text: "Actions",headerStyle: (column, colIndex) => {return { width: '35%' }; }, formatter: (rowContent, row) => {
      return (    
        <div >
          <Button variant="outline-primary" onClick={()=>selectCurrentUser(row, "Edit")}>Edit</Button>{"  "} 
          <Button variant="outline-warning" onClick={()=>selectCurrentUser(row, "Details")}>Details</Button>{"  "}
          <Button variant="outline-danger" onClick={()=>selectCurrentUser(row, "Delete")}>Delete</Button>
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
              <h1>User List</h1>
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
    <Modal isOpen={showModalCreate}>
      <ModalHeader>Create User</ModalHeader>
      <ModalBody>
        <Form>
          <Form.Group>
            <Form.Label>Email:</Form.Label>
            <Form.Control type="email" id="txtEmail" name="email" placeholder="username@domain.com" required onChange={handleChange}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="name" placeholder="Julio Robles" required onChange={handleChange}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Username:</Form.Label>
            <Form.Control type="text" id="txtUsername" name="username" placeholder="username" required onChange={handleChange}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Password:</Form.Label>
            <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}/>
          </Form.Group>
        </Form>
      </ModalBody>
      <ModalFooter>
        <Button variant="primary" onClick={()=>postUser()}>Create</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalCreate()}>Back</Button>
      </ModalFooter>
    </Modal>

    {/* Update */}
    <Modal isOpen={showModalUpdate}>
      <ModalHeader>Edit User</ModalHeader>
      <ModalBody>
        <Form>
          <Form.Group>
            <Form.Label>Id:</Form.Label>
            <Form.Control type="text" id="txtId" name="id" readOnly value={currentUser && currentUser.id}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Email:</Form.Label>
            <Form.Control type="email" id="txtEmail" name="email" placeholder="username@domain.com" required onChange={handleChange}  value={currentUser && currentUser.email}/>
          </Form.Group>
          <Form.Group>
            <Form.Label >Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="name" placeholder="Julio Robles" required onChange={handleChange}  value={currentUser && currentUser.name}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Username:</Form.Label>
            <Form.Control type="text" id="txtUsername" name="username" placeholder="username" required onChange={handleChange}  value={currentUser && currentUser.username}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Password:</Form.Label>
            <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}  value={currentUser && currentUser.password}/>
          </Form.Group>
        </Form>
      </ModalBody>
      <ModalFooter>
        <Button variant="primary" onClick={()=>putUser()}>Save</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalUpdate()}>Back</Button>
      </ModalFooter>
    </Modal>

    {/* Details */}
    <Modal isOpen={showModalDetails}>
      <ModalHeader>Details User</ModalHeader>
      <ModalBody>
        <Form>
          <Form.Group>
            <Form.Label>Id:</Form.Label>
            <Form.Control type="text" id="txtId" name="id" readOnly value={currentUser && currentUser.id}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Email:</Form.Label>
            <Form.Control type="email" id="txtEmail" name="email" readOnly value={currentUser && currentUser.email}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Name:</Form.Label>
            <Form.Control type="text" id="txtName" name="name" readOnly value={currentUser && currentUser.name}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Username:</Form.Label>
            <Form.Control type="text" id="txtUsername" name="username" readOnly value={currentUser && currentUser.username}/>
          </Form.Group>
          <Form.Group>
            <Form.Label>Password:</Form.Label>
            <Form.Control type="text" id="txtPassword" name="password" readOnly value={currentUser && currentUser.password}/>
          </Form.Group>
        </Form>
      </ModalBody>
      <ModalFooter>
        <Button variant="outline-info" onClick={()=>openCloseModalDetails()}>Back</Button>
      </ModalFooter>
    </Modal>

    {/* Delete */}
    <Modal isOpen={showModalDelete}>
      <ModalHeader>Are you sure to delete this user?</ModalHeader>
      <ModalBody>
        <Form>
          <Form.Group>
            <Form.Label><b>Id:</b></Form.Label>
            <Form.Label>{currentUser && currentUser.id}</Form.Label><br/>
            <Form.Label><b>Email:</b></Form.Label>
            <Form.Label>{currentUser && currentUser.email}</Form.Label><br/>
            <Form.Label><b>Name:</b></Form.Label>
            <Form.Label>{currentUser && currentUser.name}</Form.Label><br/>
            <Form.Label><b>Username:</b></Form.Label>
            <Form.Label>{currentUser && currentUser.username}</Form.Label><br/>
          </Form.Group>
        </Form>
      </ModalBody>
      <ModalFooter>
        <Button variant="danger" onClick={()=>deleteUser(currentUser.id)}>Delete</Button>
        <Button variant="outline-info" onClick={()=>openCloseModalDelete()}>Back</Button>
      </ModalFooter>
    </Modal>

  </Container>
);
}