using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f; //움직임이 최대치까지 갔다 다시 돌아오는데 걸리는 시간

    float movementFactor;//0 for not move, 1 for full move
    Vector3 startingPos;
	// Use this for initialization
	void Start () {
        startingPos = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
        if (period <=Mathf.Epsilon) { return; }//protect against period is zero 
        float cycles = Time.time / period;//grows continually from 0
        float tau = Mathf.PI * 2; // about 6.28

        float rawSinwave = Mathf.Sin(cycles* tau);//goes from -1 to +1 [range (0,1)]을 대체 
        movementFactor = rawSinwave / 2f + 0.5f;//0.5 이유는 바를 0~1로 설정했기 때문. 이 상태에서 나누면 -0.5~0.5가 되니

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
