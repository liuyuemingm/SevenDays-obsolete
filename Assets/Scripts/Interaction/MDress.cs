using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MDress : MonoBehaviour
{
    private void Start()
    {
        transform.gameObject.GetComponent<Image>().enabled = false;
        transform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
