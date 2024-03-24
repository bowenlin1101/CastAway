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
}
