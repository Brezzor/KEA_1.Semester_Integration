import express from 'express'
import userRouter from './routers/userRouter.js'
import swaggerJSDoc from 'swagger-jsdoc'
import swaggerUi from 'swagger-ui-express'

const PORT = process.env.PORT ?? 8080
const app = express()

app.use(express.json())
app.use(userRouter)

const swaggerDefinition = {
    openapi: '3.1.0',
    info: {
        title: 'Users API',
        version: '1.0.0',
        description:
            'This is a REST API application made with Express. It retrieves data from Users API.',
        license: {
            name: 'Licensed Under MIT',
            url: 'https://spdx.org/licenses/MIT.html',
        },
    },
    servers: [
        {
            url: `http://localhost:${PORT}`,
            description: 'Development server'
        }
    ]
}

const swaggerOptions = {
    swaggerDefinition,
    apis: ['./routers/*Router.js']
}

const swaggerSpec = swaggerJSDoc(swaggerOptions)

app.use('/swagger', swaggerUi.serve, swaggerUi.setup(swaggerSpec))

app.listen(PORT, () => console.log(`http://localhost:${PORT}`))