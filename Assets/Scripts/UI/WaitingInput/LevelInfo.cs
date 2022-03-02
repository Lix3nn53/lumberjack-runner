using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] Color currentLevelColor;
    [SerializeField] Slider slider;
    [SerializeField] Image[] levelImages;

    // Start is called before the first frame update
    void Start()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex - 1;

        levelImages[currentLevelIndex].color = currentLevelColor;

        slider.value = 0.25f * currentLevelIndex;
    }
}
