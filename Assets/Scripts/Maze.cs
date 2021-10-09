using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour
{
    public IntVector2 size;
    public MazeCell[,] cells;
    public MazeCell cellPrefab;
    public float stepDelay;
    private int currentIndex;
    private List<MazeCell> activeCells;

    // generate the maze for the mazeInstance
    public IEnumerator Generate ()
    {
        cells = new MazeCell[size.x, size.z];   // Create space to hold cells in 2D-array
        activeCells = new List<MazeCell>(); // Create space to hold list
        var delay = new WaitForSeconds(stepDelay);

        FirstGenerationStep();
        while(activeCells.Count > 0)
        {
            yield return delay;
            NextGenerationSteps();
        }
    }

    // Create first MazeCell at random coordinates and add to list of active MazeCells
    private void FirstGenerationStep ()
    {
        activeCells.Add(CreateCell(RandomCoordinates()));
    }

    private void NextGenerationSteps ()
    {
        currentIndex = activeCells.Count - 1;   // Set currentIndex to last item added to the list
        IntVector2 coordinates = activeCells[currentIndex].coordinates; // Assign the current cell's coordinates from MazeCell to a temporary coordinates
        coordinates += MazeDirections.GetRandomDirection().DirectionToIntVector2(); // Move 1 cell North, East, South, or West

        if (ContainsCoordinates(coordinates))   // Checks that the coordinates are in the maze
        {
            if (GetCell(coordinates) == null)   // Checks that the current cell has not been visited
            {
                activeCells.Add(CreateCell(coordinates));   // Create cell and add to activeCells list
                currentIndex++; // Mark location of newly created cell by incrementing current index location
            }
            else // If cell has already been created
            {
                activeCells.RemoveAt(currentIndex); // Remove from activeCells list
                currentIndex--; // Decrement the current index location
            }
        }
    }

    // Returns true if IntVector2 coordinates are in the Maze
    private bool ContainsCoordinates (IntVector2 coordinates)
    {
        return coordinates.x >= 0 && coordinates.z >= 0 && coordinates.x < size.x && coordinates.z < size.z;
    }

    public MazeCell GetCell (IntVector2 coordinates)
    {
        return cells[coordinates.x, coordinates.z];
    }

    public IntVector2 RandomCoordinates ()
    {
        return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
    }

    private MazeCell CreateCell(IntVector2 coordinates)
    {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell; // Assign a MazeCell clone to newCell
        cells[coordinates.x, coordinates.z] = newCell;  // Assign the newCell to the 2D-array cells[x,z]
        cells[coordinates.x, coordinates.z].transform.parent = transform;   // Make each MazeCell a child of Maze
        cells[coordinates.x, coordinates.z].name = "Cell (" + coordinates.x + ", " + coordinates.z + ")";   // Name each MazeCell of the 2D-array
        cells[coordinates.x, coordinates.z].coordinates = coordinates;  // Assign coordinates to MazeCell

        // Center cells around Maze as local (0,0,0)
        cells[coordinates.x, coordinates.z].transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0, coordinates.z - size.z * 0.5f + 0.5f);

        return newCell;
    }
}
