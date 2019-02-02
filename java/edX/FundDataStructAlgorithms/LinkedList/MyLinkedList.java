public class MyLinkedList<E extends Comparable<E>> {
    private Node<E> head;
    private Node<E> tail;
    
    public MyLinkedList(){
	    this.head = null;
	    this.tail = null;
    }
    
    /*
     * Insertion at the beginning
     */
    public void insertFirst(E info){
	    Node<E> newNode = new Node<E>(info);
	    newNode.setNext(head);
	    head = newNode;
	    if (tail == null){
	        tail = newNode;
	    }
    }

    /* Insertion sorted ascending */
    public void insert(E info) {
        if (null == head) {
            insertFirst(info);
            return;
        }
        if (info.compareTo(head.getInfo()) < 0) {
            insertFirst(info);
            return;
        }
        Node<E> newNode = new Node<E>(info);
        Node<E> prev = head;
        while (null != prev.getNext()) {
            Node<E> current = prev.getNext();
            if (info.compareTo(current.getInfo()) < 0) {
                newNode.setNext(current);
                prev.setNext(newNode);
                return;
            }
            prev = current;
        }
        prev.setNext(newNode);
        tail = newNode;
    }

    /*
     * Insertion at the end 
     * Implement this method
     */
    public void insertLast(E info){
        if (null == head) {
            insertFirst(info);
            return;
        }
        Node<E> newNode = new Node<E>(info);
        tail.setNext(newNode);
        tail = newNode;
        // before tail
	    // Node<E> current = head;
	    // while (null != current.getNext()) {
	    //     current = current.getNext();
	    // }
	    // current.setNext(newNode);
    }
    /*
     * Delete the first occurrence of a value 
     * Return a boolean stating if the delete was successful
     */
    public boolean deleteFirstOccurrence(E info){
        boolean success = false;
        // Implement this Method
        if (null == head) {return false;}
        if (info.equals(head.getInfo())) {
            extractFirst();
            return true;
        }
        Node<E> prev = head;
        while (null != prev.getNext()) {
            Node<E> current = prev.getNext();
            if (info.equals(current.getInfo())) {
                prev.setNext(current.getNext());
                return true;
            }
            prev = current;
        }
        return success;
    }
    /*
     * Delete all the occurrences of a value
     * Returns the number of deleted nodes
     * You can use deleteFirstOccurrence
     */
     public int deleteAll(E info){
         int number = 0;
        // Implement this method
        if (null == head) {return 0;}
        while (null != head && info.equals(head.getInfo())) {
            extractFirst();
            number++;
        }
        Node<E> prev = head;
        while (null != prev.getNext()) {
            Node<E> current = prev.getNext();
            if (info.equals(current.getInfo())) {
                prev.setNext(current.getNext());
                number++;
            } else {
                prev = current;
            }
        }
        
        return number;
    }    
    /*
     * Extraction of the first node
     */
    public E extractFirst(){
	    E data = null;
	    if (head != null){
	        data = head.getInfo();
            head = head.getNext();
            if (null == head) {
                tail = null;
            }
	    }
	    return data;
    }

    /*
     * Extraction of the last node
     * Implement this method
     */
    public E extractLast(){
	    E data = null;
        //Implement this method
        if (null == tail) {
            return null;
        }
        data = tail.getInfo();
        if (head == tail) {
            head = null;
            tail = null;
        } else {
            Node<E> prev = head;
            while (prev.getNext() != tail) {
                prev = prev.getNext();
            }
            prev.setNext(null);
            tail = prev;
        }
	    return data;
    }

    /*
     * Print all list
     */
    public void print(){
	    Node<E> current = head;
	    
	    while (current != null){
	        System.out.print(current.getInfo() + " ");
	        current = current.getNext();
	    }
	    System.out.println();
    }
}
