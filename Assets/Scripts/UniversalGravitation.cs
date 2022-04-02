using UnityEngine;
using System.Collections;

public class UniversalGravitation : MonoBehaviour
{

	private PhysicsEngine[] physicsEngineArray;

	/* -------------------- PART 2 ------------------------------------*/
	//Define the private constant for the G (gravitational coeeficient):
	private float gravity_coefficient;
	

	// Use this for initialization
	void Start()
	{
		gravity_coefficient = 6.6743E-11f;
		physicsEngineArray = GameObject.FindObjectsOfType<PhysicsEngine>();
	}

	void FixedUpdate()
	{
		CalculateGravity();
	}

	/* -------------------- PART 2 ------------------------------------*/
	void CalculateGravity()
	{
		// for each object in physicsEngineArray:
		//CODE: foreach (PhysicsEngine ObjectA in physicsEngineArray) {

		foreach (PhysicsEngine ObjectA in physicsEngineArray)
		{

			// for each object in the physicsEngineArray:
			//CODE: foreach (PhysicsEngine ObjectB in physicsEngineArray)	{

			foreach (PhysicsEngine ObjectB in physicsEngineArray)
			{

				if (ObjectA != ObjectB)
                {
					if (ObjectA != this)
                    {
						float r = Vector3.Distance(ObjectA.transform.position, ObjectB.transform.position) ;

						r = Mathf.Pow(r, 2);

						float gravityMagnitude = gravity_coefficient * ((ObjectA.mass * ObjectB.mass) / r);

						Vector3 offset = ObjectA.transform.position - ObjectB.transform.position;

						Vector3 gravityFeltVector = gravityMagnitude * offset.normalized * -1;

						ObjectA.AddForce(gravityFeltVector);

					}
                }

				// Now we have two objects A and B; we can calulcate the Fg.
				//Eliminate duplicatation: if ObjectA is not Object B
				//Eliminate gravity on itself: If objectA=!this
				//CODE: .....


				// Find the (r) distance between Object A and Object B:
				//CODE: ...


				// Find (r^2) distance to the power of two; use Mathf.Pow: 
				//CODE: ...


				// Find (Fg) magnitude of the gravity force; 
				// CODE: gravityMagnitude = ....


				// Normalizing the gravity; Just uncomment the line below:
				//CODE: Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

				// Add the force to the list of the forces on physicsEngine for object A; 
				// Note that you need to take care of the negative sign (downward acceleration) manually:
				//CODE: ...
			}
		}

	}
}