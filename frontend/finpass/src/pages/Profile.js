import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import logo from '../FinPass.png';
import './Profile.css';
import BasicInfo from './BasicInfo';
import Attachment from './Attachment';

export default class Profile extends React.Component {

  render() {
    return (
      <Router>
          <nav className="nav-extended">
            <div className="nav-wrapper blue">
              <img src={logo} alt="finPass" className='brand-logo center logo'/> 
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