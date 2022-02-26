using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class SceneLoader : MonoBehaviour
  {
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text percentText;

    private bool buttonPressed = false;

    private void Start()
    {
      IInputListener inputListener = DIContainer.GetService<IInputListener>();

      inputListener.GetAction(InputActionType.Move).performed += OnMovementInputPerformed;
    }

    public void Load(int sceneIndex)
    {
      StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
      if (loadingScreen != null)
      {
        loadingScreen.SetActive(true);
      }

      AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

      //Don't let the Scene activate until you allow it to
      operation.allowSceneActivation = false;

      //When the load is still in progress, output the Text and progress bar
      while (!operation.isDone)
      {
        // Loading = 0 - 0.9
        // Activation = 0.9 - 1.0
        float progress = Mathf.Clamp01(operation.progress / 0.9f);

        if (slider != null)
        {
          slider.value = progress;
        }
        if (percentText != null)
        {
          percentText.text = progress * 100f + "%";
        }

        // Check if the load has finished
        if (operation.progress >= 0.9f)
        {
          //Change the Text to show the Scene is ready
          percentText.text = "Press the space bar to continue";
          //Wait to you press the space key to activate the Scene
          if (buttonPressed)
            //Activate the Scene
            operation.allowSceneActivation = true; // operation is not done until this line is executed
        }

        Debug.Log(progress);
        yield return null;
      }
    }



    private void OnMovementInputPerformed(InputAction.CallbackContext context)
    {
      buttonPressed = true;
    }
  }
}