// using CineMachine;
// using UnityEngine;

// public class MapTransition : MonoBehaviour
// {
//     [SerializedField] PolygonCollider2D mapBoundary;
//     CinemachineConfiner confiner;
//     [SerializeField] Direction direction;
//     [SerializeField] float additivePos = 2f;
//     enum Direction { Up, Down, Left, Right}
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         confiner = FindObjectofType<CinemachineConfiner>();
//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.gameObject.CompareTag("Player"))
//         {
//             confiner.m_BoundingShape2D = mapBoundary;
//         }
//     }
// }
