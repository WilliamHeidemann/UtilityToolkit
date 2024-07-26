// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace UtilityToolkit.Runtime
// {
//     public static class AnimationQueue
//     {
//         private static readonly Dictionary<GameObject, Queue<Animation>> Animations = new();
//         public static int QueueLengthLimit = 0;
//         
//         public static void QueueAnimation(Animation animation)
//         {
//             if (!Animations.ContainsKey(animation.gameObject))
//             {
//                 Animations.Add(animation.gameObject, new Queue<Animation>());
//             }
//
//             var queueLength = Animations[animation.gameObject].Count;
//             if (queueLength == 0)
//             {
//                 CreateTween(animation);
//             }
//             else if (queueLength == QueueLengthLimit)
//             {
//                 return;
//             }
//
//             Animations[animation.gameObject].Enqueue(animation);
//         }
//         
//         public static void ClearQueue(GameObject obj)
//         {
//             if (Animations.TryGetValue(obj, out var queue))
//             {
//                 queue.Clear();
//             }   
//         }
//         
//         private static void CreateTween(Animation animation)
//         {
//             animation.Tween().append(() => StartNextAnimation(animation.gameObject));
//         }
//         
//         private static void StartNextAnimation(GameObject obj)
//         {
//             Animations[obj].Dequeue();
//             if (!Animations[obj].TryPeek(out var next)) return;
//             CreateTween(next);
//         }
//         
//         public abstract class Animation
//         {
//             public readonly GameObject gameObject;
//
//             protected Animation(GameObject gameObject)
//             {
//                 this.gameObject = gameObject;
//             }
//
//             public abstract LTSeq Tween();
//         }
//     }
// }
//
