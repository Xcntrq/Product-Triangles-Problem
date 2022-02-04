using System.Collections.Generic;

namespace ProductTrianglesProblem
{
    class ProductTriangles : List<ProductTriangle>
    {
        public void AddEntry(string productName, int originYear, int developmentYear, float value)
        {
            ProductTriangle productTriangle = null;

            for (int i = 0; i < Count; i++)
            {
                if (this[i].Name == productName) productTriangle = this[i];
            }

            if (productTriangle == null)
            {
                productTriangle = new ProductTriangle(productName);
                Add(productTriangle);
            }

            productTriangle.AddRecord(originYear, developmentYear, value);
        }

        public (int, int) OriginYearsSpread()
        {
            int yearMin = int.MaxValue;
            int yearMax = int.MinValue;

            foreach (ProductTriangle productTriangle in this)
            {
                int item1;
                int item2;
                (item1, item2) = productTriangle.OriginYearsSpread();
                if (item1 < yearMin) yearMin = item1;
                if (item2 > yearMax) yearMax = item2;
            }

            return (yearMin, yearMax);
        }
    }
}
