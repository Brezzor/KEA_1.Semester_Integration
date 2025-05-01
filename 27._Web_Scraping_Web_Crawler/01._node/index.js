import fs from 'fs';
import { load } from 'cheerio';

// const response = await fetch('https://www.proshop.dk/Stationaer-Mini-PC-Barebone');
// const result = await response.text();
// fs.writeFileSync('index.html', result);

const page = await fs.readFileSync('index.html', 'utf-8');

const $ = load(page);

$('#products [product]').each((index, element) => {
    const name = $(element).find('.site-product-link').text();
    const price = $(element).find('.site-currency-lg').text();
    console.log({ name, price });
});