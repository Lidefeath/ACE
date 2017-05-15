using ACE.Network;
using ACE.Network.Enum;
using System.IO;

namespace ACE.Entity
{
    public class MovementData
    {
        public MovementStateFlag MovementStateFlag { get; private set; } = 0;

        private uint currentStyle = 0;
        public uint CurrentStyle
        {
            get
            {
                return currentStyle;
            }
            set
            {
                currentStyle = value;
                MovementStateFlag |= MovementStateFlag.CurrentStyle;
            }
        }

        private uint forwardCommand = 0;
        public uint ForwardCommand
        {
            get
            {
                return forwardCommand;
            }
            set
            {
                forwardCommand = value;
                MovementStateFlag |= MovementStateFlag.ForwardCommand;
            }
        }

        private uint sideStepCommand = 0;
        public uint SideStepCommand
        {
            get
            {
                return sideStepCommand;
            }
            set
            {
                sideStepCommand = value;
                MovementStateFlag |= MovementStateFlag.SideStepCommand;
            }
        }

        private uint turnCommand = 0;
        public uint TurnCommand
        {
            get
            {
                return turnCommand;
            }
            set
            {
                turnCommand = value;
                MovementStateFlag |= MovementStateFlag.TurnCommand;
            }
        }

        private float turnSpeed = 0f;
        public float TurnSpeed
        {
            get
            {
                return turnSpeed;
            }
            set
            {
                turnSpeed = value;
                MovementStateFlag |= MovementStateFlag.TurnSpeed;
            }
        }

        private float forwardSpeed = 0f;
        public float ForwardSpeed
        {
            get
            {
                return forwardSpeed;
            }
            set
            {
                forwardSpeed = value;
                MovementStateFlag |= MovementStateFlag.ForwardSpeed;
            }
        }

        private float sideStepSpeed = 0f;
        public float SideStepSpeed
        {
            get
            {
                return sideStepSpeed;
            }
            set
            {
                sideStepSpeed = value;
                MovementStateFlag |= MovementStateFlag.SideStepSpeed;
            }
        }

        public void Serialize(BinaryWriter writer)
        {
            if ((this.MovementStateFlag & MovementStateFlag.CurrentStyle) != 0)
                writer.Write((uint)this.CurrentStyle);

            if ((this.MovementStateFlag & MovementStateFlag.ForwardCommand) != 0)
                writer.Write((uint)this.ForwardCommand);

            if ((this.MovementStateFlag & MovementStateFlag.ForwardSpeed) != 0)
                writer.Write((float)this.ForwardSpeed);

            if ((this.MovementStateFlag & MovementStateFlag.SideStepCommand) != 0)
                writer.Write((uint)this.SideStepCommand);

            if ((this.MovementStateFlag & MovementStateFlag.SideStepSpeed) != 0)
                writer.Write((float)this.SideStepSpeed);

            if ((this.MovementStateFlag & MovementStateFlag.TurnCommand) != 0)
                writer.Write((uint)this.TurnCommand);

            if ((this.MovementStateFlag & MovementStateFlag.TurnSpeed) != 0)
                writer.Write((float)this.TurnSpeed);
        }
    }
}