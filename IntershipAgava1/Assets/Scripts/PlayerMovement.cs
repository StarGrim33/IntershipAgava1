using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Ball _ball;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.position != _ball.transform.position)
            {
                transform.position = _ball.transform.position;

                _ball.StopMoving();
            }
        }
    }
}
