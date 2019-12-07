import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import Profile from './pages/Profile';
import Tasks from './pages/Tasks';
import { ExportPage } from './pages/Export/export-page';

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
            <Route path="/export">
              <ExportPage />
            </Route>
          </Switch>
        </Router>      
    </div>
  );
}

export default App;
