import React, { useState, useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

const BusLocation = () => {
    const [location, setLocation] = useState(null);

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://localhost:7272/bushub')
            .withAutomaticReconnect()
            .build();

        connection
            .start()
            .then(() => console.log('✅ Conectado a SignalR'))
            .catch(err => console.error('❌ Error conectando a SignalR', err));

        connection.on('ReceiveBusLocation', (data) => {
            console.log('📡 Datos recibidos:', data);

            try {
                const parsed = typeof data === 'string' ? JSON.parse(data) : data;
                setLocation(parsed);
            } catch (error) {
                console.error("❌ Error al parsear datos recibidos:", error);
            }
        });

        return () => {
            connection.stop();
        };
    }, []);

    return (
        <div>
            <h3>Ubicación del Bus en Tiempo Real</h3>
            {location ? (
                <p>Latitud: {location.lat} | Longitud: {location.lng}</p>
            ) : (
                <p>⏳ Esperando ubicación...</p>
            )}
        </div>
    );
};

export default BusLocation;
