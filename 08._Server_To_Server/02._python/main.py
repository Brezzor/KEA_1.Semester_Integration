from fastapi import FastAPI
import httpx

app = FastAPI()

@app.get("/fastAPIData")
def getFastAPIData():
    return { "data": "This is the data from FastAPI"}

@app.get("/requestExpressData")
async def getExpressData():
    async with httpx.AsyncClient() as client:
        response = await client.get("http://localhost:8080/expressData")
        return response.json()