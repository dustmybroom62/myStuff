namespace AlgorithmAnalysis
{
    public class Algorithms4
    {
        // Save all file lines that start with the first letter of the alphabet to a new file
        // Must be able to handle VERY large files.
        public void SaveLines(string inputFilePath, string outputFilePath)
        {
            System.IO.StreamWriter fileOut =
                new System.IO.StreamWriter(outputFilePath, false);
            System.IO.StreamReader fileIn =
                new System.IO.StreamReader(inputFilePath);
            string line = null;
            while ((line = fileIn.ReadLine()) != null)
            {
                switch (line[0]) {
                    case 'a':
                    case 'A':
                        fileOut.WriteLine(line);
                        break;
                }
            }
            fileOut.Close();
            fileIn.Close();

        }
    }
}
