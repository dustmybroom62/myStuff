import java.util.Scanner;

public class Fibonacci {
//   private static long calc_fib(int n) {
//     if (n <= 1)
//       return n;

//     return calc_fib(n - 1) + calc_fib(n - 2);
//   }

  private static long calc_fib(int n) {
      long[] fibs = new long[n+1];
      for (int i = 0; i < (n+1); i++) {
          if (i < 2) {
              fibs[i] = i;
          } else {
              fibs[i] = fibs[i - 1] + fibs[i - 2];
          }
      }
      return fibs[n];
  }

  private static int getFibonacciLastDigitNaive(int n) {
    if (n <= 1)
        return n;

    int previous = 0;
    int current  = 1;

    for (int i = 0; i < n - 1; ++i) {
        int tmp_previous = previous;
        previous = current;
        current = tmp_previous + current;
    }

    return current % 10;
}

private static int getFibonacciLastDigit(int n) {
    if (n <= 1)
        return n;

    int previous = 0;
    int current  = 1;

    for (int i = 0; i < n - 1; ++i) {
        int tmp_previous = previous;
        previous = current;
        current = (tmp_previous + current) % 10;
    }

    return current;
}

  public static void main(String args[]) {
    Scanner in = new Scanner(System.in);
    int n = in.nextInt();
    in.close();

    // System.out.println(calc_fib(n));
    System.out.println(getFibonacciLastDigitNaive(n));
    System.out.println(getFibonacciLastDigit(n));
  }
}
