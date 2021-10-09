using UnityEngine;

// North=0, East=1, South=2, West=3
public enum MazeDirection
{
    North,
    East,
    South,
    West
}

public static class MazeDirections
{
    public const int Count = 4;                          // The number of directions in the maze is set constant

    // Return random cardinal direction
    public static MazeDirection GetRandomDirection ()
    {
        return (MazeDirection)Random.Range(0, Count);    // Return a random integer between 0 (inclusive) and Count (exclusive) and cast to MazeDirection enum
    }

    // Vector directions
    private static IntVector2[] directionVectors =
    {
        new IntVector2(0, 1),       // North
        new IntVector2(1, 0),       // East
        new IntVector2(0, -1),      // South
        new IntVector2(-1, 0)       // West
    };

    // Return vector direction
    public static IntVector2 DirectionToIntVector2 (this MazeDirection direction)
    {
        return directionVectors[(int)direction];
    }
}