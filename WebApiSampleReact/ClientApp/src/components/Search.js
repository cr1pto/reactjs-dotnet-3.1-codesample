import React, { useEffect, useState } from 'react';
import { Form, FormGroup, Label, Input, Button } from 'reactstrap';
import BasicDropdown from './bootstrapComponents/basicDropdown';
import CarDealershipApi from '../api/carDealershipApi';

const Search = ({ searchData, titleText, onSearchComplete }) => {
    const [colors, onUpdateColors] = useState([]);
    const [searchOptions, onUpdateSearchOptions] = useState(searchData);
    const colorDropdownInitialText = "Choose Color";
    const [dropdownName, onUpdateDropdownName] = useState(colorDropdownInitialText);
    // const [mileageInput, setMileageInput] = useState(undefined);
    let totalMakes = 0;

    const resetState = () => {
        onUpdateDropdownName(colorDropdownInitialText);
        onUpdateSearchOptions({});
        onSearchComplete(null, 'reset');
    };

    const onDropdownChange = (result) => {
        onUpdateDropdownName(result);
        onSearchComplete(result, 'color');        
    };
    const handleUpdateIsFourWheelDrive = (isFourWheelDrive) => {
        searchOptions.isFourWheelDrive = isFourWheelDrive;
        onUpdateSearchOptions(searchOptions);
        onSearchComplete({ name: 'isFourWheelDrive', value: searchOptions.isFourWheelDrive }, 'isFourWheelDrive');
    };
    const handleUpdateHasHeatedSeats = (hasHeatedSeats) => {
        searchOptions.hasHeatedSeats = hasHeatedSeats;
        onUpdateSearchOptions(searchOptions);
        onSearchComplete({ name: 'hasHeatedSeats', value: searchOptions.hasHeatedSeats }, 'hasHeatedSeats')
    };
    const handleUpdateHasSunroof = (hasSunroof) => {
        searchOptions.hasSunroof = hasSunroof;
        onUpdateSearchOptions(searchOptions);
        onSearchComplete({ name: 'hasSunroof', value: searchOptions.hasSunroof }, 'hasSunroof')
    };
    const handleUpdateHasPowerWindows = (hasPowerWindows) => {
        searchOptions.hasPowerWindows = hasPowerWindows;
        onUpdateSearchOptions(searchOptions);
        onSearchComplete({ name: 'hasPowerWindows', value: searchOptions.hasPowerWindows }, 'hasPowerWindows')
    };
    const handleUpdateHasNavigation = (hasNavigation) => {
        searchOptions.hasNavigation = hasNavigation;
        onUpdateSearchOptions(searchOptions);
        onSearchComplete({ name: 'hasNavigation', value: searchOptions.hasNavigation }, 'hasNavigation')
    };
    const handleUpdateHasLowMiles = (hasLowMiles) => {
        searchOptions.hasLowMiles = hasLowMiles;
        onUpdateSearchOptions(searchOptions);
        onSearchComplete({ name: 'hasLowMiles', value: searchOptions.hasLowMiles }, 'hasLowMiles');
    };

    //optional for prompt
    // const onMileageEntered = (event) => {
    //     console.log('onmileageentered', event);
    //     // setMileageInput(mileageInput);

    //     if (mileageInput > 150000) {
    //         onSearchComplete({ name: 'hasLowMiles', value: false }, 'triggerHighMileage');
    //         return;
    //     }

    //     onSearchComplete({ name: 'hasLowMiles', value: true }, 'triggerLowMileage');
    // };

    useEffect(() => {
        const getColors = async () => {
            const colorsResponse = await CarDealershipApi.getFetchableColors();
            onUpdateColors(colorsResponse.data);
        };
        getColors();
    }, []);

    return (
        <span className="search">
            <strong><label>{titleText}</label></strong>
            <Button style={{ "float": "right" }} onClick={resetState}>Reset Selection</Button>
            <Form>
                <FormGroup>
                    <div className="car-type">
                        {colors &&
                            <BasicDropdown onChange={(result) => onDropdownChange(result)} name={dropdownName} items={colors.map(color => {
                                return { key: totalMakes++, name: color };
                            })} />
                        }
                        {/* <span style={{margin: "5px"}}><Input placeholder="mileage" id="mileageInput" type="number" value={mileageInput} onChange={onMileageEntered} /></span> */}
                    </div>
                </FormGroup>
                <div className="car-options">
                    <FormGroup check>
                        <Label check>
                            <Input type="checkbox" checked={searchOptions.isFourWheelDrive ? "checked" : ""} onChange={() => handleUpdateIsFourWheelDrive(!searchOptions.hasHeatedSeats)} /> Is 4-wheel Drive
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={searchOptions.hasHeatedSeats ? "checked" : ""} onChange={() => handleUpdateHasHeatedSeats(!searchOptions.hasHeatedSeats)} /> Has Heated Seats
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={searchOptions.hasSunroof ? "checked" : ""} onChange={() => handleUpdateHasSunroof(!searchOptions.hasSunroof)} /> Has Sunroof
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={searchOptions.hasPowerWindows ? "checked" : ""} onChange={() => handleUpdateHasPowerWindows(!searchOptions.hasPowerWindows)} /> Has Power Windows
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={searchOptions.hasNavigation ? "checked" : ""} onChange={() => handleUpdateHasNavigation(!searchOptions.hasNavigation)} /> Has Navigation
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={searchOptions.hasLowMiles ? "checked" : ""} onChange={() => handleUpdateHasLowMiles(!searchOptions.hasLowMiles)} /> Has Low Mileage
                        </Label>
                    </FormGroup>
                </div>
            </Form>
        </span>
    );
};

export default Search;
