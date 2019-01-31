/*
 * Exercise for Creation of a Linked List and printing
 */
public class CreateLinkedList{

    public static void main(String args[]){
	    // Create a linked list using MyLinkedList<Integer>
	   //??
	   MyLinkedList<Integer> lList = new MyLinkedList<>();
	   
	    // Insert the first 10 ints at the beginning
	    for (int i=0; i< 10; i++){
	        //???
	        lList.insertFirst(i);
	    }
	    //Print the whole list
	    //??
	    lList.print();
	    // Create another linked list using MyLinkedList<Integer>
	   //??
	   MyLinkedList<Integer> lList2 = new MyLinkedList<>();

	    // Insert 10 ints at the end
	    for (int i=0; i< 10; i++){
	        //???
	        lList2.insertLast(i);
	    }
	    //Print the whole second list
	    //??
	    lList2.print();
    }
}
