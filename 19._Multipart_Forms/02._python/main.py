from fastapi import FastAPI, Form, File, UploadFile
from typing import Optional
from datetime import datetime
import aiofiles

app = FastAPI()

@app.post("/form")
async def basic_form(username: str = Form(...), password: str = Form(default=..., min_length=8)):
    print(username, password)
    return {"username": username}

# @app.post("/fileform")
# async def file_form(file: UploadFile = File(...), desciption: Optional[str] = None):    
#     contents = await file.read()
#     print(contents)
#     return { "message": "File Uploaded" }

@app.post("/fileform")
async def file_form(file: UploadFile = File(...), desciption: Optional[str] = None):    
    safe_filename = file.filename.replace("/", "_").replace("\\", "_")

    unique_filename = datetime.now().strftime("%Y%m%d%H%M%S") + "_" + safe_filename

    async with aiofiles.open("./uploads/" + unique_filename, "wb") as f:
        while content := await file.read(1024):
            await f.write(content)
    
    return {}