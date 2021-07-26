import React, { useState } from 'react';
import { Card, CardBody, CardTitle, CardSubtitle, CardText, Button, FormGroup, Label, Input } from 'reactstrap';

const Car = ({ car, onSelected }) => {
    const currencyFormat = (num) => {
        return '$' + num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    };
    const [isSelected, onSelectCard] = useState(false);
    return (
        <div className={!isSelected ? "car" : "car selected"}>
            <Card key={car._id}>
                <CardBody>
                    <CardTitle tag="h5">{car.year} {car.make} {car.model} - {car.color}</CardTitle>
                    <CardSubtitle tag="h6" className="mb-2 text-muted">{currencyFormat(car.price)}</CardSubtitle>
                    <CardText>{car.hasLowMiles && "~~~~~Low mileage!~~~~~"}</CardText>
                    <FormGroup check>
                        <Label check>
                            <Input type="checkbox" checked={car.isFourWheelDrive ? "checked" : ""} disabled="disabled" /> Is 4-wheel Drive
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={car.hasHeatedSeats ? "checked" : ""} disabled="disabled" /> Has Heated Seats
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={car.hasSunroof ? "checked" : ""} disabled="disabled" /> Has Sunroof
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={car.hasPowerWindows ? "checked" : ""} disabled="disabled" /> Has Power Windows
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={car.hasNavigation ? "checked" : ""} disabled="disabled" /> Has Navigation
                        </Label>
                        <Label check>
                            <Input type="checkbox" checked={car.hasLowMiles ? "checked" : ""} disabled="disabled" /> Has Low Miles
                        </Label>
                    </FormGroup>
                    <Button className={"btn btn-primary"} style={{ "float": "right" }} onClick={(event) => car.buy(event, car)}>Buy!</Button>
                    {/* <Button className={"btn btn-primary"} style={{ "float": "right" }} onClick={(event) => {
                        onSelectCard(isSelected => !isSelected);
                        onSelected(event, car);
                    }}>Select Car</Button> */}
                </CardBody>
            </Card>
        </div>
    );
};

export default Car;
