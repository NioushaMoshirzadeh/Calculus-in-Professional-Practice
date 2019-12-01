using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPP5thSemester
{
    class GraphVize
    {
        public static void SaveDotFile(IFunction root, string fileName)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            string text = "graph CPP {\n}" + "binary tree" + "}";
            try
            {
                fs = new FileStream(fileName + ".dot", FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(text);

            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                if (sw != null) { sw.Close(); }
                if (fs != null) { fs.Close(); }
            }


        }
    }
}
