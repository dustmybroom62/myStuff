public class LBNode<E> {

    // Attributes
    private E info;
    private BTree<E> left;
    private BTree<E> right;
    
    /*
     * Constructor
     */
    public LBNode(E info, BTree<E> left, BTree<E> right) {
        // ... (to complete)
        this.info = info;
        this.left = left;
        this.right = right;
    }
    
    /* 
     * Access methods
     */
    public E getInfo() {
        return this.info;
    }
    
    public void setInfo(E info) {
        this.info = info;
    }
    
    public BTree<E> getLeft() {
        // ... (to complete)
        return this.left;
    }
    
    public void setLeft(BTree<E> left) {
        // ... (to complete)
        this.left = left;
    }
    
    public BTree<E> getRight() {
        // ... (to complete)
        return this.right;
    }
    
    public void setRight(BTree<E> right) {
        // ... (to complete)
        this.right = right;
    }

}
