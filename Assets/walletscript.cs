using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class walletscript : MonoBehaviour
{

    public UIManager uIManager;
    [SerializeField] private Text scoreadd;
    //// Start is called before the first frame update
    void Start()
    {
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void Update()
    {
        
 

    }
    private void FixedUpdate()
    {
       
    }
    //// Update is called once per frame
    //public void scoreaddition()
    //{
    //    if (uIManager.score > 0)
    //    {
    //        PlayerPrefs.SetInt("Score", uIManager.score);
    //       

    //    }


    //}
}
