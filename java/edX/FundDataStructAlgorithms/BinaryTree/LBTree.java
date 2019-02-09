public class LBTree<E> implements BTree<E> {
    
    // Attribute that represents the root node (recursive definition)
    private LBNode<E> root;

    /*
     * Constructor of an empty tree
     */
    public LBTree() {
        root = null;
    }
    
    /* 
     * Constructor
     */
    public LBTree(E info) {
        root = new LBNode<E>(info, new LBTree<E>(), new LBTree<E>());
    }
 
    /*
     * Checks if the tree is empty
     */
    public boolean isEmpty() {
        return (root == null);
    }
    
    /*
     * Returns the information stored in the node
     */
    public E getInfo() throws BTreeException {
        if (isEmpty()) {
            throw new BTreeException("Empty trees do not have info");
        }
        return root.getInfo();
    }
    
    /*
     * Returns left and right subtrees
     */
    public BTree<E> getLeft() throws BTreeException {
        // ... (to complete)
        return root.getLeft();
    }
    
    public BTree<E> getRight() throws BTreeException {
        // ... (to complete)
        return root.getRight();
    }

    /* 
     * Inserts a given tree as a subtree in the given side
     */
    public void insert(BTree<E> tree, int side) throws BTreeException {
        if (isEmpty()) {
            throw new BTreeException("Empty trees do not have a left or right child");
        }
        if(side==LEFT) {
            if (!root.getLeft().isEmpty()) {
                throw new BTreeException("Left subtree is not empty");
            }  
            root.setLeft(tree);
        } else {
            // ... (to complete)
            if (!root.getRight().isEmpty()) {
                throw new BTreeException("Right subtree is not empty");
            }
            root.setRight(tree);
        }
    }
    
    /*
     * Tree traversals (dummy implementations)
     */
    public String toStringPreOrder() {
        if (null == root) { return ""; }
        // System.out.println("Traverses the ["+root.getInfo()+"] tree in preorder");
        String result = root.getInfo().toString() + " ";
        result += root.getLeft().toStringPreOrder();
        result += root.getRight().toStringPreOrder();
        return result;
    }
    
    public String toStringInOrder() {
        if (null == root) { return ""; }
        // System.out.println("Traverses the ["+root.getInfo()+"] tree in order");
        String result = root.getLeft().toStringInOrder();
        result += root.getInfo().toString() + " ";
        result += root.getRight().toStringInOrder();
        return result;
    }
    
    public String toStringPostOrder() {
        if (null == root) { return ""; }
        // System.out.println("Traverses the ["+root.getInfo()+"] tree in postorder");
        String result = root.getLeft().toStringPostOrder();
        result += root.getRight().toStringPostOrder();
        result += root.getInfo().toString() + " ";
        return result;
    }
    
    /*
     * Tree properties (dummy implementations)
     */
    public int size() {
        // System.out.println("Returns the size of ["+root.getInfo()+"] tree");
        if (null == root) return 0;
        return 1 + root.getLeft().size() + root.getRight().size();
    }
    
    public int height() {
        // System.out.println("Returns the height of ["+root.getInfo()+"] tree");
        if (null == root) return -1;
        return 1 + Math.max(root.getLeft().height(), root.getRight().height());
    }
    
}
