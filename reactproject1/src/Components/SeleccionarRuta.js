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
        <div className="min-h-screen bg-gray-900 flex flex-col items-center justify-center px-6 py-12">
            <div className="bg-gray-800 p-6 rounded-2xl shadow-xl w-full max-w-6xl border-l-8 border-indigo-600">
                <h1 className="text-3xl font-bold text-center text-indigo-400 mb-6">
                    Tablero de Control Power BI
                </h1>
                <iframe title="tableroFin" width="1000" height="1003.5" src="https://app.powerbi.com/view?r=eyJrIjoiNzIyN2UyOTctMWQzNC00NTc2LTljOWUtZDM1MDI0ZTYzNzc4IiwidCI6IjA3ZGE2N2EwLTFmNDMtNGU4Yy05NzdmLTVmODhiNjQ3MGVlNiIsImMiOjR9" frameborder="0" allowFullScreen="true"></iframe>
            </div>
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
                {/* <div className="mt-4 text-center">
                    <button
                        onClick={() => {

                            window.open(`/tablero?ruta=${rutaSeleccionada}`, "_blank");

                        }}
                        className="mt-4 px-4 py-2 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700 transition disabled:opacity-50 disabled:cursor-not-allowed"
                        
                    >
                        Ir al Tablero Power BI
                    </button>*/}
                </div>
            </div>
        </div>
    );
}

export default SeleccionarRuta;


