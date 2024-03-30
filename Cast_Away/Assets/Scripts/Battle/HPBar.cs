using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    private void Start() {
    }

    public void SetHP(float hpNormalized) {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHp) {
        float curHp = health.transform.localScale.x;
        float changeAmt = curHp - newHp;
        if (changeAmt < 0) {
            while ((newHp)-curHp > Mathf.Epsilon) {
                curHp += (-changeAmt) * Time.deltaTime;
                health.transform.localScale = new Vector3(curHp, 1f);
                yield return null;
            }
            health.transform.localScale = new Vector3(newHp, 1f);
        } else {
            while (curHp-newHp > Mathf.Epsilon) {
                curHp -= changeAmt * Time.deltaTime;
                health.transform.localScale = new Vector3(curHp, 1f);
                yield return null;
            }
            health.transform.localScale = new Vector3(newHp, 1f);
        }
    }
}
