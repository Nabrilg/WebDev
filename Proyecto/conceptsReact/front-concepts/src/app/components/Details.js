import React from "react";

function Details({ concept, handleChangeMenu }) {

  return (
    <div className="card shadow-sm p-3 mb-5 bg-white rounded">
      <div className="tab-content">
        <div className="table-responsive">
          <table className="table table-borderless table-vertical-center">
            <thead>
              <tr className="text-left text-uppercase">
                <th style={{minWidth: "100px"}}>Concepto:</th>
              </tr>
            </thead>
            <tbody>
              {Object.keys(concept).map((key) => (
                <tr key={key}>
                  <td>
                    <label><strong>{key}: </strong></label>
                    <span className="d-block font-size-lg">
                      {concept[key]}
                    </span>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <button className="btn btn-outline-secondary" onClick={() => handleChangeMenu(0)}>Back</button>
      </div>
    </div>
  );
}

export default Details;
