import React from "react";
import { render } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import NavMenu from './NavMenu';

test('renders navmenu', () => {
    render(<BrowserRouter>
        <NavMenu />
    </BrowserRouter>);
});
