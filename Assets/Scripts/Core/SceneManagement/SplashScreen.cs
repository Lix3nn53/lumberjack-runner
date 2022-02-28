using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lix.Core
{
  public class SplashScreen : MonoBehaviour
  {
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private int sceneIndex;
    private Image img;

    private void Awake()
    {
      img = GetComponent<Image>();
    }

    void Start()
    {
      StartCoroutine(FadeImage(false));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
      // fade from opaque to transparent
      if (fadeAway)
      {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
          // set color with i as alpha
          img.color = new Color(1, 1, 1, i);
          yield return null;
        }
      }
      // fade from transparent to opaque
      else
      {
        float increment = 0.4f;
        // loop over 1 second
        for (float i = 0; i <= 1; i += increment * Time.deltaTime)
        {
          // set color with i as alpha
          img.color = new Color(1, 1, 1, i);
          yield return new WaitForSeconds(increment * Time.deltaTime);
        }
      }

      sceneLoader.Load(sceneIndex);
    }
  }
}