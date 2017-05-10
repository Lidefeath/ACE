using ACE.Entity;
using ACE.Network.Enum;

namespace ACE.Network.GameMessages.Messages
{
    public class GameMessagePrivateUpdateInstanceId : GameMessage
    {
        public GameMessagePrivateUpdateInstanceId(ObjectGuid currentAttackerGuid)
            : base(GameMessageOpcode.UpdateInstanceIdCharacterLink, GameMessageGroup.Group09)
        {
            // TODO: research - could these types of sends be generalized by payload type?   for example GameMessageInt
            Writer.Write((byte)1);  // wts
            Writer.Write((uint)LinkProperty.CurrentAttacker);
            Writer.Write(currentAttackerGuid.Full);
            // Writer.Align();
        }
    }
}
