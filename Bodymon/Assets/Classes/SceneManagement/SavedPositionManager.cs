using UnityEngine;
using System.Collections.Generic;

public static class SavedPositionManager // Static class to remember player positions per scene.
{

    public static Dictionary<int, Vector3> savedPositions = new Dictionary<int, Vector3>()
    {
        {
            4, new Vector3(-13.77f, 18.6f, -2)
        },
        {
            1, new Vector3(-13.6f,26f,-2)
        },
        {
            2, new Vector3(-13.6f,1.7f,-2)
        },
        {
            3, new Vector3(-13.6f,1.7f,-2)
        },
        {
            6, new Vector3(-6f, 40.6f, -2)
        },

    };
    public static int lastScene;
}