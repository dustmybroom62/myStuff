public class Palindrome{
    
    public static boolean isPalindrome(String item) {
        LinkedStack<Character> stack = new LinkedStack<>();
        for (Character c: item.toCharArray()) stack.push(c);
        String rev = "";
        for (int i=0; i<item.length(); i++) rev += stack.pop();
        return rev.equals(item);
    }
    
    public static void main(String [] args)
    {
       // TODO
       String test1 = "abcdcbe";
       System.out.println("'" + test1 + "' is" + (isPalindrome(test1) ? "" : " not") + " a palindrome");

       String test2 = "abcdcba";
       System.out.println("'" + test2 + "' is" + (isPalindrome(test2) ? "" : " not") + " a palindrome");
    }
}
