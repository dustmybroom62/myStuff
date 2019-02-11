public class LBSTree<E> implements BSTree<E> {
	
	/*
	 * Attribute: the node
	 */
	private LBSNode<E> root;
	
	/*
	 * Constructors
	 */
	public LBSTree(Comparable key, E info) {
		root = new LBSNode<E>(key, info, new LBSTree<E>(), new LBSTree<E>());
	}
	
	public LBSTree() {
		root = null;
    }
    
    public boolean isRemoved() {
        return isEmpty() ? true : root.isRemoved();
    }

    public void setRemoved(boolean state) {
        if (isEmpty()) return;
        root.setRemoved(state);
    }
	
	/* 
	 * Checks if the tree is empty
	 */
	public boolean isEmpty() {
        // ... (to complete)
        return null == root;
	}
	
	/*
	 * Returns the search key of the information stored in the tree
	 */
	public Comparable getKey() {
		if(isEmpty()) {
			return null;
		} else {
			return root.getKey();
		}
	}
	
	/*
	 * Returns the information stored in the tree
	 */
	public E getInfo() {
        // ... (to complete)
        return isEmpty() ? null : root.getInfo();
	}
	
	/* 
	 * Returns the left and right subtrees
	 */
	public BSTree<E> getLeft() {
        // ... (to complete)
        return isEmpty() ? null : root.getLeft();
	}
	
	public BSTree<E> getRight() {
        // ... (to complete)
        return isEmpty() ? null : root.getRight();
	}
	
	/*
	 * Inserts information into the tree. If key already exists, the information is overwritten
	 */
	public void insert(Comparable key, E info) {
		if(isEmpty()) {
			root = new LBSNode<E>(key, info, new LBSTree<E>(), new LBSTree<E>());
			setRemoved(false);
		} else {
			if(root.getKey().compareTo(key)>0) {
				getLeft().insert(key, info);
			} else if(root.getKey().compareTo(key)<0) {
                // ... (to complete)
                getRight().insert(key, info);
			} else {
                root.setInfo(info);
                setRemoved(false);
			}
		}
	}
	
	/*
	 * Searches for information in the tree
	 */
	public E search(Comparable key) {
        // ... (to complete)
        if (isEmpty()) return null;
        int comp = key.compareTo(getKey());
        if (0 > comp) return getLeft().search(key);
        else if (0 < comp) return getRight().search(key);
        else return getInfo();
	}

	/*
	 * Searches and extracts information (dummy implementation)
	 */
	public E extract(Comparable key) {
		if (isEmpty()) return null;
        int comp = key.compareTo(getKey());
        if (0 > comp) return getLeft().extract(key);
        else if (0 < comp) return getRight().extract(key);
        else {
			if (isRemoved()) return null;
            E info = getInfo();
            setRemoved(true);
            return info;
        }
	}
	
	/*
	 * Tree traversals (dummy implementation)
	 */
    public String toStringPreOrder() {
        if (isEmpty()) { return ""; }
        // System.out.println("Traverses the ["+root.getInfo()+"] tree in preorder");
        String result = isRemoved() ? "" : getKey().toString() + ":" + getInfo().toString() + " ";
        result += getLeft().toStringPreOrder();
        result += getRight().toStringPreOrder();
        return result;
    }
    
    public String toStringInOrder() {
        if (isEmpty()) { return ""; }
        // System.out.println("Traverses the ["+root.getInfo()+"] tree in order");
        String result = getLeft().toStringInOrder();
        result += isRemoved() ? "" : getKey().toString() + ":" + getInfo().toString() + " ";
        result += getRight().toStringInOrder();
        return result;
    }
    
    public String toStringPostOrder() {
        if (isEmpty()) { return ""; }
        // System.out.println("Traverses the ["+root.getInfo()+"] tree in postorder");
        String result = getLeft().toStringPostOrder();
        result += getRight().toStringPostOrder();
        result += isRemoved() ? "" : getKey().toString() + ":" + getInfo().toString() + " ";
        return result;
    }
	
	/*
	 * Returns size of the tree (the number of pieces of information) (dummy implementation)
	 */
	public int size() {
        if (isEmpty()) return 0;
		return (isRemoved() ? 0 : 1) + getLeft().size() + getRight().size();
	}
	
}
