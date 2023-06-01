let calculator = new calculator();
calculator.read();
alert( "Sum=" + calculator.sum());
alert( "Mul=" + calculator.mul());

function calculator() {
    this.name = "calc";
    this.a = 0;
    this.b = 0;
    this.sum = function sum() {
        return a + b;
    };
    this.mul = function mul() {
        return a * b;
    }
    this.read  = function read() {
        let a = +prompt("give me number a:", 0);
        let b = +prompt("give me number b:", 0);
    }; 
}