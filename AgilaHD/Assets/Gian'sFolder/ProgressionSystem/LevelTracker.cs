using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If you beleive that this is not cursed... then it is not cursed
/// This script tracks level progress. That's about it.
/// The eagle calls this, because of course it does
/// </summary>
public static class LevelTracker
{
    private static int lastLevelLoaded = new();

    public static void updateLevelLoaded(int level)
    {
        lastLevelLoaded = level;
    }

    public static int getLastLevel()
    {
        return lastLevelLoaded;
    }
}
