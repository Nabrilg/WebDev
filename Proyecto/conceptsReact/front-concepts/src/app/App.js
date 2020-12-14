import React from "react";
import './App.css';
import Layout from "./components/Layout";
import Login from "./components/Login";
import MedicalConcepts from "./components/MedicalConcepts";

function App() {
  const initAuthState = {
    user: undefined,
    token: undefined
  };

  const [AuthState, setAuthState] = React.useState(initAuthState);

  return (
    <>
    {AuthState.token !== undefined ? (
      <Layout username={AuthState.user.name}>
        <MedicalConcepts AuthState={AuthState} />
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
