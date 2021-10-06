using UnityEngine;

[System.Serializable] // view IntVector2 structs in the inspector window
public struct IntVector2
{
    public int x, z;

    IntVector2 (int x, int z)
    {
        this.x = x;
        this.z = z;
    }
}