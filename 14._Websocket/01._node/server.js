import {WebSocketServer} from "ws";

const PORT = process.env.PORT ?? 8081;

const server = new WebSocketServer({port: PORT});

server.on("connection", (ws) => {
    console.log("New connection:", server.clients.size);

    ws.on("message", (message) => {
        console.log("Received message from client:", message.toString());

        server.clients.forEach((client) => {
            client.send(message.toString())
        })
    })

    ws.on("close", () => {
        console.log("Client disconnected:", server.clients.size);
    })
});