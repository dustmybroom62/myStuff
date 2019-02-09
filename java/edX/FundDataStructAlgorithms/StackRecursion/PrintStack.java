public class PrintStack{

    /** Recursive algorithm to print a Stack */
    private static void print(LinkedStack<Integer> p)
    {
      // TODO 
      if (0 == p.size()) return;
      Integer e = p.pop();
      print(p);
      System.out.println(e);
      p.push(e);
    } // print
  
  
    public static void main(String [] args)
    {
      LinkedStack<Integer> p = new LinkedStack<Integer>();
  
      p.push(1);
      p.push(2);
      p.push(3);
      p.push(4);
      p.push(5);
  
      System.out.println("Stacks elements:");
      print(p);
  
      System.out.println("Stacks elements again:");
      print(p);

    } // main
  
      
  }
