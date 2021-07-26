import React from "react";
import { render } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import Layout from './Layout';

test('renders Layout', () => {
    render(<BrowserRouter><Layout /></BrowserRouter>);
});
