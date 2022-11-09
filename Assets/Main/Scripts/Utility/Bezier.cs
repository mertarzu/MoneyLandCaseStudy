using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier 
{
    public static Vector3 QuadraticBezierCurveSolver(float t, Vector3 P0, Vector3 P1, Vector3 P2)
    {
        float cX = QuadraticBezierCurve(t, P0.x, P1.x, P2.x);
        float cY = QuadraticBezierCurve(t, P0.y, P1.y, P2.y);
        float cZ = QuadraticBezierCurve(t, P0.z, P1.z, P2.z);
        return new Vector3(cX, cY, cZ);
    }
    static float QuadraticBezierCurve(float t, float P0, float P1, float P2)
    {
        float curve = P0 * (1 - t) * (1 - t) + P1 * 2 * t * (1 - t) + P2 * t * t;
        return curve;
    }

    public static Vector3 CubicBezierCurveSolver(float t, Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3)
    {
        float cX = CubicBezierCurve(t, P0.x, P1.x, P2.x, P3.x);
        float cY = CubicBezierCurve(t, P0.y, P1.y, P2.y, P3.y);
        float cZ = CubicBezierCurve(t, P0.z, P1.z, P2.z, P3.z);
        return new Vector3(cX, cY, cZ);
    }
    static float CubicBezierCurve(float t, float P0, float P1, float P2, float P3)
    {
        float curve = P0 * (1 - t) * (1 - t) * (1 - t) + P1 * 3 * t * (1 - t) * (1 - t) + P2 * 3 * t * t * (1 - t) + P3 * t * t * t;
        return curve;
    }
}
