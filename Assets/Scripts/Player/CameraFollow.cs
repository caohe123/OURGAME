using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // 把Player拖到这个变量里
    public Transform target;
    // 相机跟随的平滑度，0-1之间，越接近1越跟得紧
    public float smoothSpeed = 0.1f;

    void LateUpdate()
    {
        // 让相机位置和角色位置同步，保持Z轴不变
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
