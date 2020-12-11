using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation : MonoBehaviour
{

  public AnimationClip jump;
  Animation anim;

  // Start is called before the first frame update
  void Start()
  {
    gameObject.SetActive(false);
    anim = GetComponent<Animation>();
    anim.clip = jump;
  }
  public void playJumpAnimation()
  {
    anim.Play();
  }
}
