using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class DebugMenu : MonoBehaviour
  {
    [SerializeField] private GameObject FinishMenu;
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private SplashScreen splashScreen;

    public void LoadNextLevel()
    {
      FinishMenu.gameObject.SetActive(true);
      sceneLoader.gameObject.SetActive(true);

      int lastIndex = SceneManager.sceneCountInBuildSettings - 1;

      int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

      if (sceneIndex > lastIndex)
      {
        sceneIndex = 1;
      }

      StartCoroutine(splashScreen.FadeImageAndLoad(false, sceneIndex));
    }

    public void ReloadCurrentLevel()
    {
      FinishMenu.gameObject.SetActive(true);
      sceneLoader.gameObject.SetActive(true);
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      StartCoroutine(splashScreen.FadeImageAndLoad(false, sceneIndex));
    }
  }
}