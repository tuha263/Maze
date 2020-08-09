using strange.extensions.mediation.impl;

namespace Player
{
    public class PlayerMediator : Mediator
    {
        [Inject] public PlayerView view { get; set; }

        public override void OnRegister()
        {
            view.Init();
        }
    }
}