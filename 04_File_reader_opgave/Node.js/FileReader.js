import * as fs from "fs";

export class FileReader {
  static async ReadJsonFile() {
    await fs.readFileSync("../Text_files/me.json");
  }
}
