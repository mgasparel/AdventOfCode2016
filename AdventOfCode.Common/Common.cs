using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Common
    {
        public static Dictionary<char, Direction> Directions = new Dictionary<char, Direction>
        {
            ['U'] = Direction.North,
            ['R'] = Direction.East,
            ['D'] = Direction.South,
            ['L'] = Direction.West
        };

        public static Direction Turn(Direction currentDirection, char turn)
        {
            if (turn == 'R')
            {
                return currentDirection == Direction.West
                    ? Direction.North
                    : currentDirection + 1;
            }
            else
            {
                return currentDirection == Direction.North
                    ? Direction.West
                    : currentDirection - 1;
            }
        }

        public static void Move(Coordinate position, Direction direction, int distance, byte?[][] bounds = null)
        {
            Coordinate newPosition = new Coordinate(position);

            switch (direction)
            {
                case Direction.North:
                    newPosition.X += distance;
                    break;
                case Direction.East:
                    newPosition.Y += distance;
                    break;
                case Direction.South:
                    newPosition.X -= distance;
                    break;
                case Direction.West:
                    newPosition.Y -= distance;
                    break;
                default:
                    break;
            }

            if(IsWithinBounds(newPosition, bounds))
            {
                position.X = newPosition.X;
                position.Y = newPosition.Y;
            }

        }

        private static bool IsWithinBounds(Coordinate position, byte?[][] bounds = null)
        {
            if (bounds == null) return true;

            if(position.X < 0 ||
                position.X > bounds.Length - 1 ||
                position.Y < 0 ||
                position.Y > bounds[0].Length - 1)
            {
                return false;
            }

            return bounds[position.X][position.Y] != null;
        }

        public static string[] GetLines(string input)
        {
            return Regex.Split(input, @"\r\n");
        }
    }
}
