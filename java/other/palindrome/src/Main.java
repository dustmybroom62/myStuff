import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
	    // find the substring of user input that is a palindrome
        // if multiple are found select the lexicographically smallest
        System.out.print("Please enter a sequence of characters: ");
        Scanner s = new Scanner(System.in);
        String buffer = s.nextLine(); // "cbcxdx";
//        System.out.println(buffer);
//        boolean r = isPalindrome(buffer);
//        System.out.println(r);
//        r = isPalindrome("z");
//        System.out.println(r);
        int len = buffer.length();
        if (0 == len) {
            System.out.print(-1);
            return;
        }
        if (1 == len) {
            System.out.print(buffer);
            return;
        }
        String smallest = null;
        for (int i = 0; i < len; i++) {
            for (int j = i + 1; j < len; j++) {
                String candidate = buffer.substring(i, j + 1);
                if (isPalindrome(candidate)) {
                    if (null == smallest || candidate.compareTo(smallest) < 0) {
                        smallest = candidate;
                    }
                }
            }
        }
        if (null == smallest) {
            System.out.print(-1);
        } else {
            System.out.print(smallest);
        }
    }

    public static boolean isPalindrome(String s) {
        int len = s.length();
        int max = Math.floorDiv(len, 2);
        for (int i = 0; i < max; i++) {
            char c1 = s.charAt(i);
            char c2 = s.charAt(len - 1 - i);
            if (c1 != c2) {
                return false;
            }
        }
        return true;
    }
}
