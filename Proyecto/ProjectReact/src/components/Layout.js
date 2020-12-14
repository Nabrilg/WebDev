import React from "react";


export default function Layout({ username, children }) {
  return (
    <div className="bar d-flex flex-column flex-row-fluid">
      <div className="p-3 mb-2 bg-dark" id="kt_header">
        <div className="container-fluid d-flex align-items-stretch justify-content-between">
          <div />
          <h5 className="text-info"> {username} </h5>
        </div>
      </div>   
      <div className="p-5">
        {children}
      </div>
    </div>
  );
}