using Infrastructure.Services.FlutterMessageService;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IFlutterMessageService _flutterMessageService;
        public GameLoopState(GameStateMachine gameStateMachine, IFlutterMessageService flutterMessageService)
        {
            _flutterMessageService = flutterMessageService;
        }

        public void Enter()
        {
            _flutterMessageService.EnterGameLoop();
        }

        public void Exit()
        {
        }
    }
}