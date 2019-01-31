 /*
 * Exercise for inserting in a sorted way (lowest to highest)
 * elements within a linked list
 */
public class SortedInsertionLinkedList{

    public static void main(String args[]){
        // Create a linked list using MyLinkedList<Integer>
	    MyLinkedList<Integer> mine = new MyLinkedList<Integer>();
	   // Insert 10 ints 
	    for (int i=0; i< 10; i++){
	        mine.insert((int)(100*Math.random()));
	    }
	    
	    //Print the whole list
	    mine.print();
    }
}
