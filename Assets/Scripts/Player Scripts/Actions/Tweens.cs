using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tweens : MonoBehaviour
{
    public ParticleSystem loveParticle;
    public ParticleSystem toneParticle;
    float width;
    float height;
    float t = 1;
    Player player;
    public Ease ease = Ease.Linear;

    void Start()
    {
        player = GetComponent<Player>();
        if (player.spawnedPlayer != null)
        {
            width = player.spawnedPlayer.transform.localScale.x;
            height = player.spawnedPlayer.transform.localScale.y;
        }
    }

    private void PlayerScale(GameObject player)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(player.transform.DOScale(new Vector3(width, player.transform.localScale.y / 5, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height + 1f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, player.transform.localScale.y / 5, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height + 1f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z), 0.1f));
    }

    public void PlayerPeck(GameObject player)
    {
        Sequence mySequence1 = DOTween.Sequence();
        mySequence1.Append(player.transform.DOLocalRotate(new Vector3(player.transform.rotation.x + 60, player.transform.rotation.y, player.transform.rotation.z), 0.1f).SetLoops(1, LoopType.Incremental));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DOLocalRotate(new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z), 0.1f));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DOLocalRotate(new Vector3(player.transform.rotation.x + 60, player.transform.rotation.y, player.transform.rotation.z), 0.1f).SetLoops(1, LoopType.Restart));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DOLocalRotate(new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z), 0.1f));
        mySequence1.PrependInterval(0.1f);
        mySequence1.Append(player.transform.DOLocalRotate(new Vector3(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z), 0.1f));
    }

    public void PlayerWalk(GameObject player)
    {
        Sequence mySequence2 = DOTween.Sequence();
        mySequence2.Append(transform.DORotate(new Vector3(0f, 0f, 15f), 0.2f).SetLoops(1, LoopType.Restart).SetEase(ease, 10f));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(transform.DORotate(new Vector3(0f, 0f, -15f), 0.4f).SetLoops(1, LoopType.Restart).SetEase(ease, 10f));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(transform.DORotate(new Vector3(0f, 0f, 0f), 0.2f).SetLoops(1, LoopType.Restart).SetEase(ease, 10f));
        mySequence2.PrependInterval(0.1f);
        mySequence2.Append(player.transform.DORotate(new Vector3(player.transform.localRotation.x, player.transform.localRotation.y, player.transform.localRotation.z), 0f));
    }

    public void PlayerScaleExplode(GameObject player)
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(player.transform.DOScale(new Vector3(width, player.transform.localScale.y / 5, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width + 1f, height + 1f, player.transform.localScale.z + 1f), 1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width = 0f, height = 0f, 0f), 0.1f));
        //reset scale
    }

    public IEnumerator timeDelay()
    {
        //PlayerScaleExplode();
        yield return new WaitForSeconds(1.4f);
        loveParticle.Play();
    }

    public void PetPlayer(GameObject player) {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(player.transform.DOScale(new Vector3(width, height - 1 / 5f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height + 1/5f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height - 1/5f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(width, height + 1/5f, player.transform.localScale.z), 0.1f));
        mySequence.PrependInterval(0.1f);
        mySequence.Append(player.transform.DOScale(new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z), 0.1f));
    }
}
