﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mazes_for_Programmers.MazeAlgorithms
{
    public class BinaryTree : AlgorithmBase
    {
        public override IEnumerator On(MazeGrid grid, Tester tester)
        {
            Set unvisited = new Set();
            for (int x = 0; x < grid.columnCount; x++)
            {
                for (int y = 0; y < grid.rowCount; y++)
                {
                    unvisited.AddCell(grid[x, y]);
                    grid[x, y].colour = Color.black;
                }
            }

            for (int y = 0; y < grid.rowCount; y++)
            {
                for (int x = 0; x < grid.columnCount; x++)
                {
                    unvisited.RemoveCell(grid[x, y]);

                    // If current cell is in the north east corner
                    if (x == grid.columnCount-1 && y == 0)
                    {
                        continue;
                    }
                    // Else, if current cell is on the north edge
                    else if (y == 0)
                    {
                        grid[x, y].Link(grid[x + 1, y]);
                    }
                    // Else, if current cell is on the east edge
                    else if (x == grid.columnCount - 1)
                    {
                        grid[x, y].Link(grid[x, y - 1]);
                    }
                    else
                    {
                        if (Random.value >= 0.5f)
                            grid[x, y].Link(grid[x, y - 1]);
                        else
                            grid[x, y].Link(grid[x + 1, y]);
                    }
                    grid[x, y].colour = Color.red;
                    OnDraw(grid);
                    grid[x, y].colour = Color.white;
                    yield return new WaitForSeconds(tester.delayTime);
                }
            }
            OnComplete();
        }
    }
}
