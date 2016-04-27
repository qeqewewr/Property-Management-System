using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Global 的摘要说明
/// </summary>
/// 
namespace CEMIS.Util
{
    public class Global
    {
        private static int seed = 1;
        public Global()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public static int GetSeed()
        {
            return IncrSeed();
        }
        private static int IncrSeed()
        {
            try
            {
                // System.Threading.Monitor.Enter(seed);
                seed++;
                if (seed == 1000)
                    seed = 1;
            }
            finally
            {
                //System.Threading.Monitor.Exit(seed);

            }
            return seed;


        }


    }
}