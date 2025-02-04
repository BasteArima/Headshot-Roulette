using _Project.Scripts.Signals;
using Dialogues.Scriptables;
using Dialogues.Signals;
using UniRx;
using UnityEngine;
using UnityEngine.Playables;

namespace _Project.Scripts
{
    public class CoreBootstrap : MonoBehaviour
    {
        [SerializeField] private PlayableDirector _introDirector;
        [SerializeField] private DialogueData _toStartGameDialog;
        [SerializeField] private bool _needIntro = true;
        
        private void Awake()
        {
            MessageBroker.Default
                .Receive<EndDialogueSignal>()
                .Subscribe(OnDialogueEnd)
                .AddTo(gameObject);
        }

        private void Start()
        {
            if (_needIntro)
                _introDirector.Play();
            else
                StartGame();
        }

        private void OnDialogueEnd(EndDialogueSignal endDialogueSignal)
        {
            if (endDialogueSignal.DialogueData == _toStartGameDialog)
                StartGame();
        }

        public void StartGame()
        {
            MessageBroker.Default.Publish(new StartCoreGameSignal());
        }
    }
}