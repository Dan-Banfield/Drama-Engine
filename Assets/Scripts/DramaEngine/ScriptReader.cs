using System.Collections;
using UnityEngine.UI;
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

        [Header("Components")]
        [SerializeField]
        private AudioSource backgroundMusicAudioSource;
        [SerializeField]
        private AudioSource soundEffectAudioSource;
        [SerializeField]
        private Image backgroundImageComponent;

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

            BindExternalScriptFunctions();
        }

        private void BindExternalScriptFunctions()
        {
            storyScript.BindExternalFunction("name", (string speakerName) =>
            {
                ChangeSpeakerName(speakerName);
            },
            false);

            storyScript.BindExternalFunction("bgm", (string backgroundMusic, float fadeTime) =>
            {
                PlayBackgroundMusic(backgroundMusic, fadeTime);
            },
            false);

            storyScript.BindExternalFunction("sfx", (string soundEffect) =>
            {
                PlaySoundEffect(soundEffect);
            },
            false);

            storyScript.BindExternalFunction("bg", (string backgroundImage) =>
            {
                ChangeBackgroundImage(backgroundImage);
            },
            false);

            storyScript.BindExternalFunction("fin", () =>
            {
                FadeIn();
            },
            false);

            storyScript.BindExternalFunction("fout", () =>
            {
                FadeOut();
            },
            false);
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

        public void ChangeSpeakerName(string speakerName)
        {
            if (speakerName == "name")
            {
                nameTextComponent.text = PlayerGlobals.GetPlayerName();
                return;
            }
            nameTextComponent.text = speakerName;
        }

        public void PlayBackgroundMusic(string backgroundMusic, float fadeTime)
        {
            if (backgroundMusicAudioSource.isPlaying) backgroundMusicAudioSource.Stop();

            #region Code Block

            backgroundMusicAudioSource.clip = Resources.Load<AudioClip>("Audio/BackgroundMusic/" + backgroundMusic);
            backgroundMusicAudioSource.volume = 0;
            backgroundMusicAudioSource.Play();

            #endregion

            StartCoroutine(FadeInAudioSource(backgroundMusicAudioSource, fadeTime, 0.7f));
        }

        public void PlaySoundEffect(string soundEffect)
        {
            soundEffectAudioSource.PlayOneShot(Resources.Load<AudioClip>("Audio/SoundEffects/" + soundEffect));
        }

        public void ChangeBackgroundImage(string backgroundImage)
        {
            backgroundImageComponent.sprite = Resources.Load<Sprite>("Images/Backgrounds/" + backgroundImage);
        }

        public void FadeIn()
        {
            throw new System.NotImplementedException();
        }

        public void FadeOut()
        {
            throw new System.NotImplementedException();
        }

        private IEnumerator FadeInAudioSource(AudioSource audioSource, float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = 0;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }

            yield break;
        }

        public void EndStory()
        {
            ChangeSpeakerName("???");
            UpdateDialogue("The story has come to an end.");
        }
    }
}
