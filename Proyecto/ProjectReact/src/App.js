import React, { useState } from "react";
import './App.css';
import ConceptMenu from './components/ConceptMenu';
import Layout from "./components/Layout";
import Login from "./components/Login";


function App() {
  const initAuthState = {
    user: undefined,
    token: undefined
  };

  const [AuthState, setAuthState] = useState(initAuthState);
  return (
    <>
    {AuthState.token !== undefined ? (
      <Layout username={AuthState.user.name}>
        <ConceptMenu AuthState={AuthState} />
      </Layout>
    )
    : (
      <div className="container-fluid d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap">
        <div/>
        <Login setAuthState={setAuthState} />
        <div/>
      </div>
    )}
    </>
  );
}

export default App;
