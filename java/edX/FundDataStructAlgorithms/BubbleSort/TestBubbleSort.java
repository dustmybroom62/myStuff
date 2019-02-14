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
	
    public static void cocktailSort( int[] a ){
	    boolean swapped;
	    int numIter=0;
	    int numSwaps=0;
	    int numPasses=0;
	    do {
	        numPasses++;
	        swapped = false;
	        for (int i =0; i<=  a.length  - 2;i++) {
		        numIter++;
		        if (a[i] > a[i+1]){
		            numSwaps++;
		            swap(a,i,i+1);
		            swapped = true;
		        }
	        }
	        //we can exit the outer loop here if no swaps happened.
	        if (swapped) {
		        swapped = false;
		        for (int i= a.length - 2;i>=0;i--) {
		            numIter++;
		            if (a[i] > a[i+1]) {
			            numSwaps++;
			            swap(a,i,i+1);
			            swapped = true;
		            }
		        }
	        }
	        //if no elements have been swapped, then the list is sorted
	    } while (swapped);
	    System.out.println("Num Passes: "+numPasses+ " Num Iter: "+numIter
		            	   +" Num Swaps: "+numSwaps);
    }    
    
    /*Implement this method */
    public static void optimisedCocktailSort( int[] a ){
	    boolean swapped;
	    int numIter=0;
	    int numSwaps=0;
		int numPasses=0;
		int last = a.length - 2;
		int first = 0;
	    do {
	        numPasses++;
			swapped = false;
			int lastSwapPos = last;
	        for (int i = first; i<=  last;i++) {
		        numIter++;
		        if (a[i] > a[i+1]){
		            numSwaps++;
		            swap(a,i,i+1);
					swapped = true;
					lastSwapPos = i;
		        }
	        }
	        //we can exit the outer loop here if no swaps happened.
	        if (swapped) {
				last = lastSwapPos - 1;
				lastSwapPos = first;
		        swapped = false;
		        for (int i= last;i>=first;i--) {
		            numIter++;
		            if (a[i] > a[i+1]) {
			            numSwaps++;
			            swap(a,i,i+1);
						swapped = true;
						lastSwapPos = i;
		            }
				}
				first = lastSwapPos + 1;
	        }
	        //if no elements have been swapped, then the list is sorted
	    } while (swapped);
	    System.out.println("Num Passes: "+numPasses+ " Num Iter: "+numIter
		            	   +" Num Swaps: "+numSwaps);
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

	    System.out.println("**********************************************");
    	int array[] = {7,5,1,2,3,6,4};
        System.out.print("\t\t\tUnsorted Array: ");
	    print(array);
	
	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    System.out.println("Bubble Sort: ");
	    bubbleSort(array);
    	print(array);
	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    array = new int[]{7,5,1,2,3,6,4};
	    System.out.println("Cocktail Sort: ");
	    cocktailSort(array);
	    print(array);
        System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    array = new int[]{7,5,1,2,3,6,4};
	    System.out.println("Optimised Cocktail Sort: ");
	    optimisedCocktailSort(array);
	    print(array);

        System.out.println("**********************************************");
        array = new int[]{2,3,4,1,5,6,7};
        System.out.print("\t\t\tUnsorted Array: ");
	    print(array);

	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    System.out.println("Bubble Sort: ");
	    bubbleSort(array);
    	print(array);
	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
		array = new int[]{2,3,4,1,5,6,7};
	    System.out.println("Cocktail Sort: ");
	    cocktailSort(array);
	    print(array);
        System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    array = new int[]{2,3,4,1,5,6,7};
	    System.out.println("Optimised Cocktail Sort: ");
	    optimisedCocktailSort(array);
	    print(array);

        System.out.println("**********************************************");
    	array = new int[]{1,2,3,4,5,6,7};
	    System.out.print("\t\t\tUnsorted Array: ");
	    print(array);

	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    System.out.println("Bubble Sort: ");
	    bubbleSort(array);
    	print(array);
	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    array = new int[]{1,2,3,4,5,6,7};
	    System.out.println("Cocktail Sort: ");
	    cocktailSort(array);
	    print(array);
        System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
        array = new int[]{1,2,3,4,5,6,7};
        System.out.println("Optimised Cocktail Sort: ");
	    optimisedCocktailSort(array);
	    print(array);
	    
	    System.out.println("**********************************************");
    	array = new int[]{7,6,5,4,3,2,1};
	    System.out.print("\t\t\tUnsorted Array: ");
	    print(array);

	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    System.out.println("Bubble Sort: ");
	    bubbleSort(array);
    	print(array);
	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    array = new int[]{7,6,5,4,3,2,1};
	    System.out.println("Cocktail Sort: ");
	    cocktailSort(array);
	    print(array);
        System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
        array = new int[]{7,6,5,4,3,2,1};
        System.out.println("Optimised Cocktail Sort: ");
	    optimisedCocktailSort(array);
	    print(array);
	    
	    System.out.println("**********************************************");
	    array = new int[]{2,3,4,5,1};
	    System.out.print("\t\t\tUnsorted Array: ");
	    print(array);

	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    System.out.println("Bubble Sort: ");
	    bubbleSort(array);
    	print(array);
	    System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
	    array = new int[]{2,3,4,5,1};
	    System.out.println("Cocktail Sort: ");
	    cocktailSort(array);
	    print(array);
        System.out.println("+++++++++++++++++++++++++++++++++++++++++++++++");
        array = new int[]{2,3,4,5,1};
        System.out.println("Optimised Cocktail Sort: ");
	    optimisedCocktailSort(array);
	    print(array);
	
    }

/*	
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
*/	
}
