import React, { useState, useEffect } from 'react';
import M from 'materialize-css';

const BasicInfo = () => {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [idNumber, setIdNumber] = useState('');
  const [address, setAddress] = useState('');
  const [email, setEmail] = useState('');

  const handleClickSave = async () => {
    const form = {
      firstName,
      lastName,
      idNumber,
      address,
      email
    };
    try {
      const response = await fetch('/api/update-profile', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ ...form, id: 5 }),
      });
      if (response.status !== 200) {
        throw new Error();
      }
      M.toast({ html: 'Saved Successfully 😁' });
    } catch (err) {
      M.toast({ html: 'Failed to Save 😫' });
    }
  };

  useEffect(
    () => {
      fetch(`/api/get-profile?id=5`)
        .then((response) => response.json())
        .then(({ firstName, lastName, email, address, idNumber }) => {
          setFirstName(firstName);
          setLastName(lastName);
          setEmail(email);
          setAddress(address);
          setIdNumber(idNumber);
          M.updateTextFields();
        });
    },
    []
  );

  return (
    <div className="row">
      <form className="col s12">
        <div className="row">
          <div className="input-field col s6">
            <input id="first_name" type="text" className="validate" value={firstName} onChange={({ target: { value } }) => setFirstName(value)} />
            <label htmlFor="first_name">First Name</label>
          </div>
          <div className="input-field col s6">
            <input id="last_name" type="text" className="validate" value={lastName} onChange={({ target: { value } }) => setLastName(value)} />
            <label htmlFor="last_name">Last Name</label>
          </div>
        </div>
        <div className="row">
          <div className="input-field col s12">
            <input id="id_number" type="text" className="validate" value={idNumber} onChange={({ target: { value } }) => setIdNumber(value)} />
            <label htmlFor="id_number">ID Number</label>
          </div>
        </div>
        <div className="row">
          <div className="input-field col s12">
            <input id="address" type="text" className="validate" value={address} onChange={({ target: { value } }) => setAddress(value)} />
            <label htmlFor="address">Address</label>
          </div>
        </div>
        <div className="row">
          <div className="input-field col s12">
            <input id="email" type="email" className="validate" value={email} onChange={({ target: { value } }) => setEmail(value)} />
            <label htmlFor="email">Email</label>
          </div>
        </div>
        <div className="row">
          <div className="input-field col s12">
            <a className="waves-effect waves-light btn-large orange col s8 offset-s2" onClick={handleClickSave}>save</a>
          </div>
        </div>
      </form>
    </div>
  );
};

export default BasicInfo;
