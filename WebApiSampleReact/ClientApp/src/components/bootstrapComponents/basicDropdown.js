import React, { useState } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';
import Loading from '../Loading';

const BasicDropdown = ({ items, name, onChange }) => {
    const [dropdownOpen, setDropdownOpen] = useState(false);
    const [dropdownValue, onNameChange] = useState(name);

    const toggle = (event) => {
        setDropdownOpen(prevState => !prevState);
    };

    const onDropdownClick = (event) => {
        console.log('onDropdownClick', event);
    }

    const onDropdownItemChange = (event, item) => {
        onNameChange(item.name);
        onChange(item, 'dropdown');
    };

    return (
        <div className="basic-dropdown">
            {!items && <Loading />}
            <Dropdown isOpen={dropdownOpen} toggle={toggle}>
                <DropdownToggle onSelect={onDropdownClick}  onClick={onDropdownClick} caret>
                    {/* <span>{dropdownValue}</span> */}
                    <span>Select Color...</span>
                </DropdownToggle>
                <DropdownMenu>
                    {items &&
                        items.map((item) =>
                            <DropdownItem key={item.key} onClick={(event) => onDropdownItemChange(event, item)}>{item.name}</DropdownItem>
                        )}
                </DropdownMenu>
            </Dropdown>

            <span>Selected: {dropdownValue}</span>
        </div>
    );
}

export default BasicDropdown;