import axios from 'axios';

const API = axios.create({
    baseURL: 'https://localhost:7272/api/', // Reemplaza con tu URL real
    headers: {
        'Content-Type': 'application/json'
    }
});

export default API;
