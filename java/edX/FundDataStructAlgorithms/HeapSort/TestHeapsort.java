public class TestHeapsort{

    public enum SortOrder { 
        ASCENDING (-1), DESCENDING (1);

        private int value;
        SortOrder(int value) { this.value = value; }
        public int valueOf() { return this.value; }
    }

    private static void swap(int a[], int pos1, int pos2){
	    int tmp = a[pos1];
	    a[pos1] = a[pos2];
	    a[pos2] = tmp;
    }
    
    private static void print(int a[]){
	    for (int i=0; i < a.length; i++){
	        System.out.print(a[i]+" ");
	    }
	    System.out.println();
    }

    private static void printPiece(int a[], int lo, int hi){
	    for (int i=lo; i <= hi; i++){
	        System.out.print(a[i]+" ");
	    }
	    System.out.println();
    }

    private static void printHeap(int a[], int start, int end){
	
	    StringBuilder sb = new StringBuilder();
	   	int size = end - start+1;
	    int maxblank =0 ;
    	maxblank = (int) (Math.log(size) / Math.log(2));
	    
	    sb.append(" ");
	    
    	for(int i=0;i<=maxblank;i++){
	        for(int j=0;(j<Math.pow(2,i))&&(j+Math.pow(2,i)<=size);j++){
		        for(int k=0;(k<maxblank/((int)Math.pow(2, i)));k++){
		            sb.append(" ");
		        }
		        sb.append(a[j+(int)Math.pow(2,i)-1]+" ");
	        }
	        sb.append("\n");
	    }
	    System.out.println(sb.toString());
    }
        
    public static void heapsort(int[] a, SortOrder order){
	    int count = a.length;
	
	    System.out.println("\tInitial Heap from: 0 to "+(count-1));
	    printHeap(a,0,(count-1));
	    heapify(a, count, order);
	    

 	    int end = count - 1;
	
	    while(end > 0){
	        System.out.println("\tHeap from: 0 to "+end+" Max-heap order:");
	        System.out.print("Array: ");
	        printPiece(a,0,end);
	        System.out.println("Heap Representation: ");
	        printHeap(a,0,end);
	        swap(a,0,end);
	        System.out.println("\t\tSwapped max value with last element of the heap: ");
	        printHeap(a,0,end);
	        
	        System.out.print("Sorted: ["+end+", "+(count-1)+"] :");
	        printPiece(a, end, count-1);
	    
	        siftDown(a, 0, end - 1, order);
	        end--;
	    }
    }

    public static void heapsort(int[] a) {
        heapsort(a, SortOrder.ASCENDING);
    }
 
    public static void heapify(int[] a, int count, SortOrder order){
	    int start = (count - 2) / 2; //it is a binary heap
     	while(start >= 0){
	        //sift down the node at index start to the proper place
	        //such that all nodes below the start index are in max-heap
	        //order
	        siftDown(a, start, count - 1, order);
	        start--;
	    }
	    //after sifting down the root all nodes/elements are in heap order
    }
 
    public static void siftDown(int[] a, int start, int end, SortOrder order){
	    //end represents the limit of how far down the heap to sift
	    int root = start;
	    while((root * 2 + 1) <= end){   
	        int child = root * 2 + 1; // left child
	        //if the child has a sibling and the child's value is less than 
	        //its sibling's...
	        if( child + 1 <= end && order.valueOf() == Integer.compare(a[child], a[child + 1]) ) // parameterized version
	        // if(child + 1 <= end && a[child] < a[child + 1]) // max-heap version
		        child = child + 1; //right child
	            if( order.valueOf() == Integer.compare(a[root], a[child]) ){     //out of parameterized order
                    // if(a[root] < a[child]){     //out of max-heap order
		            swap(a,root,child);
		            //repeat to continue sifting down the child now
		            root = child;                
	            }else
		            return;
	    }
    }

    public static void main(String args[]){

	    int array[] = {7,5,1,2,3,6,4};
        System.out.print("Unsorted Array: ");
	    print(array);
	    heapsort(array);
	    System.out.println("Heapsort. Sorted Array: ");
	    print(array);

        if (true) return;

	    array = new int[] {7,5,1,2,3,6,4};
        System.out.print("Unsorted Array: ");
	    print(array);
	    heapsort(array, SortOrder.DESCENDING);
	    System.out.println("Heapsort. Sorted Array (DESC): ");
	    print(array);
    }
}
