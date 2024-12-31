using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;
using Dialogues.Scriptables;
using Dialogues.Signals;

namespace Dialogues.Behaviours
{
    public class DialogueController : MonoBehaviour
    {
        [SerializeField] private DialogueView _dialogueView;

        private void Awake()
        {
            MessageBroker.Default
                .Receive<EndDialogueSignal>()
                .Subscribe(OnDialogueEnd)
                .AddTo(gameObject);
        }

        private void OnDialogueEnd(EndDialogueSignal endDialogueSignal)
        {
            _dialogueView.Clear();
            _dialogueView.gameObject.SetActive(false);
        }

        [Button]
        public void StartDialogue(DialogueData dialogueData)
        {
            _dialogueView.gameObject.SetActive(true);
            _dialogueView.StartDialogue(dialogueData);
        }
    }
}