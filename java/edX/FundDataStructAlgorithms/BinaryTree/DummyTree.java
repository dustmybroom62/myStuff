public class DummyTree<E> implements BTree<E> {
    
    // Attribute that stores the information
    private E info;
    
    /*
     * Constructor
     */
    public DummyTree(E info) {
        System.out.println("Creating a tree with ["+info+"]");
        this.info = info;
    }
    
     /*
      * Checks if the tree is empty
      */
     public boolean isEmpty() {
         System.out.println("Is the ["+info+"] tree empty?");
         return false;
     }
     
     /*
      * Returns the information stored in the node
      */
     public E getInfo() throws BTreeException {
         System.out.println("Returns the information in the node: ["+info+"]");
         return info;
     }
     
     /*
      * Returns left and right subtrees
      */
     public BTree<E> getLeft() throws BTreeException {
         System.out.println("Returns the left subtree");
         return null;
     }
     
     public BTree<E> getRight() throws BTreeException {
         System.out.println("Returns the right subtree");
         return null;
     }
     
     /* 
      * Inserts a given tree as a subtree in the given side
      */
     public void insert(BTree<E> tree, int side) throws BTreeException {
         System.out.println("Inserts the tree with ["+tree.getInfo()+"] in the "+
           (side==LEFT ? "left" : "right")+" side of the ["+info+"] tree");
     }
     
     /*
      * Tree traversals
      */
     public String toStringPreOrder() {
         System.out.println("Traverses the ["+info+"] tree in preorder");
         return "";
     }
     
     public String toStringInOrder() {
         System.out.println("Traverses the ["+info+"] tree in order");
         return "";
     }
     
     public String toStringPostOrder() {
         System.out.println("Traverses the ["+info+"] tree in postorder");
         return "";
     }
     
     /*
      * Tree properties
      */
     public int size() {
         System.out.println("Returns the size of ["+info+"] tree");
         return -1;
     }
     
     public int height() {
         System.out.println("Returns the height of ["+info+"] tree");
         return -1;
     }
     
 }
 