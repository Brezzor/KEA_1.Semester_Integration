import express from "express";

const PORT = 8080;
const app = express();

app.get("/expressData", (req, res) => {
  res.send({ data: "This is the data from Express" });
});

app.get("/requestFastAPIData", async (req, res) => {
  await fetch("http://localhost:8000/fastAPIData")
    .then(async (response) => {
      res.send(await response.json());
    })
    .catch((error) => res.status(500).send({ error: error }));
});

app.get("/names/:name", (req, res) => {
  console.log(req.params.name);
  res.send({ data: `Your name is ${req.params.name}` });
});

app.listen(PORT, () =>
  console.log(`Server listening on: Http://localhost:${PORT}`)
);
