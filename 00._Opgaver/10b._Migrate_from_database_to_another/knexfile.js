// Update with your config settings.

/**
 * @type { Object.<string, import("knex").Knex.Config> }
 */
module.exports = {
  sql_1: {
    client: 'mssql',
    connection: {
      database: 'SampleDB',
      user: 'sa',
      password: 'admin123!',
      host: 'localhost,1433'
    },
    migrations: {
      tableName: 'knex_migrations'
    }
  },
  sql_2: {
    client: 'postgresql',
    connection: {
      database: 'master',
      user: 'sa',
      password: 'admin123',
      host: 'localhost,1434'
    },
    migrations: {
      tableName: 'knex_migrations'
    }
  }
};
