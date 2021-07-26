import axios from "axios";

const rootUrl = "https://localhost:5050/api";

const retrieveAllCars = async () => {
    return await get(`${rootUrl}/cars`);
};

const retrieveAllCarsWithFourWheelDrive = async () => {
    return await get(`${rootUrl}/cars/with/4wd`);
};

const retrieveAllCarsWithHeatedSeats = async () => {
    return await get(`${rootUrl}/cars/with/heatedseats`);
};

const retrieveAllCarsWithLowMiles = async () => {
    return await get(`${rootUrl}/cars/with/lowmiles`);
};

const retrieveAllCarsWithNavigation = async () => {
    return await get(`${rootUrl}/cars/with/navigation`);
};

const retrieveAllCarsWithPowerWindows = async () => {
    return await get(`${rootUrl}/cars/with/powerwindows`);
};

const retrieveAllCarsWithSunroof = async () => {
    return await get(`${rootUrl}/cars/with/sunroof`);
};

const retrieveQueryableColors = async () => {
    return await get(`${rootUrl}/search/colors`);
};

const retrieveQueryableMakes = async () => {
    return await get(`${rootUrl}/search/makes`);
};

const get = async (url) => await axios.get(url);
const post = async (url, body) => await axios.post(url, body);

export default class CarDealershipApi {
    static async getCars() {
        return await retrieveAllCars();
    }

    static async getFetchableColors() {
        return await retrieveQueryableColors();
    }

    static async getQueryableMakes() {
        return await retrieveQueryableMakes();
    }
}
