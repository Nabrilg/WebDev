import React from 'react';
import { Container, Navbar, Nav } from 'react-bootstrap';
import { FontAwesomeIcon as Fas} from '@fortawesome/react-fontawesome';
import { faGift, faSnowman, faCandyCane } from '@fortawesome/free-solid-svg-icons';

export const NavigationBar = () => (
    <Container>
        <Navbar bg="dark" variant="dark" >
          <Navbar.Brand href="/">UserManagerApp</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav"/>
          <Navbar.Collapse id="basic-navbar-nav">        
            <Nav className="mr-auto">
              <Nav.Item><Nav.Link href="/Home"><Fas icon={faGift} /> Home</Nav.Link></Nav.Item>
              <Nav.Item><Nav.Link href="/Users"><Fas icon={faSnowman} /> Users</Nav.Link></Nav.Item>
              <Nav.Item><Nav.Link href="/Concepts"><Fas icon={faCandyCane} /> Concepts</Nav.Link></Nav.Item>
            </Nav>
            <Nav alignment="right">
              <Nav.Item><Nav.Link href="/Login" >Login</Nav.Link></Nav.Item>
            </Nav>
          </Navbar.Collapse>        
        </Navbar>
    </Container>
)