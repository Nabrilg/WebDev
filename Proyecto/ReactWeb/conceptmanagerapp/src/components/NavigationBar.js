import React from 'react';
import { Container, Navbar, Nav } from 'react-bootstrap';

export function NavigationBar()
{ 
  const varLogged = window.sessionStorage.getItem("isLogged");
  const nameUser = window.sessionStorage.getItem("nameUser");


  const logout = (e) => {
      window.sessionStorage.clear()
      window.location.reload();
    // return false;
}
  
  return(
    
      <Navbar bg="dark" variant="dark" >
        <Container fluid style={{margin:0}}>
          <Navbar.Brand href="/">ManagerApp</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav"/>
          <Navbar.Collapse id="basic-navbar-nav">        
            <Nav className="mr-auto">
              <Nav.Item><Nav.Link href="./Home">Home</Nav.Link></Nav.Item>
              <Nav.Item><Nav.Link href="/Users">Users</Nav.Link></Nav.Item>
              <Nav.Item><Nav.Link href="/Concepts">Concepts</Nav.Link></Nav.Item>
              
            </Nav>
            <Nav alignment="right">
              {/*Ask if the user is logged to show one Nav.item or another*/}
              {varLogged === "true"
                ? <div className="container-fluid"> <div style={{color:"white", paddingRight:"20px"}}> {"Bienvenido, " + nameUser }</div>  <Nav.Item><Nav.Link href="#" onClick={()=> logout()}>Logout</Nav.Link></Nav.Item></div>
                : <Nav.Item><Nav.Link href="/Login" >Login</Nav.Link></Nav.Item>
              }
              
            </Nav>
          </Navbar.Collapse>  
        </Container>        
      </Navbar>
  );
}