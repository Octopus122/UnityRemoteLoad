using Infrastructure.States;
using UI;
using UnityEngine;

namespace Infrastructure
{
    public class GameBootStrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Curtain);
            _game.StateMachine.Enter<BootstrapState>();
            Debug.Log("Enter BootStrapState");
            DontDestroyOnLoad(this);
        }
    }
}

