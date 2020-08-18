//danrus32
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class Zmeika_test : MonoBehaviour
{
    public float width  =  70.5f;
    public float height =  42.5f;
    public float ZeroPosition = 0f;
    public GameObject zmeika;
    public GameObject zmeika_t;
    public GameObject zmeika_tails;

    List <GameObject> zmeika_tails_masiv =  new List<GameObject>();
    public float ltx;
    public float lty;
    public float _ltx;
    public float _lty;
    
    public GameObject apple;
    public float speed = 1f;
    public int expectation = 25;
    private GameObject zmeika_head;

    public float zmeika_change_x  = 0f;
    public float zmeika_change_y  =  0f;
    private int apple_eaten = 0;


   
    // Start is called before the first frame update
    
    void Start()
    {
        int randXpos = Random.Range (1,45);
        int randYpos = Random.Range (1,22);
        zmeika_head = Instantiate (zmeika, new Vector2(width  / 2f ,height/2f), Quaternion.identity) as GameObject;
        apple = Instantiate (apple, new Vector2(randXpos,randYpos), Quaternion.identity) as GameObject;
        
    }
    //tails 
    void  ZmeikaTails(){
            
            ltx = zmeika_head.transform.localPosition.x ;
            lty = zmeika_head.transform.localPosition.y;
            for (int i = 0; i < zmeika_tails_masiv.Count; i++){
                    
                    _ltx = zmeika_tails_masiv[i].transform.localPosition.x;
                    _lty = zmeika_tails_masiv[i].transform.localPosition.y;
                    zmeika_tails_masiv[i].transform.localPosition = new Vector2 (ltx, lty);
                    ltx = _ltx;
                    lty = _lty;
                    }   
 
    }
     // draw
    
        void ZmeikaRunDraw(){
                Thread.Sleep(expectation);
                zmeika_head.transform.localPosition = new Vector2(zmeika_head.transform.localPosition.x+ zmeika_change_x,zmeika_head.transform.localPosition.y +zmeika_change_y);
                
            }
    //run
        void ZmeikaRun(){
            if(Input.GetKey(KeyCode.W) && zmeika_change_y == 0){
                zmeika_change_x = 0f;
                zmeika_change_y = speed;
                }
            if(Input.GetKey(KeyCode.S) && zmeika_change_y == 0){
                zmeika_change_x = 0f ;
                zmeika_change_y = -speed;
                }
            if(Input.GetKey(KeyCode.A) && zmeika_change_x == 0){
                zmeika_change_x = -speed;
                zmeika_change_y = 0f;
                }
            if(Input.GetKey(KeyCode.D) && zmeika_change_x == 0){
                zmeika_change_x = speed;
                zmeika_change_y = 0f;
                
            
                
                }
        }
        //zmeika tails colizion
        void ColisionZmeikaTails(){
            for (int i = 0; i < zmeika_tails_masiv.Count; i++){
                if(zmeika_head.transform.localPosition.x == zmeika_tails_masiv[i].transform.localPosition.x &&
                    zmeika_head.transform.localPosition.y == zmeika_tails_masiv[i].transform.localPosition.y ){
                        Debug.Log("Colizion Zmeica_tails");
                        for (int q = 0; q < zmeika_tails_masiv.Count; q++){
                            Destroy (zmeika_tails_masiv[q]);
                            zmeika_tails_masiv.RemoveAt(q);
                            }
                        zmeika_head.transform.localPosition = new Vector3 (width  / 2f ,height/2f);
                        apple_eaten = 0;
                        
                        
                       
                        

                        
        
                        
                    }
                }
            }
        //zmeika,apple colision
    void ColisionAplpleZmeika(){
        
        float summ1 = zmeika_head.transform.localPosition.x - apple.transform.localPosition.x;
        if (summ1 < 0 )
            summ1 = apple.transform.localPosition.x - zmeika_head.transform.localPosition.x;
        float summ2 = zmeika_head.transform.localPosition.y - apple.transform.localPosition.y;
        if (summ2 < 0 )
            summ2 = apple.transform.localPosition.y - zmeika_head.transform.localPosition.y;
        if( summ1 <= 1 ){
            if (summ2 <= 1 ){
                int randXpos = Random.Range (1,45);
                int randYpos = Random.Range (1,22);
                apple.transform.localPosition = new Vector2 (randXpos, randYpos);
                Debug.Log("COLISION");
                zmeika_tails = Instantiate (zmeika_t, new Vector2(zmeika_head.transform.localPosition.x-1f,zmeika_head.transform.localPosition.x-1f), Quaternion.identity) as GameObject;
                zmeika_tails_masiv.Add(zmeika_tails);
                apple_eaten += 1;
            }   }
    }
    // Update is called once per frame
    void Update()
    {
        //tails run
        ZmeikaTails();
        //zmeika run
        ZmeikaRun();
        //zmeika draw
        ZmeikaRunDraw();
        
        //ceck colision zmeika,apple
        ColisionAplpleZmeika();
        //ceck colision zmeika,apple
        ColisionZmeikaTails();
    
        //ceck zmika  in scene
        if (zmeika_head.transform.localPosition.x <= ZeroPosition - 1)
            zmeika_head.transform.Translate(width + 1,0,0);
        if (zmeika_head.transform.localPosition.x >= width + 1) 
            zmeika_head.transform.localPosition = new Vector3 (0.1f,zmeika_head.transform.localPosition.y, zmeika_head.transform.localPosition.z);
        if (zmeika_head.transform.localPosition.y <= 0 )
             zmeika_head.transform.Translate(0,height,0);
        if (zmeika_head.transform.localPosition.y >= height )
            zmeika_head.transform.localPosition = new Vector3 (zmeika_head.transform.localPosition.x,0.1f, zmeika_head.transform.localPosition.z);
        
			
        
    }
}
