import React, { useState, useEffect } from 'react';
import axios from 'axios';

const VerTiempoLlegada = ({ rutaId }) => {
    const [tiempo, setTiempo] = useState(null);

    useEffect(() => {
        if (rutaId) {
            axios.get(`https://transportepublicoapi.somee.com/api/Hechos/${rutaId}`)
                .then(response => setTiempo(response.data))
                .catch(error => console.error('Error cargando el tiempo de llegada:', error));
        }
    }, [rutaId]);

    return (
        <div className="bg-gray-800 p-6 rounded-xl shadow-md border border-gray-600 mt-4">
            <h3 className="text-2xl font-semibold text-gray-100 mb-4">Tiempo estimado para la ruta</h3>
            {tiempo ? (
                <p className="text-lg text-gray-200">Tiempo de llegada: <span className="text-indigo-500 font-bold">{tiempo.tiempoTotalMinutosLunesASab} minutos</span></p>
            ) : (
                <p className="text-lg text-gray-400">Cargando...</p>
            )}
        </div>
    );
};

export default VerTiempoLlegada;
