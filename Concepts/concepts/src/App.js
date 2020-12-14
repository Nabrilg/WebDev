import React from 'react';
import './App.css';
import Login from './Login';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import Concepts from './Concepts';
import Concept from './Concept';
import CreateConcept from './CreateConcept';
 
function App() {
  return (
    <Router>
      <div className="App">
        <Switch>
          <Route path="/" exact component={ Login }/>
          <Route path="/concepts" component={ Concepts }/>
          <Route path="/concept/:id" component={ Concept }/>
          <Route path="/createConcept" component={ CreateConcept }/>
        </Switch>
      </div>
    </Router>
  );
}

export default App;
