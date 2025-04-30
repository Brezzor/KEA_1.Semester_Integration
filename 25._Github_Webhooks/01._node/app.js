import express from 'express';

const PORT = process.env.PORT || 8001;

const app = express();

app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.post('/githubwebhookjson', (req, res) => {
    console.log(req.body);
    res.sendStatus(204);
});

app.post('/githubwebhookform', (req, res) => {
    console.log(req.body);
    res.sendStatus(204);
});

app.listen(PORT, () => {
    console.log(`Server is running on http://localhost:${PORT}`);
});