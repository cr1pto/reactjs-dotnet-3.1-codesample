import React from "react";
import { render } from "@testing-library/react";
import BasicDropdown from './basicDropdown';


test("render when fake data is provided", () => {
    const fakeData = [];
    render(<BasicDropdown items={fakeData} name="fakeName" />);
});