/*
 * Binary Tree interface
 */
public class Test {
    public static void main(String args[]) {
        try {
            // non-recursive model
            BTree<String> colorGreen = new NonRecursiveLBTree<String>("color=GREEN");
            BTree<String> colorYellow = new NonRecursiveLBTree<String>("color=YELLOW");
            BTree<String> sizeBig = new NonRecursiveLBTree<String>("size=BIG");
            BTree<String> sizeMedium = new NonRecursiveLBTree<String>("size=MEDIUM");
            BTree<String> sizeSmall = new NonRecursiveLBTree<String>("size=SMALL");
            BTree<String> shapeRound = new NonRecursiveLBTree<String>("shape=ROUND");
            BTree<String> tasteSweet = new NonRecursiveLBTree<String>("taste=SWEET");
            
            BTree<String> watermelon = new NonRecursiveLBTree<String>("watermelon");
            BTree<String> apple = new NonRecursiveLBTree<String>("apple");
            BTree<String> grape = new NonRecursiveLBTree<String>("grape");
            BTree<String> lemon = new NonRecursiveLBTree<String>("lemon");
            BTree<String> banana = new NonRecursiveLBTree<String>("banana");
            BTree<String> cherry = new NonRecursiveLBTree<String>("cherry");
            BTree<String> berry = new NonRecursiveLBTree<String>("berry");
            BTree<String> orange = new NonRecursiveLBTree<String>("orange");

            // recursive model
/*            
            BTree<String> colorGreen = new LBTree<String>("color=GREEN");
            BTree<String> colorYellow = new LBTree<String>("color=YELLOW");
            BTree<String> sizeBig = new LBTree<String>("size=BIG");
            BTree<String> sizeMedium = new LBTree<String>("size=MEDIUM");
            BTree<String> sizeSmall = new LBTree<String>("size=SMALL");
            BTree<String> shapeRound = new LBTree<String>("shape=ROUND");
            BTree<String> tasteSweet = new LBTree<String>("taste=SWEET");
            
            BTree<String> watermelon = new LBTree<String>("watermelon");
            BTree<String> apple = new LBTree<String>("apple");
            BTree<String> grape = new LBTree<String>("grape");
            BTree<String> lemon = new LBTree<String>("lemon");
            BTree<String> banana = new LBTree<String>("banana");
            BTree<String> cherry = new LBTree<String>("cherry");
            BTree<String> berry = new LBTree<String>("berry");
            BTree<String> orange = new LBTree<String>("orange");
*/
            colorGreen.insert(sizeBig, BTree.LEFT);
            colorGreen.insert(colorYellow, BTree.RIGHT);
        
            sizeBig.insert(watermelon, BTree.LEFT);
            sizeBig.insert(sizeMedium, BTree.RIGHT);
                        
            colorYellow.insert(shapeRound, BTree.LEFT);
            colorYellow.insert(sizeSmall, BTree.RIGHT);
            
            sizeMedium.insert(apple, BTree.LEFT);
            sizeMedium.insert(grape, BTree.RIGHT);
            shapeRound.insert(lemon, BTree.LEFT);
            shapeRound.insert(banana, BTree.RIGHT);
            sizeSmall.insert(tasteSweet, BTree.LEFT);
            sizeSmall.insert(orange, BTree.RIGHT);
            
            tasteSweet.insert(cherry, BTree.LEFT);
            tasteSweet.insert(berry, BTree.RIGHT);

            System.out.println("INORDER: " + colorGreen.toStringInOrder());
            System.out.println("PREORDER: " + colorGreen.toStringPreOrder());
            System.out.println("POSTORDER: " + colorGreen.toStringPostOrder());
            System.out.println("SIZE=" + colorGreen.size());
            System.out.println("HEIGHT=" + colorGreen.height());
/*
            // First, create nodes. For instance, as follows: 
            BTree<String> colorGreen = new DummyTree<String>("color=GREEN");
            BTree<String> sizeBig = new DummyTree<String>("size=BIG");
            // ...
            BTree<String> colorYellow = new DummyTree<String>("color=YELLOW");
            BTree<String> watermelon = new DummyTree<String>("Watermelon");
            BTree<String> sizeMedium = new DummyTree<String>("size=MEDIUM");
            BTree<String> shapeRound = new DummyTree<String>("shape=ROUND");
            BTree<String> sizeSmall = new DummyTree<String>("size=SMALL");
            BTree<String> apple = new DummyTree<String>("Apple");
            BTree<String> grape = new DummyTree<String>("Grape");
            BTree<String> lemon = new DummyTree<String>("Lemon");
            BTree<String> banana = new DummyTree<String>("Banana");
            BTree<String> tasteSweet = new DummyTree<String>("taste=SWEET");
            BTree<String> orange = new DummyTree<String>("Orange");
            BTree<String> cherry = new DummyTree<String>("Cherry");
            BTree<String> berry = new DummyTree<String>("Berry");
            
            // Then connect nodes. For instance, as follows:
            colorGreen.insert(sizeBig, BTree.LEFT);
            // ...
            colorGreen.insert(colorYellow, BTree.RIGHT);
            sizeBig.insert(watermelon, BTree.LEFT);
            sizeBig.insert(sizeMedium, BTree.RIGHT);
            colorYellow.insert(shapeRound, BTree.LEFT);
            colorYellow.insert(sizeSmall, BTree.RIGHT);
            sizeMedium.insert(apple, BTree.LEFT);
            sizeMedium.insert(grape, BTree.RIGHT);
            shapeRound.insert(lemon, BTree.LEFT);
            shapeRound.insert(banana, BTree.RIGHT);
            sizeSmall.insert(tasteSweet, BTree.LEFT);
            sizeSmall.insert(orange, BTree.RIGHT);
            tasteSweet.insert(cherry, BTree.LEFT);
            tasteSweet.insert(berry, BTree.RIGHT);
        
            // Print the tree and its size and height
            System.out.println("---- tree structure ----");
            System.out.println(colorGreen.toStringPreOrder());
            System.out.println();
            System.out.print("Size = " + colorGreen.size() + ", Height = " + colorGreen.height());
*/        
        } catch(Exception e) {
            System.out.println("Exception: "+e.getMessage());
        }
    }
}
