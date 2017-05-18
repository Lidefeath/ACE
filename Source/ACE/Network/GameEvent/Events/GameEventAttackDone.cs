namespace ACE.Network.GameEvent.Events
{
    public class GameEventAttackDone : GameEventMessage
    {
        public GameEventAttackDone(Session session, uint objectId, uint numberOfAttacks)
            : base(GameEventType.AttackDone, GameMessageGroup.Group09, session)
        {
            Writer.Write(numberOfAttacks);
        }
    }
}
