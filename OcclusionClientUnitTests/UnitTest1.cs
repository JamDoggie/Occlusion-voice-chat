using Microsoft.VisualStudio.TestTools.UnitTesting;
using Occlusion_voice_chat.Opus;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.HRTF;

namespace OcclusionClientUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ClampShortToDoubleTest()
        {
            for(int i = short.MinValue; i < short.MaxValue; i++)
            {
                double d = AudioMath.ClampShortToDouble((short)i);

                Assert.IsTrue(d >= -1 && d <= 1);
            }
        }
    }
}
