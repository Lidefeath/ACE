using ACE.Network.Enum;

namespace ACE.Network.GameAction.Actions
{
    public static class GameActionCancelAttack
    {
        [GameAction(GameActionType.CancelAttack)]
        public static void Handle(ClientMessage message, Session session)
        {
            // session.Player.SetCombatMode(CombatMode.Peace); => this is wrong, gotta break the attack animation here
        }
    }
}
