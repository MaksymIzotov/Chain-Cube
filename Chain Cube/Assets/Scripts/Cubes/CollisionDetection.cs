using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cube")
        {
            if (collision.gameObject.GetComponent<CubeController>().info.score != GetComponent<CubeController>().info.score) { return; }

            CubeInfo info = GetComponent<CubeController>().info;

            CubesSpawner.Instance.MergeCubes(info.score, info.index, transform);
            Destroy(gameObject);
        }
    }
}
