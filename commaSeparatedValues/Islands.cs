using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace problemSolving
{
    static class Islands
    {   
        static public void CountIslands(byte[,] source, char blackPixelNotation = 'O', char whitePixelNotation = 'x')
        {
            if (source == null || source.GetLength(0) == 0 || source.GetLength(1) == 0)
                throw new ArgumentException("Parameter can't be null or empty");

            List<blackDot> blackDotsList = new List<blackDot>();

            string picture = "";

            // building list of black dots and a captured picture
            for (int y = 0; y < source.GetLength(0); y++)
            {
                picture += Environment.NewLine;

                for (int x = 0; x < source.GetLength(1); x++)
                {
                    if (Convert.ToBoolean(source[y, x]) == false)
                    {                        
                        picture += whitePixelNotation;
                        continue;
                    }

                    blackDotsList.Add(new blackDot(x, y));

                    picture += blackPixelNotation;
                }
            }

            // connected blackDots are united in an islands and counted
            int islandCntr = 0;    

            foreach (var blackDot in blackDotsList)
            {
                if (blackDot.isMapped == false)
                {
                    islandCntr++;
                    islandMapper(blackDot, blackDotsList);
                }
            }

            WriteLine(picture);
            WriteLine($"\nI can see {islandCntr} islands here");
        }

        // next procedure starts exploratrion from a firstPoint and than maps an island with all other connected black dots
    
        static private void islandMapper(blackDot firstDot, List<blackDot> blackDotsList)
        {
            Queue<blackDot> unexploredDotsQueue = new Queue<blackDot>();
            unexploredDotsQueue.Enqueue(firstDot);
            

            while (unexploredDotsQueue.Count > 0)
            {
                blackDot currentDot = unexploredDotsQueue.Dequeue();
                neighbors neighborsOfCurrentDot = new neighbors(currentDot);

                exploreNeighbors(neighborsOfCurrentDot, blackDotsList, unexploredDotsQueue);

                currentDot.isMapped = true;
            } 
        }

        static private void exploreNeighbors(neighbors neighborsCoords, List<blackDot> blackDotsList, Queue<blackDot> unexploredDotsQueue)
        {
            foreach (neighborCoordinates neighbor in neighborsCoords)
            {
                if (blackDotsList.Any(dot => dot.y == neighbor.y && dot.x == neighbor.x && dot.isMapped == false && dot.isInQue == false))
                {
                    blackDot newUnexploredPartOfTheIsland = blackDotsList.Find(dot => dot.y == neighbor.y && dot.x == neighbor.x);
                    unexploredDotsQueue.Enqueue(newUnexploredPartOfTheIsland);
                    newUnexploredPartOfTheIsland.isInQue = true;
                }
            }
        }

        private class blackDot
        {
            public readonly int x, y;
            public bool isMapped, isInQue;
            
            public blackDot(int x, int y)
            {
                this.x = x;
                this.y = y;
                isMapped = false;
                isInQue = false;
            }
        }

        private class neighbors : IEnumerable
        {
            public readonly neighborCoordinates[] neighborsCoords;

            public neighbors(blackDot centerPoint)
            {
                neighborsCoords = new neighborCoordinates[4]
                {
                    new neighborCoordinates(centerPoint.y - 1, centerPoint.x),
                    new neighborCoordinates(centerPoint.y, centerPoint.x + 1),
                    new neighborCoordinates(centerPoint.y + 1, centerPoint.x),
                    new neighborCoordinates(centerPoint.y, centerPoint.x - 1)
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return neighborsCoords.GetEnumerator();
            }
        }

        private struct neighborCoordinates
        {
            public readonly int x, y;

            public neighborCoordinates(int y, int x)
            {
                this.x = x;
                this.y = y;
            }

        }
    }
}