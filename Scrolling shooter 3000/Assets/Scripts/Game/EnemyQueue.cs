//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyQueue : MonoBehaviour
//{
//    public List<Wave> waveQueue;

//    [SerializeField] EnemyPooler pooler;

//    private void Start()
//    {
//        waveQueue.Clear();
//        EnemyPooler.onPoolingComplete += CreateQueue;
//    }

//    void CreateQueue()
//    {
//        foreach(Wave wave in pooler.waves)
//        {
//            waveQueue.AddRange(pooler.waves);
//        }
//    }
//}
