using UnityEngine;
using DramaEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingSceneConfiguration : MonoBehaviour
{
    #region Properties

    [SerializeField]
    private GameObject loadingUI;

    [SerializeField] 
    private TMPro.TextMeshProUGUI versionLabel;
    [SerializeField]
    private Image backgroundImageComponent;

    #endregion

    void Awake()
    {
        InitializeScene();
    }

    private void InitializeScene()
    {
        UpdateBackgroundImage();
        UpdateVersionLabel();
        StartCoroutine(LoadingExample());
    }

    private void UpdateBackgroundImage()
    {
        backgroundImageComponent.sprite = Resources.Load<Sprite>("Images/Art/CoverArt");
    }

    private void UpdateVersionLabel()
    {
        versionLabel.text = VersionInfo.CurrentVersion.ToVersionString();
    }

    private IEnumerator LoadingExample()
    {
        ShowLoadingUI();

        yield return new WaitForSeconds(5);
        yield return SceneManager.LoadSceneAsync("StoryScene");

        CloseLoadingUI();
    }

    private void ShowLoadingUI()
    {
        loadingUI.SetActive(true);
    }

    private void CloseLoadingUI()
    {
        loadingUI.SetActive(false);
    }
}
