import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Button, Container, Table } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';



const baseUrl = "http://localhost:8080/api/conceptos";

export function Concepts() { 
    
  
    const [ data, setData]=useState([]);  
  
    const getConcepts=async()=>{
      await axios.get(baseUrl)
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


   
    
    
    
    
return (

    <Container className="text-center text-md-left">

        
    <h1>Concepts List </h1>
    <p> 
        <Button className="left" variant="success btn-sm"> <Fas icon={faPlus} /> New</Button>
    </p>

    <Table>
        <thead>
            <tr>
                
                <th>idCODE</th>
                <th>pxordx</th>
                <th>oldpxordx</th>
                <th>codeType</th>
            
                <th>Actions</th>
                

            </tr>

        </thead>
        <tbody>
        
          <tr>                       
            <td>1</td>  
            <td>hello</td> 
            <td>bye</td> 
            <td>sick</td> 
            
    
            <td>
              <Button variant="outline-primary btn-sm">Edit</Button> 
              <Button variant="outline-warning btn-sm">Details</Button> 
              <Button variant="outline-danger btn-sm">Delete</Button> 
            </td>
          </tr>

          <tr>                       
            <td>2</td>  
            <td>nice</td> 
            <td>ugly</td> 
            <td>vomit</td> 
            
    
            <td>
              <Button variant="outline-primary btn-sm">Edit</Button> 
              <Button variant="outline-warning btn-sm">Details</Button> 
              <Button variant="outline-danger btn-sm">Delete</Button> 
            </td>
          </tr>

          <tr>                       
            <td>3</td>  
            <td>not nice</td> 
            <td>sad</td> 
            <td>flu</td> 
            
    
            <td>
              <Button variant="outline-primary btn-sm">Edit</Button> 
              <Button variant="outline-warning btn-sm">Details</Button> 
              <Button variant="outline-danger btn-sm">Delete</Button> 
            </td>
          </tr>



        </tbody>
    </Table>


    </Container>

);
}