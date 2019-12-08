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
            <a href="/" className="brand-logo center logo">
              <img src={logo} alt="finPass" className='brand-logo center logo'/> 
            </a>
          </div>
        </nav>
        <ExportPage />
      </div>
    );
  }
}