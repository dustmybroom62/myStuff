import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Scanner;

public class Anagram {
    public static String sortCharacters( String s ) {
        char[] chArray = s.toCharArray();
        Arrays.sort(chArray);
        return new String(chArray);
    }
        
    public static void main(String[] args) {
        HashMap<String, HashSet<String>> dict = new HashMap<>();
        Scanner scan = new Scanner(System.in);
        int longestList = 0;
        String line;
        while (true) {
            try {
                line = scan.nextLine();
            } catch (Exception e) {
                break;
            }
            //if (null == line || 0 == line.length()) break;

            String key = sortCharacters(line);
            HashSet<String> valList = dict.get(key);
            if (null == valList) {
                valList = new HashSet<String>();
                dict.put(key, valList);
            }
            valList.add(line);
            int listSize = valList.size();
            if (longestList < listSize) { longestList = listSize;}
        }
        scan.close();
        System.out.println("Keys: " + dict.size());
        System.out.println("beard/bread: " + dict.get(sortCharacters("bread")).contains("beard") );
        System.out.println("search: " + dict.get(sortCharacters("search")).size());
        System.out.println("longest list: " + longestList);
    }
}