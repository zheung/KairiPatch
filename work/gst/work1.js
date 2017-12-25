let fs = require('fs');

let jp = fs.readFileSync('work/ref/catalog.jp.dat', 'utf-8');
let cn = fs.readFileSync('work/ref/catalog.cn.dat', 'utf-8');
let jpl = jp.split('\n');
let cnl = cn.split('\r\n');

let dict = {};

let arrv = [];

for(let line of jpl) {
	if(!line) continue;

	let data = line.split(',');
	let type = data[0];
	let name = data[1];
	let id = (name.match(/\d+/) || [])[0];

	if(type == '<b>' && /_ext\.dat/.test(name)) {
		dict[id] = line;
	}
}

console.log(Object.keys(dict).length);

for(let line of cnl) {
	if(!line) continue;

	let data = line.split(',');
	let type = data[0];
	let name = data[1];
	let id = (name.match(/\d+/) || [])[0];

	if(type == '<b>' && /_ext\.dat/.test(name) && dict[id]) {
		delete dict[id];
	}
}

let arrc = Object.values(dict);

console.log(arrc.length);

for(let line of arrc) {
	let data = line.split(',');
	let name = data[1];
	let id = (name.match(/\d+/) || [])[0];

	arrv.push(`<bundle_ver>, card/ext/card_${id}_ext.dat, 0, ${data[2]}`);
	try {
		fs.renameSync(`patch/card/ext/card_${id}_ext.dat`, `patch/card/ext/card_${id}_ext.dat.new`);
	}
	catch(e) { true; }
}

let dir = '';

for(let line of jpl) {
	let data = line.split(',');
	let type = data[0];

	dir = data[1] ? data[1] : dir;

	if(type == '<a>') {
		let id = (dir.match(/\d{8}/) || [])[0];

		if(id && dict[id]) {
			arrc.push(line.replace(/\d+$/, `card/ext/card_${id}_ext.dat`));
		}
	}
}

fs.writeFileSync('work/catalog.ext.txt', arrc.join('\n'));
fs.writeFileSync('work/version.ext.unity3d', arrv.join('\n'));