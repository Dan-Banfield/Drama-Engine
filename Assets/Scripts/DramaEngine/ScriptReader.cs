using UnityEngine;
using Ink.Runtime;
using TMPro;

namespace DramaEngine
{
    public class ScriptReader : MonoBehaviour
    {
        #region Properties

        [Header("Story Files")]
        [SerializeField]
        private TextAsset inkJsonFile;
        [SerializeField]
        private Story storyScript;

        [Header("UI Components")]
        [SerializeField]
        private TextMeshProUGUI dialogueTextComponent;
        [SerializeField]
        private TextMeshProUGUI nameTextComponent;

        #endregion

        void Start()
        {
            LoadStory();
            ProceedStory();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) { HandleMouseClicks(); return; }
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) { HandleTouchInput(); return; }
        }

        private void HandleMouseClicks()
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

            ProceedStory();
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount <= 0) return;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    ProceedStory();
                    break;
            }
        }

        private void LoadStory()
        {
            storyScript = new Story(inkJsonFile.text);
        }

        public void ProceedStory()
        {
            if (!storyScript.canContinue)
            {
                EndStory();
                return;
            }

            string dialogue = storyScript.Continue().Trim();
            UpdateDialogue(dialogue);
        }

        private void UpdateDialogue(string dialogue)
        {
            dialogueTextComponent.text = dialogue;
        }

        public void EndStory()
        {
            dialogueTextComponent.text = "The story has come to and end.";
        }
    }
}

