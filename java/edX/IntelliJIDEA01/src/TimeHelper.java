import java.time.Duration;
import java.time.Instant;

public class TimeHelper {
    long totalSeconds = 0;

    public TimeHelper (long numSeconds) {
        totalSeconds = numSeconds;
    }

    public long inMinutes() {
        return totalSeconds / 60;
    }

    public long inHours() {
        return totalSeconds / 3600;
    }

    private String plural(long n) {
        return 1 == n ? "" : "s";
    }

    @Override
    public String toString() {
        long h = inHours();
        long m = totalSeconds / 60 % 60;
        long s = totalSeconds % 60;
        return String.format("%d hour%s %d minute%s %d second%s"
        , h, plural(h)
        , m, plural(m)
        , s, plural(s));
    }
}
