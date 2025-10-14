using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GhostProjectile : MonoBehaviour {

       public int damage = 30;
       public float speed = 10f;
       private Transform playerTrans;
       private Vector2 target;
       public GameObject hitEffectAnim;
       public float SelfDestructTime = 2.0f;

       void Start() {
             //NOTE: transform gets location, but we need Vector2 for direction, so we can use MoveTowards.
             playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
             target = new Vector2(playerTrans.position.x, playerTrans.position.y);

             StartCoroutine(selfDestruct());

             //code for trajectory (moves target way beyond player position):
             Vector2 startPos = transform.position;
             float distance = Vector2.Distance(startPos, target);
             distance = distance * (10f);
             Vector2 difference = target - startPos;
             difference = difference.normalized * distance;
             target = (startPos + difference);
       }

       void Update () {
              transform.position = Vector2.MoveTowards (transform.position, target, speed * Time.deltaTime);
       }

       //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
       void OnTriggerEnter2D(Collider2D collision){
              if (collision.CompareTag("Player")) {
                     GameHandler.Instance.TakeDamage(damage);
              }
              if (!collision.CompareTag("Enemy")) {
                     Destroy (gameObject);
              }
       }

       IEnumerator selfDestruct(){
              yield return new WaitForSeconds(SelfDestructTime);
              Destroy (gameObject);
       }
}
