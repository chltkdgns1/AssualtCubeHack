using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaltCubeHack
{
    public abstract class SingleTon<T> where T : SingleTon<T>, new()
    {
        static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                    instance.Init();
                }
                return instance;
            }
        }

        abstract protected void Init();
    }
}
