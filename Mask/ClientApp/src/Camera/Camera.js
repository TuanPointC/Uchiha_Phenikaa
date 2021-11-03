import React, { useState, useEffect } from "react";
import * as signalR from "@microsoft/signalr";
const Camera = () => {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl("/videohub")
        .build();

    // Starts the SignalR connection
    hubConnection.start().then(() => {
        hubConnection.invoke("SendMessage");
    });

    const [image, setImage] = useState(null);
    useEffect(() => {
        hubConnection.on("ReceiveMessage", base64 => {
            setImage(base64);
        });
    },[hubConnection]);

    if (image) {
        return <img src={'data:image/png;base64,' + image} alt="img" />
    }
    return (
        <div>Camera</div>
    )
}

export default Camera;