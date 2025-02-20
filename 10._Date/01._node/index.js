//UTC - ISO 8601
let date = new Date();
console.log(date);

// Local Date
date = Date();
console.log(date);

// Unix Epoch
date = Date.now();
console.log(date);

// Danish Date
date = new Intl.DateTimeFormat("da-dk").format(new Date());
console.log(date);

// American Date
date = new Intl.DateTimeFormat("en-us").format(new Date());
console.log(date);

// Local Date String
date = new Date().toLocaleString();
console.log(date);
