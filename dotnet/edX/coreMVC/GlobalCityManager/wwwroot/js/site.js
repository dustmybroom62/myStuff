
function utcToLocale(inTime) {
    function d2(num) { return num.toString().padStart(2, '0'); }
    let now = new Date( inTime );
    return `${now.getFullYear()}-${d2(now.getMonth()+1)}-${d2(now.getDate())} ${d2(now.getHours())}:${d2(now.getMinutes())}:${d2(now.getSeconds())}`;            
}
