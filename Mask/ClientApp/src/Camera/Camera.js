import React, { useState, useEffect } from "react";
import * as signalR from "@microsoft/signalr";
import { Button } from 'antd'

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/videohub")
    .configureLogging(signalR.LogLevel.Information)
    .build();


const Camera = () => {


    const [image, setImage] = useState(null);
    const [isConnection, setIsConnection] = useState(false)
    useEffect(() => { console.log(isConnection) }, [isConnection])

    connection.on("ReceiveFrame", base64 => {
        setImage(base64);
    });

    const start = async () => {
        try {
            await connection.start();
            console.log("SignalR Connected.");
            setIsConnection(true);
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
    }

    const stop = async () => {
        if (isConnection) {
            try {
                await connection.stop();
                console.log("SignalR Disconnected.");
                setIsConnection(false);
            } catch (err) {
                console.log(err);
                setTimeout(start, 5000);
            }
        }
        else {
            start();
        }

    }


    if (image) return (
        <div>
            <Button type="primary" onClick={stop}>{!isConnection ? 'Connect Camera' : 'Disconnect Camera'}</Button>
            <br />
            <img src={'data:image/png;base64,' + image} alt="img" style={{ height: '85vh' }} />
        </div>
    )
    return (
        <div>
            <Button type="primary" onClick={start}>Connect Camera</Button>
        </div>
    )
}
export default Camera;