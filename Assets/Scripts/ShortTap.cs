using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

public class ShortTap : UIBehaviour
{
    protected override void Awake()
    {
        base.Awake();

        const double shortTapThreshold = 200d;

        this.OnPointerUpAsObservable()
            .Timestamp() // 時間情報付与
            .WithLatestFrom( // ポインターが離れたとき、最後に押された時の情報と合体させる
                this.OnPointerDownAsObservable().Timestamp(),
                (l, r) => new { up = l, down = r }
            )
            // 押した時と離れたときの間隔が shortTapThreshold 以下のときだけ通す
            .Where(pair => (pair.up.Timestamp - pair.down.Timestamp) <= TimeSpan.FromMilliseconds(shortTapThreshold))
            .Subscribe(_ => Debug.Log("Short Tap!"));
    }

}
