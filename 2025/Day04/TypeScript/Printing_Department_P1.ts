import { readFileSync } from "fs";

let input:string[] = readFileSync("input.txt", "ascii").split('\n')
let result = 0
type cords = {x:number; y:number}

function checkAdjacentPositions(x:number, y:number):boolean
{
	let count:number = 0
	let positions: cords[] = []
	
	let iter = 0
	for (let dx = 1; dx >= -1; dx--)
		for (let dy = 1; dy >= -1; dy--)
			if (dy || dx)
				positions[iter++] = { x: x + dx, y: y + dy }
	for (let i = 0; i < positions.length; i++)
	{
		if (input[positions[i]!.y] == undefined ||
				input[positions[i]!.y]![positions[i]!.x] == undefined)
			continue
		if (input[positions[i]!.y]![positions[i]!.x] == '@')
			count++;
	}
	return (count < 4)
}


for (let y = 0; y < input.length; y++)
	for (let x = 0;x<input[y]!.length; x++)
		if (input[y]![x]! == '@' && checkAdjacentPositions(x, y))
			result += 1

console.log(result)