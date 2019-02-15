public class TestQuicksort{

    public enum SortOrder { 
        ASCENDING (-1), DESCENDING (1);

        private int value;
        SortOrder(int value) { this.value = value; }
        public int valueOf() { return this.value; }
    }

    /* Lomuto Partition */
    private static int partition(int[] a, int low, int high, SortOrder order){
	    int pivot = a[high];
	    int i = low;
	    for (int j=low; j<= (high -1); j++){
	        if ( order.valueOf() == Integer.compare(a[j], pivot) ){
	            System.out.print(i+" <-> "+j+": ");
		        swap(a,i,j);
		        print(a);
		        i = i + 1;
	        }
	    }
        System.out.print(i+" <-> "+high+": ");
	    swap(a,i,high);
	    print(a);
	    return i;
    }
    
    private static void quicksort(int[] a, int low, int high, SortOrder order){
	    int p;
		if ((a == null) || (a.length == 0))
	        return;
		if (low >= high)
	        return;
		if (low < high){
	        p = partition(a,low,high, order);
	        quicksort(a,low,p-1, order);
	        quicksort(a,p+1,high, order);
	    }
    }

    public static void quicksorting(int[] a){
        quicksorting(a, SortOrder.ASCENDING);
    }

    public static void quicksorting(int[] a, SortOrder order){
	    quicksort(a,0,a.length-1, order);
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

	    int array[] = {7,5,1,2,3,6,4};
        System.out.print("Unsorted Array: ");
	    print(array);
	    quicksorting(array);
	    System.out.println("Quicksort. Sorted Array: ");
	    print(array);
    	array = new int[]{1,2,3,4,5,6,7};
        System.out.print("Unsorted Array: ");
	    print(array);
	    quicksorting(array);
	    System.out.println("Quicksort. Sorted Array: ");
	    print(array);

        array = new int[]{1,1,1,1,1,1,1,1,1};
        System.out.print("Unsorted Array: ");
	    print(array);
	    quicksorting(array);
	    System.out.println("Quicksort. Sorted Array: ");
	    print(array);

	    array = new int[] {7,5,1,2,3,6,4};
        System.out.print("Unsorted Array: ");
	    print(array);
	    quicksorting(array, SortOrder.DESCENDING);
	    System.out.println("Quicksort Descending. Sorted Array: ");
	    print(array);
    	array = new int[]{7,6,5,4,3,2,1};
        System.out.print("Unsorted Array: ");
	    print(array);
	    quicksorting(array, SortOrder.DESCENDING);
	    System.out.println("Quicksort Descending. Sorted Array: ");
	    print(array);

        array = new int[]{1,1,1,1,1,1,1,1,1};
        System.out.print("Unsorted Array: ");
	    print(array);
	    quicksorting(array, SortOrder.DESCENDING);
	    System.out.println("Quicksort Descending. Sorted Array: ");
	    print(array);

    }
}
