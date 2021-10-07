using UnityEngine;

public class Maze : MonoBehaviour
{
    public IntVector2 size;
    public MazeCell[,] cells;
    public MazeCell cellPrefab;

    // generate the maze for the mazeInstance
    public void Generate ()
    {
        cells = new MazeCell[size.x, size.z];   // Create space to hold cells

        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.z; z++)
            {
                CreateCell(x, z);
            }
        }
    }

    private void CreateCell(int x, int z)
    {
        cells[x, z] = Instantiate(cellPrefab) as MazeCell;  // Assign a MazeCell to (x, z)
        cells[x, z].transform.parent = transform;   // Make each MazeCell a child of Maze
        cells[x, z].name = "Cell (" + x + ", " + z + ")";
        cells[x, z].coordinates.x = x;  // Assign x-coordinate
        cells[x, z].coordinates.z = z;  // Assign z-coordinate
        cells[x, z].transform.localPosition = new Vector3(x - size.x * 0.5f + 0.5f, 0, z - size.z * 0.5f + 0.5f);   // Center cells around Maze as local (0,0,0)
    }
}
