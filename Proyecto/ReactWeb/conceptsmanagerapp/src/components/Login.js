import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import "./Login.css";

export function Login(){

    const baseUrl = "https://javerianawebdevapi.azurewebsites.net/api/Login";
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    const [currentLoginUser, setCurrentLoginUser] = useState({
        email: '',
        password: ''
    })

    const handleChange=e=>{
        const {name, value}= e.target;
        setCurrentLoginUser({
          ...currentLoginUser,
          [name]: value
        })
        }
    
    function validateForm() {
      return email.length > 0 && password.length > 0;
    }
  
    function handleSubmit(event) {
      event.preventDefault();
    }

    const postLogin = async() => {
        currentLoginUser.email = email;
        currentLoginUser.password = password;
        console.log("email ", currentLoginUser.email);
        console.log("pass ", currentLoginUser.password);
        await axios.post(baseUrl, JSON.stringify(currentLoginUser), {
            headers: {
                'Content-Type' : 'application/json'
            }
        })
        .then(response => {
            console.log("repsonse", response.status);
        }).catch(error => {
            console.log(error);
        })
    }

    return (
    <div className="Login">
    <Form onSubmit={handleSubmit}>
      <Form.Group size="lg" controlId="email">
        <Form.Label>Email</Form.Label>
        <Form.Control
          autoFocus
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </Form.Group>
      <Form.Group size="lg" controlId="password">
        <Form.Label>Password</Form.Label>
        <Form.Control
          type="password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>
      <Button block size="lg" type="submit" disabled={!validateForm()} onClick={() => postLogin()}>
        Login
      </Button>
    </Form>
  </div>
)}