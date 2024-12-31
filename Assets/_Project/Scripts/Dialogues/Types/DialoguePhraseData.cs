using Dialogues.Scriptables;

namespace Dialogues.Types
{
    [System.Serializable]
    public struct DialoguePhraseData
    {
        public DialogueCharacter Character;
        public AvatarsEmotionTypes Emotion;
        public string PhraseKey;
    }
}