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

  private static long getFibonacciLastDigitNaive(long n) {
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

private static int getFibonacciLastDigit(long n) {
    if (n <= 1)
        return (int) n;

    int previous = 0;
    int current  = 1;

    for (long i = 0; i < n - 1; ++i) {
        int tmp_previous = previous;
        previous = current;
        current = (tmp_previous + current) % 10;
    }

    return current;
}

private static int getFibonacciSumLastDigit(long n) {
    int result = (getFibonacciLastDigit(n + 2) - 1 + 10) % 10;
    return result;
}

  public static void main(String args[]) {
    Scanner in = new Scanner(System.in);
    long n = in.nextLong(); // in.nextInt();
    in.close();

    // System.out.println(calc_fib(n));
    //System.out.println(getFibonacciLastDigitNaive(n));
    System.out.println("last digit: " + getFibonacciLastDigit(n));
    System.out.println("sum last digit: " + getFibonacciSumLastDigit(n));
  }
}
