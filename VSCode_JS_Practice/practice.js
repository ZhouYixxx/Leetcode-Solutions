function checkSpam(str){
    var lowerStr = str.toLocaleLowerCase();
    return lowerStr.includes('viagra') || lowerStr.includes('xxx');
}

function camelize(str){
    let str1 = str.split('-').map((value, index)=>{
        if (index != 0) {
            return value.toLowerCase();
        }
        return value[0].toUpperCase() + value.slice(1).toLowerCase();
    }).join('');
    return str1;
}