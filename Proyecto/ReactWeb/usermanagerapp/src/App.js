import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Layout } from './Layout';
import { Home } from './components/Home';
import { UsersList } from './components/Users';
import { Login } from './components/Login';
import { NoMatch } from './components/NoMatch';
import { NavigationBar } from './components/NavigationBar';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar></NavigationBar>
        <Layout>
          <Router>
            {/* To know where to redirect given a route */}
            <Switch>
              <Route exact path="/" component={Home}></Route>
              <Route path="/Home" component={Home}></Route>
              <Route path="/Users" component={UsersList}></Route>            
              <Route path="/Login" component={Login}></Route>
              <Route component={NoMatch}></Route>
            </Switch>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
