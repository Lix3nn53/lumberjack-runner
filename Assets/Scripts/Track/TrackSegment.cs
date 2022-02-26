using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lix.Core;

namespace Lix.CubeRunner
{
  public class TrackSegment : MonoBehaviour
  {
    public GameObject DroppedCubeThrash;
    private int partEveryLength;
    private int partOffset;
    private int partCount;

    private SegmentPart[] segmentParts;

    // BetweenParts
    private BetweenParts[] betweenPartsArray;

    private void clear()
    {
      if (segmentParts != null)
      {
        for (int i = 0; i < segmentParts.Length; i++)
        {
          if (segmentParts[i] == null)
          {
            continue;
          }

          Destroy(segmentParts[i].gameObject);
        }
      }

      // remove uncollected cubes
      if (betweenPartsArray != null)
      {
        for (int i = 0; i < betweenPartsArray.Length; i++)
        {
          if (betweenPartsArray[i] == null)
          {
            continue;
          }

          // Destroy(betweenPartsArray[i].gameObject);
          betweenPartsArray[i].returnCubesAndDestroySelf();
        }
      }

      // remove cubes dropped from player
      GameObject[] droppedCubes = new GameObject[this.DroppedCubeThrash.transform.childCount];
      for (int i = 0; i < this.DroppedCubeThrash.transform.childCount; i++)
      {
        droppedCubes[i] = this.DroppedCubeThrash.transform.GetChild(i).gameObject;
      }
      for (int i = 0; i < droppedCubes.Length; i++)
      {
        // Destroy(this.DroppedCubeThrash.transform.GetChild(i).gameObject);
        PoolManager.Get("CubePool").Pool.Release(droppedCubes[i]);
      }
    }

    private void randomize(float segmentLength)
    {
      partCount = UnityEngine.Random.Range(2, 4);
      partEveryLength = (int)segmentLength / partCount;
      partOffset = (int)segmentLength % partCount;

      segmentParts = new SegmentPart[partCount];
      betweenPartsArray = new BetweenParts[partCount + 1];
    }

    private void generate(GameObject segmentPartPrefab, GameObject betweenPartsPrefab, int cubeLength, int cubeDistanceBetween, float segmentLength)
    {
      float previousX = transform.position.x;

      for (int i = 0; i < partCount; i++)
      {
        float x = transform.position.x + (i * partEveryLength) + partOffset;

        SegmentPart segmentPart = Instantiate(segmentPartPrefab, new Vector3(x, 0, 0), Quaternion.identity).GetComponent<SegmentPart>();
        segmentPart.transform.SetParent(transform);
        segmentParts[i] = segmentPart;

        BetweenParts betweenParts = Instantiate(betweenPartsPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BetweenParts>();
        betweenParts.transform.SetParent(transform);
        betweenParts.generate(previousX + cubeDistanceBetween, x, UnityEngine.Random.Range(0, 5), cubeLength, cubeDistanceBetween);
        betweenPartsArray[i] = betweenParts;

        previousX = x;
      }

      // Cubes from last part until end of segment
      BetweenParts betweenPartss = Instantiate(betweenPartsPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BetweenParts>();
      betweenPartss.transform.SetParent(transform);
      betweenPartss.generate(previousX + cubeDistanceBetween, transform.position.x + segmentLength, UnityEngine.Random.Range(0, 5), cubeLength, cubeDistanceBetween);
      betweenPartsArray[partCount] = betweenPartss;
    }

    public void OnStart(GameObject segmentPartPrefab, GameObject betweenPartsPrefab, int cubeLength, int cubeDistanceBetween, float segmentLength)
    {
      randomize(segmentLength);
      generate(segmentPartPrefab, betweenPartsPrefab, cubeLength, cubeDistanceBetween, segmentLength);
    }

    public void OnRestart(GameObject segmentPartPrefab, GameObject betweenPartsPrefab, int cubeLength, int cubeDistanceBetween, float segmentLength)
    {
      clear();
      randomize(segmentLength);
      generate(segmentPartPrefab, betweenPartsPrefab, cubeLength, cubeDistanceBetween, segmentLength);
    }
  }
}