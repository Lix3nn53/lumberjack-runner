using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lix.CubeRunner
{
  public class Triggerable : MonoBehaviour
  {

    public virtual void OnTriggerEnter(Collider other)
    {
      this.OnTrigger(other);
    }

    public virtual void OnTrigger(Collider other)
    {

    }
  }
}