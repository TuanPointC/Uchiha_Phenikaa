import React, { useState, useEffect } from "react";
import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/videohub")
    .configureLogging(signalR.LogLevel.Information)
    .withAutomaticReconnect()
    .build();

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 100);
    }

    // try {
    //     await connection.invoke("SendMessage");
    // } catch (err) {
    //     console.error(err);
    // }
};
connection.onclose(async () => {
    await start();
});
const Camera = () => {

    start();


    const [image, setImage] = useState(null);
    connection.on("ReceiveMessage", base64 => {
        setImage(base64);
    });


    if (image) {
        return <img src={'data:image/png;base64,' + image} alt="img" style={{ width: '100%', height:'85vh' }} />
    }
    return (
        <div>Camera</div>
    )
}

export default Camera;