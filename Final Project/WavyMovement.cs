using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyMovement : MonoBehaviour
{/*
    float m_Speed = 1;
    float m_XScale = 1;
    float m_YScale = 1;
 
    private Vector3 m_Pivot;
    private Vector3 m_PivotOffset;
    private float m_Phase;
    private bool m_Invert = false;
    //private float m_2PI = Mathf.PI * 2;
    private float x_move;
    private float y_move;

    // Start is called before the first frame update
    void Start() {
        m_Pivot = transform.position;
    }
 
    // Update is called once per frame
    void Update () {
        m_PivotOffset = Vector3.up * 2 * m_YScale;
    
        m_Phase += m_Speed * Time.deltaTime;
        if(m_Phase > Mathf.PI)
        {
            m_Invert = !m_Invert;
            m_Phase -= Mathf.PI;
            m_Pivot = transform.position;
        }
        if(m_Phase < 0) m_Phase += Mathf.PI;
    
        transform.position = m_Pivot + (m_Invert ? m_PivotOffset : Vector3.zero);
        x_move = transform.position.x + Mathf.Sin(m_Phase) * m_XScale;
        y_move = transform.position.y + Mathf.Cos(m_Phase) * (m_Invert ? -1 : 1) * m_YScale;

        transform.position = new Vector3(x_move, y_move, 0);
    }
    */
}
