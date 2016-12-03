using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class AdventOfCodeDay3
    {
        public List<Triangle> triangles = new List<Triangle>();

        public List<Triangle> ParseTrianglePerRow(string input)
        {
            var inputLines = Common.GetLines(input);

            foreach (var line in inputLines)
            {
                var sides = ParseSides(line);

                triangles.Add(new Triangle(sides[0], sides[1], sides[2]));
            }

            return triangles;
        }

        public List<Triangle> ParseTriangleTriplets(string input)
        {
            string[] inputLines = Common.GetLines(input);

            List<Triangle> triangleTriplet = GetNewTriplet();

            for (int lineNumber = 0; lineNumber < inputLines.Length; lineNumber++)
            {
                string line = inputLines[lineNumber];
                int[] sides = ParseSides(line);

                int currentSide = GetCurrentSideFromLineNumber(lineNumber);

                SetSideLengthOnTriangles(triangleTriplet, sides, currentSide);

                if (currentSide == 3)
                {
                    triangleTriplet.ForEach((triangle) => triangles.Add(triangle));

                    triangleTriplet = GetNewTriplet();
                }
            }

            return triangles;
        }

        private static void SetSideLengthOnTriangles(List<Triangle> triangleTriplet, int[] sides, int currentSide)
        {
            for (int j = 0; j < triangleTriplet.Count; j++)
            {
                triangleTriplet[j].Sides[currentSide] = sides[j];
            }
        }

        private static int GetCurrentSideFromLineNumber(int lineNumber)
        {
            int sideNumber = (lineNumber + 1) % 3;

            //Every third line should return 3 instead of zero
            return sideNumber == 0
                ? 3
                : sideNumber;
        }

        private static List<Triangle> GetNewTriplet()
        {
            return new List<Triangle>
            {
                new Triangle(),
                new Triangle(),
                new Triangle()
            };
        }

        private static int[] ParseSides(string line)
        {
            return new int[] {
                    int.Parse(line.Substring(0, 5).Trim()),
                    int.Parse(line.Substring(5, 5).Trim()),
                    int.Parse(line.Substring(10, 5).Trim())
                };
        }
    }

    public class Triangle
    {
        public Dictionary<int, int> Sides;

        public bool IsValid
        {
            get
            {
                for (int sideNum = 1; sideNum <= Sides.Count; sideNum++)
                {
                    if (SumAdjacentSides(sideNum) <= Sides[sideNum])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private int SumAdjacentSides(int sideNum)
        {
            int sum = 0;
            for (int j = 1; j <= Sides.Count; j++)
            {
                if (sideNum == j) continue;

                sum += Sides[j];
            }

            return sum;
        }

        public Triangle()
        {
            Sides = new Dictionary<int, int>
            {
                [1] = 0,
                [2] = 0,
                [3] = 0
            };
        }

        public Triangle(int side1, int side2, int side3)
        {
            Sides = new Dictionary<int, int>{
                [1] = side1,
                [2] = side2,
                [3] = side3
            };
        }
    }
}
