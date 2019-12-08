using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BSP.B1
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Controller : MonoBehaviour
    {
        private int count;
        private GroundState groundState;
        private bool dirCheckLeft = false;
        private bool dirCheckRight = false;
        private float speed = 28f;
        private float accel = 4f;
        private float airaccel = 2f;
        private float jump = 10f;
        public float dashDistance = 5;
        CharacterController controller;
        private Vector2 input = Vector2.zero;

        private void Awake()
        {
            this.GetComponent<Rigidbody2D>().simulated = true;
        }

        private void Start()
        {
            groundState = new GroundState(this.gameObject);
            count = 0;
        }

        private void Update()
        {
            dirCheckLeft = false;
            dirCheckRight = false;
            if (Input.GetKey(KeyCode.A))
            {
                input.x = -1;
                dirCheckLeft = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                input.x = 1;
                dirCheckRight = true;
            }
            else
            {
                input.x = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {   
                input.y = 1;
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, (input.x == 0) ? transform.localEulerAngles.y : (input.x + 1) * 90,
                transform.localEulerAngles.z);
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (dirCheckLeft == true && dirCheckRight == false && groundState.isGround() == true)
                {
                    transform.position -= new Vector3(7.5f * Time.deltaTime * dashDistance, 0.01f, 0.0f);
                }
                if (dirCheckRight == true && dirCheckLeft == false && groundState.isGround() == true)
                {
                    transform.position += new Vector3(7.5f * Time.deltaTime * dashDistance, 0.01f, 0.0f);
                }
            }
            if (count >= 20)
                Application.Quit();
        }

        private void FixedUpdate()
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(
            ((input.x * speed) - this.GetComponent<Rigidbody2D>().velocity.x * (groundState.isGround() ? accel : airaccel)), 0));
            this.GetComponent<Rigidbody2D>().velocity = new Vector2((input.x == 0 && groundState.isGround()) ? 0 : this.GetComponent<Rigidbody2D>().velocity.x,
                (input.y == 1 && groundState.isTouching()) ? jump :
                this.GetComponent<Rigidbody2D>().velocity.y);
            if (groundState.isWall() && !groundState.isGround() && input.y == 1)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                    -groundState.wallDirection() * speed * 0.75f,
                    this.GetComponent<Rigidbody2D>().velocity.y);
            }
            input.y = 0;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
                count++;
        }

        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.CompareTag("EnemyBullet"))
        //    {
        //        SceneManager.LoadScene("Restart");
        //    }
        //}
    }
}
