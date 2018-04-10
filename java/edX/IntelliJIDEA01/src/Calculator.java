
public class Calculator {
    Number result;

    public Calculator() {
        this.result = 0;
    }

    private Number factorial (Number num1) {
        long result = 1;
        for (long i = 0; i < num1.longValue(); i++){
            result *= (i + 1);
        }
        return result;
    }

    public void operate (String operator, Number num1) {
        //Make it better! Give a better solution for operate(String, Number)
        Number result = 0;
        switch (operator) {
            case "+": {
                result = this.result.doubleValue() + num1.doubleValue();
                break;
            }
            case "-": {
                result = this.result.doubleValue() - num1.doubleValue();
                break;
            }
            case "/": {
                result = this.result.doubleValue() / num1.doubleValue();
                break;
            }
            case "*": {
                result = this.result.doubleValue() * num1.doubleValue();
                break;
            }
            case "!": {
                result = factorial(num1);
                break;
            }
            case "cos": {
                result = Math.cos(num1.doubleValue());
                break;
            }
            case "sin": {
                result = Math.sin(num1.doubleValue());
                break;
            }
            case "tan": {
                result = Math.tan(num1.doubleValue());
                break;
            }
            default: {
                result = num1;
            }
        }
        System.out.println(this.result.doubleValue() + " " + operator + " " + num1.doubleValue() + " = " + result.doubleValue());
        this.result = result;
    }

    public void operate (String operator) {
        //Complete the missing implementation
        //this.result = newValue
        switch (operator){
            case "C":
                this.result = 0;
                break;
            case "e":
                this.result = Math.E;
                break;
            default:
                break;
        }
        System.out.println("Result of " + operator + " = " + this.result.doubleValue());
    }

    public void operate (String operator, String opValue) {
        //Complete the missing implementation
        //this.result = newValue
        System.out.println(this.result.doubleValue() + " " + operator + " " + opValue + " = ?");
        switch (opValue){
            case "pi":
                operate(operator, Math.PI);
                break;
            default:
                break;
        }
    }

    public void firstValue(Number num1) {
        this.result = num1;
    }

}