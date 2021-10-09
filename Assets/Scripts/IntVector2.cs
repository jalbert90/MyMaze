using UnityEngine;

[System.Serializable]     // View IntVector2 structs in the inspector window
public struct IntVector2
{
    public int x, z;      // Hold x and z here

    // Constructor
    // Each IntVector2 will have an x-component and a z-component
    // new IntVector2(x, z)
    public IntVector2 (int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    // Define + operator for IntVector2
    public static IntVector2 operator +(IntVector2 a, IntVector2 b)
    {
        a.x += b.x;
        a.z += b.z;
        return a;
    }
}