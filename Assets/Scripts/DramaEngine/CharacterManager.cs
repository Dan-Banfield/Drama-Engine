using UnityEngine;

namespace DramaEngine
{
    public class CharacterManager : MonoBehaviour
    {
        #region Properties

        [Header("Characters")]
        [SerializeField]
        private GameObject characterOne;
        [SerializeField]
        private GameObject characterTwo;
        [SerializeField]
        private GameObject characterThree;

        #endregion

        public void ShowCharacter(int characterIndex)
        {
            switch (characterIndex)
            {
                case 1:
                    characterOne.SetActive(true);
                    break;
                case 2:
                    characterTwo.SetActive(true);
                    break;
                case 3:
                    characterTwo.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        public void HideCharacter(int characterIndex)
        {
            switch (characterIndex)
            {
                case 1:
                    characterOne.SetActive(false);
                    break;
                case 2:
                    characterTwo.SetActive(false);
                    break;
                case 3:
                    characterTwo.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }
}
