public class LinkedQueue<E> implements Queue<E> {
    // Attributes
    private int _size;
    private Node<E> head;
    private Node<E> tail;
    
    public LinkedQueue() {
        // TODO
        _size = 0;
        head = null;
        tail = null;
    }

    public boolean isEmpty() {
        // TODO
        return 0 == _size;
    }

    public int size() {
        // TODO
        return _size;
    }

    public E front() {
        // TODO
        return null == head ? null : head.getInfo();
    }

    public void enqueue(E info) {
        // TODO
        Node<E> n = new Node<E>(info, null);
        if (null == head) {
            head = n;
        }
        if (null != tail) {
            tail.setNext(n);
        }
        tail = n;
        _size++;
    }

    public E dequeue() {
        // TODO
        if (null == head) {
            return null;
        }
        E result = head.getInfo();
        head = head.getNext();
        if (null == head) {
            tail = null;
        }
        _size--;
        return result;
    }

    public static void main(String[] args) {

        LinkedQueue<Integer> q = new LinkedQueue<Integer>();

        q.enqueue(1);
        q.enqueue(2);
        q.enqueue(3);
        q.enqueue(4);
        q.enqueue(5);

        System.out.println("Size: " + q.size());

        Integer e = q.front();
        System.out.println("Size: " + q.size());
        System.out.println(e);

        e = q.dequeue();
        e = q.dequeue();
        System.out.println("Size: " + q.size());

        e = q.dequeue();
        e = q.dequeue();
        e = q.dequeue();
        System.out.println("Size: " + q.size() + " isEmpty: " + q.isEmpty());

    }
}
