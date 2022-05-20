using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Destroyer : MonoBehaviour
{
    [SerializeField] private GameplayHandler GamePlayHandler;

    /// <summary>If the ball touches the floor, remove the object from the list and destroy the object itself</summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Ball")) 
        {
            GamePlayHandler.DestroyBall(collision.gameObject);
        }

        Destroy(collision.gameObject);
    }
}
