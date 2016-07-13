using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINAB_Entidades.Tipos
{
    [Serializable]
    public class ListaProceso
    {
        public ListaProceso(string procesoId)
        {
            IdProceso = procesoId;
            if (Listado == null)
            {
                Listado = new List<SAB_ALM_DETALLEMOVIMIENTOS>();
            }
        }

        public string IdProceso
        {
            get; set;
        }

        public List<SAB_ALM_DETALLEMOVIMIENTOS> Listado
        {
            get; set;
        }
    }

    public static class BancoProcesos
    {
        public static void Init()
        {
            if (Procesos == null)
            {
                Procesos = new List<ListaProceso>();
            }
        }

        public static List<ListaProceso> Procesos { get; set; }
        

        public static void InsertItem(string idproceso, SAB_ALM_DETALLEMOVIMIENTOS item)
        {
            var proceso = Get(idproceso);
            try
            {
                proceso.Listado.Add(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteItem(string idproceso, SAB_ALM_DETALLEMOVIMIENTOS item)
        {
            var proceso = Get(idproceso);
            try
            {
                proceso.Listado.Remove(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ListaProceso Get(string idproceso)
        {
            return Procesos.FirstOrDefault(p => p.IdProceso == idproceso);
        }
    }

}
