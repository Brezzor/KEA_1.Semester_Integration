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

app.listen(PORT, () => console.log(`Link to server: Http://localhost:${PORT}`));
