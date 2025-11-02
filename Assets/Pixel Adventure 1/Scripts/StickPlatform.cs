using UnityEngine;

public class StickPlatform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag=="Player"){
            other.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag=="Player"){
            other.transform.SetParent(null);
        }
    }
}
