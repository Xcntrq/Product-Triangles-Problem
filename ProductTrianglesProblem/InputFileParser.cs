using System;
using System.Globalization;
using System.IO;

namespace ProductTrianglesProblem
{
    class InputFileParser
    {
        private readonly string _fileName;
        private readonly ProductTriangles _productTriangles;

        public InputFileParser(string fileName, ProductTriangles productTriangles)
        {
            _fileName = fileName;
            _productTriangles = productTriangles;
        }

        public void Parse()
        {
            StreamReader streamReader = new StreamReader(_fileName);

            using (streamReader)
            {
                //Skip the first line, headers
                if (streamReader.Peek() >= 0) streamReader.ReadLine();

                while (streamReader.Peek() >= 0)
                {
                    string currentLine = streamReader.ReadLine();

                    char[] separators = { ',', ' ' };
                    string[] currentLineSplit = currentLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    string currentProductName = currentLineSplit[0];
                    int originYear = int.Parse(currentLineSplit[1]);
                    int developmentYear = int.Parse(currentLineSplit[2]);
                    float value = float.Parse(currentLineSplit[3], CultureInfo.InvariantCulture);

                    _productTriangles.AddEntry(currentProductName, originYear, developmentYear, value);
                }
            }
        }
    }
}
