
/// <summary>
/// Library Utility Comments....
/// </summary>
namespace ZKTeco.ProyectSample.UtilityLibraries
{
    #region "Usings"
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public class StringSets
    {

        #region "Variables Miembros"
        /// <summary>
        /// Almacenamos todos los sets de enteros que entren en el método Exists.
        /// </summary>
        private List<int[]> lstItems { get; set; }

        /// <summary>
        /// Almacenamos todos los sets de enteros que se dupliquen
        /// </summary>
        private readonly List<ItemsDuplicates> lstItemsDuplicates;
        #endregion

        #region "Constructor"
        /// <summary>
        /// 
        /// </summary>
        public StringSets()
        {
            lstItems = new List<int[]>();
            lstItemsDuplicates = new List<ItemsDuplicates>();
        }

        #endregion

        #region "Métodos"
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">String representando un SET de valores delimitado por coma.</param>
        /// <returns></returns>
        public bool Exists (string lstSets)
        {
            bool isInsert = false;

            if (!string.IsNullOrEmpty (lstSets))
            {
                //Separamos el string que llega separados por "," y lo convertimos a un array de int[]
                int[] sEts = lstSets.Split(',').Select(int.Parse).ToArray();

                //Recorremos el listado de Items (Sets) que vamos almacenando para comprobar si ya esta insertado o no.
                foreach (var item in lstItems.Where (x=> x.Length == sEts.Length))
                {
                    //comprobamos si el SETs de enteros que entra por parámetro (Sets) es igual que la secuencia (Item)
                    isInsert = sEts.OrderBy(x => x).SequenceEqual(item.OrderBy(x => x));
                    if (isInsert)
                    {
                        //Si está ya insertado obtenemos el item en el listado de duplicados por si este ya hubiera sido insertado antes como duplicado                       
                        var value = lstItemsDuplicates.FirstOrDefault(x => x.Values.OrderBy(y=>y).SequenceEqual(item.OrderBy(z => z)));
                        if (value == null )
                            //Si no estaba ya insertado lo añadimos concontador 1
                            lstItemsDuplicates.Add(new ItemsDuplicates() { Total = 1, Values = sEts });
                        else
                            //Si ya estaba duplicado incrementamos contador para llevar la cuenta de ese Sets de enteros repetidos.
                            lstItemsDuplicates.FirstOrDefault(x=>x.Total == value.Total).Total++ ;
                        break;
                    }
                }
                //Almacenamos todos en una lista
                lstItems.Add(sEts);
            }

            //Devolvemos True o False si ya está insertado o no.
            return isInsert;
        }


        /// <summary>
        /// Devuelve en una estructura InfoSets con información sobre sets duplicados y no duplicados que han sido insertados hasta el momento.
        /// </summary>
        /// <returns></returns>
        public InfoSets GetSetsInfo()
        {
            //Creamos una estructura con la inforamación del set a devolver
            InfoSets objInfo = new InfoSets();
            objInfo.numSetsDuplicados = lstItemsDuplicates.Count ;
            objInfo.numSetsNoDuplicados = lstItems.Count - lstItemsDuplicates.Count;
            //Devolvemos la información de los sets duplicados y no duplicados.
            return objInfo;
        }


        // <summary>
        // Devuelve en una lista de enteros las inserciones incorrectas realizadas hasta el momento..
        // </summary>
        // <returns></returns>
        public List<int[]> GetSetsWrongs()
        {
            //Devolvemos la lista de inserciones incorrectas desl listado de duplicados.
            var ret = lstItemsDuplicates.Select(x=>x.Values);
            return ret.ToList();
        }


        /// <summary>
        /// Devuleve un string con el Set de elementos del grupo más frecuente insertado.
        /// </summary>
        /// <returns></returns>
        public string GetSetFrequently()
        {
            //Ordenamos la lista de duplicados por el valor TOTAL para que nos quede ordenado de manera DESCENDIENTE
            var ret = lstItemsDuplicates.OrderByDescending(x => x.Total).FirstOrDefault().Values ;
            //Devolvermos el primer valor de la lista que nos da el sets de valores con más frecuencia insertado.

            return string.Join(",", ret);
        }

        #endregion
    }
}
