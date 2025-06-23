using UnityEngine;

public class VectorOperator : MonoBehaviour
{
    public Vector3 vecA = new Vector3(1, 0, 0);
    public Vector3 vecB = new Vector3(0, 1, 0);

    void Start()
    {
        float resultD = Vector3.Dot(vecA, vecB);
        float resultA = Vector3.Angle(vecA, vecB);
        Vector3 resultC = Vector3.Cross(vecA, vecB);

        Debug.Log($"벡터의 내적 : {resultD}");
        Debug.Log($"벡터의 끼인각 : {resultA}");
        Debug.Log($"벡트의 외적 : {resultC}");
    }
}
