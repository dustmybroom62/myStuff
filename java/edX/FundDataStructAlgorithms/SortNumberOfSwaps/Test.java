public class Test{

    public static int bubbleSort(int[] a){
        int nSwaps=0;
    	int n=a.length;
	    for(int i=0; i<n; i++){
	        for(int j=1; j<(n-i); j++){
		        if(a[j-1]>a[j]){
		            nSwaps++;
		            swap(a,j-1,j);
		        }
	        }
	    }
	    return nSwaps;
    }

    public static int selectionSort(int a[]){
	    int n=a.length;
	    int nSwaps=0;
	    for (int i=0; i<(n-1); i++){ 
	        int m=0;
	        for (int j=1; j<(n-i); j++){
		        if (a[j]>a[m]){
		            m=j;
		        }
	        }
	        nSwaps++;
	        swap(a,n-1-i,m);
	    }
	    return nSwaps;
    }

    public static int insertionSort(int[] a){
        int nSwaps=0;
	    for (int i=1; i<a.length; i++){
	        int tmp=a[i];
	        int j=i;
	        while ((j>0) && (tmp<a[j-1])){
	            nSwaps++;
		        a[j]=a[j-1];
		        j--;
	        } 
	        a[j]=tmp;
	    }
	    return nSwaps;
    }
    private static void swap(int a[], int pos1, int pos2){
	    int tmp = a[pos1];
	    a[pos1] = a[pos2];
	    a[pos2] = tmp;
    }

    public static void main(String[] args) {
        

        long startTime, endTime; 
        int swapsBubble, swapsSelection, swapsInsertion;

        int lengths[] = {10,20,50,100,200,1000,5000,10000,20000,30000};
        System.out.println("Random Array");
        System.out.format("%10s %20s %20s %20s\n","Number", "Swaps Bubble", "Swaps Selection", "Swaps Insertion");
    
        for (int num:lengths){
    
	        int array1[] = new int[num];
	        int array2[] = new int[num];
	        int array3[] = new int[num];
	
	        for(int i=0; i<array1.length; i++) {
	            array1[i] = (int) ((Math.random() +1.0)*num);
	        }
	
	        System.arraycopy(array1,0,array2, 0,array1.length);
	        System.arraycopy(array1,0,array3, 0,array1.length);
	
	        swapsBubble=bubbleSort(array1);
	        
	        swapsSelection=selectionSort(array2);
	        
	        swapsInsertion=insertionSort(array3);
	        
	        System.out.format("%10d %20d %20d %20d\n",num, swapsBubble, 
	                            swapsSelection,swapsInsertion);
        }

        System.out.println("Sorted Array");
        System.out.format("%10s %20s %20s %20s\n","Number", "Swaps Bubble", "Swaps Selection", "Swaps Insertion");
    
        for (int num:lengths){
    
	        int array1[] = new int[num];
	        int array2[] = new int[num];
	        int array3[] = new int[num];
	
	        for(int i=0; i<array1.length; i++) {
	            array1[i] = i;
	        }
	
	        System.arraycopy(array1,0,array2, 0,array1.length);
	        System.arraycopy(array1,0,array3, 0,array1.length);
	
	        swapsBubble=bubbleSort(array1);
	        
	        swapsSelection=selectionSort(array2);
	        
	        swapsInsertion=insertionSort(array3);
	        
	        System.out.format("%10d %20d %20d %20d\n",num, swapsBubble, 
	                            swapsSelection,swapsInsertion);
        }
        
        System.out.println("Inverse Sorted Array");
        System.out.format("%10s %20s %20s %20s\n","Number", "Swaps Bubble", "Swaps Selection", "Swaps Insertion");
    
        for (int num:lengths){
    
	        int array1[] = new int[num];
	        int array2[] = new int[num];
	        int array3[] = new int[num];
	
	        for(int i=0; i<array1.length; i++) {
	            array1[i] = array1.length-i;
	        }
	
	        System.arraycopy(array1,0,array2, 0,array1.length);
	        System.arraycopy(array1,0,array3, 0,array1.length);
	
	        swapsBubble=bubbleSort(array1);
	        
	        swapsSelection=selectionSort(array2);
	        
	        swapsInsertion=insertionSort(array3);
	        
	        System.out.format("%10d %20d %20d %20d\n",num, swapsBubble, 
	                            swapsSelection,swapsInsertion);
        }
        
        
        System.out.println("Array all elements equal");
        System.out.format("%10s %20s %20s %20s\n","Number", "Swaps Bubble", "Swaps Selection", "Swaps Insertion");
    
        for (int num:lengths){
    
	        int array1[] = new int[num];
	        int array2[] = new int[num];
	        int array3[] = new int[num];
	
	        for(int i=0; i<array1.length; i++) {
	            array1[i] = 1;
	        }
	
	        System.arraycopy(array1,0,array2, 0,array1.length);
	        System.arraycopy(array1,0,array3, 0,array1.length);
	
	        swapsBubble=bubbleSort(array1);
	        
	        swapsSelection=selectionSort(array2);
	        
	        swapsInsertion=insertionSort(array3);
	        
	        System.out.format("%10d %20d %20d %20d\n",num, swapsBubble, 
	                            swapsSelection,swapsInsertion);
        }
        
        
    }  
    
}
