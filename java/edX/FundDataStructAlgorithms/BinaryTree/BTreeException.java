/*
 * Class that models exceptions in trees
 */
 
public class BTreeException extends Exception {
    
    /*
     * Constructor without parameters
     */
    public BTreeException() {
        super();
    }
    
    /*
     * Constructor that receives the exception message
     */
    public BTreeException(String message) {
        super(message);
    }
    
}
