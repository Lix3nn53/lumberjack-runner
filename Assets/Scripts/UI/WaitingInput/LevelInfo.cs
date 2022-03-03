using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
  [SerializeField] Color previousLevelColor;
  [SerializeField] Color currentLevelColor;
  [SerializeField] Slider slider;
  [SerializeField] Image[] levelImages;

  // Start is called before the first frame update
  void Start()
  {
    int currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;

    for (int i = 0; i < currentLevelIndex; i++)
    {
      levelImages[i].color = previousLevelColor;
    }
    levelImages[currentLevelIndex].color = currentLevelColor;

    slider.value = 0.33f * currentLevelIndex;
  }
}
