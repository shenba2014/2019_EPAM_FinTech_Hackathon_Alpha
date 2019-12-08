import React from 'react';
import logo from '../FinPass.png';
import './page.css';
import { ExportPage } from './Export/export-page';

export default class Tasks extends React.Component {
  render() {
    return (
      <div>
        <nav className="nav">
          <div className="nav-wrapper blue">
            <a href="/" className="brand-logo logo">
              <img src={logo} alt="finPass" className='brand-logo logo'/> 
            </a>
            <ul className="right hide-on-med-and-down blue">
              <li><a href="/profile/basic">My Profile</a></li>
            </ul>
          </div>
        </nav>
        <ExportPage />
      </div>
    );
  }
}