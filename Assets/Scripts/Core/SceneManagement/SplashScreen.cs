using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
      if (SceneManager.GetActiveScene().buildIndex == 0)
      {
        {
          if (fadeAway)
          {
            // fade from opaque to transparent
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
              Color c = img.color;
              c.a = i;
              img.color = c;
              yield return null;
            }
            sceneLoader.gameObject.SetActive(true);
          }
          else
          {
            // fade from transparent to opaque
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
              Color c = img.color;
              c.a = i;
              img.color = c;
              yield return null;
            }
          }
        }
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
      }

      sceneLoader.Load(sceneIndex);
    }
  }
}