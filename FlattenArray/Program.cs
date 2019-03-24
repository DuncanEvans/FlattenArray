using System;
using System.Collections;
using System.Linq;

namespace FlattenArray
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Build Array of Arbitrarily Nested Arrays of Integers

            ArrayList arbArray = new ArrayList();
            arbArray.Add(new ArrayList());
            ((ArrayList)arbArray[0]).Add(1);
            ((ArrayList)arbArray[1]).Add(7);
            ((ArrayList)arbArray[2]).Add(11);
            arbArray.Add(9);
            arbArray.Add(new ArrayList());
            ((ArrayList)arbArray[2]).Add(new ArrayList());
            ((ArrayList)((ArrayList)arbArray[2])[0]).Add(67);
            ((ArrayList)((ArrayList)arbArray[2])[1]).Add(32);
            ((ArrayList)((ArrayList)arbArray[2])[2]).Add(3);
            ((ArrayList)((ArrayList)arbArray[2])[3]).Add(2);
            ((ArrayList)arbArray[2]).Add(5);
            arbArray.Add(new ArrayList());
            ((ArrayList)arbArray[3]).Add(new ArrayList());
            ((ArrayList)((ArrayList)arbArray[3])[0]).Add(new ArrayList());
            arbArray.Add(new ArrayList());
            ((ArrayList)arbArray[4]).Add(new ArrayList());
            ((ArrayList)((ArrayList)arbArray[4])[0]).Add(new ArrayList());
            ((ArrayList)((ArrayList)((ArrayList)((ArrayList)arbArray[4])[0])[0])).Add(8);
            arbArray.Add(72);
            arbArray.Add(48);
            arbArray.Add(70);
            arbArray.Add(81);
            arbArray.Add(new ArrayList());

            #endregion
            
            ArrayList flattenedList = Flatten(arbArray);

            foreach (Object obj in flattenedList)
            {
                Console.WriteLine(obj.ToString());
            }
        }

        public static ArrayList Flatten(ArrayList list)
        {
            ArrayList flattenedList = new ArrayList();
            flattenedList.AddRange(list);

            while (flattenedList.OfType<ArrayList>().Any())
            {
                int i = flattenedList.IndexOf(flattenedList.OfType<ArrayList>().ElementAt(0));
                ArrayList tmp = (ArrayList)flattenedList[i];
                flattenedList.RemoveAt(i);
                flattenedList.InsertRange(i, tmp);
            }

            return flattenedList;
        }
    }
}
