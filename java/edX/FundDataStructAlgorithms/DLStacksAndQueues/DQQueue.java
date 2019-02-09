/*
 * Class that implements a Queue with a Deque
 *  
 * @author DIT-UC3M
 *
 */
public class DQQueue implements Queue {

    private Dqueue data;
  
    public DQQueue() {
     // TODO
     data = new DLDqueue();
    }
  
    public void enqueue(Object obj) {
     // TODO
     data.insertLast(obj);
    }
  
    public Object dequeue() {
      // TODO
      return data.removeFirst();
    }
  
    public int size() {
     // TODO
     return data.size();
    }
  
    public String toString() {
     // TODO
     return data.toString();
    }
  
    public static void main(String[] args) {
      DQQueue queue = new DQQueue();
      for (int i = 0; i < 5; i++) {
        queue.enqueue(i);
      }
      System.out.println("Printing queue: " + queue);
  
      //int s = queue.size();
      System.out.println("Printing size: " + queue.size());
  
      Object o = queue.dequeue();
      System.out.println("Deque element = " + o);
  
      System.out.println("Printing queue: " + queue);
      
      DQStack stack = new DQStack();
      for (int i = 0; i < 5; i++) {
        stack.push(i);
      }
      System.out.println("Printing stack: " + stack);
  
      //int s = stack.size();
      System.out.println("Printing size: " + stack.size());
  
       o = stack.pop();
      System.out.println("Pop element = " + o);
  
      System.out.println("Printing stack: " + stack);
      
    }
  }
  