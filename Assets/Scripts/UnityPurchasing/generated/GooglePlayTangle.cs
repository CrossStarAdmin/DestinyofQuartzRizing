// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("40wR/xiKBpoNsVgQnoO2Hl5KiWnWJvnTsMpDoKdWS51hTs+dGI8vF/n8XJUskIwfT16FwJInuLR0VPFI4wq+qnxQUuaOrL5j+6PYufv1as4dz8Mf7OP+D/6rFLfZ/RHCGkdJZG2ai1aJvChlLsFBu/xp10DGNvu3mhkXGCiaGRIamhkZGKv6mys46cgHhUl8GWDYVFSOcJtA/k7PytQccOX0iulaUKC1DCzQZZ8NSvW/WSFL4UZtu+c4368artdhxJD3ISMqp3Aomhk6KBUeETKeUJ7vFRkZGR0YG3D970EagxY2OT869PHFtADOdH1heIwai+jQATqufI6ghS9aEnxdJRQHEJ4pLGdVd4WZefxCJ2NQzVinMOBGeFd2zRF/dRobGRgZ");
        private static int[] order = new int[] { 13,5,2,7,12,9,9,10,10,9,13,12,13,13,14 };
        private static int key = 24;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
