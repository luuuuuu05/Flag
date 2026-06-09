using UnityEngine;

public enum FlagRarity
{
    Common,
    Rare,
    Legendary
}

public class FlagType : MonoBehaviour
{
    [SerializeField] private FlagRarity rarity = FlagRarity.Common;

    public FlagRarity Rarity => rarity;

    public int GetScore()
    {
        return rarity switch
        {
            FlagRarity.Common => 10,
            FlagRarity.Rare => 20,
            FlagRarity.Legendary => 30,
            _ => 10
        };
    }

    public Color GetColor()
    {
        return rarity switch
        {
            FlagRarity.Common => Color.white,
            FlagRarity.Rare => Color.blue,
            FlagRarity.Legendary => Color.yellow,
            _ => Color.white
        };
    }
}