using System.Collections.Generic;
using UnityEngine;

namespace Dialogues.Scriptables
{
    [CreateAssetMenu(menuName = "Data/Dialogues/DialogueCharacter", fileName = "NewDialogueCharacter")]
    public class DialogueCharacter : ScriptableObject
    {
        [SerializeField] private string _characterNameKey;
        [SerializeField] private Gradient _namePanelGradient;
        [SerializeField] private List<SerializablePair<AvatarsEmotionTypes, Sprite>> _avatars;

        public string CharacterNameKey => _characterNameKey;
        public Gradient NamePanelGradient => _namePanelGradient;
        public List<SerializablePair<AvatarsEmotionTypes, Sprite>> Avatars => _avatars;
    }
}