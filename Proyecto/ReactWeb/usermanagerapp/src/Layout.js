import React from 'react';
import {Container} from 'react-bootstrap';

// render content inside another component Container
export const Layout = (props) => (
    <Container>
        {props.children}
    </Container>
)