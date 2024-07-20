using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static List<Color> availableColors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow };
    private static List<Color> initialColors = new List<Color> { Color.red, Color.green, Color.blue, Color.yellow };

    public static Color GetAndRemoveColor()
    {
        if (availableColors.Count == 0)
        {
            // Reset the availableColors list when all colors are assigned
            availableColors = new List<Color>(initialColors);
        }

        Color assignedColor = availableColors[0];
        availableColors.RemoveAt(0);
        return assignedColor;
    }
}