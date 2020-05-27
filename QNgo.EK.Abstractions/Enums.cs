namespace QNgo.EK.Abstractions
{
    public enum TurnPhase
    {
        TurnStart,
        PlayerAction,
        Draw,
        TurnEnd
    }

    public enum PlayerActionType
    {
        DrawCard,
        PlayCard
    }

    public enum CardFamily
    {
        Bomb,
        Defuse,
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
        ImplodingBomb,
        TargetedAttack,
        AlterDeck,
        DrawBottom,
        Reverse,
        Filler6

    }
}
