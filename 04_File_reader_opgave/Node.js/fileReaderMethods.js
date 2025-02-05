import * as fs from "fs";
import { Me } from "./me.js";

export class FileReaderMethods {
  static async readJsonFile() {
    const data = await fs.readFileSync(
      "./04_File_reader_opgave/Text_files/me.json"
    );
    const jsonData = JSON.parse(data);
    const me = new Me(jsonData.name, jsonData.age, jsonData.hobbies);
    me.writeToConsole();
  }
  static async readXmlFile() {
    const data = await fs.readFileSync(
      "./04_File_reader_opgave/Text_files/me.xml"
    );
  }
}
