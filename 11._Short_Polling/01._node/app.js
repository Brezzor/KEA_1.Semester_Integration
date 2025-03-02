import express from "express";

const PORT = 8080;

const app = express();

app.use(express.static("public"));

const randomNumbers = [1, 25, 574];

app.get("/randomnumbers", (req, res) => {
  res.send({ data: randomNumbers });
});

app.get("/simulatenewnumbers", (req, res) => {
  const newNumber = getRandomInt(0, 1000);
  randomNumbers.push(newNumber);
  res.send({ data: newNumber });
});

function getRandomInt(min, max) {
  return Math.floor(Math.random() * (max - min + 1) + min);
}

app.listen(PORT, () => {
  console.log(`http://localhost:${PORT}`);
});
