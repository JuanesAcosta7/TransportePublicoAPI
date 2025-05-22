import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import API from "../api.js";

function SeleccionarRuta({ onRutaSeleccionada }) {
    const [rutas, setRutas] = useState([]);
    const [rutaSeleccionada, setRutaSeleccionada] = useState("");
    const navigate = useNavigate();

    useEffect(() => {
        API.get("/DimRuta")
            .then((res) => setRutas(res.data))
            .catch((err) => console.error("Error cargando rutas:", err));
    }, []);

    const handleChange = (e) => {
        const valor = e.target.value;
        setRutaSeleccionada(valor);
        if (onRutaSeleccionada) {
            onRutaSeleccionada(valor);
        }
    };

    const irAlTablero = () => {
        // Navega a tablero (sin importar si rutaSeleccionada está vacía)
        navigate("/tablero");
    };

    return (
        <div className="bg-gray-800 p-6 rounded-xl shadow-md border border-gray-600">
            <h2 className="text-2xl font-semibold text-gray-100 mb-4">
                Selecciona una Ruta
            </h2>
            <select
                value={rutaSeleccionada}
                onChange={handleChange}
                className="block w-full px-4 py-3 text-lg text-gray-700 bg-gray-200 border border-gray-400 rounded-lg focus:outline-none focus:ring-2 focus:ring-indigo-500"
            >
                <option value="">-- Selecciona una ruta --</option>
                {rutas.map((ruta) => (
                    <option key={ruta.rutaKey} value={ruta.rutaKey}>
                        {ruta.nombre} ({ruta.sentido})
                    </option>
                ))}
            </select>

            <div className="mt-4 text-center">
                <button
                    onClick={irAlTablero}
                    className="mt-4 px-4 py-2 bg-indigo-600 rounded-lg text-white hover:bg-indigo-700 transition"
                >
                    Ir al Tablero Power BI
                </button>
            </div>
        </div>
    );
}

export default SeleccionarRuta;
