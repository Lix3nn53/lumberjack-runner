using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lix.Core;


namespace Lix.LumberjackRunner
{
  public class FinishMenu : MonoBehaviour
  {
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private SplashScreen splashScreen;
    [SerializeField] private GameObject container;
    [SerializeField] private Button winButton;
    [SerializeField] private Button loseButton;

    private GameManager gameManager;


    private void Start()
    {
      container.SetActive(false);

      gameManager = DIContainer.GetService<GameManager>();

      gameManager.OnGameOverEvent += OnGameOver;
    }

    public void OnGameOver(bool isWin)
    {
      container.SetActive(true);
      if (isWin)
      {
        winButton.gameObject.SetActive(true);
        loseButton.gameObject.SetActive(false);
      }
      else
      {
        winButton.gameObject.SetActive(false);
        loseButton.gameObject.SetActive(true);
      }
    }

    public void LoadNextLevel()
    {
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
      sceneLoader.gameObject.SetActive(true);
      int sceneIndex = SceneManager.GetActiveScene().buildIndex;
      StartCoroutine(splashScreen.FadeImageAndLoad(false, sceneIndex));
    }

    private void OnDisable()
    {
      gameManager.OnGameOverEvent -= OnGameOver;
    }
  }
}