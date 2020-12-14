import React from "react";
import Dropdown from "react-bootstrap/Dropdown";

export default function Layout({ username, children }) {
  return (
    <div className="d-flex flex-column flex-row-fluid">
      {/* Header */}
      <div className="p-3 mb-2 bg-dark" id="kt_header">
        <div className="container-fluid d-flex align-items-stretch justify-content-between">
          <div />
          {/* toolbar */}
          <Dropdown className="align-self-center">
            <Dropdown.Toggle id="kt-profile-dropdown" variant="btn btn-outline-light">{username} </Dropdown.Toggle>
            <Dropdown.Menu>
              <Dropdown.Item>
                <button className="btn btn-danger">Cerrar sesión</button>
              </Dropdown.Item>
            </Dropdown.Menu>
          </Dropdown>
        </div>
      </div>   
      <div className="p-5">
        {children}
      </div>
    </div>
  );
}