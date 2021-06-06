using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMask : MonoBehaviour
{
    private void Start()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }


}
