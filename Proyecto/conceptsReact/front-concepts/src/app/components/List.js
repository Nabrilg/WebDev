import React from "react";
import Pagination from "./Pagination";

export default function List(props) {
  const { concepts, handleChangeMenu, handleEditConcept, handleDeleteConcept, handleDetailsConcept } = props;
  const initPaginationProps = {
    offset: 0,
    perPage: 10,
    currentPage: undefined
  };

  const [paginationProps, setPaginationProps] = React.useState(initPaginationProps);
  
  const handlePageClick = concept => {
    const selectedPage = concept.selected;
    const offset = selectedPage * paginationProps.perPage;
    const perPage = paginationProps.perPage;
    setPaginationProps({ currentPage: selectedPage, offset: offset, perPage: perPage});
  };
  return (
    <div className="card shadow-sm p-3 mb-5 bg-white rounded">
      <div className="card-header bg-white">
        <div className="container-fluid d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap">
          <div />
          <button className="btn btn-outline-success" onClick={() => handleChangeMenu(1)}>Añadir concepto</button>
        </div>
      </div>
      <div className="card-body tab-content">
        <div className="table-responsive">
          <table className="table table-borderless table-vertical-center">
            <thead>
              <tr className="text-left text-uppercase">
                <th style={{minWidth: "100px"}}>concepto Id</th>
                <th style={{minWidth: "100px", maxWidth: "100px"}}>Descripción</th>
                <th style={{minWidth: "100px"}}>Código</th>
              </tr>
            </thead>
            <tbody>
              {concepts.slice(paginationProps.offset, paginationProps.offset + paginationProps.perPage).map((concept, index) => (
                <tr key={index}>
                  <td>
                    <span className="d-block font-size-lg">
                      {concept.concept_Id}
                    </span>
                  </td>
                  <td>
                    <span style={{minWidth: "100px", maxWidth: "400px"}} className="d-block font-size-lg">
                      {concept.short_Desc}
                    </span>
                  </td>
                  <td>
                    <span className="d-block font-size-lg">
                      {concept.code}
                    </span>
                  </td>
                  <td>
                    <button className="btn btn-outline-primary" onClick={() => handleDetailsConcept(index)}>Detalle</button>
                    <button className="btn btn-outline-danger ml-2" onClick={() => handleDeleteConcept(concept.id, index)}>Eliminar</button>
                    <button className="btn btn-outline-success ml-2" onClick={() => handleEditConcept(concept, index)}>Editar</button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div><Pagination pageCount={paginationProps.pageCount} handlePageClick={handlePageClick} currentPage={paginationProps.currentPage} /></div>
        </div>
      </div>
    </div>
  );
}