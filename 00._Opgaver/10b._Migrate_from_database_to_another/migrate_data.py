import psycopg2

source_conn = psycopg2.connect(
    dbname='sourcedb',
    user='user',
    password='password',
    host='localhost',
    port=5433
)

target_conn = psycopg2.connect(
    dbname='targetdb',
    user='user',
    password='password',
    host='localhost',
    port=5434
)

def migrate():
    with source_conn.cursor() as src, target_conn.cursor() as tgt:        
        tgt.execute("""
            CREATE TABLE IF NOT EXISTS employees (
                id SERIAL PRIMARY KEY,
                name VARCHAR(100),
                department VARCHAR(100)
            )
        """)

        src.execute("SELECT name, department FROM employees")
        rows = src.fetchall()

        for row in rows:
            tgt.execute(
                "INSERT INTO employees (name, department) VALUES (%s, %s)",
                row
            )

    target_conn.commit()
    print("Migration complete!")

if __name__ == "__main__":
    migrate()
    source_conn.close()
    target_conn.close()
