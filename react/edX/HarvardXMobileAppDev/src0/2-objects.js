
const o = new Object()
o.firstName = 'Jordan'
o.lastName = 'Hayashi'
o.isTeaching = true
o.greet = function() { console.log('Hello!') }

//console.log(JSON.stringify(o))

const o2 = {}
o2['name'] = {}
o2['name']['firstName'] = 'Jordan'
o2['name']['prefix'] = 'Mr'
const a = 'lastName'
o2[a] = 'Hayashi'

console.log(JSON.stringify(o2));

const o3 = {
  firstName: 'Jordan',
  lastName: 'Hayashi',
  greet: function() {
    console.log('hi')
  },
  address: {
    street: "Main st.",
    number: '111'
  }
}

//console.log(JSON.stringify(o3));

// see 3-objectsMutation.js for more objects
