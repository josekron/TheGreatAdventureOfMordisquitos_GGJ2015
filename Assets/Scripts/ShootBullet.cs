using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {
	public GameObject bullet;
	private float time;
	public float shootTime=5;
	public enum dir{left,right};
	public dir direction;
	// Use this for initialization

    private float distanceShoot = 1.1f;
	void Start () {
		if (direction.Equals(dir.left)) {
			this.transform.Rotate(new Vector3(0,180,180));
		}
	}
	
	// Update is called once per frame
	void Update () {
		GameObject obj;
		time += Time.deltaTime;
		if(time>=shootTime){
			if(direction.Equals(dir.left)){
                obj = (GameObject)Instantiate(bullet, new Vector3(this.transform.position.x - distanceShoot, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				obj.rigidbody.constantForce.force=Vector3.left;
                obj.transform.Rotate(0, -90, 0);
			}else if(direction.Equals(dir.right)){
                obj = (GameObject)Instantiate(bullet, new Vector3(this.transform.position.x + distanceShoot, this.transform.position.y, this.transform.position.z), Quaternion.identity);
				obj.rigidbody.constantForce.force=Vector3.right;
                obj.transform.Rotate(0, -90, 0);

			}
				time=0;
		}
	}
	
}
