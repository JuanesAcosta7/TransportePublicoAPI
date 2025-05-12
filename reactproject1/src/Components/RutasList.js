import React, { useState, useEffect } from 'react';
import axios from 'axios';

const RutasList = () => {
    const [rutas, setRutas] = useState([]);

    useEffect(() => {
        axios.get('https://transportepublicoapi.somee.com/api/Ruta')  // Cambia la URL si es diferente
            .then(response => setRutas(response.data))
            .catch(error => console.error('Error cargando las rutas:', error));
    }, []);

    return (
        <div className="bg-gray-800 p-6 rounded-xl shadow-md border border-gray-600">
            <h2 className="text-2xl font-semibold text-gray-100 mb-6">Rutas Disponibles</h2>
            <ul className="space-y-4">
                {rutas.map((ruta) => (
                    <li
                        key={ruta.id}
                        className="bg-gray-700 hover:bg-indigo-600 rounded-lg p-4 cursor-pointer transition duration-300 ease-in-out transform hover:scale-105"
                    >
                        <p className="text-gray-200 font-semibold">{ruta.nombreRuta}</p>
                        <p className="text-gray-400 text-sm">De {ruta.estacionInicio} a {ruta.estacionFin}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default RutasList;

