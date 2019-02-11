import java.util.ArrayList;
import java.util.Arrays;

/**
 * Models the complete set of potential paths from a starting point. 
 * Notice that it grows exponentially,
 * and thus may surpass space/time limits pretty soon.
 *  
 * @author Raquel M. Crespo-Garcia <rcrespo@it.uc3m.es>
 */
public class PathsTree {
	
	private PathsTreeNode root;
	
	/**
	 * Initializes an empty tree
	 */
	public PathsTree() {
		this.root = null;
	}

	/**
	 * Initializes a tree starting at position (0, 0) of Maze maze 
	 */
	public PathsTree(Maze maze) {
		this.root = new PathsTreeNode(maze, new MazePosition(0, 0, null));
	}
	
	/**
	 * Initializes a tree with root at position pos of Maze maze
	 */
	public PathsTree(Maze maze, MazePosition pos) {
		this.root = new PathsTreeNode(maze, pos);
	}

	public void print() {
		print(0);
	}
	
	private void print(int indent) {
        // TO DO
        if (null == root) return;
		String strIndent = new String(new char[2 * indent]).replace("\0", " "); // indentation
		/* 
		// Alternative for indentation
		char[] chars = new char[2 * indent];
		Arrays.fill(chars, ch);
		String s = new String(chars);
		*/
	System.out.println(strIndent + root.pos.toString());
        for (PathsTree pathsTree : root.children) {
            pathsTree.print(indent + 1);
        }
	}
	
	public ArrayList<Path> findAllPaths() {
		ArrayList<Path> paths = new ArrayList<Path>();
		return findAllPaths(paths);
	}

	public ArrayList<Path> findAllPaths(ArrayList<Path> paths) {
        // TO DO
        if (null == root) return paths;
        for (PathsTree pathsTree : root.children) {
            pathsTree.findAllPaths(paths);
        }
        if (MazeStatus.GOAL == root.maze.getPosStatus(root.pos)) {
            Path result = new Path();
            MazePosition current = root.pos;
            while (null != current) {
                int[] coords = current.getCoords();
                int row = coords[0], col = coords[1];
                result.insertFirst(row, col);
                current = current.getFrom();
            }
            paths.add(result);
        }
        return paths;
	}


	/**
	 * Models each node in the paths tree
	 * Contains the position of the current step 
	 * and references to the next possible steps
	 */
	private class PathsTreeNode {
		
		private Maze maze;
		private MazePosition pos;
		private ArrayList<PathsTree> children;

		PathsTreeNode(Maze maze, MazePosition pos) {
			this.maze = maze;
			this.pos = pos;
			this.children = new ArrayList<PathsTree>();
			this.stepForward();
		}
		
		void stepForward() {

			if (maze.getPosStatus(pos) != MazeStatus.GOAL) {
				// if GOAL reached, nowhere to go

				MazePosition next;
				for (Movement mov : Movement.values()) {
					next = maze.getNeighbour(pos, mov);
					if ((next != null) 
						&& (maze.getPosStatus(next) == MazeStatus.OPEN || maze.getPosStatus(next) == MazeStatus.GOAL) // valid position
						&& !this.isAncestor(next)) // not already visited in this path 						
					{
						children.add(new PathsTree(maze, next));
					}
				}	
			}
			
		}
		
		/**
		 * Checks whether pos is an ancestor of this
		 */
		boolean isAncestor(MazePosition pos) {
			
			boolean res = false;
			MazePosition p = this.pos;
			while (p != null) {
				if (p.equals(pos)){
					return true;
				}
				p = p.getFrom();
			}
			return res;
			
		}
		
	}

}
