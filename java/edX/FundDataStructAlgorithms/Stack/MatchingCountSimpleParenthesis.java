import java.util.Stack;

public class MatchingCountSimpleParenthesis {
    
    /*
     * Implement this function without using Stacks
     * Assume that you only the parenthesis ( and )
     * are present
     * If the number of parenthesis is out of balance,
     * throw an exception
     * If it is balanced, return the max depth
     */
    public static int depthSimple(String mystring) throws Exception{
        //char c;
	    int count = 0;
	    int max = 0;
    
        // Implement this method
        char[] chars = mystring.toCharArray();
        for (char var : chars) {
            switch(var) {
                case '(':
                max = Math.max(max, ++count);
                break;
                case ')':
                if (0 > --count) throw new Exception(mystring + " has no balanced parenthesis.");
                break;
            }
        }

        if (0 != count) throw new Exception(mystring + " has no balanced parenthesis.");
        
	    return max;
    }

    static void test(Stack<Integer> s1) {
        Stack<String> s2 = new Stack<String>();
        int a = 0;
        while (!s1.isEmpty()) {
          int b = s1.pop();
          if(b>a) {
            s2.push("*");
          } else if(b<a) {
            s2.push("-");
          }
          a = b;
        }  
        while (!s2.isEmpty()) {
          System.out.println(s2.pop());
        }
      }
    
    public static void main(String args[]){
	/*
	 * This main program should print:
	 * (((2+3)/6)-4)*5) has no balanced parenthesis
	 * Depth = 3
	 * ((2+3)/6)-4)*5 has no balanced parenthesis 
	 */
	    try{
	        System.out.println("Depth = "+depthSimple("(((2+3)/6)-4)*5)"));
	    }catch(Exception e){
	        System.out.println(e.getMessage());
	    }
	    try{
	        System.out.println("Depth = "+depthSimple("(((2+3)/6)-4)*5"));
	    }catch(Exception e){
	        System.out.println(e.getMessage());
	    }
    	try{
	        System.out.println("Depth = "+depthSimple("((2+3)/6)-4)*5"));
	    }catch(Exception e){
	        System.out.println(e.getMessage());
        }
        
        Stack<Integer> s = new Stack<>();
        s.push(1);
        s.push(3);
        s.push(5);
        s.push(6);
        s.push(2);
        s.push(2);
        test(s);
    }
}

