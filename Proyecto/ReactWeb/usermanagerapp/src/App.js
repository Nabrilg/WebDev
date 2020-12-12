import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Layout } from './Layout';
import { NoMatch } from './components/NoMatch';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { List } from './components/Users';
<<<<<<< HEAD
import { Concepts } from './components/Concepts';
=======
>>>>>>> c04f2a6df82de8a20819505a30dbf19d816adeb0
import { NavigationBar } from './components/NavigationBar';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

function App() {
  return (
    <div className="App">
      <React.Fragment>
        <NavigationBar />
        <Layout>
          <Router>
            <Switch>
              <Route exact path="/" component={Home} />
              <Route path="/Home" component={Home} />
              <Route path="/Users" component={List} />
              <Route path="/Login" component={Login} />
<<<<<<< HEAD
              <Route path="/Concepts" component={Concepts} />
=======
>>>>>>> c04f2a6df82de8a20819505a30dbf19d816adeb0
              <Route component={NoMatch} />
            </Switch>
          </Router>
        </Layout>
      </React.Fragment>
    </div>
  );
}

export default App;
