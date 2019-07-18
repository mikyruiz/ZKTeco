/// <summary>
/// 
/// </summary>
namespace ZKTeco.ProyectSample.Console
{

    #region "USING"
    using System;
    using System.Collections.Generic;
    using UtilityLibraries;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    static class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*INICIO*/
            System.Diagnostics.Debug.WriteLine("Inicio: " +  DateTime.Now);

            
            StringSets clsStringSets = new StringSets();

            //Generamos un random de datos instroducidos como entrada
            List<int[]> lstCollecion = GenerateRamdomData();

            //Recorremos la collecion y compromamos si existe un SET de items.
            foreach (var item in lstCollecion)
            {
                bool ret = clsStringSets.Exists(string.Join(",", item));
                if (ret) System.Diagnostics.Debug.WriteLine(ret);
            }

            System.Diagnostics.Debug.WriteLine(null);

            //Elementos duplicados y no duplicados
            InfoSets resInfo = clsStringSets.GetSetsInfo();
            System.Diagnostics.Debug.WriteLine("Nº Elementos sets Duplicados:" + resInfo.numSetsDuplicados);
            System.Diagnostics.Debug.WriteLine("Nº Elementos sets No Duplicados:" + resInfo.numSetsNoDuplicados);

            System.Diagnostics.Debug.WriteLine(null);
            

            //Inserciones incorrectas hasta el momento
            List<int[]> setsWrongs = clsStringSets.GetSetsWrongs ();
            System.Diagnostics.Debug.WriteLine("Inserciones incorrectas hasta el momento:");
            if (setsWrongs != null)
                foreach (var wrong in setsWrongs)
                    System.Diagnostics.Debug.WriteLine(string.Join(",", wrong));

            System.Diagnostics.Debug.WriteLine(null);

            //Elementos del grupo más frecuente
            System.Diagnostics.Debug.WriteLine("Elementos del grupo más frecuente:" + clsStringSets.GetSetFrequently());
            
            System.Diagnostics.Debug.WriteLine("Fin: " + DateTime.Now);
            /*FIN*/
        }


        /// <summary>
        /// Método aleatorio que genera 10000 Sets de enteros de 3 integers (Esto se puede modificar a gusto, tanto el nº de sets como el rango de enteros a generar)
        /// </summary>
        /// <returns></returns>
        static private List<int[]> GenerateRamdomData()
        {
            List<int[]> lstInts = new List<int[]>();
            Random rand = new Random();
            int randLen = 0;
           
            for (int j = 0; j < 10000; j++)//10000 rango de SETS para probar.
            {
                randLen = rand.Next(3, 4); //Generamos SETs de 3 numéricos.
                int[] randNumber = new int[randLen];
                for (int i = 0; i < randLen; i++)
                {
                    randNumber[i] = rand.Next(1, 100);                    
                }
                lstInts.Add(randNumber);
            }
            return lstInts;          
        }
    }
}
