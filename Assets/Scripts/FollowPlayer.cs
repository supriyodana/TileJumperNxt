using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Ball;

    public float followSpeed = 5f;
    public float fixedX = 0f;
    public float fixedY = 15f;
    public float fixedZOffset = -13f;

    void LateUpdate()
    {
        float targetZ = Ball.position.z + fixedZOffset;

        Vector3 targetPos = new Vector3(fixedX, fixedY, targetZ);

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);
    }
}
