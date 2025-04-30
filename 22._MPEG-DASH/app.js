import express from 'express';

const PORT = process.env.PORT || 8000;

const app = express();

app.use(express.static('public'));
app.use(express.static('videos'));

app.listen(PORT, () => {
    console.log(`Server is running on: http://localhost:${PORT}`);
});