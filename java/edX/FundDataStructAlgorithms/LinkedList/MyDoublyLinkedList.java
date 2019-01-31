public class MyDoublyLinkedList<E extends Comparable<E>>{
    private Node<E> head;
    private Node<E> tail;
    
    public MyDoublyLinkedList(){
	    this.head = null;
	    this.tail = null;
    }
    
    /*
     * Insertion at the beginning
     */
    public void insert(E info){
	    Node<E> newNode = new Node<E>(info);
	    newNode.setNext(head);
	    if (head != null){
	        head.setPrev(newNode);
	    }
	    head = newNode;
	    if (tail == null){
	        tail = newNode;
	    }
    }
    /*
     * Insertion at the end 
     */
    public void insertEnd(E info){
	    Node<E> newNode = new Node<E>(info);
	    if (tail == null){
            head = newNode;
	        tail = newNode;
	    }else{
            tail.setNext(newNode);
            newNode.setPrev(tail);
	        tail = newNode;
	   }
    }
    
    /*
     * Extraction of the first node
     */
    public E extract(){
	    E data = null;
	    // Implement this method
	    if (head != null){
	        data = head.getInfo();
            head = head.getNext();
            if (null == head) {
                tail = null;
            } else {
                head.setPrev(null);
            }
	    }
	    return data;
    }
    /*
     * Extraction of the last node
     */
    public E extractEnd(){
	    E data = null;
        // Implement this method
        if (null == tail) {
            return null;
        }
        data = tail.getInfo();
        tail = tail.getPrev();
        if (null == tail) {
            head = null;
        } else {
            tail.setNext(null);
        }
	    return data;
    }
    /*
     * Delete all nodes with info equal to value
     * returns number of deleted nodes
     */
     
     public int deleteAll(E info){
         int deleted = 0;
         
         // Implement this method
         if (null == head) {return 0;}
         while (null != head && info.equals(head.getInfo())) {
             extract();
             deleted++;
         }
         Node<E> prev = head;
         while (null != prev && null != prev.getNext()) {
             Node<E> current = prev.getNext();
             if (info.equals(current.getInfo())) {
                 Node<E> next = current.getNext();
                 prev.setNext(next);
                 if (null == next) {
                     tail = prev;
                 } else {
                     next.setPrev(prev);
                 }
                 deleted++;
             } else {
                 prev = current;
             }
         }
          
         return deleted;
     }
     
    /*
     * Print all list forward
     */
    public void print(){
	    Node<E> current = head;
	    
	    while (current != null){
	        System.out.print(current.getInfo() + " ");
	        current = current.getNext();
	    }
	    System.out.println();
    }
    /*
     * Print all list backwards
     */
    public void printBackwards(){
	    Node<E> current = tail;
	    
	    while (current != null){
	        System.out.print(current.getInfo() + " ");
	        current = current.getPrev();
	    }
	    System.out.println();
    }
}
