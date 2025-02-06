import express from "express";

const app = express();

app.get("/", (req, res) => {
  res.send({ data: `From: ${req.hostname} Hello, World!` });
});

app.get("/Greetings", (req, res) => {
  res.send({ data: `From: ${req.hostname} Greetings! Traveler` });
});

const PORT = 3000;
app.listen(PORT), () => console.log("Server is running on port", PORT);
