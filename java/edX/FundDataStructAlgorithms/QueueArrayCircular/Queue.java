/**
 * Universidad Carlos III de Madrid
 * Departamento de Ingenieria Telematica.
 * Int circular queue
 * 2017
 */


/**
  * Int Queue
  */
  public class Queue{

    /** Number of element in the queue */
    private int numElements;
    private int capacity;

    /** Array to save elements **/
    private int elements[];

    /** Indice to last element */
    private int head;
    private int tail;

    // Add one position and calculates if we must return the first position array.
    // Module opertion (%) is very important for this.
    private int next(int pos){
        return (pos+1) % (capacity+1);
    }


    /** Constructor to init the state object */
    Queue(int capacity){
        numElements = 0;
        this.capacity = capacity;
        // We must create the array with an extra element to control the conditions empty and full
        elements = new int [capacity+1];
        tail = 0;
        head = 0;
    }

    /** Is empty the queue? */
    public boolean isEmpty(){
        // todo
        return 0 == numElements;
    }

    /** Is full the queue */
    public boolean isFull(){
        // todo
        return numElements >= capacity;
    }

    /** Insert an element in the queue */
    public void enqueue(int element){
        // todo
        if (0 != numElements++) {
            tail = next(tail);
        }
        elements[tail] = element;
    }

    /** Extract the element in the queue.
     *  There isn't control error */
    public int dequeue(){
        // todo
        int element = elements[head];
        if (0 != --numElements) {
            head = next(head);
        }
        return element;
    }

    /** Returns the number of elements in the queue */
    public int numElements(){
        return numElements;
    }

    /** Print the elements in the queue*/
    public void print(){

        System.out.println("Head: " + head + " Tail: " + tail + " Number Elements: " + this.numElements);
        // from head to tail
        if (0 == this.numElements) {return;}
        int start = head;
        int end = tail < head ? tail + capacity + 1 : tail;
        int i = start;
        while (start <= end)
        {
            System.out.println(elements[i] + "-");
            i = next(start++);
        }
        System.out.println();
    }

   public static void main(String args[]){
     // Five elements maximun in the queue
     Queue queue = new Queue(5);

     System.out.println("Is empty?: " + queue.isEmpty());
     queue.enqueue(1);
     queue.enqueue(2);
     queue.enqueue(3);
     queue.enqueue(4);
     queue.enqueue(5);
     System.out.println("Is full?: " + queue.isFull());

     int e;

     e = queue.dequeue();
     e = queue.dequeue();

     queue.print();

     e = queue.dequeue();
     e = queue.dequeue();

     queue.print();

     e = queue.dequeue();

     queue.print();

     queue.enqueue(1);

     queue.print();

     queue.enqueue(2);
     queue.enqueue(3);
     queue.enqueue(4);
     queue.enqueue(5);

     queue.print();

     System.out.println("Is empty?: " + queue.isEmpty());
     System.out.println("Is full?: " + queue.isFull());

     queue.dequeue();
     queue.dequeue();

     queue.print();

   } // main

} // Queue