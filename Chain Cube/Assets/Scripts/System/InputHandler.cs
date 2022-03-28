using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private float sensitivity = 0.0025f;
    private bool touched;
    private Vector3 mousePos;
    private float move;
    [SerializeField] private float roadSize = 3;

    [SerializeField] private Transform playerCube;

    private void Update()
    {
        if (Gameplay.Instance.gameState != Gameplay.STATE.PLAY) { return; }

        MoveCubePC();
        MoveCubeAndroid();
    }

    private void CallShoot()
    {
        if (!playerCube.GetChild(0)) { return; }

        Transform cube = playerCube.GetChild(0);

        cube.parent = null;
        cube.GetComponent<CubeController>().Shoot();

        Timer.Instance.CallTimer();
        Gameplay.Instance.IncreaseShots();
    }

    private void MoveCubePC()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touched = true;
            mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0) && touched)
        {
            touched = false;
            move = 0;

            CallShoot();
        }

        if (touched)
        {
            move = -(mousePos.x - Input.mousePosition.x) * sensitivity;
            mousePos = Input.mousePosition;
        }

        playerCube.position = new Vector3(Mathf.Clamp(playerCube.position.x + move, -roadSize, roadSize), playerCube.position.y, playerCube.position.z);

    }

    private void MoveCubeAndroid()
    {
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    touched = true;

                    mousePos = t.position;
                    break;

                case TouchPhase.Moved:
                    move = -(mousePos.x - t.position.x) * sensitivity;
                    mousePos = t.position;
                    break;

                case TouchPhase.Stationary:
                    move = 0;
                    break;

                case TouchPhase.Ended:
                    if (!touched) { return; }

                    touched = false;
                    move = 0;

                    CallShoot();
                    break;
            }
        }

        playerCube.position = new Vector3(Mathf.Clamp(playerCube.position.x + move, -roadSize, roadSize), playerCube.position.y, playerCube.position.z);
    }
}
