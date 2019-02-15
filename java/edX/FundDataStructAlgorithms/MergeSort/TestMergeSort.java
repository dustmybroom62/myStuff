public class TestMergeSort{

    public enum SortOrder { 
        ASCENDING (-1), DESCENDING (1);

        private int value;
        SortOrder(int value) { this.value = value; }
        public int valueOf() { return this.value; }
    }

    public static void mergeSort(int[] a, SortOrder order){
    	int n=a.length;
	    int[] b=new int[n];
	    msort(a, 0, n-1, b, order);
    }

    public static void mergeSort(int[] a){
        mergeSort(a, SortOrder.ASCENDING);
    }    
    private static void msort(int[] a, int lo, int hi, int[] b, SortOrder order){
	    int mid;
	    System.out.print("Calling msort ("+lo+", "+hi+") array= ");
	    printPiece(a,lo,hi);
	    if (lo<hi){
	        mid=(lo+hi)/2;
	        msort(a, lo, mid, b, order);
	        System.out.print("\t\tMsort ("+lo+" ,"+mid+") array= ");
	        printPiece(a,lo,mid);
	        msort(a, mid+1, hi, b, order);
	        System.out.print("\t\tMsort ("+(mid+1)+" ,"+hi+") array= ");
	        printPiece(a,mid+1,hi);
	        merge(a, lo, mid, hi, b, order);
	    }
	    System.out.print("Result msort ("+lo+" ,"+hi+") array= ");
	    printPiece(a,lo,hi);
    }
    
    private static void merge(int[] a, int lo, int mid, int hi, int[] b, SortOrder order){
	    int i,j,k;
	    i=lo;
	    j=mid+1;
	    k=lo;
	    while ((i<=mid) && (j<=hi)){
	        if ( order.valueOf() == Integer.compare(a[i], a[j]) ){
		        b[k] = a[i];
		        i++;
	        }else {
		        b[k]=a[j]; 
		        j++;
	        }
	        k++;
	    }
	    while (i<=mid) {b[k]=a[i]; i++; k++;}
	    while (j<=hi)  {b[k]=a[j]; j++; k++;}
	    for (k=lo; k<=hi; k++) {a[k]=b[k];}
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

    public static void main(String args[]){

	int array[] = {7,5,1,2,3,6,4};
	    System.out.print("Unsorted Array: ");
	    print(array);
	    mergeSort(array);
	    System.out.println("Merge Sort. Sorted Array: ");
	    print(array);

        array = new int[] {7,5,1,2,3,6,4};
	    System.out.print("Unsorted Array: ");
	    print(array);
	    mergeSort(array, SortOrder.DESCENDING);
	    System.out.println("Merge Sort Descending. Sorted Array: ");
	    print(array);
    }
}
