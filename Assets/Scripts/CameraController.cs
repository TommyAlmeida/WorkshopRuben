using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject player;
    
    private Vector3 _distance;
    
    // Start is called before the first frame update
    void Start()
    {
        _distance = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + _distance;
    }
}
