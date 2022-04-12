using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public UnityEvent beforeSpawnCheck;

    [SerializeField] private float duration = 1f;

    private void Awake() => Instance = this;

    public void CallTimer()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(duration);

        beforeSpawnCheck.Invoke();

        if (!LoseTriggerCheck.Instance.isCubeInside)
            CubesSpawner.Instance.SpawnCube();
    }
}
