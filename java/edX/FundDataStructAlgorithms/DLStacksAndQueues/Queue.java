/**
 * Interface for a Queue.
 *
 * @author DIT-UC3M
 *
 */
public interface Queue {
    public void enqueue(Object obj);
    public Object dequeue();
    int size();
}
