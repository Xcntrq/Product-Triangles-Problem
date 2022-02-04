using System;
using System.IO;
using System.Text;

namespace ProductTrianglesProblem
{
    class OutputFileWriter
    {
        private readonly string _fileName;
        private readonly int _yearMin;
        private readonly int _yearMax;
        private readonly ProductTriangles _productTriangles;

        public OutputFileWriter(string fileName, int yearMin, int yearMax, ProductTriangles productTriangles)
        {
            _fileName = fileName;
            _yearMin = yearMin;
            _yearMax = yearMax;
            _productTriangles = productTriangles;
        }

        public void WriteToFile()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int numberOfDevYears = _yearMax - _yearMin + 1;
            string firstLine = string.Concat(_yearMin, ", ", numberOfDevYears);
            stringBuilder.Append(firstLine);
            stringBuilder.Append(Environment.NewLine);

            foreach (ProductTriangle productTriangle in _productTriangles)
            {
                string newLine = productTriangle.ToString();
                stringBuilder.Append(newLine);
                stringBuilder.Append(Environment.NewLine);
            }

            File.WriteAllText(_fileName, stringBuilder.ToString());
        }
    }
}
