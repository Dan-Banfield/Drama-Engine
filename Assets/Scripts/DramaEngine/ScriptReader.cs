using UnityEngine;
using Ink.Runtime;

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

        [Header("Scripts")]
        [SerializeField]
        private ScriptCommands scriptCommands;

        #endregion

        private void Awake()
        {
            LoadStory();
        }

        void Start()
        {
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
            BindExternalFunctions();
        }

        private void BindExternalFunctions()
        {
            storyScript.BindExternalFunction("name", (string speakerName) => scriptCommands.ChangeSpeakerName(speakerName));
            storyScript.BindExternalFunction("bgm", (string backgroundMusic, float fadeTime) => scriptCommands.PlayBackgroundMusic(backgroundMusic, fadeTime));
            storyScript.BindExternalFunction("sfx", (string soundEffect) => scriptCommands.PlaySoundEffect(soundEffect));
            storyScript.BindExternalFunction("bg", (string backgroundImage) => scriptCommands.ChangeBackgroundImage(backgroundImage));
            storyScript.BindExternalFunction("fin", () => scriptCommands.FadeIn());
            storyScript.BindExternalFunction("fout", () => scriptCommands.FadeOut());
        }

        public void ProceedStory()
        {
            if (!storyScript.canContinue)
            {
                EndStory();
                return;
            }

            string dialogue = storyScript.Continue().Trim();
            scriptCommands.UpdateDialogue(dialogue);
        }

        public void EndStory()
        {
            scriptCommands.ChangeSpeakerName("???");
            scriptCommands.UpdateDialogue("The story has come to an end.");
        }
    }
}
