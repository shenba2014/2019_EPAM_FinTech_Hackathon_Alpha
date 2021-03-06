import React from 'react';
import './Attachment.css';

export default class Attachment extends React.Component {
  render() {
    return (
      <div className="row">
        <div className="col s12">
          <div className="collection">
            <a href="#!" className="collection-item">
              <span className="new badge red" data-badge-caption="">delete</span>
              <span className="new badge blue" data-badge-caption="">download</span>
              myAttachment#1
            </a>
            <a href="#!" className="collection-item">
              <span className="new badge red" data-badge-caption="">delete</span>
              <span className="new badge blue" data-badge-caption="">download</span>
              myAttachment#2
            </a>
          </div>
        </div>
        <div className="row">
            <div className="input-field col s12">
              <a className="waves-effect waves-light btn-large orange col s8 offset-s2">upload</a>
            </div>
          </div>
      </div>
    );
  }
}