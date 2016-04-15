using UnityEngine;
using System.Collections;

/// The six basic Stats in PTU:
/// HP, ATK, DEF, SpATK, SpDEF, and SPD
public enum Stat {HP = 0, ATK = 1, DEF = 2, SpATK = 3, SpDEF = 4, SPD = 5}

/// A static utility class for Stats.
public static class Stats {
    private static string[] statStrings = new string[6] {"HP","ATK", "DEF", "SpATK", "SpDEF", "SPD"};

    /// Returns a string of the given Stat.
    public static string toString(Stat s)
    {
        return statStrings [(int) s];
    }
}