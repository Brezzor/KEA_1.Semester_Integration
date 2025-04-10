import express from 'express';
import cors from 'cors';

const app = express();

app.use(express.static("public"));
app.use(cors());

app.get("/timestamp", (req, res) => {
    res.send({ data: new Date() });
});

const PORT = Number(process.env.PORT) || 8080;

app.listen(PORT, () => console.log(`Server is running on: http://localhost:${PORT}`));