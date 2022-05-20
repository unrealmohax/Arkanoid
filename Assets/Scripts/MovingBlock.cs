using UnityEngine;

public class MovingBlock : Block
{
    [SerializeField] private float velocity;
    [SerializeField] private Transform block;
    [SerializeField] private Transform leftpos;
    [SerializeField] private Transform rightpos;

    private float leftLimit = 0;
    private float rightLimit = 0;
    private bool isGoingLeft = false;

    private void Start()
    {
        leftLimit = leftpos.position.x;
        rightLimit = rightpos.position.x;
    }
    /// <summary>Move the object from left to right within the given boundaries</summary>
    private void Update()
    {
        if (block.position.x <= leftLimit)
        {
            isGoingLeft = false;
        }
        else if (block.position.x >= rightLimit)
        {
            isGoingLeft = true;
        }

        Move();
    }

    private void Move()
    {
        Vector3 direction = isGoingLeft ? Vector3.left : Vector3.right;

        block.Translate(direction * velocity * Time.deltaTime);
    }
}
