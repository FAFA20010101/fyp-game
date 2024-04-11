using UnityEngine;

public class TrainController : MonoBehaviour
{
    public Transform leftTrack; // ���y�D��Transform
    public Transform rightTrack; // �k�y�D��Transform
    public Transform lever; // ���a�쪺Transform
    public float leverRotationThreshold = 45f; // ���a�쪺�����H��

    private bool isLeftTrack = true; // �����O�_��p�b���y�D�W

    private void Update()
    {
        // �ˬd���a�쪺���ਤ�סA�ھڨ��פ����y�D
        if (lever != null)
        {
            float leverRotation = lever.localEulerAngles.z;

            if (leverRotation >= leverRotationThreshold && isLeftTrack)
            {
                // ������k�y�D
                isLeftTrack = false;
                MoveTrainToTrack(rightTrack);
            }
            else if (leverRotation < leverRotationThreshold && !isLeftTrack)
            {
                // �����쥪�y�D
                isLeftTrack = true;
                MoveTrainToTrack(leftTrack);
            }
        }
    }

    private void MoveTrainToTrack(Transform track)
    {
        // �N�����w�����w�y�D�W
        transform.position = track.position;
        transform.rotation = track.rotation;
    }
}
