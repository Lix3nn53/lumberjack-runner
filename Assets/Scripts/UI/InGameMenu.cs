using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lix.Core;

namespace Lix.LumberjackRunner
{
  public class InGameMenu : MonoBehaviour
  {
    public GameObject Panel;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private Slider trackProgress;
    [SerializeField] private Transform finishLocation;
    private GameManager gameManager;
    private PlayerMovement playerMovement;

    private void Start()
    {
      gameManager = DIContainer.GetService<GameManager>();

      gameManager.OnCurrentCoinValueChangeEvent += OnCoinValueChange;

      coinText.text = gameManager.CurrentCoins.ToString();

      playerMovement = DIContainer.GetService<PlayerMovement>();

      playerMovement.OnPlayerMoveEvent += OnPlayerMove;
    }

    public void OnCoinValueChange(int amount)
    {
      coinText.text = gameManager.CurrentCoins.ToString();
    }

    // TODO Fix slider stuttering
    // private void Update()
    // {
    //   trackProgress.value = playerMovement.transform.position.z / finishLocation.position.z;
    //   // float target = playerMovement.transform.position.z / finishLocation.position.z;
    //   // trackProgress.value = Mathf.Lerp(trackProgress.value, target, Time.deltaTime);
    // }

    // NOT USING THIS because FixedUpdate is too laggy for UI
    public void OnPlayerMove(Vector3 position)
    {
      trackProgress.value = playerMovement.transform.position.z / finishLocation.position.z;
    }

    private void OnDisable()
    {
      gameManager.OnCurrentCoinValueChangeEvent -= OnCoinValueChange;
      playerMovement.OnPlayerMoveEvent -= OnPlayerMove;
    }
  }
}