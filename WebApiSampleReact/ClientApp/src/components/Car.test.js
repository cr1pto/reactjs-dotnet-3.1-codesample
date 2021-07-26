import React from "react";
import { render } from "@testing-library/react";
import Car from './Car';


test("render when fake data is provided", () => {
  const fakeCar = {
    _id: "12341327418230948",
    year: 2001,
    price: 20000
  };
  render(<Car car={fakeCar} />);
});