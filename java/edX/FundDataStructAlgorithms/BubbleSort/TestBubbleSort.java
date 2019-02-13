public class TestBubbleSort{
    /* This is a possible solution for the exercise */
    public static void bubbleSortRecursive(int[] a){
        bubbleSortRec(a,a.length);
    }
        
    public static void bubbleSortRec(int[] a, int n){
	   if (1 == n) return;
	   bubbleSortRec(a, n-1);
		System.out.println("Outer: "+n);
		int big = a[n-1];
	   for (int i = 0; i < n; i++) {
			System.out.println("\tInner: "+i);
			if (a[i] > big) {
			   a[n-1] = a[i];
			   a[i] = big;
			   big = a[n-1];
				System.out.print("\t\t[ "+(n-1)+"<->"+i+" ]: ");
				print(a);
				}
	   }
    }
    
    /* This is the algorithm from the video */
    /* 
       You should use a variable swapped to
       finish the algorithm when no swapping are done within 
       the inner loop
    */
    public static void bubbleSort(int[] a){
	    int n=a.length;
	    int num_iter=0;
	    int nSwaps=0;
	    for(int i=0; i<n; i++){
			// System.out.println("Outer: "+i);
			boolean bSwap = false;
	        for(int j=1; j<(n-i); j++){
	            num_iter++;
	            // System.out.println("\tInner: "+j);
		        if(a[j-1]>a[j]){
					bSwap = true;
		            nSwaps++;
		            swap(a,j-1,j);
		            // System.out.print("\t\t[ "+(j-1)+"<->"+j+" ]: ");
		            // print(a);
		        }
			}
			if (!bSwap) break;
	    }
	    System.out.println("Num iterations: "+num_iter+", Num Swaps: "+nSwaps);
    }
	
    /* Implement this algorithm */
    public static void bubbleSortMoreOptimized(int[] a){
	    int n=a.length;
	    int num_iter=0;
	    int nSwaps=0;
	    for(int i=0; i<n; i++){
			// System.out.println("Outer: "+i);
			int lastSwapPos = -1;
	        for(int j=1; j<(n); j++){
	            num_iter++;
	            // System.out.println("\tInner: "+j);
		        if(a[j-1]>a[j]){
		            nSwaps++;
					swap(a,j-1,j);
					lastSwapPos = j;
		            // System.out.print("\t\t[ "+(j-1)+"<->"+j+" ]: ");
		            // print(a);
		        }
			}
			if (0 > lastSwapPos) break;
			n = 1 + lastSwapPos;
	    }
	    System.out.println("Num iterations: "+num_iter+", Num Swaps: "+nSwaps);
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
    
    public static void main(String args[]){

        System.out.println("******************************************");
        System.out.println("******************************************");
	    int array[] = {7,5,1,2,3,6,4};
	    System.out.print("Unsorted Array: ");
	    print(array);
		
		// bubbleSort(array);
		// bubbleSortMoreOptimized(array);
		bubbleSortRecursive(array);
	    System.out.print("Final Output Bubble Sort: ");
	    print(array);
        System.out.println("******************************************");
        System.out.println("******************************************");
	    array = new int[]{2,3,4,1,5,6,7};
	    System.out.print("Unsorted Array: ");
	    print(array);
	    
		// bubbleSort(array);
		// bubbleSortMoreOptimized(array);
		bubbleSortRecursive(array);
	    System.out.print("Final Output Bubble Sort: ");
	    print(array);
       
	    System.out.println("******************************************");
        System.out.println("******************************************");
	    array = new int[]{1,2,3,4,5,6,7};
	    System.out.print("Unsorted Array: ");
	    print(array);
	    
		// bubbleSort(array);
		// bubbleSortMoreOptimized(array);
		bubbleSortRecursive(array);
	    System.out.print("Final Output Bubble Sort: ");
	    print(array);
        
    }
}
