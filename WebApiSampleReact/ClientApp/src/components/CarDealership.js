import React, { useEffect, useState, useRef } from 'react';
import Cars from './Cars';
import Search from './Search';
import CarDealershipApi from '../api/carDealershipApi';

const titleText = "I want a car with the following options:";

const CarDealership = () => {
    const [carDealershipData] = useState({});
    const [cars, onUpdateCars] = useState([]);
    const [searchData, updateSearchData] = useState({});
    const [selectedCars, onUpdateSelectedCars] = useState([]);
    const backingData = useRef([]);
    const buyCar = (event, car) => {
        console.log('buyCar', event, car);
    };

    const onSearchComplete = (result, source) => {
        let filteredItems = [];
        onUpdateCars(backingData.current);
        if (source === 'reset') {
            // onUpdateSelectedCars([]);
            updateSearchData({});
            return;
        }

        // if (source === 'triggerHighMileage') {
        //     filteredItems = cars.filter((value) => !value.hasLowMiles);
        // }
        // else if (source === 'triggerLowMileage') {
        //     filteredItems = cars.filter((value) => value.hasLowMiles);
        // }
        if (source === 'isFourWheelDrive') {
            const flagItemsToFilter = cars.filter((value) => value.isFourWheelDrive);
            filteredItems = filteredItems.concat(flagItemsToFilter);
        }
        if (source === 'hasHeatedSeats') {
            const flagItemsToFilter = cars.filter((value) => value.hasHeatedSeats);
            filteredItems = filteredItems.concat(flagItemsToFilter);
        }
        if (source === 'hasSunroof') {
            const flagItemsToFilter = cars.filter((value) => value.hasSunroof);
            filteredItems = filteredItems.concat(flagItemsToFilter);
        }
        if (source === 'hasPowerWindows') {
            const flagItemsToFilter = cars.filter((value) => value.hasPowerWindows);
            filteredItems = filteredItems.concat(flagItemsToFilter);
        }
        if (source === 'hasNavigation') {
            const flagItemsToFilter = cars.filter((value) => value.hasNavigation);
            filteredItems = filteredItems.concat(flagItemsToFilter);
        }
        if (source === 'hasLowMiles') {
            const flagItemsToFilter = cars.filter((value) => value.hasLowMiles);
            filteredItems = filteredItems.concat(flagItemsToFilter);
        }
        if (source === 'color') {
            const colorItemsToFilter = backingData.current.filter((value) => value.color === result.name);
            filteredItems = filteredItems.concat(colorItemsToFilter);
        }

        onUpdateCars(filteredItems);
        // onUpdateSelectedCars([]);
    };

    useEffect(() => {
        const getCars = async () => {
            const carsResponse = await CarDealershipApi.getCars();
            carDealershipData.carResponse = carsResponse;

            for (let i = 0; i < carDealershipData.carResponse.data.length; i++) {
                carDealershipData.carResponse.data[i].buy = buyCar;
            }
            onUpdateCars(carDealershipData.carResponse.data);
            backingData.current = carDealershipData.carResponse.data;
        };
        getCars();
    }, []);

    return (
        <div>
            <h1>Car Dealership</h1>
            <div className="card card-primary">
                <div className="card-body">
                    <div className="card-title">Welcome to Snazzy Cars!</div>
                    <div className="card-body">Please follow the options below to search for the right car for yourself.</div>
                    <hr />
                    <div>
                        {selectedCars.length > 0 && `${selectedCars.length} cars selected: ${selectedCars.map(car => `${car.year} - ${car.make} - ${car.color}`)}`}
                        {selectedCars.length > 0 && <hr />}

                    </div>
                    <Search searchData={searchData} titleText={titleText} onSearchComplete={onSearchComplete} />
                    {cars &&
                        <Cars cars={cars} onSelected={(event, item) => {
                            selectedCars.push(item);
                        }} />
                    }
                </div>
            </div>
        </div>
    );
};

export default CarDealership;
