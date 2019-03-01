import java.util.*;

public class FibonacciHuge {
    private static long getFibonacciHugeNaive(long n, long m) {
        if (n <= 1)
            return n;

        long previous = 0;
        long current  = 1;

        for (long i = 0; i < n - 1; ++i) {
            long tmp_previous = previous;
            previous = current;
            current = tmp_previous + current;
        }

        return current % m;
    }

    private static long get_pisano_period(long m) {
        long a = 0, b = 1, c = a + b;
        for (int i = 0; i < m * m; i++) {
            c = (a + b) % m;
            a = b;
            b = c;
            if (a == 0 && b == 1) return i + 1;
        }
        return m;
    }
    
    private static long getFibonacciHuge(long n, long m) {
        if (n <= 1) { return n; }

        long period = get_pisano_period(m);
        long remainder = n % period;

        long first = 0;
        long second = 1;
    
        long res = remainder;
    
        for (int i = 1; i < remainder; i++) {
            res = (first + second) % m;
            first = second;
            second = res;
        }
    
        return res % m;
    }
    
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        long n = scanner.nextLong();
        long m = scanner.nextLong();
        scanner.close();
        System.out.println(getFibonacciHugeNaive(n, m));
        System.out.println(getFibonacciHuge(n, m));
    }
}

