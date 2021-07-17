using UnityEngine;

public class 數學 : MonoBehaviour
{

    public int a = 10;
    public int b = 3;
    public int c = 0;

    public float scare_a = 99;
    public float scare_b = 1;

    public float hp=100;
    public int key = 1;

    public bool 過關 = false;

    private void Start()
    {
        #region 數學運算子教學
        print(a+b);//13
        print(a - b);//7
        print(a * b);//30
        print(a / b);//3
        print(a % b);//1
        print(6/2*(1+2)); //6/2(1+2) =題目錯了

        c = c + 1;
        c += 1;
        c++;

        #endregion

        #region 比較運算子

        print("99大於1" + (scare_a > scare_b)); //true
        //>大於 <小於 >=大等 <=小等 !=不等 ==等於
        // &&並且 ||或著 

        print("過關 ："+ (hp>=1&&key==1));
        //過關(!true);

        過關 = (hp >= 1 && key == 1) ? true : false;
        print(過關);
        #endregion
    }
}
