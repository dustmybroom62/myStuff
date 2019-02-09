/**
 * Universidad Carlos III de Madrid
 * Departamento de Ingenieria Telematica.
 * Int queue
 * 2017
 */

/**
 * Int Queue
 */
public class Queue {

    /** Max num elements */
    private int numElements;

    /** Array to save elements **/
    private int elements[];

    /** Indice to last element */
    private int last;

    /** Constructor to init the state object */
    Queue(int numElements) {
        // todo
        this.numElements = numElements;
        this.elements = new int[numElements];
        this.last = -1;
    }

    /** Is empty the queue? */
    public boolean isEmpty() {
        // todo
        return this.last < 0;
    }

    /** Is full the queue */
    public boolean isFull() {
        // todo
        return !(this.last < this.numElements - 1);
    }

    /**
     * Insert an element in the queue
     * 
     * @throws Exception
     */
    public void enqueue(int element) throws Exception {
        // todo
        if (isFull())
            throw new Exception("Queue is full");
        this.elements[++last] = element;
    }

    /**
     * Extract the element in the queue. There isn't control error
     * 
     * @throws Exception
     */
    public int dequeue() throws Exception {
        // todo
        if (isEmpty())
            throw new Exception("Queue is empty");
        int element = this.elements[0];
        for (int i = 0; i < last; i++) {
            this.elements[i] = this.elements[i + 1];
        }
        last--;
        return element;
    }

    /** Returns the number of elements in the queue */
    public int numElements() {
        // todo
        return this.last + 1;
    }

    /** Print the elements in the queue */
    public void print() {
        // todo to test the class
        System.out.print("{");
        for (int i = 0; i < last + 1; i++) {
            if (i > 0)
                System.out.print(", ");
            System.out.print(this.elements[i]);
        }
        System.out.println("}");
    }

    public static void main(String args[]) throws Exception {
     // Five elements maximun in the queue
     NaturalQueue queue = new NaturalQueue(5);

     System.out.println("Is empty?: " + queue.isEmpty());
     queue.enqueue(-1);
     queue.enqueue(2);
     queue.enqueue(3);
     queue.enqueue(4);
     queue.enqueue(5);
     System.out.println("Is full?: " + queue.isFull());

     System.out.println("Elemento: " + queue.dequeue());
     System.out.println("Elemento: " + queue.dequeue());
     System.out.println("Elemento: " + queue.dequeue());
     System.out.println("Elemento: " + queue.dequeue());
     System.out.println("Elemento: " + queue.dequeue());

     System.out.println("Is empty?: " + queue.isEmpty());

/*        
        // test the class
        System.out.println("Test the queue class");
        Queue queue = new Queue(10);
        for (int i = 0; i < 10; i++) {
            try {
                queue.enqueue(i + 10);
            } catch (Exception e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        System.out.println("Queue has " + queue.numElements() + " elements.");
        queue.print();
        int[] temp = new int[4];
        for (int i = 0; i < 4; i++) {
            try {
                int x = queue.dequeue();
                System.out.println("dequeue: " + x);
                temp[i] = x;
            } catch (Exception e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        System.out.println("Queue has " + queue.numElements() + " elements.");
        queue.print();
        for (int i = 0; i < temp.length; i++) {
            try {
                queue.enqueue(temp[i]);
            } catch (Exception e) {
                // TODO Auto-generated catch block
                e.printStackTrace();
            }
        }
        System.out.println("Queue has " + queue.numElements() + " elements.");
        queue.print();
*/
    } // main

} // Queue

// Implements the necessary class
class NaturalQueue extends Queue {
    public NaturalQueue(int capacity) {
        super(capacity);
    }
    public void enqueue(int element) throws Exception {
        if (0 > element) return;
        super.enqueue(element);
    }
}

