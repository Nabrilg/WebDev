import React from "react";

function Details({ concept, backBtn }) {

  return (
    <div className="card shadow-sm p-3 mb-5 bg-white rounded">
    <button className="btn btn-outline-success" onClick={() => backBtn(0)}>Back</button>
      <div className="tab-content">
        <div className="table-responsive">
          <table className="table table-borderless table-vertical-center">
            <thead>
              <tr className="text-left text-uppercase">
                <th style={{minWidth: "100px"}}>Concept:</th>
              </tr>
            </thead>
            <tbody>
              {Object.keys(concept).map((key) => (
                <tr key={key}>
                  <td>
                    <div className="row">
                      <div className="col">
                        <label><strong>{key}: </strong></label>
                      </div>
                      <div className="col">
                        <span className="d-block font-size-lg">
                          {concept[key]}
                        </span>
                      </div>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
}

export default Details;
