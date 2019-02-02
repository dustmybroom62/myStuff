/**
 * Class MazePath represents a path through a maze 
 * composed of a doubly-linked list of MazeSteps (positions)
 * 
 * @author Raquel M. Crespo-Garcia <rcrespo@it.uc3m.es>
 */
public class Path {

    /** First position in the path */    
    private PathStep first;
    
    /** Last position in the path */    
    private PathStep last;
    
    /**
     * Initializes empty path
     */
    public Path() {
        this.first = null;
        this.last = null;
    }
    
    /**
     * Insert the given coordinates as a new step in the first position of the path
     */
    public void insertFirst(int row, int col) {
        // Learning concepts:
        // Insert first element in doubly linked list
        PathStep pathStep = new PathStep(row, col);
        pathStep.setNext(first);
        first = pathStep;
        if (null == last) {
            last = pathStep;
        }
    }
    
    /**
     * Insert the given coordinates as a new step in the last position of the path
     */
    public void insertLast(int row, int col) {
        // Learning concepts:
        // Insert last element in doubly linked list
        PathStep pathStep = new PathStep(row, col);
        pathStep.setPrev(last);
        if (null != last) {
            last.setNext(pathStep);
        }
        last = pathStep;
        if (null == first) {
            first = pathStep;
        }

    }
    
    /**
     * Returns the coordinates of the first step in the path and removes it from the path. 
     * If the Path is empty, returns null.
     */
    public int[] extractFirst() {
        // Learning concepts:
        // Extract first element of doubly linked list
        if (null != first) {
            int[] result = new int[] {first.getRow(), first.getCol()};
            PathStep next = first.getNext();
            if (null == next) {
                first = null; last = null;
            } else {
                first = next; first.setPrev(null);
            }
            return result;
        }

        return null;
    }
    
    /**
     * Returns the coordinates of the last step in the path and removes it from the path. 
     * If the Path is empty, returns null.
     */
    public int[] extractLast() {

        // Learning concepts:
        // Extract last element of doubly linked list
        if (null != last) {
            int[] result = new int[] {last.getRow(), last.getCol()};
            PathStep prev = last.getPrev();
            if (null == prev) {
                first = null; last = null;
            } else {
                last = prev; last.setNext(null);
            }
            return result;
        }

        return null;
    }
    
    /**
     * Returns a String based representation of the Path.
     * If the Path is empty, returns an empty String ("")
     * If the Path is not empty, returns an String with the format:
     * (row1, col1), (row2, col2), ..., (rowN, colN)
     */
    public String toString() {
        
        String sPath = "";
        
        // Traverse a linked list concatenating the coordinates of each step. 
        // Recommendation: use the toString method in the PathStep class to get the 
        // "(row, col)" String corresponding to the pair of coordinates of each step.
        
        // Learning concepts:
        // traverse a linked list
        // Important: the Path must not be modified by the method!
        
        for (PathStep current = first; null != current; current = current.getNext()) {
            if (sPath.length() > 0) { sPath += ", "; }
            sPath += current.toString();
        }
        return sPath;
    }
    

}
