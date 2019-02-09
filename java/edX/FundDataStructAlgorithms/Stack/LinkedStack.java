import java.util.EmptyStackException;

public class LinkedStack<E extends Comparable<E>>{
    private Node<E> top;
    private int size;

    public LinkedStack(){
	    this.top = null;
	    this.size = 0;
    }
    public int size(){
	    return this.size;
    }
    public boolean isEmpty(){
	    return (size==0);
    }
    
    public E top() throws EmptyStackException{
	    if (size==0)
	        throw new EmptyStackException();
	    return top.getElem();
    }
    public E pop() throws EmptyStackException{
	    if (top==null)
	        throw new EmptyStackException();
	    E aux;
	    aux = top.getElem();
	    top = top.getNext();
	    size--;
	    return aux;
    }
    public void push(E obj){
	    Node<E> n = new Node<E>(obj,top);
	    top = n;
	    size++;
    }
    /*
     * Implement this method
     * If the Object o is within the Stack,
     * Returns the 1-distance to the top of the position
     * where it is stored (1 -> at the top, 2 -> top -1, etc.)
     * If the object is not found at the Stack
     * It returns -1
     * Use compareTo to compare both elements instead of equals
     * Compare how the program behaves using equals or using compareTo
     * This is a possible implementation.
     */
    public int search(E o){
        int result = -1;
        Node<E> curNode = top;
        int dist = 0;
        while (null != curNode) {
            dist++;
            // if (o.equals(curNode.getElem())) { result = dist; break; }
            if (0 == o.compareTo(curNode.getElem())) { result = dist; break; }
            curNode = curNode.getNext();
        }
        return result;
    }
    public static void main(String args[]){
    
        LinkedStack<String> stack = new LinkedStack<String>();
        stack.push("A");
        stack.push("B");
        stack.push("C");
        stack.push("D");
        System.out.println(stack.size +" " +stack.top());
        System.out.println("D at 1-distance: "+stack.search("D"));
        System.out.println("B at 1-distance: "+stack.search("B"));
        System.out.println("Z at 1-distance: "+stack.search("Z"));
    }
    
}
