// let myname = 'Mike'; //第一次定义name

// function showName() {
//     alert(myname);  //输出 Mike 还是 Jay ？
// }

// function changeName() {
//     let myname = 'Jay'; //重新定义name
//     showName(); //调用showName()
// }

// changeName();

for (let i = 0; i < 5; i++) {
    setTimeout(function timer() {
        console.log(i);
    }, 1000);
}

