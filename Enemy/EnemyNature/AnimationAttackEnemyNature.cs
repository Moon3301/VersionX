using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAttackEnemyNature : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootType1(){
        EnemyNature.instance.ShootType1();
    }

    public void AttackFalse(){
        EnemyNature.instance.AttackFalse();
    }
}
