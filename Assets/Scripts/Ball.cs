using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class Ball : MonoBehaviour
{
    [SerializeField] private SoundsHandler SH;

    [SerializeField] private GameObject hitEffect;
    [SerializeField] private Rigidbody2D rigidbodyBall;
    [SerializeField] private int Damage = 1;

    private float minspeed = 3f;
    private float speed = 5f;

    private int damageBonus = 2;
    private int minDamage = 1;
    private int maxDamage = 10;

    private bool IsActive = false;

    private void Start()
    {
        SH = FindObjectOfType<SoundsHandler>();
        Events.Buff.AddListener(IncreasedDamage);
    }

    public void PunchBall()
    {
        if (!IsActive) 
        {
            rigidbodyBall.velocity = new Vector2(Random.Range(minspeed, speed + 1), speed);
            IsActive = true;
        }
    }

    private void IncreasedDamage(string buff) 
    {
        /// <summary>If you get the 2xDamage buff, increase the damageBonus times the range (minDamage, maxDamage) </summary>
        if (buff.Equals("2xDamage"))
        {
            Damage = Mathf.Clamp(Damage * damageBonus, minDamage, maxDamage);
        }

        StartCoroutine(ReductionDamage());
    }

    private IEnumerator ReductionDamage() 
    {
        /// <summary>Wait 10 seconds and remove the damage boost</summary>
        yield return new WaitForSeconds(10);
        Damage = Mathf.Clamp(Damage / damageBonus, minDamage, maxDamage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /// <summary>If the object can be damaged, play a hit sound and create an effect at the point of contact</summary>
        if (collision.collider.TryGetComponent(out IDamageable damageable)) 
        {
            Debug.Log("Hit");
            SH.PlaySound(1);
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Vector2 point = hit.point;
                Instantiate(hitEffect, new Vector3(point.x, point.y, 0), Quaternion.identity);
            }

            damageable.TakingDamage(Damage);
        }
        /// <summary>If the object is a platform, change the flight of the balloon depending on the touch point on the platform</summary>
        else if (collision.collider.TryGetComponent(out Platform platform))
        {
            Debug.Log("Platform");

            float PointX = 0;
            float forceX = 0;

            foreach (ContactPoint2D hit in collision.contacts)
            {
                /// <summary>If touching the platform on the left, give force to the left otherwise to the right </summary>
                PointX = (hit.point.x - platform.transform.position.x) / (platform.transform.localScale.x / 2);
                forceX = (PointX > 0)? Mathf.Clamp(PointX, 0, 1) : Mathf.Clamp(PointX, -1, 0);
            }

            rigidbodyBall.velocity = new Vector2(forceX * speed, speed);
        }
    }

    private void Update()
    {
        /// <summary>If the ball is active and its Y speed is less than the minimum, assign the minimum value </summary>
        if (IsActive)
        {
            if (rigidbodyBall.velocity.y < minspeed && rigidbodyBall.velocity.y >= 0)
            {
                rigidbodyBall.velocity = new Vector2(rigidbodyBall.velocity.x , minspeed);
            }
            else if (rigidbodyBall.velocity.y < 0 && rigidbodyBall.velocity.y >= -minspeed)
            {
                rigidbodyBall.velocity = new Vector2(rigidbodyBall.velocity.x, -minspeed);
            }
        }
    }
}
