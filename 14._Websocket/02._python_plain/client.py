import asyncio
from websockets import connect

async def send_message():
    async with connect("ws://localhost:8000") as websocket:
        await websocket.send("Hello, World!")

        message = await websocket.recv()
        print(f"Received: {message}")

if __name__ == "__main__":
    asyncio.run(send_message())