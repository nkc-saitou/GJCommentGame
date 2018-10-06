using UnityEngine;

public static class WordImage
{
    public static Color TypeToColor(WordType type)
    {
        switch (type)
        {
            case WordType.Troll:  return Color.red;
            case WordType.Normal: return Color.white;
        }
        return Color.black;
    }
}
