import React from 'react';
import { Route } from 'react-router-dom';
import './custom.css'
import CarDealership from './components/CarDealership';
import Home from './components/Home';
import Layout from './components/Layout';

 export const App = () => {
    return (
        <Layout>
            <Route exact path='/' component={Home} />
            <Route path='/carDealership' component={CarDealership} />
        </Layout>
    );
}

export default App;

