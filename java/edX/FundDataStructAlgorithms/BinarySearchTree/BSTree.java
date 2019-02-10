public interface BSTree<E> {
	/* 
	 * Checks if the tree is empty
	 */
	boolean isEmpty();
	
	/*
	 * Returns the search key of the information stored in the tree
	 */
	Comparable getKey();
	
	/*
	 * Returns the information stored in the tree
	 */
	E getInfo();
	
	/* 
	 * Returns the left and right subtrees
	 */
	BSTree<E> getLeft();
	BSTree<E> getRight();
	
	/*
	 * Inserts information into the tree. If key already exists, the information is overwritten
	 */
	void insert(Comparable key, E info);
	
	/*
	 * Searches for information in the tree
	 */
	E search(Comparable key);
	
	/*
	 * Searches and extracts information 
	 */
	E extract(Comparable key);
	
	/*
	 * Tree traversals
	 */
	String toStringPreOrder();
	String toStringInOrder();
	String toStringPostOrder();
	
	/*
	 * Returns size of the tree (the number of pieces of information)
	 */
	int size();
	
}
