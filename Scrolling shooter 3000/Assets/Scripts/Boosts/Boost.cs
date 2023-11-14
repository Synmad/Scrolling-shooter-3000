using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    public abstract string boostName { get; }
    public abstract void Effect(); 
}
