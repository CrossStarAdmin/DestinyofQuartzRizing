using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using Assets.FEScripts.Functions;
using DG.Tweening;
using TMPro;
using Cysharp.Threading.Tasks;

namespace Assets.FEScripts.Components.UI
{
    public class DiceComponent: MonoBehaviour
    {
        private Transform diceTransform;
        private RectTransform diceRectTransform;
        private float duration = 1.0f;
        private int spinTurns = 2;
        private Ease ease = Ease.OutCubic;
        private void Awake()
        {
            diceTransform = gameObject.transform;
            diceRectTransform = gameObject.GetComponent<RectTransform>();
        }
        private Dictionary<int, Quaternion> faceUpRotations = new Dictionary<int, Quaternion>
        {
            { 1, Quaternion.Euler(0,    0,  0) },
            { 2, Quaternion.Euler(0,   -270,  0) },
            { 3, Quaternion.Euler(-90,   0,  0) },
            { 4, Quaternion.Euler(-270,  0,  0) },
            { 5, Quaternion.Euler(0,  -90,  0) },
            { 6, Quaternion.Euler(0,  -180,  0) },
        };

        public async UniTask RollAnimation(int _result)
        {
            // 既存のアニメーションがあれば停止
            diceTransform.DOKill();

            // 目ごとの回転を取得（最終目標）
            if (!faceUpRotations.TryGetValue(_result, out var targetRot))
            {
                Debug.LogError($"Rotation mapping not found for result={_result}");
                return;
            }

            // ① 最初の目をランダムに設定（1-6のいずれかの面）
            int startFace = UnityEngine.Random.Range(1, 7);
            Quaternion startFaceRot = faceUpRotations[startFace];
            
            // ② バウンド時の目もランダムに設定（最終目標とは違う面）
            int bounceFace = UnityEngine.Random.Range(1, 7);
            while (bounceFace == _result) // 最終目標と同じ場合は再抽選
            {
                bounceFace = UnityEngine.Random.Range(1, 7);
            }
            Quaternion bounceFaceRot = faceUpRotations[bounceFace];
            
            // 少し傾きを加える（自然な感じに）
            Vector3 bounceTilt = new Vector3(
                UnityEngine.Random.Range(-15f, 15f),
                UnityEngine.Random.Range(-15f, 15f),
                UnityEngine.Random.Range(-15f, 15f)
            );

            // 位置設定
            var startPosition = new Vector3(600, 500, 100);
            var firstBouncePosition = new Vector3(200, 200, 0);
            var endPosition = new Vector3(0, 0, 0);

            // 最初の位置と回転に設定
            diceTransform.position = startPosition;
            diceTransform.rotation = startFaceRot;

            // アニメーションシーケンスの作成
            Sequence seq = DOTween.Sequence();
            
            // ① 最初のバウンドへ移動と回転（複数回転させる）
            seq.Append(diceTransform.DOLocalMove(firstBouncePosition, duration * 0.6f)
                .SetEase(Ease.OutQuad));
            seq.Join(diceTransform.DORotate(
                bounceFaceRot.eulerAngles + bounceTilt + new Vector3(720, 720, 0), 
                duration * 0.6f, 
                RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuad));

            // ② バウンド時の傾いた状態を設定
            seq.AppendCallback(() => {
                diceTransform.rotation = Quaternion.Euler(bounceFaceRot.eulerAngles + bounceTilt);
            });

            // ③ 最後の位置へ移動と回転（目的の面へ自然に到達）
            seq.Append(diceTransform.DOLocalMove(endPosition, duration * 0.4f)
                .SetEase(Ease.OutQuad));
            seq.Join(diceTransform.DORotate(targetRot.eulerAngles, duration * 0.4f)
                .SetEase(Ease.OutQuad));

            // アニメーション完了を待つ
            await seq.AsyncWaitForCompletion();

            // 念のため固定（誤差消し）
            diceTransform.rotation = targetRot;
            Debug.Log($"🎲 result = {_result}");
        }
    }
}