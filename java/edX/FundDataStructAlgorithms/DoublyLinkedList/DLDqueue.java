/**
 * Class that implements a Deque with a Double Linked List.
 *
 * @author DIT-UC3M
 *
 */
public class DLDqueue implements Dqueue {
    // Attributes
    private int _size;
    private DNode _top;
    private DNode _tail;
  
    public DLDqueue() {
      // TODO
      _top = new DNode();
      _tail = new DNode();
      _top.setNext(_tail);
      _tail.setPrev(_top);
      _size = 0;
    }
  
    public void insertFirst(Object obj) {
      // TODO
      DNode second = _top.getNext();
      DNode first = new DNode(obj, second, _top); //see DNode class. param 2, 3 reversed in implementation.
      second.setPrev(first);
      _top.setNext(first);
      _size++;
    }
  
    public void insertLast(Object obj) {
      // TODO
      DNode second = _tail.getPrev();
      DNode last = new DNode(obj, _tail, second); //see DNode class. param 2, 3 reversed in implementation.
      second.setNext(last);
      _tail.setPrev(last);
      _size++;
    }
  
    public Object removeFirst() {
      // TODO
      if (0 == _size) return null;
      DNode node = _top.getNext();
      _top.setNext(node.getNext());
      node.getNext().setPrev(_top);
      _size--;
      return node.getVal();
    }
  
    public Object removeLast() {
      // TODO
      if (0 == _size) return null;
      DNode node = _tail.getPrev();
      _tail.setPrev(node.getPrev());
      node.getPrev().setNext(_tail);
      _size--;
      return node.getVal();
    }
  
    public int size() {
      // TODO
      return _size;
    }
  
    public String toString() {
      // TODO
      String result = "{";
      DNode curNode = _top.getNext();
      for (int i = 0; i < _size; i++) {
          if (0 != i) { result += ", "; }
          result += curNode.getVal();
          curNode = curNode.getNext();
      }
      return result + "}";
    }
  
    public static void main(String [] args)
    {
        DLDqueue dlq = new DLDqueue();
        // dlq.insertFirst("A");
        dlq.insertLast("A");
        System.out.println( dlq.toString() );
        dlq.insertLast("B");
        // dlq.insertFirst("B");
        System.out.println( dlq.toString() );
        // dlq.insertFirst("C");
        dlq.insertLast("C");
        System.out.println( dlq.toString() );
        // dlq.insertFirst("S");
        dlq.insertLast("S");

        System.out.println( dlq.toString() );

        System.out.println( dlq.removeFirst() );

        System.out.println( dlq.toString() );

        System.out.println( dlq.removeLast() );

        System.out.println( dlq.toString() );

        dlq.insertFirst("first");
        dlq.insertLast("last");
        System.out.println( dlq.toString() );
    }
  
  }
  