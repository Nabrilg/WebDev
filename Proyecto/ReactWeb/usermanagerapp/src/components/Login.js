import React, { useState } from 'react';
import axios from 'axios';
import { Button, Container, Form } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faSleigh } from '@fortawesome/free-solid-svg-icons';
import { useHistory } from "react-router-dom";

const baseUrl = "http://localhost:64499/api/Login";

export function Login(){

  const history = useHistory();

  const configLogged = {
    headers: {
      accept: 'application/json'
    }
  };


  // Control data
  const [currentUser, setCurrentUser]= useState({
    email: '',
    password: ''
  });

  const handleChange=e=>{
    const {name, value}= e.target;
    setCurrentUser({
      ...currentUser,
      [name]: value
    })
  }
      
  const postUser=async() => {
    //delete currentUser.id;
    await axios.post(baseUrl, currentUser, configLogged)
    .then (response=>{
      sessionStorage.setItem('jwtToken', response.data.token);
      sessionStorage.setItem('userName', response.data.name);
      history.push("/Users");
    }).catch(error=>{
      console.log(error);
    })
  }

  return (
    <Container className="text-center text-md-left">
    <h3>Log in</h3>
    {/* Create */}
      <Form>
        <Form.Group>
          <Form.Label>Email:</Form.Label>
          <Form.Control type="email" id="txtEmail" name="email" placeholder="username@domain.com" required onChange={handleChange}/>
        </Form.Group>
        <Form.Group>
          <Form.Label>Password:</Form.Label>
          <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}/>
        </Form.Group>
        <Button variant="success" onClick={()=>postUser()}><Fas icon={faSleigh} /> Log In</Button>
      </Form>
  </Container>
  );
}
