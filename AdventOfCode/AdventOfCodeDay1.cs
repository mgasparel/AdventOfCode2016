using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class AdventOfCodeDay1
    {
        private List<Coordinate> AllVisitedLocations { get; set; }

        public AdventOfCodeDay1()
        {
            AllVisitedLocations = new List<Coordinate>();
        }

        public List<Coordinate> RunSequence(string input)
        {
            var currentPos = new Coordinate();
            Direction direction = Direction.North;

            List<string> steps = Regex.Split(input, @", ").ToList();

            foreach (var step in steps)
            {
                char directionChar = step[0];
                int distance = Math.Abs(int.Parse(step.Substring(1)));
                direction = Common.Turn(direction, directionChar);

                Console.WriteLine($"Move {distance} units to the {direction.ToString()}");

                for (int i = 0; i < distance; i++)
                {
                    Common.Move(currentPos, direction, 1);

                    Console.WriteLine($"Currently at position {currentPos.X}, {currentPos.Y}");

                    //Alternatively, we could eagerly check if we've been here before
                    AllVisitedLocations.Add(new Coordinate { X = currentPos.X, Y = currentPos.Y });
                }
            }

            return AllVisitedLocations;
        }

        public Coordinate GetFirstLocationVisitedTwice()
        {
            for (int i = 0; i < AllVisitedLocations.Count; i++)
            {
                for (int j = 0; j < AllVisitedLocations.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (AllVisitedLocations[i].X == AllVisitedLocations[j].X &&
                        AllVisitedLocations[i].Y == AllVisitedLocations[j].Y)
                    {
                        return AllVisitedLocations[i];
                    }
                }
            }

            throw new Exception("You didn't cross your own path!");
        }
    }
}