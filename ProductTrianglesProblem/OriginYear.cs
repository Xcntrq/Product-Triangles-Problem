using System.Collections.Generic;
using System.Globalization;

namespace ProductTrianglesProblem
{
    class OriginYear
    {
        private readonly int _startingYear;
        private readonly List<float> _developmentYears;

        public int StartingYear => _startingYear;

        public OriginYear(int startingYear)
        {
            _startingYear = startingYear;
            _developmentYears = new List<float>();
        }

        public void AddDevelopmentYear(int developmentYear, float value)
        {
            int developmentYearIndex = developmentYear - _startingYear;
            while (_developmentYears.Count < developmentYearIndex + 1)
            {
                _developmentYears.Add(0);
            }
            if (_developmentYears[developmentYearIndex] == 0) _developmentYears[developmentYearIndex] = value;
        }

        public override string ToString()
        {
            string result = "";
            float sum = 0;

            for (int i = 0; i < _developmentYears.Count; i++)
            {
                sum += _developmentYears[i];
                result = string.Concat(result, ", ", sum.ToString("G", CultureInfo.CreateSpecificCulture("en-US")));
            }

            return result;
        }
    }
}
