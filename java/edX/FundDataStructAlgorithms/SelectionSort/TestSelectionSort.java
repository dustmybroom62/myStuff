public class TestSelectionSort{
    public static void selectionSort(int a[]){
	    int n=a.length;
	    int numSwaps = 0;
	    for (int i=0; i<(n-1); i++){ 
	        int m=0;
	        numSwaps++;
	        System.out.println(numSwaps + ": storing the bigger at "+(n-i-1));
	        System.out.println("\t\t\tLooking for the bigger one from 0 to "
			                    +(n-i-2));
	        System.out.println("\t\t\t\tThe bigger is a["+m+"] = "+a[m]);
	        for (int j=1; j<(n-i); j++){
		        if (a[j]>a[m]){
		            m=j;
		            System.out.println("\t\t\t\tThe bigger is a["+m+"] = "+a[m]);
		        }
	        }
	        swap(a,n-1-i,m);
	        System.out.print("\t\t\tSwap "+ numSwaps + "("+(n-1-i)+ "<->"+m+")"
	                            +": ");
	        print(a);
	    }
    }
    /* 
     Implement this method placing the smallest one at the selected position
     instead of the biggest one (as in the previous method) */
    public static void selectionSortDescendingOrder(int a[]){
	    int n=a.length;
	    int numSwaps = 0;
	    for (int i=0; i<(n-1); i++){ 
	        int m=0;
	        numSwaps++;
	        System.out.println(numSwaps + ": storing the smaller at "+(n-i-1));
	        System.out.println("\t\t\tLooking for the smaller one from 0 to "
			                    +(n-i-2));
	        System.out.println("\t\t\t\tThe smaller is a["+m+"] = "+a[m]);
	        for (int j=1; j<(n-i); j++){
		        if (a[j]<a[m]){
		            m=j;
		            System.out.println("\t\t\t\tThe smaller is a["+m+"] = "+a[m]);
		        }
	        }
	        swap(a,n-1-i,m);
	        System.out.print("\t\t\tSwap "+ numSwaps + "("+(n-1-i)+ "<->"+m+")"
	                            +": ");
	        print(a);
	    }
    }

    /* 
     Implement this method selecting the smallest one and placing it at the left*/
     public static void selectionSortAlternativeVersion(int a[]){
	    int n=a.length;
	    int numSwaps = 0;
	    for (int i=0; i<(n-1); i++){ 
	        int m=i;
	        numSwaps++;
	        System.out.println(numSwaps + ": storing the smaller at "+(i));
	        System.out.println("\t\t\tLooking for the smaller one from " + (i) + " to "
			                    +(n-1));
	        System.out.println("\t\t\t\tThe smaller is a["+m+"] = "+a[m]);
	        for (int j=i+1; j<(n); j++){
		        if (a[j]<a[m]){
		            m=j;
		            System.out.println("\t\t\t\tThe smaller is a["+m+"] = "+a[m]);
		        }
	        }
	        swap(a,i,m);
	        System.out.print("\t\t\tSwap "+ numSwaps + "("+(i)+ "<->"+m+")"
	                            +": ");
	        print(a);
	    }
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
	    selectionSort(array);
	    System.out.print("Final Output SelectionSort: ");
	    print(array);
        /* Comment out the following lines to test your code */
	    System.out.println("---------------------------------------");

        array = new int[]{7,5,1,2,3,6,4};
	    System.out.print("Unsorted Array: ");
	    print(array);
	    selectionSortDescendingOrder(array);
	    System.out.print("Final Output SelectionSortDescending: ");
	    print(array);

        /* Comment out the following lines to test your code */
	    array = new int[]{7,5,1,2,3,6,4};
	    System.out.print("Unsorted Array: ");
	    print(array);
	    selectionSortAlternativeVersion(array);
	    System.out.print("Final Output Alternative SelectionSort: ");
	    print(array);

    }
}
