using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed=1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.Rotate(new Vector3(0f,0f,360f*speed*Time.deltaTime));  
    }
}
