import express from "express";

const PORT = Number(process.env.PORT) || 8080;

const app = express();

app.use(express.static("public"));

app.get("/synchronizetime", (req, res) => {
  res.writeHead(200, {
    "connection": "keep-alive",
    "content-type": "text/event-stream",
    "cache-control": "no-cache",
  });

  setInterval(() => sendTimeToClient(res), 1000);
});

function sendTimeToClient(res) {
    const time = new Date().toISOString();
    res.write(`data: ${time} \n\n`);
}

app.listen(PORT, () => {
  console.log(`Server listens on: http://localhost:${PORT}`);
});
