using UnityEngine;
using System.Collections;

public class truthOD : MonoBehaviour
{

    Animator theAnim;
    playerManager thePlayerMan;

    private void Start()
    {
        theAnim = GetComponent<Animator>();
        thePlayerMan = playerManager.instance;


    }

}
