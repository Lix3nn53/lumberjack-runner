using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lix.Core
{
  [RequireComponent(typeof(SceneLoader))]
  public class SceneLoadAtStart : MonoBehaviour
  {
    private SceneLoader sceneLoader;
    [SerializeField] private int sceneIndex;
    void Awake()
    {
      sceneLoader = GetComponent<SceneLoader>();
    }
    // Start is called before the first frame update
    void Start()
    {
      sceneLoader.Load(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {

    }
  }
}