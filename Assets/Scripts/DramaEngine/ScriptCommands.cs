using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DramaEngine
{
    public class ScriptCommands : MonoBehaviour
    {
        #region Properties

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

        public void UpdateDialogue(string dialogue)
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

            StartCoroutine(FadeInAudioSource(backgroundMusicAudioSource, fadeTime, 0.8f));
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
    }
}
