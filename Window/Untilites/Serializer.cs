using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowEngine.Untilites
{
    public static class Serializer
    {
        public static void Serialize<T>(T instance, string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(fs, instance);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        internal static T FromFile<T>(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var serializer = new DataContractSerializer(typeof(T));
                    T instance = (T)serializer.ReadObject(fs);
                    return instance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }
    }
}
