import React, { useState, useEffect } from 'react';
import axios from 'axios';

const VerTiempoLlegada = () => {
    const [fact, setFact] = useState(null);

    useEffect(() => {
        axios.get('https://backfin1.somee.com/api/FactUbicacionVehiculo')
            .then(response => {
                const facts = response.data;
                console.log('Datos recibidos:', facts);

                // Tomar el primer registro disponible sin filtrar
                const factPrimer = facts[0] || null;
                console.log('Fact seleccionado:', factPrimer);

                setFact(factPrimer);
            })
            .catch(error => console.error('Error cargando datos de FactUbicacionVehiculo:', error));
    }, []);

    const calcularHorarios = () => {
        if (!fact) return [];

        const nombreRuta = fact?.ruta?.nombre || '';
        const paradas = nombreRuta.split(' - ');
        if (paradas.length < 2) return [];

        const horaInicioDate = new Date();
        horaInicioDate.setHours(fact.tiempo?.hora || 6);
        horaInicioDate.setMinutes(fact.tiempo?.minuto || 0);
        horaInicioDate.setSeconds(0);

        const frecuenciaMinutos = 10;
        const tiempoTotal = 40; // Aquí deberías ajustar si tienes tiempo total real
        const duracionEntreParadas = tiempoTotal / (paradas.length - 1);

        const horariosPorSalida = [];

        for (let i = 0; i < 10; i++) {
            const salida = new Date(horaInicioDate.getTime() + i * frecuenciaMinutos * 60000);

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
            {!fact ? (
                <p className="text-lg text-gray-400">Cargando datos...</p>
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
                    <p className="text-red-400">No se pudo calcular el horario. Revisa los datos.</p>
                )
            )}
        </div>
    );
};

export default VerTiempoLlegada;
