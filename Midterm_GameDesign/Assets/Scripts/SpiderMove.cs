using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpiderMove : MonoBehaviour {

       public Animator anim;
       public Rigidbody2D rb2D;
       public float speed = 0.5f;
       private Transform target;
       public int damage = 10;

       public int EnemyLives = 2;
       //private GameHandler gameHandler;

       public float attackRange = 10;
       public bool isAttacking = false;
       private float scaleX;

       public float knockBackForce = 10f;

       void Start () {
              anim = GetComponentInChildren<Animator> ();
              rb2D = GetComponent<Rigidbody2D> ();
              scaleX = gameObject.transform.localScale.x;

              GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
              if (playerObj != null) {
                     target = playerObj.transform;
              }
       }

       void Update () {
              if (target == null) return;
              float DistToPlayer = Vector3.Distance(transform.position, target.position);

              if (DistToPlayer <= attackRange){
                     transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                     if (target.position.x > gameObject.transform.position.x){
                            gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
                     } else {
                            gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
                     }
              }
       }
       //        if ((target != null) && (DistToPlayer <= attackRange)){
       //               transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
       //              //anim.SetBool("Walk", true);
       //              //flip enemy to face player direction. Wrong direction? Swap the * -1.
       //              if (target.position.x > gameObject.transform.position.x){
       //                             gameObject.transform.localScale = new Vector2(scaleX, gameObject.transform.localScale.y);
       //              } else {
       //                              gameObject.transform.localScale = new Vector2(scaleX * -1, gameObject.transform.localScale.y);
       //              }
       //        }
       //         //else { anim.SetBool("Walk", false);}
       // }

       //2. Replace OnCollisionEnter2D() with this version, to include knockback:
       
       
       
       public void OnCollisionEnter2D(Collision2D other){
              if (other.gameObject.CompareTag("Player")) {
                     isAttacking = true;
                     //anim.SetBool("Attack", true);
                     if (GameHandler.Instance != null){
                            GameHandler.Instance.TakeDamage(damage);
                     }
                     Player_EndKnockBack knockback = other.gameObject.GetComponent<Player_EndKnockBack>();
                     if (knockback != null){
                            knockback.EndKnockBack();
                     }
                     
                     Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
                     if (pushRB != null && rb2D != null){
                            Vector2 moveDirectionPush = rb2D.transform.position - other.transform.position;
                            pushRB.AddForce(moveDirectionPush.normalized * knockBackForce *-1f, ForceMode2D.Impulse);
                     }
              }
       }


              //        //rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              //        //StartCoroutine(HitEnemy());

              //        //Tell the player to STOP getting knocked back before getting knocked back:
              //        other.gameObject.GetComponent<Player_EndKnockBack>().EndKnockBack();
              //        //Add force to the player, pushing them back without teleporting:
              //       Rigidbody2D pushRB = other.gameObject.GetComponent<Rigidbody2D>();
              //       Vector2 moveDirectionPush = rb2D.transform.position - other.transform.position;
              //       pushRB.AddForce(moveDirectionPush.normalized * knockBackForce * - 1f, ForceMode2D.Impulse);
              // }
       

       public void OnCollisionExit2D(Collision2D other){
              if (other.gameObject.CompareTag("Player")) {
                     isAttacking = false;
                     //anim.SetBool("Attack", false);
              }
       }

       //DISPLAY the range of enemy's attack when selected in the Editor
       void OnDrawGizmosSelected(){
              Gizmos.DrawWireSphere(transform.position, attackRange);
       }
}