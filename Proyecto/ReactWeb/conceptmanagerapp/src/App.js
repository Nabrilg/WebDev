import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Layout } from './Layout';
import { NoMatch } from './components/NoMatch';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { ListUsers } from './components/Users';
import { NavigationBar } from './components/NavigationBar';
import { ListConcepts } from './components/Concepts';
import { Redirect } from 'react-router';

function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar />
        <Layout >
          <Router>
          <Switch> 
            <Route exact path="/" component={Home} >
              {/** Ask if the user is logged two show one Component or another */}
              {window.sessionStorage.getItem("isLogged") === "true"  ?  <Home /> : <Login />}
            </Route>
            <Route path="/Home" >
              {/** Ask if the user is logged two show one Component or another */}
              {window.sessionStorage.getItem("isLogged") === "true"  ?  <Home /> : <Login />}
            </Route>
            <Route path="/Users" >
              {/** Ask if the user is logged two show one Component or another */}
              {window.sessionStorage.getItem("isLogged") === "true"  ? <ListUsers />: <Redirect to="/"/>}
            </Route>
            <Route path="/Concepts"  >
              {/** Ask if the user is logged two show one Component or another */}
              {window.sessionStorage.getItem("isLogged") === "true"  ? <ListConcepts />: <Redirect to="/"/>}
            </Route>
            <Route path="/Login" >
              {/** Ask if the user is logged two show one Component or another */}
              {window.sessionStorage.getItem("isLogged") === "true"  ?  <Redirect to="/"/> : <Login />}
            </Route>
            <Route path="/Logout">
              {/** Ask if the user logged Out redirect to deafult path */}
              <Redirect to="/" />
            </Route>
            {/** Other routes not defined */}
            <Route component={NoMatch} />
          </Switch>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
