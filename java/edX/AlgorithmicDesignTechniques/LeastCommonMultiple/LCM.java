import java.util.*;

public class LCM {
  private static long lcm_naive(int a, int b) {
    for (long l = 1; l <= (long) a * b; ++l)
      if (l % a == 0 && l % b == 0)
        return l;

    return (long) a * b;
  }

private static int gcd (int a, int b) {
    if (0 == b) return a;
    return gcd(b, a % b);
}

private static long lcm(int a, int b) {
    long d = gcd(a, b);
    return (a / d) * (b / d) * d;
}

  public static void main(String args[]) {
    Scanner scanner = new Scanner(System.in);
    int a = scanner.nextInt();
    int b = scanner.nextInt();
    scanner.close();

    System.out.println("lcm_naive: " + lcm_naive(a, b));
    System.out.println("lcm:       " + lcm(a, b));
  }
}
