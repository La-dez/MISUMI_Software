using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stereo_Vision
{
    public interface IMeasurable
    {       
        float[] Points { get; set; }
        float Get_Measure();
       // abstract float 
    }
    public class Line2D: IMeasurable
    {
        public float[] Points { set; get; }
        public float Get_Measure()
        {
            return 0;
        }
    }
}
