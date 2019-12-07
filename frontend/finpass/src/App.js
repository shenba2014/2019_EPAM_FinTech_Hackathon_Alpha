import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Profile from './pages/Profile';
import Tasks from './pages/Tasks';

function App() {
  return (
    <div>
        <Router>
          <Switch>
            <Route path="/profile">
              <Profile />
            </Route>
            <Route path="/tasks">
              <Tasks />
            </Route>
          </Switch>
        </Router>      
    </div>
  );
}

export default App;
