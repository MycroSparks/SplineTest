using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplineMesh
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Spline))]
    public class SplineController : MonoBehaviour {

        Spline spline;

        // Use this for initialization
        void Start () {
            spline = GetComponent<Spline>();

        }
	
	    // Update is called once per frame
	    void Update () {
            if (Input.GetKeyDown(KeyCode.F))
            {
                CurveSample sample = spline.GetSample(0.5f);
                spline.InsertNode(1, (new SplineNode(sample.location + Vector3.left * 3, (spline.nodes[0].Direction + spline.nodes[1].Direction)/2)));

                GetComponent<SplineMeshTiling>().CreateMeshes();

                Debug.Log(sample.distanceInCurve + "|" + sample.timeInCurve);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                spline.RemoveNode(spline.nodes[spline.nodes.Count-1]);
                GetComponent<SplineMeshTiling>().CreateMeshes();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                CurveSample sample = spline.GetSample(spline.nodes.Count - 2 + 0.5f);
                spline.nodes[spline.nodes.Count - 1].Position = sample.location;
                GetComponent<SplineMeshTiling>().CreateMeshes();
            }
	    }
    }
}