using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Lix.Core;



namespace Lix.LumberjackRunner
{
  public class FinishMenu : MonoBehaviour
  {
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameObject container;

    private GameManager gameManager;


    private void Start()
    {
      container.SetActive(false);

      gameManager = DIContainer.GetService<GameManager>();

      gameManager.OnGameOverEvent += OnGameOver;
    }

    public void OnGameOver()
    {
      container.SetActive(true);
    }

    public void LoadNextLevel()
    {
      sceneLoader.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
      gameManager.OnGameOverEvent -= OnGameOver;
    }
  }
}