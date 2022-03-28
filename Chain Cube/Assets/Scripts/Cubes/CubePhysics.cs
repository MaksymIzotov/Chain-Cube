using UnityEngine;

[CreateAssetMenu(fileName = "Info", menuName = "ScriptableObjects/CubePhysics", order = 1)]
public class CubePhysics : ScriptableObject
{
    public float dropForce;
    public float upwardsForce;
}
