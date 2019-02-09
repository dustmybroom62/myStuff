/**
 * Interface PathFinder models an algorithm for finding a path in a maze
 * @author Raquel M. Crespo-Garcia <rcrespo@it.uc3m.es>
 *
 */
public interface PathFinder {
	
	/**
	 * Finds a path through the maze to the target
	 * starting at coordinates (0,0)
	 * 
	 * @param Path the path to the target goal
	 */
	Path findPath(Maze maze);

}
