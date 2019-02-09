import java.util.Stack;

public class RPNcalculator{

    /*
     * Implement a simple RPN calculator
     * with an Stack
     * this is a possible solution, others are
     * also possible
     */
    public static int calculate(String ops[]){
	    int result = 0;
	    int x,y;
	    String operators = new String("+-/*");
        // Define a Stack 
        Stack<String> stack = new Stack<>();

	    for (String op: ops){
            // Implement here your algorithm
            if (-1 < operators.indexOf(op)) {
                y = Integer.valueOf(stack.pop());
                x = Integer.valueOf(stack.pop());
                int val = 0;
                switch (op) {
                    case "+":
                        val = x + y;
                        break;
                    case "-":
                        val = x - y;
                        break;
                    case "/":
                        val = x / y;
                        break;
                    case "*":
                        val = x * y;
                        break;
                }
                stack.push(String.valueOf(val));
            } else {
                stack.push(op);
            }
	    }

        // if the stack is not empty, result= stack.pop()
        // else result = 0
        if (!stack.empty()) { result = Integer.valueOf(stack.pop()); }
	    return result;
    }
    public static void main(String args[]){
        /*
	     * The main program should print
	        5 3 + =8
            5 3 - = 2
            2 1 12 3 / - + = -1
            3 2 * 11 - = -5
	    */
	    
	    String[] argu= new String[]{"5","3","+"};
	    int result = calculate(argu);
	    System.out.println("5"+" 3"+" +"+" ="+ result);
	    result = calculate(new String[]{"5","3","-"});
	    System.out.println("5"+" 3"+" -"+" = "+ result);
    	result = calculate(new String[]{"2","1","12","3","/", "-", "+"});
	    System.out.println("2"+" 1"+" 12"+" 3"+" /"+ " -"+ " +"+" = "+ result);
	    result = calculate(new String[]{"3", "2", "*", "11", "-"});
	    System.out.println("3"+" 2"+" *"+" 11"+" -"+" = "+ result);
	     
    }
}
