using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Lix.Core;
using TMPro;

namespace Lix.LumberjackRunner
{
  public class WaitingInputMenu : MonoBehaviour
  {
    public GameObject Panel;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private float range = 120f;
    [SerializeField] private float endOffset = 20f;

    [SerializeField] [Range(0f, 4f)] private float lerpTime;
    [SerializeField] private RectTransform touchToStart;

    private float startX;

    private float endX;

    private float t;

    private bool forward = true;

    private GameManager gameManager;


    private void Start()
    {
      startX = touchToStart.anchoredPosition.x - range;
      endX = touchToStart.anchoredPosition.x + range + endOffset;

      gameManager = DIContainer.GetService<GameManager>();
      gameManager.OnTotalCoinValueChangeEvent += OnTotalCoinValueChange;

      coinText.text = gameManager.TotalCoins.ToString();
    }

    public void OnTotalCoinValueChange(int amount)
    {
      coinText.text = gameManager.TotalCoins.ToString();
    }

    private void OnDisable()
    {
      gameManager.OnTotalCoinValueChangeEvent -= OnTotalCoinValueChange;
    }

    private void Update()
    {
      if (forward)
      {
        t += lerpTime * Time.deltaTime;
      }
      else
      {
        t -= lerpTime * Time.deltaTime;
      }

      touchToStart.anchoredPosition = new Vector2(Mathf.SmoothStep(startX, endX, t), touchToStart.anchoredPosition.y);

      if (t >= 1)
      {
        forward = false;
      }
      else if (t <= 0)
      {
        forward = true;
      }
    }

  }
}