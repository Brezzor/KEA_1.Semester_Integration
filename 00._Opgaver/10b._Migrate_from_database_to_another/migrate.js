import knex from 'knex'
import cfg from './knexfile.js'

const sql1 = knex(cfg.sql_1)
const sql2 = knex(cfg.sql_2)
