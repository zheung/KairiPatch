let fs = require('fs');

let jp = fs.readFileSync('patch/ext-jp.txt', 'utf-8');
let di = fs.readFileSync('patch/ext-di.txt', 'utf-8');

let dict = {}, arr = [];

for(let line of di.split('\r\n')) {
	dict[line] = true;
}

for(let line of jp.split('\n')) {
	let name = line.split(',')[1];

	if(name) {
		let id = name.match(/(Live2D\/Card_|card\/ext\/card_)(\d+)/)[2];

		if(dict[id])
			arr.push(line);
	}
}

fs.writeFileSync('patch/ext.txt', arr.join('\n'));