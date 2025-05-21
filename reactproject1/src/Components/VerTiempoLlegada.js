import React, { useState, useEffect } from 'react';
import axios from 'axios';

const VerTiempoLlegada = ({ rutaId }) => {
    const [hecho, setHecho] = useState(null);

    useEffect(() => {
        if (rutaId) {
            axios.get('https://transportepublicoapi.somee.com/api/Hechos')
                .then(response => {
                    const hechos = response.data;
                    const hechoFiltrado = hechos.find(h => h.ruta.id === parseInt(rutaId));
                    setHecho(hechoFiltrado || null);
                })
                .catch(error => console.error('Error cargando los datos de hechos:', error));
        }
    }, [rutaId]);

    const formatearHora = (horaStr) => {
        if (!horaStr || typeof horaStr !== 'string') return null;
        const partes = horaStr.trim().split(':');
        if (partes.length < 2) return null;
        const horas = partes[0].padStart(2, '0');
        const minutos = partes[1].padStart(2, '0');
        return `${horas}:${minutos}`;
    };

    const calcularHorarios = () => {
        if (!hecho) return [];

        const nombreRuta = hecho?.ruta?.nombreRuta;
        const paradas = nombreRuta?.split(' - ') || [];
        const horaInicioStr = formatearHora(hecho?.tiempo?.horaInicioLunesASabado);
        const frecuencia = hecho?.frecuencia?.frecuenciaLunesASabado;
        const tiempoTotal = hecho?.tiempoTotalMinutosLunesASab;

        console.log("Hora Inicio:", horaInicioStr);
        console.log("Frecuencia:", frecuencia);
        console.log("Tiempo Total:", tiempoTotal);
        console.log("Paradas:", paradas);

        if (!horaInicioStr || !frecuencia || !tiempoTotal || paradas.length < 2) return [];

        const horaInicioDate = new Date(`1970-01-01T${horaInicioStr}:00`);
        if (isNaN(horaInicioDate.getTime())) {
            console.error('Fecha inválida al construir hora de inicio:', horaInicioStr);
            return [];
        }

        const duracionEntreParadas = tiempoTotal / (paradas.length - 1);
        const horariosPorSalida = [];

        for (let i = 0; i < 10; i++) {
            const salida = new Date(horaInicioDate.getTime() + i * frecuencia * 60000);

            const horariosParada = paradas.map((parada, index) => {
                const llegada = new Date(salida.getTime() + index * duracionEntreParadas * 60000);
                return {
                    parada,
                    hora: llegada.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' })
                };
            });

            horariosPorSalida.push(horariosParada);
        }

        return horariosPorSalida;
    };

    const horarios = calcularHorarios();

    return (
        <div className="bg-gray-800 p-6 rounded-xl shadow-md border border-gray-600 mt-4">
            <h3 className="text-2xl font-semibold text-gray-100 mb-4">Horarios estimados por parada</h3>
            {!hecho ? (
                <p className="text-lg text-gray-400">Cargando...</p>
            ) : (
                horarios.length > 0 ? (
                    horarios.map((salida, idx) => (
                        <div key={idx} className="mb-4">
                            <p className="text-indigo-400 font-bold mb-1">Salida {idx + 1}</p>
                            <ul className="list-disc list-inside text-gray-300">
                                {salida.map((p, i) => (
                                    <li key={i}>
                                        <span className="font-semibold text-white">{p.parada}:</span> {p.hora}
                                    </li>
                                ))}
                            </ul>
                        </div>
                    ))
                ) : (
                    <p className="text-red-400">No se pudo calcular el horario. Revisa los datos de la ruta.</p>
                )
            )}
        </div>
    );
};

export default VerTiempoLlegada;

