using UnityEngine;

public class LoseTriggerCheck : MonoBehaviour
{
    public static LoseTriggerCheck Instance;

    private void Awake()
    {
        Instance = this;
    }

    public bool isCubeInside;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Cube")
            isCubeInside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cube")
            isCubeInside = false;
    }


}
