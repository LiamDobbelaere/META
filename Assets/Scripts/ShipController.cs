using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {
    public float speedMultiplier;
    public float acceleration;
    public float maxBanking;

    private float smoothHorizontal;
    private float smoothVertical;
    private float banking;

    private Transform mesh;
    private Rigidbody rigidbody;

    private bool isDead;

	// Use this for initialization
	void Start () {
        mesh = transform.Find("MeshRepresentation");
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isDead)
        {
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.None;
            transform.Find("Main Camera").parent = null;
            transform.gameObject.AddComponent<MeshCollider>();
            transform.GetComponent<MeshCollider>().convex = true;
            isDead = true;
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	// Update is called once per frame
	void Update () {
        if (!isDead)
        {
            smoothHorizontal = Mathf.Lerp(smoothHorizontal, Input.GetAxis("Horizontal"), 0.2f);
            smoothVertical = Mathf.Lerp(smoothVertical, Input.GetAxis("Vertical"), 0.2f);

            transform.position += (transform.forward * Time.deltaTime * acceleration)
                + (transform.right * smoothHorizontal * speedMultiplier)
                + (transform.up * smoothVertical * speedMultiplier);

            if (Input.GetButton("Bank"))
            {
                banking = Mathf.Lerp(banking, maxBanking, 0.2f);
            }
            else
            {
                banking = Mathf.Lerp(banking, 0f, 0.2f);


                int targetValue = ((int)((transform.localEulerAngles.y + 45.0f) / 90f)) * 90;

                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.Lerp(transform.localEulerAngles.y, targetValue, 0.2f), transform.localEulerAngles.z);
            }

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + smoothHorizontal * banking, transform.eulerAngles.z);

            mesh.localEulerAngles = new Vector3(-smoothVertical * 25f, 0f, -smoothHorizontal * 25f);
        }
    }
}
