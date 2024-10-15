using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // ?????´ìš©?€ ë³€ê²½í•˜ì§€ ë§?ê²???
    
    private Transform camT;
    [SerializeField] private Vector3 CamOffset;
    void Start()
    {
        if (Camera.main != null) camT = Camera.main.transform;
    }

    void LateUpdate()
    {
        var position = transform.position;
        position.z = -10;
        camT.position = position + CamOffset;
    }
}
