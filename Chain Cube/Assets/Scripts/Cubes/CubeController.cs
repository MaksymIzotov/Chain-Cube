using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeController : MonoBehaviour
{
    Rigidbody rb;

    public CubePhysics physics;
    public CubeInfo info;

    public bool isCreated;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (isCreated) { return; }

        AddUpwardForce();
    }

    public void Shoot()
    {
        rb.AddForce(transform.forward * physics.dropForce, ForceMode.Impulse);
    }

    public void AddUpwardForce()
    {
        rb.AddForce(transform.up * physics.upwardsForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * physics.upwardsForce / 2, ForceMode.Impulse);
    }
}
