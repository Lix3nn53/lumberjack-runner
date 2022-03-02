using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

public class CameraRotator : MonoBehaviour
{
  [SerializeField] GameObject target;

  private void OnEnable()
  {
    CurvedWorldManager curvedWorldManager = DIContainer.GetService<CurvedWorldManager>();

    StartCoroutine(DisableCurvedShader(curvedWorldManager));
  }

  void Update()
  {
    // Spin the object around the target at 20 degrees/second.
    transform.RotateAround(target.transform.position, Vector3.up, 40 * Time.deltaTime);
  }

  //   private void OnDestroy() {
  //     CurvedWorldManager curvedWorldManager = DIContainer.GetService<CurvedWorldManager>();
  //     curvedWorldManager.SetEnable(true);
  //   }

  IEnumerator DisableCurvedShader(CurvedWorldManager curvedWorldManager)
  {
    yield return new WaitForSeconds(0.8f);

    curvedWorldManager.SetEnable(false);

  }
}
