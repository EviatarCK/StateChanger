using System;

namespace HomeWorkState
{
    public class PlayerController
    {
        static void Main(string[] args)
        {
            PlayerController player = new PlayerController(new StandingState());
            player.GetKey();
            player.StateChanger();
            player.GetKey();
            player.GetKey();
            player.StateChanger();
            player.GetKey();
            player.StateChanger();
        }
        private PlayerControllerState _state;

        public PlayerController(PlayerControllerState state)
        {
            _state = state;
        }

        public void GetKey()
        {
            _state.PressKey(this);
        }

        public void StateChanger()
        {
            _state.ChangeStance(this);
        }

        public PlayerControllerState CurrentState
        {
            get { return _state; }
            set { _state = value; }
        }
    }


    public abstract class PlayerControllerState
    {
        public abstract void PressKey(PlayerController player);

        public abstract void ChangeStance(PlayerController player);
    }


    public class StandingState : PlayerControllerState
    {
        public StandingState()
        {
            Console.WriteLine("IM STANDING");
        }

        public override void PressKey(PlayerController player)
        {
            Console.WriteLine("UP Arrow was pressed");
        }

        public override void ChangeStance(PlayerController player)
        {
            player.CurrentState = new JumppingState();
        }
    }


    public class JumppingState : PlayerControllerState
    {
        public JumppingState()
        {
            Console.WriteLine("IM JUMPING");
        }

        public override void PressKey(PlayerController player)
        {
            player.CurrentState = new DivingState();
        }

        public override void ChangeStance(PlayerController player)
        {
            player.CurrentState = new DuckingState();
        }
    }


    public class DivingState : PlayerControllerState
    {
        public DivingState()
        {
            Console.WriteLine("IM DIVING");
        }

        public override void PressKey(PlayerController player)
        {
            player.CurrentState = new JumppingState();
        }

        public override void ChangeStance(PlayerController player)
        {
            player.CurrentState = new DuckingState();
        }
    }


    public class DuckingState : PlayerControllerState
    {
        public DuckingState()
        {
            Console.WriteLine("IM DUCKING");
        }

        public override void PressKey(PlayerController player)
        {
            Console.WriteLine("Down Arrow was pressed");
        }

        public override void ChangeStance(PlayerController player)
        {
            player.CurrentState = new StandingState();
        }
    }
}

