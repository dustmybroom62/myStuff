/**
 * Class MazePosition encapsulates the coordinates 
 * of a given position in a maze.
 * 
 * @author Raquel M. Crespo-Garcia <rcrespo@it.uc3m.es>
 */
public class MazePosition {
	int[] coords;
	MazePosition from;
	
	MazePosition(int[] coords) {
		this(coords, null);
	}
	MazePosition(int row, int col) {
		this(row, col, null);
	}
	
	MazePosition(int[] coords, MazePosition from) {
		setCoords(coords);
		this.from = from;
	}
	MazePosition(int row, int col, MazePosition from) {
		setCoords(new int[]{row, col});
		this.from = from;
	}
	
	public int[] getCoords() {
		return coords;
	}
	public void setCoords(int[] coords) {
		this.coords = coords;
	}
	
	public MazePosition getFrom() {
		return from;
	}

    public String toString() {
	return( "("+coords[0] + ", " + coords[1] + ")" );
    }
    
    public boolean equals(Object o) {
    	
    	/* 
    	 * Checks just the coordinates,
    	 * ignores the previos position (from)
    	 * so that contains detects as the same cell 
    	 * two positions with the same coordinates 
    	 * despite having been reached from two different paths. 
    	 */
    	MazePosition opos = (MazePosition) o;
    	int[] ocoords = opos.getCoords();
    	
    	boolean res = this.coords.length == ocoords.length;
    	for (int i=0; res && i<this.coords.length; i++) {
    		if (this.coords[i] != ocoords[i]){
    			res = false;
    		}
    	}
    	
    	return res;
    	
    }
    
}
