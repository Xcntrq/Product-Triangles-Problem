using System.Collections.Generic;

namespace ProductTrianglesProblem
{
    class ProductTriangle
    {
        private readonly string _name;
        private readonly List<OriginYear> _originYears;

        public string Name => _name;

        public ProductTriangle(string name)
        {
            _name = name;
            _originYears = new List<OriginYear>();
        }

        public ProductTriangle(ProductTriangle productTriangle)
        {
            _name = productTriangle.Name;
            _originYears = new List<OriginYear>(productTriangle._originYears);
        }

        public void AddRecord(int startingYear, int developmentYear, float value)
        {
            OriginYear originYear = null;
            if (_originYears != null)
            {
                for (int i = 0; i < _originYears.Count; i++)
                {
                    if (_originYears[i].StartingYear == startingYear) originYear = _originYears[i];
                }
            }
            if (originYear == null)
            {
                originYear = new OriginYear(startingYear);
                _originYears.Add(originYear);
            }

            originYear.AddDevelopmentYear(developmentYear, value);
        }

        public (int, int) OriginYearsSpread()
        {
            int yearMin = int.MaxValue;
            int yearMax = int.MinValue;

            foreach (OriginYear originYear in _originYears)
            {
                if (originYear.StartingYear < yearMin) yearMin = originYear.StartingYear;
                if (originYear.StartingYear > yearMax) yearMax = originYear.StartingYear;
            }

            return (yearMin, yearMax);
        }

        public ProductTriangle ExtendYears(int yearMin, int yearMax)
        {
            ProductTriangle resultTriangle = new ProductTriangle(this);

            for (int originYear = yearMin; originYear <= yearMax; originYear++)
            {
                for (int developmentYear = originYear; developmentYear <= yearMax; developmentYear++)
                {
                    resultTriangle.AddRecord(originYear, developmentYear, 0);
                }
            }

            return resultTriangle;
        }

        public void SortOriginYears()
        {
            for (int j = 0; j < _originYears.Count; j++)
            {
                for (int i = 0; i < _originYears.Count - 1; i++)
                {
                    if (_originYears[i].StartingYear > _originYears[i + 1].StartingYear)
                    {
                        (_originYears[i], _originYears[i + 1]) = (_originYears[i + 1], _originYears[i]);
                    }
                }
            }
        }

        public override string ToString()
        {
            string result = _name;

            SortOriginYears();

            for (int i = 0; i < _originYears.Count; i++)
            {
                result = string.Concat(result, _originYears[i].ToString());
            }

            return result;
        }
    }
}
