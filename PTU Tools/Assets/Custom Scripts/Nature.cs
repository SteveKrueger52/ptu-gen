using UnityEngine;
using System.Collections;

/// <summary>
/// A Pokemon Nature. There are 36 Natures total, 
/// each raising one stat and lowering another.
/// </summary>
///
/// The numeric value of the Nature identifies 
/// which stats are raised or lowered:
///   Raised stat  = [(floor(id / 6)) % 6]
///   Lowered stat = [id % 6]
/// 
///    HP = 0
///   ATK = 1
///   DEF = 2
/// SPATK = 3
/// SPDEF = 4
///   SPD = 5
public enum Nature
{
    /// [+ HP, - HP] - Neutral
    COMPOSED = 0,
    /// [+ HP, - ATK]
    CUDDLY = 1,
    /// [+ HP, - DEF]
    DISTRACTED = 2,
    /// [+ HP, - SpATK]
    PROUD = 3,
    /// [+ HP, - SpDEF]
    DECISIVE = 4,
    /// [+ HP, - SPD]
    PATIENT = 5,

    /// [+ ATK, - HP]
    DESPERATE = 6,
    /// [+ ATK, - ATK] - Neutral
    HARDY = 7,
    /// [+ ATK, - DEF]
    LONELY = 8,
    /// [+ ATK, - SpATK]
    ADAMANT = 9,
    /// [+ ATK, - SpDEF]
    NAUGHTY = 10,
    /// [+ ATK, - SPD]
    BRAVE = 11,

    /// [+ DEF, - HP]
    STARK = 12,
    /// [+ DEF, - ATK]
    BOLD = 13,
    /// [+ DEF, - DEF] - Neutral
    DOCILE = 14,
    /// [+ DEF, - SpATK]
    IMPISH = 15,
    /// [+ DEF, - SpDEF]
    LAX = 16,
    /// [+ DEF, - SPD]
    RELAXED = 17,

    /// [+ SpATK, - HP]
    CURIOUS = 18,
    /// [+ SpATK, - ATK]
    MODEST = 19,
    /// [+ SpATK, - DEF]
    MILD = 20,
    /// [+ SpATK, - SpATK] - Neutral
    BASHFUL = 21,
    /// [+ SpATK, - SpDEF]
    RASH = 22,
    /// [+ SpATK, - SPD]
    QUIET = 23,

    /// [+ SpDEF, - HP]
    DREAMY = 24,
    /// [+ SpDEF, - ATK]
    CALM = 25,
    /// [+ SpDEF, - DEF]
    GENTLE = 26,
    /// [+ SpDEF, - SpATK]
    CAREFUL = 27,
    /// [+ SpDEF, - SpDEF] - Neutral
    QUIRKY = 28,
    /// [+ SpDEF, - SPD]
    SASSY = 29,

    /// [+ SPD, - HP]
    SKITTISH = 30,
    /// [+ SPD, - ATK]
    TIMID = 31,
    /// [+ SPD, - DEF]
    HASTY = 32,
    /// [+ SPD, - SpATK]
    JOLLY = 33,
    /// [+ SPD, - SpDEF]
    NAIVE = 34,
    /// [+ SPD, - SPD] - Neutral
    SERIOUS = 35

}

/// A static utility class for Pokémon Natures.
public static class Natures
{
    private static string[] natureStrings = 
        new string[36]{"Composed" ,"Cuddly","Distracted","Proud"  ,"Decisive","Patient",
                       "Desperate","Hardy" ,"Lonely"    ,"Adamant","Naughty" ,"Brave"  ,
                       "Stark"    ,"Bold"  ,"Docile"    ,"Impish" ,"Lax"     ,"Relaxed",
                       "Curious"  ,"Modest","Mild"      ,"Bashful","Rash"    ,"Quiet"  ,
                       "Dreamy"   ,"Calm"  ,"Gentle"    ,"Careful","Quirky"  ,"Sassy"  ,
                       "Skittish" ,"Timid" ,"Hasty"     ,"Jolly"  ,"Naive"   ,"Serious"};

   
    /// Generates a random Nature from the 32 possible natures.
    public static Nature generateNature ()
    {
        return (Nature)Random.Range (0, 36);
    }

    /// Gets the lowered stat of the given Nature.
    public static int getLoweredStat (Nature n)
    {
        return ((int)n % 6);
    }

    /// Gets the raised stat of the given Nature.
    public static int getRaisedStat (Nature n)
    {
        return (Mathf.FloorToInt ((float)n / 6f) % 6);
    }

    /// Is the given Nature neutral?
    /// That is, does it raise and lower the same stat?
    public static bool isNeutralStat (Nature n)
    {
        return getLoweredStat (n) == getRaisedStat (n);
    }

    /// Returns a string of the given Nature.
    public static string toString(Nature n)
    {
        return natureStrings [(int) n];
    }
        
}
