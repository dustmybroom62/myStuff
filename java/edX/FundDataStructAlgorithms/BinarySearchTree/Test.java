/*
 * Implementation of Binary Search Trees
 */ 
public class Test {

	public static void main(String args[]) {
		// FIFA World Rankings http://en.wikipedia.org/wiki/FIFA_World_Rankings (9 Feb 2017)
		
		BSTree<Integer> tree = new LBSTree();
		tree.insert("Argentina", 1635);
		tree.insert("Brazil", 1529);
		tree.insert("Germany", 1433);
		tree.insert("Chile", 1386);
		tree.insert("Belgium", 1371);
		tree.insert("France", 1313);
		tree.insert("Colombia", 1304);
		tree.insert("Portugal", 1240);
		tree.insert("Uruguay", 1195);
		tree.insert("Spain", 1168);
		
		System.out.println("INORDER: " + tree.toStringInOrder());
		System.out.println("SIZE= " + tree.size());

		System.out.println("France: " + tree.extract("France"));

		System.out.println("France: " + tree.search("France"));

		System.out.println("INORDER: " + tree.toStringInOrder());
		System.out.println("SIZE= " + tree.size());
	}
	
}
