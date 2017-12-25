let fs = require('fs');

let ext = fs.readFileSync('patch/ext.txt', 'utf-8');

let dict = {}, arr = [], brr = [];

for(let line of ext.split('\n')) {
	if(/^<b>/.test(line)) {
		brr.push(line);
	}
	else if(/^<a>/.test(line)) {
		arr.push(line);
	}
}

let set = new Set(), start = 4541, v=[];

for(let a of arr) {
	let name = a.split(',')[1];
	let id = name.match(/(Live2D\/Card_|card\/ext\/card_)(\d+)/)[2];

	set.add(id);

	brr.push(a.replace(/\,\d+$/, `,${start+set.size}`));
}

fs.writeFileSync('patch/catalog-ext.txt', brr.join('\n'));