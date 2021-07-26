import React from 'react';
import Car from './Car';

const Cars = ({cars, onSelected}) => {
    return (
        <div>
            {cars && cars.map(car => <Car key={car._id} car={car} onSelected={onSelected}/>)}
        </div>
    );
};

export default Cars;
