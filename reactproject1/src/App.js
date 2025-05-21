import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import RutasList from './Components/RutasList.js';
import VerTiempoLlegada from './Components/VerTiempoLlegada.js';
import SeleccionarRuta from './Components/SeleccionarRuta.js';
import TableroPowerBI from './Components/TableroPowerBI.jsx';
import './App.css';

const App = () => {
    const [rutaId, setRutaId] = useState(null);

    useEffect(() => {
        const script = document.createElement("script");
        script.src = "//code.tidio.co/e0osth7rsc9yhz5h18msxqmxgategml9.js";
        script.async = true;
        document.body.appendChild(script);
        return () => document.body.removeChild(script);
    }, []);

    const Principal = () => (
        <div className="min-h-screen bg-gray-900 flex flex-col items-center justify-start px-6 py-12">
            <div className="bg-gray-800 shadow-xl rounded-2xl p-8 max-w-5xl w-full space-y-8 border-l-8 border-gray-600">
                <h1 className="text-4xl font-extrabold text-center text-indigo-400 tracking-wide mb-6">
                    <span className="text-indigo-500">Sistema</span> de Transporte Publico
                </h1>

                <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
                    <div className="bg-gray-700 p-6 rounded-xl shadow-md border border-gray-600 col-span-2 md:col-span-1">
                        <h2 className="text-2xl font-semibold text-gray-100 mb-4">Selecciona una Ruta</h2>
                        <SeleccionarRuta onRutaSeleccionada={setRutaId} />
                    </div>

                    <div className="bg-gray-700 p-6 rounded-xl shadow-md border border-gray-600">
                        <h2 className="text-2xl font-semibold text-gray-100 mb-4">Rutas Disponibles</h2>
                        <RutasList onRutaSelect={setRutaId} />
                    </div>
                </div>

                {rutaId && (
                    <div className="bg-gray-700 p-6 rounded-xl shadow-md border border-gray-600">
                        <VerTiempoLlegada rutaId={rutaId} />
                        <p className="text-center text-gray-300 font-medium mt-4">
                            Has seleccionado la ruta con ID: <span className="text-indigo-500 font-semibold">{rutaId}</span>
                        </p>
                    </div>
                )}
            </div>
        </div>
    );

    return (
        <Router>
            <Routes>
                <Route path="/" element={<Principal />} />
                <Route path="/tablero" element={<TableroPowerBI />} />
            </Routes>
        </Router>
    );
};

export default App;

