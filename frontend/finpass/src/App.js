import React from 'react';
import './App.css';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Profile from './pages/Profile';
import Tasks from './pages/Tasks';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h2>
          FinPass
        </h2>
        <Router>
          <ul>
            <li>
              <Link to="/profile">My Profile</Link>
            </li>
            <li>
              <Link to="/tasks">Tasks</Link>
            </li>
          </ul>
          <Switch>
            <Route path="/profile">
              <Profile />
            </Route>
            <Route path="/tasks">
              <Tasks />
            </Route>
          </Switch>
        </Router>
      </header>
      
    </div>
  );
}

export default App;
