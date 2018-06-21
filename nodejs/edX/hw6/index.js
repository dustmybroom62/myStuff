var express = require('express');
var app = express();

var Animal = require('./Animal.js');
var Toy = require('./Toy.js');

app.use('/findToy', (req, res) => {
    var id = req.query.id;
    if (!id) {
        res.json({});
    }
    Toy.findOne({id: id}, (err, animal) => {
        if (err) {
            res.json({});
        } else if (!animal) {
            res.json({});
        } else {
            res.json(animal);
        }
    });
});

app.use('/findAnimals', (req, res) => {
    var species = req.query.species;
    var trait = req.query.trait;
    var gender = req.query.gender;
    var query = {};
    var bParams = false;

    if (species) {
        bParams = true;
        query['species'] = species;
    }
    if (gender) {
        bParams = true;
        query['gender'] = gender;
    }
    if (trait) {
        bParams = true;
        query['traits'] = trait;
    }

    if (!bParams) {
        res.json({});
    } else {
        Animal.find(query, (err, animals) => {
            if (err) {
                res.json({});
            } else if (!animals || 0 == animals.length) {
                res.json({});
            } else {
                found = [];
                animals.forEach( (animal) => {
                    var a = {
                        name: animal.name,
                        species: animal.species,
                        breed: animal.breed,
                        gender: animal.gender,
                        age: animal.age
                    };
                    found.push(a);
                });
                res.json(found);
            }
        });
    }
});

app.use('/animalsYoungerThan', (req, res) => {
    var age = parseInt(req.query.age);
    var query = {};
    if (isNaN(age)) {
        res.json({});
    } else {
        query['age'] = { $lt: age};
        found = {count: 0};
        Animal.find(query, (err, animals) => {
            if (err) {
                console.log(err);
                res.json(found);
            } else if (!animals || 0 == animals.length) {
                res.json(found);
            } else {
                var names = [];
                animals.forEach( (animal) => {
                    names.push(animal.name);
                });
                found['names'] = names;
                found['count'] = animals.length;
                res.json(found);
            }
        });
    }
});

app.use('/calculatePrice', (req, res) => {
    var ids = req.query.id;
    var qtys = req.query.qty;
    if (!ids) {
        res.json({});
        return;
    }
    if (!qtys) {
        res.json({});
        return;
    }

    var query = {};
    var idCount = 0;
    var qtyCount = 0;
    var bArray = false;
    
    if (Array.isArray(ids)) {
        idCount = ids.length;
        bArray = true;
    }

    if (Array.isArray(qtys)) {
        qtyCount = qtys.length;
        bArray = true;
    }
    
    if (qtyCount != idCount) {
        res.json({});
        return;
    }

    let itemMap = new Map();

    if (!bArray) {
        var qty = parseInt(qtys);
        if (!isNaN(qty) && 0 < qty) {
            itemMap.set(ids, qty);
            query['id'] = ids;
        }
    } else {
        for (var i = 0; i < idCount; i++) {
            var qty = parseInt(qtys[i]);
            if (!isNaN(qty) && 0 < qty) {
                if (itemMap.has(ids[i])) {
                    qty += itemMap.get(ids[i]);
                }
                itemMap.set(ids[i], qty);
            }
        }
        var inList = [];
        for (let [id, qty] of itemMap) {
            inList.push(id);
        }
        query['id'] = {$in: inList};
    }

    var toysResult = {totalPrice: 0, items: []};

    if (0 == itemMap.size) {
        res.json(toysResult);
        return;
    }

    Toy.find(query, (err, toys) => {
        if (err) {
            res.json(toysResult);
            return;
        }
        if (!toys || 0 == toys.length) {
            res.json(toysResult);
            return;
        }
        toys.forEach( (toy) => {
            var id = toy.id;
            var price = toy.price;
            if (itemMap.has(id)) {
                var qty = itemMap.get(id);
                var subtotal = price * qty;
                toysResult.totalPrice += subtotal;
                toysResult.items.push({
                    item: id,
                    qty: qty,
                    subtotal: subtotal
                });
            }
        });
        res.json(toysResult);
        return;
    });

});

app.use('/', (req, res) => {
	res.json({ msg : 'It works!' });
    });


app.listen(3000, () => {
	console.log('Listening on port 3000');
    });



// Please do not delete the following line; we need it for testing!
module.exports = app;