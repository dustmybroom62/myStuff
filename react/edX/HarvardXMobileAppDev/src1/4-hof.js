// Higher Order Functions take funcs as args or return funcs
function map(arr, fn) {
  const newArr = []

  arr.forEach(function(val) {
    newArr.push(fn(val))
  })

  return newArr
}

function addOne(num) { return num + 1 }
function add(x, y) {return x + y}
const x = [0,1,2,3]

console.log(map(x, addOne))

console.log(filter(x, val => { return val > 1 }))



console.log(reduce(x, add, 0))

console.log(x.reduce(add))

function filter(arr, fn) {
  const newArr = []
  arr.forEach(val => {
    if (fn(val)) newArr.push(val)
  })

  return newArr
}

function reduce(arr, fn, initialVal) {
  let returnVal = initialVal

  arr.forEach(val => {
    returnVal = fn(returnVal, val)
  })

  return returnVal
}
