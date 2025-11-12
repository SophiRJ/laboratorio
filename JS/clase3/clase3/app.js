import { Circulo } from "./mathUtils";

import(PI, suma, Circulo) from './mathUtils.js';

console.log(`Valor de PI: ${PI}`)
console.log(`Suma 2+3=${suma(2, 3)}`);

const c = new Circulo(5);
console.log(`El area del circulo de radio 5 es ${c.area()}`);