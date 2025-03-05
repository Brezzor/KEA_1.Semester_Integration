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
    return me;
  }
  static async readXmlFile() {
    const data = await fs.readFileSync("./Text_files/me.xml", "utf-8");
    let me;
    parseString(data, (err, res) => {
      if (err) throw err;
      me = new Me(
        res.me.name[0],
        parseInt(res.me.age[0]),
        res.me.hobbies[0].hobby
      );
    });
    return me;
  }
  static async readYamlFile() {
    const data = await fs.readFileSync("./Text_files/me.yaml", "utf-8");
    const result = YAML.parse(data);
    const me = new Me(result.name, result.age, result.hobbies);
    return me;
  }
  static async readCsvFile() {
    const data = csvToJson
      .parseSubArray("*", "/")
      .fieldDelimiter(",")
      .getJsonFromCsv("./Text_files/me.csv");
    const me = new Me(data[0].name, parseInt(data[0].age), data[0].hobbies);
    return me;
  }
  static async readTxtFile() {
    let me;
    const data = await fs.readFileSync("./Text_files/me.txt", "utf-8");
    const splitted = data.split(/[:\r\n]+/).map((s) => s.trim());
    const hobbies = splitted[5].split(", ");
    me = new Me(splitted[1], parseInt(splitted[3]), hobbies);
    return me;
  }
}
