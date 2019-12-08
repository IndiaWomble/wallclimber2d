using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BSP.B1
{
	/**/
	public class GroundState
	{
		private GameObject player;
		private float width;
		private float height;
		private float length;

		public GroundState(GameObject playerRef)
		{
			player = playerRef;
            width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
            height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;

            length = 0.05f;
        }

        public bool isGround()
        {
            bool b1 = Physics2D.Raycast(
                new Vector2(player.transform.position.x,
                player.transform.position.y - height),Vector2.down, length);
            bool b2 = Physics2D.Raycast(
                new Vector2(player.transform.position.x + (width - 0.2f),
                player.transform.position.y - height), Vector2.down, length);
            bool b3 = Physics2D.Raycast(
                new Vector2(player.transform.position.x - (width - 0.2f),
                player.transform.position.y - height), Vector2.down, length);

            return (b1 || b2 || b3);
        }

        public bool isWall()
        {
            bool left = isWallLeft();
            bool right = isWallRight();

            return (left || right);
        }
        public bool isWallLeft()
        {
            return Physics2D.Raycast(
                new Vector2(player.transform.position.x - width,
                player.transform.position.y), Vector2.left, length);
        }

        public bool isWallRight()
        {
            return Physics2D.Raycast(
                new Vector2(player.transform.position.x + width,
                player.transform.position.y), Vector2.right, length);
        }
        public bool isTouching()
        {
            return (isGround() || isWall());
        }

        public int wallDirection()
        {
            bool left = isWallLeft();
            bool right = isWallRight();

            if (left)
                return -1;
            else if (right)
                return 1;
            else
                return 0;
        }
	}
}
