import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Profile from './pages/Profile';
import Tasks from './pages/Tasks';
import Home from './pages/Home';
import { ExportPage } from './pages/Export/export-page';
import './App.css';

function App() {
  return (
    <div className='root'>
        <Router>
          <Switch>
            <Route path="/profile">
              <Profile />
            </Route>
            <Route path="/tasks">
              <Tasks />
            </Route>
            <Route path="/export">
              <ExportPage />
            </Route>
            <Route path="/">
              <Home />
            </Route>
          </Switch>
        </Router>      
    </div>
  );
}

export default App;
