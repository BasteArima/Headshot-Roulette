using System.Linq;
using Cysharp.Threading.Tasks;
using Febucci.UI;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Dialogues.Scriptables;
using Dialogues.Signals;
using Dialogues.Types;

namespace Dialogues.Behaviours
{
    public class DialogueView : MonoBehaviour
    {
        [SerializeField] private TypewriterByCharacter _textTypewriterByCharacter;
        [SerializeField] private TMP_Text _characterName;
        [SerializeField] private Image _characterAvatar;
        [SerializeField] private Button _nextPhraseButton;
        [SerializeField] private Animator _nextPhraseIconTipAnimator;
        [SerializeField] private Animator _viewAnimator;

        [SerializeField] private int _delayForHideBeforeEventCall; // ms

        private DialogueData _dialogueData;
        private int _currentDialogueIndex;

        private void Awake()
        {
            _nextPhraseButton.onClick.AddListener(OnNextPhraseButton);
            _textTypewriterByCharacter.onTextShowed.AddListener(OnTextShowed);
        }

        private void OnNextPhraseButton()
        {
            if (_textTypewriterByCharacter.isShowingText)
                SkipTypewriting();
            else
                TryStartNextPhrase();
        }

        private void SkipTypewriting()
        {
            _textTypewriterByCharacter.SkipTypewriter();
        }

        private void TryStartNextPhrase()
        {
            _currentDialogueIndex++;

            if (_currentDialogueIndex < _dialogueData.Phrases.Length)
                ShowPhrase(_dialogueData.Phrases[_currentDialogueIndex]);
            else
                EndDialogue();
        }

        private void ShowPhrase(DialoguePhraseData phraseData)
        {
            _nextPhraseIconTipAnimator.gameObject.SetActive(false);
            _textTypewriterByCharacter.ShowText(phraseData.PhraseKey);
            _characterName.text = phraseData.Character.CharacterNameKey;
            if (null != phraseData.Character.Avatars)
            {
                _characterAvatar.gameObject.SetActive(true);
                var emotionSprite = phraseData.Character.Avatars.FirstOrDefault(x => 
                    x.Key == phraseData.Emotion).Value;
                _characterAvatar.sprite = emotionSprite;
            }
            else
            {
                _characterAvatar.gameObject.SetActive(false);
            }
        }

        private void OnTextShowed()
        {
            _nextPhraseIconTipAnimator.gameObject.SetActive(true);
        }

        private async void EndDialogue()
        {
            _viewAnimator.SetBool("IsShow", false);

            await UniTask.Delay(_delayForHideBeforeEventCall);

            MessageBroker.Default.Publish(new EndDialogueSignal()
            {
                DialogueData = _dialogueData
            });
        }

        public void StartDialogue(DialogueData dialogueData)
        {
            _dialogueData = dialogueData;
            _currentDialogueIndex = 0;
            MessageBroker.Default.Publish(new StartDialogueSignal()
            {
                DialogueData = _dialogueData
            });
            ShowPhrase(_dialogueData.Phrases[_currentDialogueIndex]);
            _viewAnimator.SetBool("IsShow", true);
        }

        public void Clear()
        {
            _dialogueData = null;
            _currentDialogueIndex = 0;
        }
    }
}