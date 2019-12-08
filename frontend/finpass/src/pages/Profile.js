import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import logo from '../FinPass.png';
import './page.css';
import BasicInfo from './Profile/BasicInfo';
import Attachment from './Profile/Attachment';

export default class Profile extends React.Component {

  render() {
    return (
      <Router>
          <nav className="nav-extended">
            <div className="nav-wrapper blue">
              <a href="/" className="brand-logo center logo">
                <img src={logo} alt="finPass" className='brand-logo center logo'/> 
              </a>
            </div>
            <div className="nav-content blue">
              <ul className="tabs tabs-transparent">
                <li className="tab"><Link to="/profile/basic">Basic Info</Link></li>
                <li className="tab"><Link to="/profile/attachment">Attachment</Link></li>
              </ul>
            </div>
          </nav>
          <Switch>
            <Route path="/profile/basic">
              <BasicInfo />
            </Route>
            <Route path="/profile/attachment">
              <Attachment />
            </Route>
          </Switch>
      </Router>
    );
  }
}