using UnityEngine;
using UnityEngine.Events;

public class Events : MonoBehaviour
{
    public static UnityEvent<int,int> Victory = new UnityEvent<int, int>();
    public static UnityEvent<int, int> Defeat = new UnityEvent<int, int>();
    public static UnityEvent<string> Buff = new UnityEvent<string>();
}
