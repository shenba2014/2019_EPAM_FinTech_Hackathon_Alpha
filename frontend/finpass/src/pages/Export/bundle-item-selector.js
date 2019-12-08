import React, { Fragment } from 'react';

export const BundleItemSelector = ({ items, onChange }) => (
    <Fragment>
        <h6>
            2. Select the data items you want to export into the bundle
        </h6>
        <form action="#">
            {items.map(({ id, name, checked }) => (
                <p key={id}>
                    <label>
                        <input type="checkbox" value={id} checked={checked} onChange={({ target: { value, checked } }) => onChange({ id: value, checked })} />
                        <span>{name}</span>
                    </label>
                </p>
            ))}
        </form>
    </Fragment>
);
