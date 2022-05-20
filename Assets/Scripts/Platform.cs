using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Transform rightLimitPosition;
    [SerializeField] private Transform leftLimitPosition;

    private float Velocity = 15f;
    private float rightLimit = 0f;
    private float leftLimit = 0f;
    private float lengthPlatform = 0f;
    private float currDiff = 0f;

    private void Start()
    {
        Events.Buff.AddListener(UpdateLenghtPlatform);

        rightLimit = rightLimitPosition.position.x;
        leftLimit = leftLimitPosition.position.x;
        UpdateLenghtPlatform();
    }

    /// <summary>Change the size of the platform depending on the buff you receive</summary>
    private void UpdateLenghtPlatform(string buff = "") 
    {
        if (buff.Equals("BigPlatform")) 
        {
            platform.localScale = new Vector3(Mathf.Clamp(platform.localScale.x * 1.2f, 1, 3), platform.localScale.y, platform.localScale.z);
        }
        else if (buff.Equals("SmallPlatform"))
        {
            platform.localScale = new Vector3(Mathf.Clamp(platform.localScale.x / 1.2f, 1, 3), platform.localScale.y, platform.localScale.z);
        }

        lengthPlatform = Mathf.Abs(platform.localScale.x);
    }

    private void Update()
    {
        #region ПК-версия
        if (Input.GetAxis("Horizontal") != 0)
        {
            Move(Input.GetAxis("Horizontal"));
        }
        #endregion

        #region Мобильная версия
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                Vector2 swipeDelta = Input.touches[0].position;
                MoveOnMobile(swipeDelta);
            }
        }
        #endregion
    }

    /// <summary>Controls on a computer</summary>
    private void Move(float swipeDelta)
    {
        platform.Translate(Vector3.right * Velocity * swipeDelta * Time.deltaTime);
        platform.position = new Vector3(Mathf.Clamp(platform.position.x, leftLimit + lengthPlatform / 2, rightLimit - lengthPlatform / 2), platform.position.y, platform.position.z);
    }

    /// <summary>Control on the phone</summary>
    private void MoveOnMobile(Vector2 swipeDelta)
    {
        float weightRoad = Mathf.Abs(rightLimit - lengthPlatform / 2) + Mathf.Abs(leftLimit + lengthPlatform / 2);
        float Position = (swipeDelta.x / Screen.width) * weightRoad - weightRoad / 2;
        currDiff = Mathf.MoveTowards(currDiff, Position, Velocity * Time.deltaTime);
        transform.position = new Vector3(currDiff, transform.position.y, transform.position.z); 
    }
}
