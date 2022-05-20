using UnityEngine;

public class UIHearth : MonoBehaviour
{
    [SerializeField] private GameObject[] Hearts;

    public void HeartDisplay(int Count) 
    {
        for (int i = 0; i < Hearts.Length - Count; i++)
        {
            if (Hearts[i] != null) 
            {
                Hearts[i].SetActive(false);
            }
        }     
    }
}
