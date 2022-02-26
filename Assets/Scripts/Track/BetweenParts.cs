using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class BetweenParts : MonoBehaviour
  {
    public void generate(float start, float end, float z, int cubeLength, int cubeDistanceBetween)
    {
      for (float cubeX = start; cubeX < end; cubeX += cubeLength + cubeDistanceBetween)
      {
        int randomHeight = UnityEngine.Random.Range(1, 4);

        for (int i = 1; i <= randomHeight; i++)
        {
          // Cube cube = Instantiate(TrackManager.Instance.CubePrefab, new Vector3(cubeX, i, z), Quaternion.identity, transform).GetComponent<Cube>();
          GameObject cube = PoolManager.Get("CubePool").Pool.Get();
          cube.transform.SetParent(this.transform);
          cube.transform.position = new Vector3(cubeX, i, z);
        }
      }
    }

    public void returnCubesAndDestroySelf()
    {
      GameObject[] cubes = new GameObject[transform.childCount];
      for (int i = 0; i < transform.childCount; i++)
      {
        cubes[i] = transform.GetChild(i).gameObject;
      }
      for (int i = 0; i < cubes.Length; i++)
      {
        // Destroy(this.DroppedCubeThrash.transform.GetChild(i).gameObject);
        PoolManager.Get("CubePool").Pool.Release(cubes[i]);
      }

      Destroy(this.gameObject);
    }
  }
}