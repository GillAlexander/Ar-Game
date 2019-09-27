using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeTestTween : MonoBehaviour
{
	public ParticleSystem tweenParticle;
	public Ease ease = Ease.Linear;

    float width;
    float height;
	float baseRotX, baseRotY, baseRotZ;
	float t = 1;

    void Start()
    {
        width = transform.localScale.x;
        height = transform.localScale.y;
		baseRotX = transform.localRotation.x;
		baseRotY = transform.localRotation.y;
		baseRotZ = transform.localRotation.z;
	}

    void Update()
	{
		t += Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.E) && t > 0.8f)
		{
			//StartCoroutine(timeDelay());
			PlayerWalk();
			t = 0;
		}
	}

    private void PlayerScale()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y / 5, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, height + 1f, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y / 5, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, height + 1f, transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(transform.DOScale(new Vector3(width, height, transform.localScale.z), 0.1f));
    }

    public void PlayerPeck()
    {
        Sequence mySequence1 = DOTween.Sequence();
        mySequence1.Append(transform.DORotate(new Vector3(60f, 0f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(transform.DORotate(new Vector3(60f, 0f, 0f), 0.1f).SetLoops(1, LoopType.Restart));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(transform.DORotate(new Vector3(0f, 0f, 0f), 0.1f));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(transform.DORotate(new Vector3(baseRotX, baseRotY, baseRotZ), 0.1f));
    }

    public void PlayerWalk()
    {
        Sequence mySequence2 = DOTween.Sequence();
		mySequence2.Append(transform.DORotate(new Vector3(0f, 0f, 15f), 0.2f).SetLoops(1, LoopType.Restart).SetEase(ease, 10f));
		mySequence2.PrependInterval(0.1f);
		mySequence2.Append(transform.DORotate(new Vector3(0f, 0f, -15f), 0.4f).SetLoops(1, LoopType.Restart).SetEase(ease, 10f));
		mySequence2.PrependInterval(0.1f);
		mySequence2.Append(transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f).SetLoops(1, LoopType.Restart).SetEase(ease, 10f));
		mySequence2.PrependInterval(0.1f);
		mySequence2.Append(transform.DORotate(new Vector3(baseRotX, baseRotY, baseRotZ), 0f).SetEase(ease, 10f));
	}

	private void PlayerScaleExplode()
	{
		Sequence mySequence = DOTween.Sequence();
		mySequence.Append(transform.DOScale(new Vector3(width, transform.localScale.y / 5, transform.localScale.z), 0.1f));
		mySequence.PrependInterval(0.1f);
		mySequence.Append(transform.DOScale(new Vector3(width + 1f, height + 1f, transform.localScale.z + 1f), 1f));
		mySequence.PrependInterval(0.1f);
		mySequence.Append(transform.DOScale(new Vector3(width = 0f, height = 0f, 0f), 0.1f));
	}

	public IEnumerator timeDelay()
	{
		PlayerScaleExplode();
		yield return new WaitForSeconds(1.4f);
		tweenParticle.Play();
	}
}
