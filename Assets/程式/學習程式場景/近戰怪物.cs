using UnityEngine;
using System.Collections;

public class 近戰怪物 : 怪物控制
{
    #region 欄位
    [Header("攻擊區域")]
    public Vector2 v2攻擊區域;
    public Vector3 v3尺寸;
    #endregion
    #region 事件
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1, 0.3f, 0.1f, 0.3f);
    //    Gizmos.DrawCube(transform.position + transform.right * v2攻擊區域.x + transform.up * v2攻擊區域.y, v3尺寸);
    //}
    protected override void OnDrawGizmos()
    {
        //副類別原本的程式內容
        base.OnDrawGizmos();
        Gizmos.color = new Color(1, 0.3f, 0.1f, 0.3f);
        Gizmos.DrawCube(transform.position + transform.right * v2攻擊區域.x + transform.up * v2攻擊區域.y, v3尺寸);
    }
    protected override void Update()
    {
        base.Update();
        atkk();
    }
    #endregion
    #region 方法
    private void atkk()
    {
        hit = Physics2D.OverlapBox(transform.position + transform.right * v2攻擊區域.x + transform.up * v2攻擊區域.y, v3尺寸, 0, 1 << 7);

        if (hit)
        {
            print(hit.name);
            state = StateEnemy.atkkack;
        }
    }
    protected override void 不同的攻擊()
    {
        base.不同的攻擊();
        StartCoroutine(playerie());
    }
    private IEnumerator playerie()       //ctrl+k+d 格式化   alt+上下 移動所選
    {
        for (int i = 0; i < atkdelay.Length; i++)
        {
            yield return new WaitForSeconds(atkdelay[i]);
            print("第一次攻擊");
            if (hit) playerh.Hurt(atk);
        }
        yield return new WaitForSeconds(攻擊回復動作);
        if (hit)
        {
            state = StateEnemy.atkkack;
        }
        else
        {
            state = StateEnemy.walk;
        }
        //yield return new WaitForSeconds(atkdelay2);
        //print("第二次攻擊");
        //if (hit) playerh.Hurt(atk);
    }
    #endregion
}
