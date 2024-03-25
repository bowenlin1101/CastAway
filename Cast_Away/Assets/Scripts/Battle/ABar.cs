using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABar : MonoBehaviour
{
    [SerializeField] GameObject aggression;

    private void Start() {
    }

    public void SetAggression(float aggressionNormalized) {
        aggression.transform.localScale = new Vector3(aggressionNormalized, 1f);
    }

    public IEnumerator SetASmooth(float newHp) {
        float curHp = aggression.transform.localScale.x;
        float changeAmt = curHp - newHp;
        while (curHp-newHp > Mathf.Epsilon) {
            curHp -= changeAmt * Time.deltaTime;
            aggression.transform.localScale = new Vector3(curHp, 1f);
            yield return null;
        }
        aggression.transform.localScale = new Vector3(newHp, 1f);
    }
}
