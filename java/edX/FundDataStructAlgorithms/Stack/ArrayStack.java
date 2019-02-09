import java.util.EmptyStackException;
public class ArrayStack{
    
    public static final int DEFAULT_CAPACITY=1000;
    private int capacity;
    private Object data[];
    private int top=-1;
    
    public ArrayStack(int capacity) {
	    this.capacity=capacity;
	    data=new Object[capacity];
    }

    public ArrayStack() {
	    this(DEFAULT_CAPACITY);
    }
    
    public boolean isEmpty(){
	    return (top<0);
    }

    public int size(){
	    return (top+1);
    }

    public Object top() throws EmptyStackException{
	    if (isEmpty())
	        throw new EmptyStackException();
	    return data[top];
    }

    public Object pop() throws EmptyStackException{
	    if (isEmpty())
	        throw new EmptyStackException();
	    Object o = data[top];
	    top--;
	    return o; 
    }

    public void push(Object o) throws StackOverflowException{
	    if (size() == capacity)
	        throw new StackOverflowException("Stack Overflow");
	    data[++top]=o;
    }

    /*
     * Implement this method
     * If the Object o is within the Stack,
     * Returns the 1-distance to the top of the position
     * where it is stored (1 -> at the top, 2 -> top -1, etc.)
     * If the object is not found at the Stack
     * It returns -1
     * Use equals to compare both objects
     */
    public int search(Object o){
        for (int i = 0; i < top + 1; i++) {
            if (o.equals(data[i])) {
                return top - i + 1;
            }
        }

	    return -1;
    }
    
    public static void main(String[] args){

        /* The program should print:
	    Stack Overflow
        -1
         1
         10
	    */	
	    ArrayStack mine = new ArrayStack(10);
	    for (int i =0; i < 11; i++){
	        try{
		        mine.push(i);
	        }catch(Exception e){
		        System.out.println(e.getMessage());
	        }
    	}
        
	    System.out.println(mine.search(10));
	    System.out.println(mine.search(9));
	    System.out.println(mine.search(0));
    }
}
