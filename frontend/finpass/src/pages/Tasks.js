import React from 'react';
import logo from '../FinPass.png';
import './Profile.css';
import { ExportPage } from './Export/export-page';

export default class Tasks extends React.Component {
  render() {
    return (
      <div>
        <nav className="nav">
          <div className="nav-wrapper blue">
            <img src={logo} alt="finPass" className='brand-logo center logo'/> 
          </div>
        </nav>
        <ExportPage />
      </div>
    );
  }
}