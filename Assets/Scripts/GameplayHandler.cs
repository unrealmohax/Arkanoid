using System.Collections.Generic;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{
    [SerializeField] private UIHearth UIHeart;
    [SerializeField] private List<GameObject> Blocks = new List<GameObject>();

    private List<GameObject> Balls = new List<GameObject>();
    private Ball ball;
    
    [SerializeField] private Transform platform;
    [SerializeField] private GameObject ballprefab;

    [SerializeField] private int level;
    private int maximumLevel—ompleted=0;


    private int Heart = 3;
    private int Score = 0;

    private void Start()
    {
        GameObject Ballprefabs = Instantiate(ballprefab, platform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        CreateBall(Ballprefabs);
        maximumLevel—ompleted = MaxLevel—ompleted();
        PlayerPrefs.SetInt("currLevel", level);
    }

    private int MaxLevel—ompleted() 
    {
        if (PlayerPrefs.HasKey("maximumLevel—ompleted"))
        {
            return PlayerPrefs.GetInt("maximumLevel—ompleted");
        }
        else 
        {
            return 0;
        }
    }

    /// <summary>Remove the destroyed unit from the list if there is nothing left, record the maximum level completed and the number of stars if higher</summary>
    public void DestroyBlock(GameObject Block, int pay) 
    {
        int maxHeart = 0;
        Blocks.Remove(Block);
        Score += pay;

        if (Blocks.Count == 0)
        {
            Events.Victory?.Invoke(Heart, Score);
            maximumLevel—ompleted = MaxLevel—ompleted();

            if (maximumLevel—ompleted < level)
            {
                PlayerPrefs.SetInt("maximumLevel—ompleted", level);
            }

            if (PlayerPrefs.HasKey("lvl" + level.ToString()))
            {
                maxHeart = PlayerPrefs.GetInt("lvl" + level.ToString());
            }

            if (maxHeart < Heart)
            {
                PlayerPrefs.SetInt("lvl" + level.ToString(), Heart);
            }
        }   
    }

    /// <summary>Create a ball and add it to the list</summary>
    private void CreateBall(GameObject Ball)
    {
        ball = Ball.GetComponent<Ball>();
        Balls.Add(Ball.gameObject);
    }

    /// <summary>Remove the ball from the list if there are lives left create a new one, if there are no balls left on the list lost</summary>
    public void DestroyBall(GameObject Ball)
    {
        GameObject Ballprefabs;
        Balls.Remove(Ball);
       
        if (Heart > 0) 
        {
            Heart--;
            UIHeart.HeartDisplay(Heart);
            Ballprefabs = Instantiate(ballprefab, platform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            CreateBall(Ballprefabs);
        }

        if (Balls.Count == 0)
            Events.Defeat?.Invoke(Heart, Score);
    }

    private void Update()
    {
        #region œ -‚ÂÒËˇ
        if (Input.GetKey(KeyCode.Space))
        {
            ball.PunchBall();
        }
        #endregion

        #region ÃÓ·ËÎ¸Ì‡ˇ-‚ÂÒËˇ
        if (Input.touches.Length > 0) 
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                ball.PunchBall();
            }
        }
        
        #endregion
    }
}
