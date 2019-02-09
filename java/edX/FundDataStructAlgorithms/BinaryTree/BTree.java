public interface BTree<E> {

    /* Constants for representing left and right children */ 
    static final int LEFT = 0;
    static final int RIGHT = 1;
    
    /*
     * Checks if the tree is empty
     */
    boolean isEmpty();
    
    /*
     * Returns the information stored in the node
     */
    E getInfo() throws BTreeException;
    
    /*
     * Returns left and right subtrees
     */
    BTree<E> getLeft() throws BTreeException;
    BTree<E> getRight() throws BTreeException;
    
    /* 
     * Inserts a given tree as a subtree in the given side
     */
    void insert(BTree<E> tree, int side) throws BTreeException;
    
    
    /*
     * Tree traversals
     */
    String toStringPreOrder();
    String toStringInOrder();
    String toStringPostOrder();
    
    /*
     * Tree properties
     */
    int size();
    int height();

}
