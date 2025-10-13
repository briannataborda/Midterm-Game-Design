using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour{

      public int damage = 50;
      public GameObject hitEffectAnim;
      public float SelfDestructTime = 4.0f;
      public float SelfDestructVFX = 0.5f;
      public GameObject projectileArt;
      public GameObject splatterPrefab;

      void Start(){
           StartCoroutine(SelfDestruct());
      }

      //if the bullet hits a collider, play the explosion animation, then destroy the effect and the bullet
      void OnTriggerEnter2D(Collider2D other){
            if (other.CompareTag("Enemy")){
                  EnemyTakeDamage enemy = other.GetComponent<EnemyTakeDamage>();
                  if (enemy != null){
                        int damageAmount = 50;
                        if (GameHandler.Instance != null){
                              damageAmount = GameHandler.Instance.playerAttack;
                        }
                  
                  Debug.Log("Dealing " + damageAmount + " damage to enemy");
                  enemy.TakeDamage(damageAmount);
                  } 
                  DestroyProjectile();
            } else if (!other.CompareTag("Player")){
                  DestroyProjectile();
            }
      } 


      //       if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.CompareTag("Enemy")) {
      //             //gameHandlerObj.playerGetHit(damage);
      //             other.gameObject.GetComponent<EnemyTakeDamage>().TakeDamage(GameHandler.Instance.playerAttack);
                  
      //       }
      //      if (other.gameObject.tag != "Player") {
      //             gameObject.GetComponent<BoxCollider2D>().enabled = false;
      //             //GameObject animEffect = Instantiate (hitEffectAnim, transform.position, Quaternion.identity);
      //             projectileArt.SetActive(false);
      //             //Destroy (animEffect, 0.5);
      //             StartCoroutine(SelfDestruct());
      //       }
      

      void DestroyProjectile(){
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        if (projectileArt != null)
        {
            projectileArt.SetActive(false);
        }

        if (hitEffectAnim != null)
        {
            GameObject effect = Instantiate(hitEffectAnim, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }

        Destroy(gameObject, 0.1f);
    }

      // IEnumerator SelfDestructHit(GameObject VFX){
      //       //MakeSplat();
      //       yield return new WaitForSeconds(SelfDestructVFX);
      //       //Destroy (VFX);
      //       Destroy (gameObject);
      // }

      IEnumerator SelfDestruct(){
            yield return new WaitForSeconds(SelfDestructTime);
            Destroy(gameObject);
      }

      /*
      //Make a mark on the ground where the projectile hit
      void MakeSplat(){
            GameObject splat = Instantiate (splatterPrefab, transform.position, Quaternion.identity);
            float zRotation = Random.Range(0f,179f);
            splat.transform.eulerAngles = new Vector3(0, 0, zRotation);
            float size = Random.Range(0.5f,0.9f);
            splat.transform.localScale = new Vector3(splat.transform.localScale.x * size, splat.transform.localScale.y * size, 1);
      }
      */
}