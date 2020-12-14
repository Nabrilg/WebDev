import ReactPaginate from "react-paginate";
function Pagination({pageCount, handlePageClick, currentPage}){
  return <ReactPaginate
          previousLabel={"← Anterior"}
          nextLabel={"Siguiente →"}
          breakLabel={<span className="gap">...</span>}
          pageCount={pageCount}
          onPageChange={handlePageClick}
          forcePage={currentPage}
          containerClassName={"pagination justify-content-center"}
          pageClassName={"page-link"}
          previousClassName={"page-link"}
          previousLinkClassName={"page-item"}
          nextClassName={"page-link"}
          nextLinkClassName={"page-item"}
          disabledClassName={"disabled"}
          activeClassName={"page-item active"}
          activeLinkClassName={"page-link"}
        />
  }
export default Pagination;
