using UnityEngine;

public class TrainController : MonoBehaviour
{
    public Transform leftTrack; // 左軌道的Transform
    public Transform rightTrack; // 右軌道的Transform
    public Transform lever; // 操縱桿的Transform
    public float leverRotationThreshold = 45f; // 操縱桿的旋轉閾值

    private bool isLeftTrack = true; // 火車是否行駛在左軌道上

    private void Update()
    {
        // 檢查操縱桿的旋轉角度，根據角度切換軌道
        if (lever != null)
        {
            float leverRotation = lever.localEulerAngles.z;

            if (leverRotation >= leverRotationThreshold && isLeftTrack)
            {
                // 切換到右軌道
                isLeftTrack = false;
                MoveTrainToTrack(rightTrack);
            }
            else if (leverRotation < leverRotationThreshold && !isLeftTrack)
            {
                // 切換到左軌道
                isLeftTrack = true;
                MoveTrainToTrack(leftTrack);
            }
        }
    }

    private void MoveTrainToTrack(Transform track)
    {
        // 將火車定位到指定軌道上
        transform.position = track.position;
        transform.rotation = track.rotation;
    }
}
