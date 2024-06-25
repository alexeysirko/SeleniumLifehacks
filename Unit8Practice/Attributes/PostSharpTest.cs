//using PostSharp.Aspects;
//using PostSharp.Serialization;

namespace Unit8Practice.Attributes
{
    internal class PostSharpTest
    {
        //[TrackUsage]
        public static void PostSharpLogic()
        {
            Console.WriteLine("Some random action");
        }
    }

    //[PSerializable]
    //public class TrackUsage : MethodInterceptionAspect
    //{
    //    public TrackUsage()
    //    {

    //    }

    //    public override void OnInvoke(MethodInterceptionArgs args)
    //    {
    //        NotifyCodeHit();
    //        //base.OnInvoke(args);
    //    }

    //    public void NotifyCodeHit()
    //    {
    //        Console.WriteLine("CODE HIT!");
    //    }
    //}
}
