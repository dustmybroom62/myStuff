/**
 * Main class of the Java program.
 */
public class Main {

	public static void main(String[] args) {
		
        // Test StackPathFinder
        /*
		StackPathFinder pf = new StackPathFinder();

		System.out.println("Test StackPathFinder");
		Maze maze;
		Path path;

		maze = new Maze(MazeSamples.sMaze2);
		path = pf.findPath(maze);
		System.out.println(maze.toString());
		System.out.println(path.toString());

		maze = new Maze(MazeSamples.sMaze3);
		path = pf.findPath(maze);
		System.out.println(maze.toString());
		System.out.println(path.toString());

		maze = new Maze(MazeSamples.sMaze4);
		path = pf.findPath(maze);
		System.out.println(maze.toString());
        System.out.println(path.toString());
        */
        
		// Test QueuePathFinder
		QueuePathFinder pf = new QueuePathFinder();

		System.out.println("Test QueuePathFinder");
		Maze maze;
		Path path;

		maze = new Maze(MazeSamples.sMaze2);
		path = pf.findPath(maze);
		System.out.println(maze.toString());
		System.out.println(path.toString());

		maze = new Maze(MazeSamples.sMaze3);
		path = pf.findPath(maze);
		System.out.println(maze.toString());
		System.out.println(path.toString());

		maze = new Maze(MazeSamples.sMaze4);
		path = pf.findPath(maze);
		System.out.println(maze.toString());
		System.out.println(path.toString());

	}
    
    /** 
     * Builds a path through the Maze starting at position (0, 0) 
     * and following the given sequence of movements.
     */
    /*
    public static Path buildPath(Maze maze, Movement[] movs) {
        
        Path path = new Path();
        
        int[] currentCoords = new int[] {0, 0};  // (row, col)
        int[] nextCoords;
        
        path.insertLast(currentCoords[0], currentCoords[1]);
        
        for (int i=0; i<movs.length; i++) {
            nextCoords = maze.getNeighbourCoords(currentCoords[0], currentCoords[1], movs[i]);
            if (nextCoords != null) {
                path.insertLast(nextCoords[0], nextCoords[1]);
            } else {
                // invalid movement: stop here
                break;
            }
            currentCoords = nextCoords;
        }

        return path;
        
    }
    
    
    public static void main(String[] args) {
        
        
        Maze maze;
        
        // Test Maze: part 1

        System.out.println("Test Maze. Part 1: constructor and toString");
        
        maze = new Maze(5, 8);
        System.out.println("Test Maze. Part 1: empty Maze");
        System.out.println(maze.toString());


        // Test Maze: part 2

        System.out.println("Test Maze. Part 2: stringToMaze and toString");

        maze = new Maze(MazeSamples.sMaze1);
        System.out.println(maze.toString());

        maze = new Maze(MazeSamples.sMaze3);
        System.out.println(maze.toString());


        // Test Path (parts 3 and 4)
        System.out.println("Test Path");
        
        Path path;

        maze = new Maze(MazeSamples.sMaze1);
        path = buildPath(maze, PathSamples.movsPath1a);
        System.out.println("Test Path (Part 3)");
        System.out.println(path.toString());
        System.out.println("Test Path (Part 4)");
        maze.followPath(path);
        System.out.println(maze.toString());

        maze = new Maze(MazeSamples.sMaze1);
        path = buildPath(maze, PathSamples.movsPath1b);
        System.out.println("Test Path (Part 3)");
        System.out.println(path.toString());
        System.out.println("Test Path (Part 4)");
        maze.followPath(path);
        System.out.println(maze.toString());
        
    }
    */
}
