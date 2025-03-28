import { Router } from 'express'

const router = Router()

let nextId = 4
const users = [
    { id: 1, name: 'Arne' },
    { id: 2, name: 'Minbo' },
    { id: 3, name: 'Charlie' },
]

/**
 * @swagger
 * components:
 *   schemas:
 *     User:
 *       type: object
 *       properties:
 *         id:
 *           type: integer
 *           description: The user ID.
 *           example: 0
 *         name:
 *           type: string
 *           description: The user's name.
 *           example: Leanne Graham
 */

/**
 * @swagger
 * components:
 *   schemas:
 *     NewUser:
 *       type: object
 *       properties:
 *         name:
 *           type: string
 *           description: The user's name.
 *           example: Leanne Graham
 */

/**
 * @openapi
 * /api/users:
 *   get:
 *     description: Get all users
 *     responses:
 *       200:
 *         description: Returns all users
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 data:
 *                      type: array
 *                      items:
 *                          $ref: '#/components/schemas/User'
 */
router.get('/api/users', (req, res) => {
    res.send({ data: users })
})

/**
 * @openapi
 * /api/users:
 *   post:
 *     description: Create a new user
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *            schema:
 *               type: object
 *               $ref: '#/components/schemas/NewUser'
 *     responses:
 *       200:
 *         description: Returns the users that was created
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 data:
 *                      type: array
 *                      items:
 *                          $ref: '#/components/schemas/User'
 */
router.post('/api/users', (req, res) => {
    const newUser = req.body
    newUser.id = nextId++
    users.push(newUser)

    res.send({ data: newUser })
})

export default router;