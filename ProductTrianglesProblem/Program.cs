using System;

namespace ProductTrianglesProblem
{
    class Program
    {
        static void Main()
        {
            string directory = Environment.CurrentDirectory;
            string inputFileName = string.Concat(directory, @"\file-1-input.txt");
            string outputFileName = string.Concat(directory, @"\file-1-output.txt");

            ProductTriangles productTriangles = new ProductTriangles();
            InputFileParser inputFileParser = new InputFileParser(inputFileName, productTriangles);
            inputFileParser.Parse();

            int yearMin;
            int yearMax;
            (yearMin, yearMax) = productTriangles.OriginYearsSpread();

            OutputFileWriter outputFileWriter = new OutputFileWriter(outputFileName, yearMin, yearMax, productTriangles);
            outputFileWriter.WriteToFile();
        }
    }
}
