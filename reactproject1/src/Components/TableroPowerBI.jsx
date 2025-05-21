
import React from "react";

const TableroPowerBI = () => {
    return (
        <div className="min-h-screen bg-gray-900 flex flex-col items-center justify-center px-6 py-12">
            <div className="bg-gray-800 p-6 rounded-2xl shadow-xl w-full max-w-6xl border-l-8 border-indigo-600">
                <h1 className="text-3xl font-bold text-center text-indigo-400 mb-6">
                    Tablero de Control Power BI
                </h1>
                <iframe title="tableroFin" width="1000" height="3000.5" src="https://app.powerbi.com/view?r=eyJrIjoiNzIyN2UyOTctMWQzNC00NTc2LTljOWUtZDM1MDI0ZTYzNzc4IiwidCI6IjA3ZGE2N2EwLTFmNDMtNGU4Yy05NzdmLTVmODhiNjQ3MGVlNiIsImMiOjR9" frameborder="0" allowFullScreen="true"></iframe>
            </div>
        </div>
    );
};

export default TableroPowerBI;
