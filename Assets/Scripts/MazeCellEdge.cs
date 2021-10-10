using UnityEngine;

public class MazeCellEdge : MonoBehaviour
{
    private MazeCell cell, otherCell;     // Each MazeCellEdge will be between cell and otherCell
    private MazeDirection direction;      // Direction to get from the first cell to the second cell

    // Pass in first cell, second cell, and direction to get from first cell to second cell
    public void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        this.cell = cell;                                                     // First cell
        this.otherCell = otherCell;                                           // Second cell
        this.direction = direction;                                           // Direction to get from cell to otherCell

        transform.parent = cell.transform;                                    // Set the parent of the MazeCellEdge to the first cell
        transform.localRotation = direction.DirectionToRotation();            // Rotate MazeCellEdge to appropriate position
    }
}
