import express from "express";
import { FileReaderMethods } from "./fileReaderMethods.js";

const PORT = 8080;

const app = express();

app.get("/json", async (req, res) => {
  const me = await FileReaderMethods.readJsonFile();
  res.status(200).send({ me });
});

app.get("/xml", async (req, res) => {
  const me = await FileReaderMethods.readXmlFile();
  res.status(200).send({ me });
});

app.get("/yaml", async (req, res) => {
  const me = await FileReaderMethods.readYamlFile();
  res.status(200).send({ me });
});

app.get("/csv", async (req, res) => {
  const me = await FileReaderMethods.readCsvFile();
  res.status(200).send({ me });
});

app.get("/txt", async (req, res) => {
  const me = await FileReaderMethods.readTxtFile();
  res.status(200).send({ me });
});

app.get("/jsonFromCsharp", async (req, res) => {
  await fetch("http://localhost:5083/json")
    .then(async (response) => {
      res.send(await response.json());
    })
    .catch((error) => res.status(500).send({ error: error }));
});

app.get("/xmlFromCsharp", async (req, res) => {
  await fetch("http://localhost:5083/xml")
    .then(async (response) => {
      res.send(await response.json());
    })
    .catch((error) => res.status(500).send({ error: error }));
});

app.get("/csvFromCsharp", async (req, res) => {
  await fetch("http://localhost:5083/csv")
    .then(async (response) => {
      res.send(await response.json());
    })
    .catch((error) => res.status(500).send({ error: error }));
});

app.get("/yamlFromCsharp", async (req, res) => {
  await fetch("http://localhost:5083/yaml")
    .then(async (response) => {
      res.send(await response.json());
    })
    .catch((error) => res.status(500).send({ error: error }));
});

app.get("/txtFromCsharp", async (req, res) => {
  await fetch("http://localhost:5083/txt")
    .then(async (response) => {
      res.send(await response.json());
    })
    .catch((error) => res.status(500).send({ error: error }));
});

app.listen(PORT, () => console.log(`Link to server: Http://localhost:${PORT}`));
