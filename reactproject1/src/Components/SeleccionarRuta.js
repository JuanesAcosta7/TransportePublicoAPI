import React, { useState, useEffect } from "react";

function SeleccionarRuta({ onRutaSeleccionada }) {
    const [rutas, setRutas] = useState([]);
    const [rutaSeleccionada, setRutaSeleccionada] = useState("");

    useEffect(() => {
        fetch("https://transportepublicoapi.somee.com/api/Ruta")
            .then((res) => res.json())
            .then((data) => setRutas(data))
            .catch((err) => console.error("Error cargando rutas:", err));
    }, []);

    const handleChange = (e) => {
        const valor = e.target.value;
        setRutaSeleccionada(valor);
        onRutaSeleccionada(valor);
    };

    return (
        <div className="bg-gray-800 p-6 rounded-xl shadow-md border border-gray-600">
            <h2 className="text-2xl font-semibold text-gray-100 mb-4">Selecciona una Ruta</h2>
            <div className="relative">
                <select
                    value={rutaSeleccionada}
                    onChange={handleChange}
                    className="block w-full px-4 py-3 text-lg text-gray-700 bg-gray-200 border border-gray-400 rounded-lg focus:outline-none focus:ring-2 focus:ring-indigo-500"
                >
                    <option value="">-- Selecciona una ruta --</option>
                    {rutas.map((ruta) => (
                        <option key={ruta.id} value={ruta.id}>
                            {ruta.codigo} - {ruta.nombreRuta}
                        </option>
                    ))}
                </select>
                {rutaSeleccionada && (
                    <p className="mt-2 text-center text-indigo-600 font-semibold">
                        Has seleccionado la ruta con ID: {rutaSeleccionada}
                    </p>
                )}
            </div>
        </div>
    );
}

export default SeleccionarRuta;
