using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.CMD.Controller
{
    public abstract class  ControllerBase
    {

        protected  void Save(string fileName, object item)
        {

            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }

        }

       
        protected  void Load<T>(string fileName)
        {

            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("food.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T) ;
                }
            }

        }

    }


}
