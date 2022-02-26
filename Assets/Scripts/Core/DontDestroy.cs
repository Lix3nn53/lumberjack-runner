using UnityEngine;

namespace Lix.Core
{
  // Must be root game object
  public abstract class DontDestroy : MonoBehaviour
  {

    private DontDestroy instance;

    protected virtual void Awake()
    {
      if (instance == null)
      {
        instance = this;

        DontDestroyOnLoad(gameObject);
        Debug.Log("DontDestroyOnLoad: " + gameObject.name);
      }
      else
      {
        Destroy(gameObject);
        Debug.Log("DontDestroy already exists: " + gameObject.name);
      }
    }

  }
}