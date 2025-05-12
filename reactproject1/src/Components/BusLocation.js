import React, { useState, useEffect } from 'react';
import { HubConnectionBuilder } from '@microsoft/signalr';

const BusLocation = () => {
    const [location, setLocation] = useState(null);

    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl('https://transportepublicoapi.somee.com/bushub')  // URL de tu API de SignalR
            .build();

        connection
            .start()
            .then(() => console.log('Conectado a SignalR'))
            .catch(err => console.error('Error conectando a SignalR', err));

        connection.on('ReceiveBusLocation', (data) => {
            setLocation(data);
        });

        return () => {
            connection.stop();
        };
    }, []);

    return (
        <div>
            <h3>Ubicacion del Bus en Tiempo Real</h3>
            <p>{location ? `Ubicacion: ${location}` : "Esperando ubicacion..."}</p>
        </div>
    );
};

export default BusLocation;
