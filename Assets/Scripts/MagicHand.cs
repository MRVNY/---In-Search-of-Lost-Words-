using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHand : MonoBehaviour
{
    public static MagicHand Instance;
    private GameObject ActiveMagic;
    private GameObject Ball;
    private Camera cam;

    public GameObject Huo;
    public GameObject Shui;
    public GameObject Feng;
    public GameObject Gong;
    public GameObject Wei;

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        cam = Camera.main;
        Huo.SetActive(false);
        //Activate("Huo");
        //Attack();
    }

    public void Activate(string magicName)
    {   
        bool activate = false;
        switch (magicName)
        {
            case "Huo":
                ActiveMagic = Huo;
                activate = true;
                break;
        }
        
        if (activate){
            ActiveMagic.SetActive(true);
        }
    }

    public void Attack()
    {
        Ball = Instantiate(ActiveMagic, ActiveMagic.transform.position, ActiveMagic.transform.rotation);
        Ball.transform.SetParent(transform.parent.parent.parent);
        
        RaycastHit hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 1));
        Vector3 targetPosition;
        
        if (Physics.Raycast(ray, out hit))
        { 
            targetPosition = hit.point;
        }
        else
        {
            targetPosition = ray.GetPoint(10);
        }

        Vector3 direction = targetPosition - Ball.transform.position;
        Ball.GetComponent<Rigidbody>().AddForce(direction * 50);
        }


    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale==1 && Input.GetKeyDown(KeyCode.Space) && ActiveMagic != null)
        {
            Attack();
        }
    }
}
