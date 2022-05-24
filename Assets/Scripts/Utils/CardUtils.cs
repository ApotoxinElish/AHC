namespace AHC
{
    /// <summary>
    /// Miscellaneous card-related utilities.
    /// </summary>
    public static class CardUtils
    {
        public static bool CardCanBePlayed(CardTemplate card, IntVariable playerResource)
        {
            // The player can only play a card if it has a cost that is lower or
            // equal to the player's available resource.
            return card.Cost <= playerResource.Value;
        }

        // public static bool CardHasTargetableEffect(CardTemplate card)
        // {
        //     // Checks if the card contains an effect that targets a specific enemy.
        //     // This is used to determine whether the targeting arrow needs to be
        //     // enabled or not.
        //     return false;
        // }
    }
}
