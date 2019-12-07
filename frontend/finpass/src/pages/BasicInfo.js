import React from 'react';
import './BasicInfo.css';

export default class BasicInfo extends React.Component {
  render() {
    return (
      <div className="row">
        <form className="col s12">
          <div className="row">
            <div className="input-field col s6">
              <input id="first_name" type="text" className="validate" />
              <label htmlFor="first_name">First Name</label>
            </div>
            <div className="input-field col s6">
              <input id="last_name" type="text" className="validate" />
              <label htmlFor="last_name">Last Name</label>
            </div>
          </div>
          <div className="row">
            <div className="input-field col s12">
              <input id="id_number" type="text" className="validate" />
              <label htmlFor="id_number">ID Number</label>
            </div>
          </div>
          <div className="row">
            <div className="input-field col s12">
              <input id="address" type="text" className="validate" />
              <label htmlFor="address">Address</label>
            </div>
          </div>
          <div className="row">
            <div className="input-field col s12">
              <input id="email" type="email" className="validate" />
              <label htmlFor="email">Email</label>
            </div>
          </div>
        </form>
      </div>
    );
  }
}