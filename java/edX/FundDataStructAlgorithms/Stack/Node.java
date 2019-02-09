public class Node<E>{
    private E elem;
    private Node<E> next;

    public Node(){
	    this.next = null;
    }
    public Node(E elem){
	    this.elem = elem;
	    this.next = null;
    }
    public Node(E elem, Node<E> next){
	    this.elem = elem;
	    this.next = next;
    }

    public E getElem(){
	    return this.elem;
    }
    public void setElem(E elem){
	    this.elem = elem;
    }
    public Node<E> getNext(){
	    return this.next;
    }

    public void setNext(Node<E> next){
	    this.next = next;
    }

}
