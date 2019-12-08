import React from 'react';
import logo from '../FinPass.png';
import './page.css';


export default class Profile extends React.Component {

  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col s12">
            <div className="row">
              <div className="input-field col s12">
                <img src={logo} className="col s6 offset-s3" alt="finPass" /> 
              </div>
            </div>
            <div className="row">
              <div className="input-field col s12">
                <a className="waves-effect waves-light btn-large col s12 orange" href="/profile/basic">My Profile</a>
              </div>
            </div>
            <div className="row">
              <div className="input-field col s12">
                <a className="waves-effect waves-light btn-large col s12 orange" href="/tasks">Tasks</a>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}