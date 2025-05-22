import React, { useState, useEffect } from 'react';
import API from '../api.js'; // Asegúrate de usar tu archivo api.js configurado con Axios

const RutasList = () => {
    const [rutas, setRutas] = useState([]);

    useEffect(() => {
        API.get('/DimRuta')
            .then(response => setRutas(response.data))
            .catch(error => console.error('Error cargando las rutas:', error));
    }, []);

    return (
        <div className="bg-gray-800 p-6 rounded-xl shadow-md border border-gray-600">
            <h2 className="text-2xl font-semibold text-gray-100 mb-6">Rutas Disponibles</h2>
            <ul className="space-y-4">
                {rutas.map((ruta) => (
                    <li
                        key={ruta.rutaKey}
                        className="bg-gray-700 hover:bg-indigo-600 rounded-lg p-4 cursor-pointer transition duration-300 ease-in-out transform hover:scale-105"
                    >
                        <p className="text-gray-200 font-semibold">{ruta.nombre}</p>
                        <p className="text-gray-400 text-sm">Sentido: {ruta.sentido}</p>
                        <p className="text-gray-400 text-sm">Estado: {ruta.activa ? 'Activa' : 'Inactiva'}</p>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default RutasList;
