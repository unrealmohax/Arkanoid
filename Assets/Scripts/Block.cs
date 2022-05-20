using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Block : MonoBehaviour, IDamageable
{
    [SerializeField] private GameplayHandler GameplayHandler;
    [SerializeField] private SwitchColor SwitchColor;

    [Range(0, 7)]
    [SerializeField] private int Health;
    [SerializeField] private int maxHealth;
    private int pay;

    [SerializeField] private GameObject[] buff;

    
    private void Start()
    {
        SwitchColor.Colour—hange(Health);
        maxHealth = Health;
        pay = (int) Mathf.Pow(Health, 1.5f) * 10;
    }

    #region IDamageable 
    /// <summary>Take damage and change the colour of the block, if there is no health left and the initial health was positive destroy the object</summary>
    public void TakingDamage(int Damage) 
    {
        Health -= Damage;
        SwitchColor.Colour—hange(Health);
        if (Health <= 0 && maxHealth > 0)
        {
            Destroy();
        }
    }
    #endregion

    /// <summary>Remove the block from the list and destroy it, create a buff with a certain chance</summary>
    private void Destroy()
    {
        GameplayHandler.DestroyBlock(gameObject, pay);
        Destroy(gameObject);

        if (buff.Length != 0)
        {
            float chance = Random.Range(0,101);
            if (chance <= 15f) 
            {
                int count = Random.Range(0, buff.Length);
                Instantiate(buff[count], transform.position, Quaternion.identity);
            }
        }
    }
}
