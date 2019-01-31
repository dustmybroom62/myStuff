/*
 * Exercise for Linked List with Head and Tail
 */
public class LinkedListHeadTail{

    public static void main(String args[]){
        // Create a linked list using MyLinkedList<Integer>
	    MyLinkedList<Integer> mine = new MyLinkedList<Integer>();
	   
	    System.out.println("Inserting at beginning");
	    // Insert the first 10 ints at the beginning
	    for (int i=0; i< 10; i++){
	        mine.insertFirst(i);
	    }
	    //Print the whole list
	    mine.print();
	    
	    System.out.println("Extracting from beginning");
	    //Extract all the elements from the list from the beginning
        Integer bar;
        while( (bar=mine.extractFirst()) != null){
            System.out.print(bar + " ");
        }	    
        System.out.println();
        System.out.println("Inserting at the end");
	    // Insert 10 ints at the end
	    for (int i=0; i< 10; i++){
	        mine.insertLast(i);
	    }
	    //Print the whole second list
	    mine.print();
        System.out.println("Extracting from the end");
        
        //Extract all the elements from the list from the end
        
        while( (bar=mine.extractLast()) != null){
            System.out.print(bar + " ");
        }
        
    }
}
