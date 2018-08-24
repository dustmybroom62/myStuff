function makeFunctionArray() {
  const arr = []
  let i = 0;
  for ( ; i < 5; i++) {
    arr.push(function () { console.log(i) })
  }

  return arr
}

const functionArr = makeFunctionArray()

// we expect this to log 0, but it doesn't
for (let x = 0; x < functionArr.length; x++) {
  functionArr[x]()
}
