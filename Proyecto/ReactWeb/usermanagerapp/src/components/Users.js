import React, { useState, useEffect } from 'react';
import axios from "axios";
import {Container, Table, Button} from 'react-bootstrap';
import { FontAwesomeIcon as Fas } from '@fortawesome/react-fontawesome';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

export function UsersList()
{
    const baseUrl = "http://localhost:5001/api/Users";
    
    const [ data, setData ] = useState([]);

    const GetUsers = async() => {
        await axios.get(baseUrl)
                   .then (response => {
                       setData(response.data);
                   }).catch(error => {
                       console.log(error);
                   })
    };
    userEffect(() => {
        GetUsers();
    },[]);

    return(
        <Container className="text-center text-md-left">
            <h1>User List</h1>
            <div class="container">
                <p> 
                    <Button className="left" variant="success btn-sm"><Fas icon={faPlus}></Fas>New</Button>
                {/* <a href="#" class="btn btn-success"><i class="fas fa-plus"></i> New</a> */}
                </p>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Email</th>
                        <th>Name</th>
                        <th>Username</th>
                        <th>Password</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(usr => (
                        <tr>
                        <td>{usr.id}</td>
                        <td>{usr.email}</td>
                        <td>{usr.name}</td>
                        <td>{usr.username}</td>
                        <td>{usr.password}</td>
                        <td>
                        <Button variant="outline-primary">Edit</Button>
                        <Button variant="outline-warning">Details</Button>
                        <Button variant="outline-danger">Delete</Button>
                        </td>
                    </tr>
                    ))}
                </tbody>
            </Table>
        </Container>
    );
}