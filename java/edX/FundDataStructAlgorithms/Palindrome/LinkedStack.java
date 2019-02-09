public class LinkedStack<E> implements Stack<E> {
    private Node<E> top;
    private int size;

    public LinkedStack() {
        top = null;
        size = 0;
    }

    public boolean isEmpty() {
        return top == null;
    }

    public int size() {
        return size;
    }

    public E top() {
        E info;
        if (isEmpty()){
            info = null;
        } else {
            info = top.getInfo();
        }
        return info;
    }

    public void push(E info){
        Node<E> n = new Node<E>(info, top);
        top = n;
        size++;
    }

    public E pop() {
        E info;
        if (!isEmpty()){
            info = top.getInfo();
            top = top.getNext();
            size--;
        } else {
            info = null;
        }
        return info;
    }
}
