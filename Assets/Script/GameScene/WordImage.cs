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

    public static int TypeToDepth(WordType type)
    {
        switch (type)
        {
            case WordType.Troll: return 0;
            case WordType.Normal: return 5;
        }

        return 5;
    }
}
