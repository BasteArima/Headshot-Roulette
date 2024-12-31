using Dialogues.Types;
using UnityEngine;

namespace Dialogues.Scriptables
{
    [CreateAssetMenu(menuName = "Data/Dialogues/DialogueData", fileName = "NewDialogue")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField] private DialoguePhraseData[] _phrases;

        public DialoguePhraseData[] Phrases => _phrases;
    }
}