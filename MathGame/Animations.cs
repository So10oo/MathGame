using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace MathGame
{
    internal static class Animations
    {
        public static StringAnimationUsingKeyFrames CreatStringAnimation(string message, double secondAnimation = 1, double secondEnd = 2)
        {
            var animation = new StringAnimationUsingKeyFrames();
            animation.AutoReverse = false;
            animation.FillBehavior = FillBehavior.Stop;
            double dTS = secondAnimation / message.Length;
            string tempText = string.Empty;
            double tempTime = 0;
            for (int i = 0; i < message.Length; i++)
            {
                tempTime += dTS;
                tempText += message[i];
                var frame = new DiscreteStringKeyFrame(tempText, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(tempTime)));
                animation.KeyFrames.Add(frame);
            }
            var frameEnd = new DiscreteStringKeyFrame(tempText, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(tempTime + secondEnd)));
            animation.KeyFrames.Add(frameEnd);
            return animation;
        }

        
    }
}
