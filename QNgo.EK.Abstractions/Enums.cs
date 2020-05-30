namespace QNgo.EK.Abstractions
{
    public enum TurnPhase
    {
        TurnStart,
        PlayerAction,
        TurnEnd,
        Elimination,
        GameEnd
    }

    public enum PlayerActionType
    {
        DrawCard,
        PlayCard
    }

    public enum CardFamily
    {
        Lose,
        ExtraLife,
        Nope,
        Skip,
        Attack,
        Shuffle,
        Favor,
        PeekDeck,
        Filler1,
        Filler2,
        Filler3,
        Filler4,
        Filler5,
        LoseExtra,
        TargetedAttack,
        AlterDeck,
        DrawBottom,
        Reverse,
        FillerWildcard,
        Destruction,
        HideEnd,
        SkipAll,
        Return,
        PeekDeckExtra,
        LockCard,
        SwapTopBottom,
        AlterDeckExtra,
        Blind
    }
}
