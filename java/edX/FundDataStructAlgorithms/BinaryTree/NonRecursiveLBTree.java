public class NonRecursiveLBTree<E> implements BTree<E> {
    
    // Attributes (non-recursive definition)
    private E info;
    private BTree<E> left;
    private BTree<E> right;
 
    /*
     * Constructor of an empty tree
     */
    public NonRecursiveLBTree() {
        // ... (to complete)
        this.info = null;
        this.left = null;
        this.right = null;
    }
    
    /* 
     * Constructor
     */
    public NonRecursiveLBTree(E info) {
        // ... (to complete)
        this.info = info;
        this.left = null;
        this.right = null;
    }
 
    /*
     * Checks if the tree is empty
     */
    public boolean isEmpty() {
        return (info == null);
    }
    
    /*
     * Returns the information stored in the node
     */
    public E getInfo() throws BTreeException {
        if (isEmpty()) {
            throw new BTreeException("Empty trees do not have info");
        }
        return info;
    }
    
    /*
     * Returns left and right subtrees
     */
    public BTree<E> getLeft() throws BTreeException {
        // ... (to complete)
        return this.left;
    }
    
    public BTree<E> getRight() throws BTreeException {
        // ... (to complete)
        return this.right;
    }

    /* 
     * Inserts a given tree as a subtree in the given side
     */
    public void insert(BTree<E> tree, int side) throws BTreeException {
        if (isEmpty()) {
            // ... (to complete)
            throw new BTreeException("Empty trees do not have a left or right child");
        }
        if(side==LEFT) {
            if (this.left!=null) {
                throw new BTreeException("Left subtree is not empty");
            }  
            this.left = tree;
        } else {
            // ... (to complete)
            if (null != this.right) {
                throw new BTreeException("Right subtree is not empty");
            }
            this.right = tree;
        }
    }
    
    /*
     * Tree traversals
     */
    public String toStringPreOrder() {
        if (isEmpty()) {
            // ... (to complete)
            return "";
        } else {
            return info.toString() + " " +
                   (left!=null ? left.toStringPreOrder() : "") +
                   (right!=null ? right.toStringPreOrder() : "");
        }
    }
    
    public String toStringInOrder() {
        // ... (to complete)
        if (isEmpty()) return "";
        return (left!=null ? left.toStringPreOrder() : "") +
                info.toString() + " " +
                (right!=null ? right.toStringPreOrder() : "");
    }
    
    public String toStringPostOrder() {
        // ... (to complete)
        if (isEmpty()) return "";
        return (left!=null ? left.toStringPreOrder() : "") +
                (right!=null ? right.toStringPreOrder() : "") +
                info.toString() + " ";
    }
    
    /*
     * Tree properties
     */
    public int size() {
        // ... (to complete)
        if (null == info) return 0;
        return 1 + (null == left ? 0 : left.size()) + (null == right ? 0 : right.size());
    }
    
    public int height() {
        // ... (to complete)
        if (null == info) return -1;
        return 1 + Math.max( (null == left ? -1 : left.height()), (null == right ? -1 : right.height()) );
    }
    
}
