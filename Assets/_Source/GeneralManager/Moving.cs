using UnityEngine;

public class Moving : MonoBehaviour
{
   private float _speed = 15.0f;

   void Update()
   {
      transform.Translate(Vector3.left * _speed * Time.deltaTime);
   }
}