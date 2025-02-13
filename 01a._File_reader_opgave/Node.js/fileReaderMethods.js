import * as fs from "fs";
import { Me } from "./me.js";
import { parseString } from "xml2js";
import YAML from "yaml";
import * as csvToJson from "convert-csv-to-json";

export class FileReaderMethods {
  static async readJsonFile() {
    const data = await fs.readFileSync("./Text_files/me.json", "utf-8");
    const jsonData = JSON.parse(data);
    const me = new Me(jsonData.name, jsonData.age, jsonData.hobbies);
    console.log("Json file:");
    me.writeToConsole();
  }
  static async readXmlFile() {
    const data = await fs.readFileSync("./Text_files/me.xml", "utf-8");
    let me;
    parseString(data, (err, res) => {
      if (err) throw err;
      me = new Me(res.me.name, res.me.age, res.me.hobbies[0].hobby);
    });
    console.log("Xml file:");
    me.writeToConsole();
  }
  static async readYamlFile() {
    const data = await fs.readFileSync("./Text_files/me.yaml", "utf-8");
    const result = YAML.parse(data);
    const me = new Me(result.name, result.age, result.hobbies);
    console.log("Yaml file:");
    me.writeToConsole();
  }
  static async readCsvFile() {
    const data = csvToJson
      .parseSubArray("*", "/")
      .fieldDelimiter(",")
      .getJsonFromCsv("./Text_files/me.csv");
    const me = new Me(data[0].name, data[0].age, data[0].hobbies);
    console.log("Csv file:");
    me.writeToConsole();
  }
  static async readTxtFile() {
    let me;
    const data = await fs.readFileSync("./Text_files/me.txt", "utf-8");
    const splitted = data.split(/[:\r\n]+/).map((s) => s.trim());
    const hobbies = splitted[5].split(", ");
    me = new Me(splitted[1], splitted[3], hobbies);
    console.log("Txt file:");
    me.writeToConsole();
  }
}
