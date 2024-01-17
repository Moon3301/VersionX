using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTornado : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage;

    public GameObject directional;

    public float time;

    public float finalTime;

    public GameObject Tornado;

    void Start()
    {
        
        Tornado.SetActive(false);
        Tornado.transform.position = Tornado.transform.position + new Vector3(2f,-3.5f,0);
        directional.transform.position = directional.transform.position + new Vector3(2f,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        

        
    }

    private void OnEnable() {
        
        StartCoroutine(TestContador());

        

    }

    IEnumerator TestContador(){

        directional.SetActive(true);
        yield return new WaitForSeconds(time);
        directional.SetActive(false);
        Tornado.SetActive(true);

        StartCoroutine(Disable());

    }

    IEnumerator Disable() {

        yield return new WaitForSeconds(finalTime);

        Tornado.SetActive(false);
        gameObject.SetActive(false);
        

    }
    
    
}
