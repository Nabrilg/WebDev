import React, { useState }  from 'react';
import axios from 'axios';
import { Button, Container, Form, Card } from 'react-bootstrap';
import {  useHistory } from "react-router-dom";

const baseUrl = "https://javerianawebdevapi.azurewebsites.net/api/login";
//const baseUrl = "https://localhost:44306/api/Login";

export function Login()
{
  const history = useHistory();
  const varLogged = window.sessionStorage.getItem("isLogged");
  // Control data
  const [loginUser, setLoginUser]= useState({
    email: '',
    password: ''
  });

  //Change manager for the data coming from forms.
  const handleChange=e=>{
    const {name, value}= e.target;
    setLoginUser({
      ...loginUser,
      [name]: value
    })
  }
  
  //Post request login
  const postLogin = async() => {
    await axios.post(baseUrl, loginUser)
    .then (response=>{
      {/** Storage the session variables */}
      window.sessionStorage.setItem("isLogged", "true");
      window.sessionStorage.setItem("token", response.data.token);
      window.sessionStorage.setItem("nameUser", response.data.name);
      history.push("/");
      window.location.reload();
    }).catch(error=>{
      console.log(error);
    })
  }

  return (
    <div>
      {/** If the user is already logged In, don´t render the login View*/}
      { varLogged === "true"
        ? history.push("/")
        :
          <Container className="text-center text-md-left" style={{width:"70%"}}>
            <Card style={{ margin:"55px"}}>
              <Card.Header as="h5"> Inicio de sesión</Card.Header>
              <Card.Body style={{padding:"25px"}}>
              <Form style={{margin:"15px"}}>
                  <Form.Group>
                    <Form.Label>Email:</Form.Label>
                    <Form.Control type="email" id="txtEmail" name="email" placeholder="username@domain.com" required onChange={handleChange}/>
                  </Form.Group>
                  <Form.Group>
                    <Form.Label>Password:</Form.Label>
                    <Form.Control type="password" id="txtPassword" name="password"  onChange={handleChange}/>
                  </Form.Group>
              </Form>
              <div className="col-md-12 text-center">
              <Button variant="dark" style={{width:"40%", align:"center"}} onClick={()=>postLogin()}>Aceptar</Button>
              </div>
              </Card.Body>
            </Card>
          </Container>
      }
    </div>



  );

}