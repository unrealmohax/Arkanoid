using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    [SerializeField] private Vector2 DefaultResolution = new Vector2(1080, 1920);
    [Range(0f, 1f)]
    [SerializeField] private float WidthOrHeight = 0;
    [SerializeField] private Camera componentCamera;

    private float initialSize;
    private float targetAspect;

    private void Start()
    {
        initialSize = componentCamera.orthographicSize;
        targetAspect = DefaultResolution.x / DefaultResolution.y;

        UpdateWight();
    }

    /// <summary>Resize the camera to scale the picture to width</summary>
    private void UpdateWight()
    {
        float constantWidthSize = initialSize * (targetAspect / componentCamera.aspect);
        componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, initialSize, WidthOrHeight);
    }
}