import React, { Fragment, useState, useEffect, useRef } from 'react';
import M from 'materialize-css';
import { BundleItemSelector } from './bundle-item-selector';

export const ExportPage = () => {
    const [bank, setBank] = useState('');
    const [availableItems, setAvailableItems] = useState([]);
    const [selectedItems, setSelectedItems] = useState([]);

    const bankSelector = useRef(null);

    const handleItemSelectionChange = ({ id, checked }) => {
        if (checked) {
            selectedItems.add(id);
        } else {
            selectedItems.delete(id);
        }
        setSelectedItems(new Set(selectedItems));
        setAvailableItems(availableItems.map((item) => {
            if (item.id !== id) {
                return item;
            }
            return { ...item, checked: checked };
        }));
    };

    const handleClickExport = async (e) => {
        const response = await fetch('/api/create-document-link', { method: 'POST' });
        const data = await response.json();
        console.log(data);
    };

    useEffect(
        () => {
            M.FormSelect.init(bankSelector.current);
        },
        []
    );

    useEffect(
        () => {
            Promise.resolve([
                { id: 'pErSoNAl', name: 'Personal Info', checked: true },
                { id: 'uPloAd1', name: 'Upload 1', checked: false },
                { id: 'uPloAd2', name: 'Upload 2', checked: false },
            ]).then((data) => {
                setAvailableItems(data);

                const selected = data.filter(({ checked }) => checked).map(({ id }) => id);
                setSelectedItems(new Set(selected));
            });
        },
        []
    );

    return (
        <Fragment>
            <h2>Export Your Data Bundle</h2>

            <div className="input-field col s12">
                <select ref={bankSelector} value={bank} onChange={({ target: { value } }) => setBank(value)}>
                    <option value="" disabled>Choose a bank</option>
                    <option value="1">China Merchants Bank</option>
                    <option value="2">Citic Bank</option>
                    <option value="3">Ping An Bank</option>
                </select>
                <label>1. Which bank your data bundle will be generated for</label>
            </div>

            {
                bank.length > 0 && <BundleItemSelector items={availableItems} onChange={handleItemSelectionChange} />
            }
            {
                bank.length > 0 && <a className="waves-effect waves-light btn" onClick={handleClickExport}>Export</a>
            }
        </Fragment>
    );
};
