using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public IntVector2 coordinates;     // (x,z)

    private MazeCellEdge[] edges;      // Store the edges of each MazeCell here. Ex) a quad will have 4 edges
}
