using UnityEngine;
using System.Linq;

public class learnLinq : MonoBehaviour
{
    public int[] score = {10,80,-60,40,-55,0,1,-7 };
    public int[] result;
    public int[] result60;

    private void Start()
    {
        //score中有沒有=0 的值
        // =>檢查
        //score.Where(zxc => zxc == 0);
        result = score.Where(zxc => zxc > 0).ToArray();
        result60 = score.Where(zxc => zxc >= 60).ToArray();
    }
}
