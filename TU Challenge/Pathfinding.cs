using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{

    public class Pathfinding
    {

        //public class path
        //{
        //    Vector2 _start;
        //    Vector2 _destination;
        //    Dictionary<Vector2, Vector2> _breadthResult;


        //    public path(Vector2 start, Vector2 destination, Dictionary<Vector2, Vector2> breadthResult)
        //    {
        //        _start = start;
        //        _destination = destination;
        //        _breadthResult = breadthResult;
        //    }

        //    public bool IsComplete(Vector2 start, Vector2 destination)
        //    {
        //        return true;
        //    }

        //    
        //    //public bool IsComplete(Vector2 start, Vector2 destination)
        //    //{

        //    //}
        //}

        public List<Vector2> CompletePath { get; private set; }

        public char[,] Grid { get; private set; }

        private List<Vector2> neighboors = new List<Vector2>();

        public Pathfinding(string map)
        {
            string[] parts = map.Split('\n');


            Grid = new char[parts.Length , parts[0].Length];

            for(int i = 0; i < parts.Length; i++)
            {
                for(int j = 0; j < parts[0].Length; j++)
                {
                    Grid[i, j] = parts[i][j];
                }
            }

        }
        public bool IsOutOfBound(Vector2 vector2)
        {
            if (vector2.X < 0 || vector2.Y < 0 || vector2.X >= Grid.GetLength(0) || vector2.Y >= Grid.GetLength(1))
                return true;
            return false;
        }

        public int GetNeighboors(Vector2 vector2)
        {
            Vector2[] neigbourgCoord = {new Vector2(0,1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(1, 1), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(-1, 1) };

            int result = 0;

            for(int i = 0; i <neigbourgCoord.Length; i++)
            {
                Vector2 neighboor = new Vector2(vector2.X + neigbourgCoord[i].X, vector2.Y + neigbourgCoord[i].Y);
                if (!IsOutOfBound(neighboor))
                {
                    if(Grid[neighboor.X, neighboor.Y] != 'X')
                    {
                        result++;
                        neighboors.Add(neighboor);
                    }
                }
            }
            return result;
        }

        public int GetNeighboors(Vector2 vector2, List<Vector2> exclude)
        {
            Vector2[] neigbourgCoord = { new Vector2(0, 1), new Vector2(0, -1), new Vector2(1, 0), new Vector2(-1, 0), new Vector2(1, 1), new Vector2(-1, -1), new Vector2(1, -1), new Vector2(-1, 1) };

            int result = 0;

            for (int i = 0; i < neigbourgCoord.Length; i++)
            {
                Vector2 neighboor = new Vector2(vector2.X + neigbourgCoord[i].X, vector2.Y + neigbourgCoord[i].Y);
                if (!IsOutOfBound(neighboor))
                {
                    if (Grid[neighboor.X, neighboor.Y] != 'X')
                    {
                        result++;
                        neighboors.Add(neighboor);
                        foreach (Vector2 v in exclude)
                        {
                            if (v == new Vector2(vector2.X + neigbourgCoord[i].X, vector2.Y + neigbourgCoord[i].Y))
                            {
                                result--;
                                neighboors.Remove(neighboor);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool BreadthFirstSearch(Vector2 start, Vector2 destination)
        {
            Queue<Vector2> frontier = new Queue<Vector2>();
            Dictionary<Vector2, Vector2> cameFrom = new Dictionary<Vector2, Vector2>();
            frontier.Enqueue(start);
            cameFrom[start] = start;

            while (frontier.Count != 0)
            {
                Vector2 current = frontier.Peek();
                for (int i = 0; i < GetNeighboors(current); i++)
                {
                    if (!cameFrom.ContainsKey(neighboors[0]))
                    {
                        frontier.Enqueue(neighboors[0]);
                        cameFrom[neighboors[0]] = current;
                        neighboors.RemoveAt(0);
                    }
                    if(frontier.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        frontier.Dequeue();
                    }
                }
            }

            if (cameFrom.ContainsKey(destination) || cameFrom.ContainsValue(destination))
            {
                CompletePath = ReconstructPath(cameFrom, start, destination);
                return true;
            }
            return false;
        }

        public List<Vector2> ReconstructPath(Dictionary<Vector2, Vector2> breadthResult, Vector2 start, Vector2 destination)
        {
            Vector2 current = destination;
            List<Vector2> path = new List<Vector2>();

            while (current != start)
            {
                path.Add(current);
                current = breadthResult[current];
            }
            return path;
        }

        public char GetCoord(Vector2 el)
        {
            return Grid[el.X, el.Y];
        }



        //const string _map1 = "_____\n" +
    //                         "__X__\n" +
    //                         "_____";

        //const string _map2 = "_____\n" +
        //                     "__X__\n" +
        //                     "__X__\n" +
        //                     "__X__\n" +
        //                     "__X__";

        //const string _map3 = "__X__\n" +
        //                     "__X__\n" +
        //                     "__X__\n" +
        //                     "__X__\n" +
        //                     "__X__";
    }

}
