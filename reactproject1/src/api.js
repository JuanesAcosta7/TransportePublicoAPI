import axios from 'axios';

const API = axios.create({
    baseURL: 'https://backfin1.somee.com/api/', // Reemplaza con tu URL real
    headers: {
        'Content-Type': 'application/json'
    }
});

export default API;
