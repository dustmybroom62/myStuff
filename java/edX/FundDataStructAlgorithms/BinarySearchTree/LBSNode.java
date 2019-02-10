public class LBSNode<E> {

    // Attributes
    private boolean removed;
    private Comparable key;
    private E info;
    
    private BSTree<E> right;
    private BSTree<E> left;
    
    public LBSNode(Comparable key, E info, BSTree<E> left, BSTree<E> right) {
      // ... (to complete)
      this.key = key;
      this.info = info;
      this.left = left;
      this.right = right;
      this.removed = false;
    }
    
    // Access methods
    public boolean isRemoved() { return this.removed; }
    public void setRemoved(boolean state) { this.removed = state; }
    
    public void setKey(Comparable key) {
      this.key = key;
    }
    public Comparable getKey() {
      return key;
    }
    
    public void setInfo(E info) {
      // ... (to complete)
      this.info = info;
    }
    public E getInfo() {
      // ... (to complete)
      return isRemoved() ? null : this.info;
    }
    
    public void setLeft(BSTree<E> left) {
      // ... (to complete)
      this.left = left;
    }
    public BSTree<E> getLeft() {
      // ... (to complete)
      return this.left;
    }
    
    public void setRight(BSTree<E> left) {
      // ... (to complete)
      this.right = right;
    }
    public BSTree<E> getRight() {
      // ... (to complete)
      return this.right;
    }
  
    /* 
     * Returns a String representation
     */
    public String toString() {
      return key.toString()+"/"+info.toString();
    }   
    
  }
  