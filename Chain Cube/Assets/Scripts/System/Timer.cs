using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [SerializeField] private float duration = 1f;

    private void Awake() => Instance = this;

    public void CallTimer()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(duration);

        CubesSpawner.Instance.SpawnCube();
    }
}
