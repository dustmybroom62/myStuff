/*
 * Implement all your JavaScript in this file!
 */
var _displayStack = [];
var _operatorStack = [];
var _operandStack = [];
var _display = $('#display');
var _INF = '_Infinity';
var _DIGIT = 1;
var _FUNC = 2;
var _EQ = 3;
var _LastUsed = 0;

function checkDisplay() {
    var d = display();
    console.log('checkDisplay: ' + d);
    if ('' == d) return false;
    if (_INF == d) return false;
    return true;
}

function numberClicked(val) {
    if (_EQ == _LastUsed) {
        clearAll();
    }
    _LastUsed = _DIGIT;
    _displayStack.push(val);
    display(_displayStack.join(''));
}

function clearAll() {
    _LastUsed = 0;
    _displayStack = [];
    _operatorStack = [];
    _operandStack = [];
    display('');
}

function doEqual() {
    console.log('doEqual');
    if (_FUNC == _LastUsed) return;
    if (0 == _operandStack.length) return;
    if (0 == _operatorStack.length) return;
    if (!checkDisplay()) return;

    var op1, op2, oper;

    if (_EQ == _LastUsed) {
        op1 = display();
        op2 = _operandStack.pop();
        _operandStack.push(op2);
    } else {
        op2 = display();
        op1 = _operandStack.pop();
        _operandStack.push(op2);
    }
    _LastUsed = _EQ;
    showResult(op1, op2);
}

function showResult(op1, op2) {
    var oper = _operatorStack.pop();
    _operatorStack.push(oper);
    var result = eval(op1 + ' ' + oper + " " + op2);
    var d = Number(result);
    if (isNaN(d)) {
        display(_INF);
        return null;
    }
    display(d);
    return d;
}

function doFunction(op) {
    console.log('doFunction: _LastUsed: ' + _LastUsed);
    if (_FUNC == _LastUsed) {
        _operatorStack = [op];
        return;
    }
    if (!checkDisplay()) {
        return;
    }

    if (_EQ == _LastUsed) {
        _operandStack = [display()];
        _operatorStack = [op];
        _LastUsed = _FUNC;
        return;
    }

    _LastUsed = _FUNC;

    if (0 == _operandStack.length) {
        _operandStack.push(display());
        _operatorStack = [op];
        return;
    }

    var op1 = _operandStack.pop();
    var op2 = display();
    var d = showResult(op1, op2);
    _operatorStack = [op];
    if (null == d) return;
    _operandStack.push(d);
}

function operatorClicked(val) {
    _displayStack = [];
    switch(val) {
        case '+':
        case '-':
        case '*':
            doFunction(val);
            break;
        case '\xF7':
            doFunction('/');
            break;
        case '=':
            doEqual();
            break;
        case 'C':
            clearAll();
            break;
    }
}

function display(val) {
    
    if (null == val) {
        return _display.val();
    }
    _display.val(val);
    return val;
}

$('button').click(function () {
    var id = $(this).prop('id');
    //console.log(id);
    if (id.indexOf('button') == 0) {
        numberClicked($(this).val());
    } else {
        operatorClicked($(this).html());
    }
});