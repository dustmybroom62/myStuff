import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Scanner;

public class SpellCheck {

    static HashSet<String> loadDictionary(String fileName) throws FileNotFoundException {
        HashSet<String> result = new HashSet<>();
        File file = new File(fileName);
        Scanner s = new Scanner(file);
        while (s.hasNextLine()) {
            result.add(s.nextLine());
        }
        s.close();
        return result;
    }
    public static void main(String[] args) throws FileNotFoundException {
        HashSet<String> dict = loadDictionary(args[0]);
        System.out.println("dict wordCount: " + dict.size());

        HashSet<String> bard = new HashSet<>();
        int errorCount = 0;
        HashSet<String> badWords = new HashSet<>();
        File file = new File(args[1]);
        Scanner s = new Scanner(file);
        while (s.hasNextLine()) {
            String line = s.nextLine();
            String[] words = line.split("\\W");
            for (String word : words) {
                if (2 > word.length()) continue;
                String test = word.toLowerCase();
                bard.add(test);
                if (!dict.contains(test)) {
                    errorCount++;
                    badWords.add(word);
                }
            }
        }
        s.close();
        System.out.println("errorCount: " + errorCount);
        System.out.println("bad wordCount: " + badWords.size());
        System.out.println("bard wordCount: " + bard.size());
    }
}