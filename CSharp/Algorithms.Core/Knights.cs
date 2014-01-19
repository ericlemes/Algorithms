using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Core
{
    public class Knights
    {

        private static readonly List<KeyValuePair<int, int>> possibleMoves = new List<KeyValuePair<int, int>>(){
            {new KeyValuePair<int, int>(1, 2)},
            {new KeyValuePair<int, int>(-1, -2)},
            {new KeyValuePair<int, int>(-1, 2)},
            {new KeyValuePair<int, int>(1, -2)},
            {new KeyValuePair<int, int>(2, 1)},
            {new KeyValuePair<int, int>(-2, -1)},
            {new KeyValuePair<int, int>(-2, 1)},
            {new KeyValuePair<int, int>(2, -1)}
        };

        public static List<KeyValuePair<int, int>> FindKnightRoute(KeyValuePair<int, int> chessboardSize,
            KeyValuePair<int, int> initialPosition, KeyValuePair<int, int> finalPosition)
        {
            bool[,] visited = new bool[chessboardSize.Key, chessboardSize.Value];

            if (!InRange(visited, initialPosition))
                return null;

            Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> parents = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>>();            

            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            q.Enqueue(initialPosition);
            visited[initialPosition.Key, initialPosition.Value] = true;

            while (q.Count > 0)
            {
                KeyValuePair<int, int> pair = q.Dequeue();
                if (pair.Key == finalPosition.Key && pair.Value == finalPosition.Value)
                    return FormatSolution(parents, pair);

                foreach (KeyValuePair<int, int> possibleMove in possibleMoves)
                {
                    KeyValuePair<int, int> nextMove = new KeyValuePair<int, int>(pair.Key + possibleMove.Key, pair.Value + possibleMove.Value);
                    if (!InRange(visited, nextMove))
                        continue;
                    if (!visited[nextMove.Key, nextMove.Value])
                    {
                        q.Enqueue(nextMove);
                        visited[nextMove.Key, nextMove.Value] = true;
                        parents.Add(nextMove, pair);
                    }
                }
            }
            return null;
        }

        private static List<KeyValuePair<int, int>> FormatSolution(Dictionary<KeyValuePair<int, int>, KeyValuePair<int, int>> parents, KeyValuePair<int, int> pair)
        {
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();
            
            KeyValuePair<int, int> tmp = pair;
            while (parents.ContainsKey(tmp))
            {
                result.Add(tmp);
                tmp = parents[tmp];
            }
            result.Reverse();
            return result;
        }

        public static bool InRange(bool[,] chessboard, KeyValuePair<int, int> position)
        {
            if (position.Key < 0 || position.Key > chessboard.GetLength(0) - 1)
                return false;
            if (position.Value < 0 || position.Value > chessboard.GetLength(1) - 1)
                return false;
            return true;
        }

    }
}
