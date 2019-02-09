/**
 * Interface for a Deque.
 *
 * @author DIT-UC3M
 *
 */
public interface Dqueue {
    void insertFirst(Object obj);
    void insertLast(Object obj);
    Object removeFirst();
    Object removeLast();
    int size();
  }
  