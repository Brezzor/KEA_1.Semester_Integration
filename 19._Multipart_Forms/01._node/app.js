import express from 'express';
import multer from 'multer';

const storage = multer.diskStorage({
    destination: (req, file, cb) => {
        cb(null, './uploads');
    },
    filename: (req, file, cb) => {
        const uniquePrefix = Date.now() + '-' + Math.round(Math.random() * 1E9);
        const uniqueFilename = `${uniquePrefix}-${file.originalname}`;

        cb(null, uniqueFilename);
    }
});

function fileFilter(req, file, cb) {
    const validTypes = ['image/jpeg', 'image/png', 'image/svg+xml'];

    if (validTypes.includes(file.mimetype)) {
        cb(null, true);
    } else {
        cb(new Error('Only .jpg, .png and .svg files are allowed!'), false);
    }
}

const upload = multer({ storage: storage, limits: { fileSize: 1024 * 1024 * 2, files: 5 }, fileFilter: fileFilter });

const PORT = Number(process.env.PORT) || 8001;

const app = express();

app.use(express.urlencoded({ extended: true }));

app.post('/form', (req, res) => {
    console.log(req.body);
    delete req.body.password;
    res.send(req.body);
});

app.post('/fileform', upload.array('file'), (req, res) => {
    console.log(req.body);
    res.send({});
});


app.listen(PORT, () => console.log(`Server is running on http://localhost:${PORT}`));