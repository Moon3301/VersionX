using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnTrap : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> trapSpike;

    public Animator animator;


    void Start()
    {
        desactiveTrap();
    }

    private void OnTriggerStay2D(Collider2D other){

        if (other.tag == "Player"){
            activeTrap();
        }else{
            desactiveTrap();
        }

        

    }

    public void activeTrap(){

        animator.SetBool("activebtn", true);

        for(int i = 0 ; i< trapSpike.Count; i++){
            trapSpike[i].GetComponent<Animator>().SetBool("active", true);
        }
    }

    public void desactiveTrap(){

        animator.SetBool("activebtn", false);

        for(int i = 0 ; i< trapSpike.Count; i++){
            trapSpike[i].GetComponent<Animator>().SetBool("active", false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
