/**
 * Classes with Generics 
 */
class MyClass<E>{
    private E attribute;
    MyClass(E var){
	    this.attribute = var;
    }
    public E get(){
	    return this.attribute;
    }
    public void set(E value){
	    this.attribute = value;
	}
	
	public boolean equals(Object obj){
		if (obj instanceof MyClass<?>){
			MyClass mc = (MyClass) obj;
			return this.attribute.equals(mc.attribute);
		}
		else
			return false;
	}
    
    // public boolean Override equals(E other){
    //     return other.attribute == this.attribute;
    // }
    
}

public class GenericsTest{

    public static void main(String args[]){

    	Integer a = new Integer(65);
	    int b = 65;
	    String foo = new String("A new String");
	
	    MyClass<Integer> one = new MyClass<Integer>(a);
	    System.out.println(one.get());

	    MyClass<Integer> two = new MyClass<Integer>(b);
	    System.out.println(two.get());

	    MyClass<String> first = new MyClass<String>(foo);
	    System.out.println(first.get());

	    MyClass<String> second = new MyClass<String>("A new String");
	    System.out.println(second.get());

        // If no equals method is provided, 
        // equals is the one imlpemented by the class Object
        // that compares references
        // So, you should override the equals method for this class
	    if (one.equals(two))
	        System.out.println("They are equal");
	    else
	        System.out.println("They are different");

	    if (second.equals(first))
	        System.out.println("They are equal");
	    else
	        System.out.println("They are different");

    }

}
