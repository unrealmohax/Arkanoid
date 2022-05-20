using UnityEngine;

public class Buff : MonoBehaviour
{
    [SerializeField] private SoundsHandler SH;

    private void Start()
    {
        SH = FindObjectOfType<SoundsHandler>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// <summary>If crossed with a platform, destroy the buff and start the event with buff selection</summary>
        if (collision.TryGetComponent<Platform>(out Platform platform))
        {
            Debug.Log("TakeBuff "+ tag);
            Events.Buff?.Invoke(gameObject.tag);
            SH.PlaySound(2);
            Destroy(gameObject);
        }   
    }
}
