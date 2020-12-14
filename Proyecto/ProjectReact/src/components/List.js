import React, { useState } from "react";
import Pagination from "./Pagination";

function List({ concepts, backSelectBtn, DeleteBtn,backBtn }) {
  const startState = {
    offset: 0,
    perPage: 10,
    currentPage: 0
  };
  const [state,setState] = useState(startState);
  const handlePageClick = concept => {
    const selectedPage = concept.selected;
    const offset = selectedPage * state.perPage;
    const perPage = state.perPage;
    setState({ currentPage: selectedPage, offset: offset, perPage: perPage});
  };
  return (
    <div className="card shadow-sm p-3 mb-5 bg-white rounded">
      <div className="tab-content">
        <div className="table-responsive">
        <button className="btn btn-outline-success" onClick={() => backBtn(1)}>Add Concept</button>
          <table className="table table-borderless table-vertical-center">
            <thead>
              <tr className="text-left text-uppercase">
                <th style={{minWidth: "100px"}}>concept Id</th>
                <th style={{minWidth: "100px"}}>Description</th>
                <th style={{minWidth: "100px"}}>Code</th>
              </tr>
            </thead>
            <tbody>
              {concepts.slice(state.offset, state.offset + state.perPage).map((concept, index) => (
                <tr key={index}>
                  <td>
                    <span className="d-block font-size-lg">
                      {concept.concept_Id}
                    </span>
                  </td>
                  <td>
                    <span className="d-block font-size-lg">
                      {concept.short_Desc}
                    </span>
                  </td>
                  <td>
                    <span className="d-block font-size-lg">
                      {concept.code}
                    </span>
                  </td>
                  <td>
                    <button className="btn btn-outline-success" onClick={() => backSelectBtn(3,concept)}>Details</button>
                    <button className="btn btn-outline-success" onClick={() => DeleteBtn(concept,index)}>Delete</button>
                    <button className="btn btn-outline-success" onClick={() => backSelectBtn(2,concept,index)}>Edit</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div><Pagination pageCount={state.pageCount} handlePageClick={handlePageClick} currentPage={state.currentPage} /></div>
        </div>
      </div>
    </div>
  );
}

export default List;
