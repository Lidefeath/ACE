using ACE.Network.Sequence;
using ACE.Network.Motion;
using ACE.Entity;
using ACE.Network.Enum;

namespace ACE.Network.GameMessages.Messages
{
    public class GameMessageUpdateMotion : GameMessage
    {
       public GameMessageUpdateMotion(ObjectGuid animationTargetGuid, byte[] instance_timestamp, SequenceManager sequence, MotionState newState)
            : base(GameMessageOpcode.Motion, GameMessageGroup.Group0A)
        {
            Writer.WriteGuid(animationTargetGuid);
            // who is getting the message - the rest of the sequences are the target objects sequences -may be the same
            byte[] movement_instance;
            var server_control_timestamp = sequence.GetNextSequence(SequenceType.ObjectServerControl);
            
            if (!newState.IsAutonomous)
                movement_instance = sequence.GetNextSequence(SequenceType.ObjectMovement);
            else
                movement_instance = sequence.GetCurrentSequence(SequenceType.ObjectMovement);

            Writer.Write(instance_timestamp);
            Writer.Write(server_control_timestamp);
            Writer.Write(movement_instance);
            
            ushort autonomous;
            if (newState.IsAutonomous)
                autonomous = 1;
            else
                autonomous = 0;
            Writer.Write(autonomous);
            var movementData = newState.GetPayload(animationTargetGuid, sequence);
            Writer.Write(movementData);
            Writer.Align();
        }
    }
}
