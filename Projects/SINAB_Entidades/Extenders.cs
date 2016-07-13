using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Web.Configuration;

namespace SINAB_Entidades
{

    public partial class SAB_CAT_DOCUMENTOSBASE : EntityObject
    {
        public string TipoDocumento
        {
            get
            {
                return SAB_CAT_TIPODOCUMENTOBASE.DESCRIPCION;
            }
        }

    }

    public partial class FiltrarLotes_Result : ComplexObject
    {
        public int IDTIPOTRANSACCION { get; set; }
    }

    public partial class SAB_CP_ASPECTOSPRODUCTOS : EntityObject
    {
        public string Nombre
        {
            get { return SAB_CP_CAT_ASPECTOS.nombre; }
        }

        public EnumHelpers.EstadoAspectos EstadoAspecto
        {
            get { return (EnumHelpers.EstadoAspectos) (estado ?? 0); }
        }

    
    }

    public partial class SAB_CP_ESTADOSPRODUCTOS : EntityObject
    {

        public string EstadoProducto
        {
            get
            {
                return estado == 0 ? "Certificado" : "No Certificado";
            }
        }
    }

    public partial class SAB_UACI_ENTREGABASES : EntityObject
    {
        public string Nombre {
            get { return SAB_CAT_PROVEEDORES.NOMBRE; }
        }
    }

    public partial class SAB_CP_ESTADOSPRODUCTOS : EntityObject
    {
        public string Certificado {
            get
            {
                return estado == 0 ? "Certificado" : "No Certificado";
            }
        }
    }

    public partial class SAB_EST_CIFRADOPRODUCTOSSOLICITUDES : EntityObject
    {
        public string CifradoUnificado
        {
            get
            {
                return
                    string.Format("{0}{1}{2}{3}{4}{5}{6}{7}", Anio, CodigoInstitucion, AreaGestion,
                        UnidadPresupuestaria, LineaTrabajo, ClasificadorGastos, FuenteFinanciamiento,
                        ObjetoEspecificoGastos);
            }
        }
    }

    public partial class SAB_EST_SOLICITUDES : EntityObject
    {
        public string TipoSolicitud
        {
            get
            {
                return COMPRACONJUNTA == 0 ? EnumHelpers.TipoCompra.Individual.ToString() : EnumHelpers.TipoCompra.Conjunta.ToString();
            }
        }

        public string Estado
        {
            get
            {
                var res = string.Empty;
                switch (IDESTADO)
                {
                    case 1:
                        res = EnumHelpers.EstadosSolicitud.Grabada.ToString();
                        break;
                    case 2:
                        res = EnumHelpers.GetEnumDescription(EnumHelpers.EstadosSolicitud.EnviadaUACI);
                        break;
                    case 3:
                        res = EnumHelpers.EstadosSolicitud.Autorizada.ToString();
                        break;
                    case 4:
                        res = EnumHelpers.GetEnumDescription(EnumHelpers.EstadosSolicitud.RechazadaUACI);
                        break;
                    case 5:
                        res = EnumHelpers.GetEnumDescription(EnumHelpers.EstadosSolicitud.RechazadoProcesoCompra);
                        break;
                    case 6:
                        res = EnumHelpers.GetEnumDescription(EnumHelpers.EstadosSolicitud.AprobadoProcesoCompra);
                        break;
                }
                return res;
            }
        }

        public string Suministro
        {
            get { return SAB_CAT_SUMINISTROS.DESCRIPCION; }
        }

        public string UnidadTecnica
        {

            get { return SAB_CAT_DEPENDENCIAS.NOMBRE; }
        }

        public string DependenciaSolicitante
        {
            get { return SAB_CAT_DEPENDENCIAS.NOMBRE; }
        }

        public string ClaseSuministro {
            get
            {
                return SAB_CAT_SUMINISTROS == null ? "" : SAB_CAT_SUMINISTROS.DESCRIPCION;
            }
        }

        public string Descripcion {
            get { return SAB_CAT_ESTADOS.DESCRIPCION; }
        }

        public IEnumerable<string> FuentesFinanciamiento {
            get
            {
                return SAB_EST_FUENTEFINANCIAMIENTOSOLICITUDES.Select(ff => ff.SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE);
            }
        }
    }

    public partial class SAB_CAT_GRUPOS : EntityObject
    {
        public string DescripcionCompleta
        {
            get { return string.Format("({0}) {1}", CORRELATIVO, DESCRIPCION); }
        }
    }

    public partial class SAB_CAT_SUBGRUPOS : EntityObject
    {
        public string DescripcionCompleta
        {
            get { return string.Format("({0}) {1}", CORRELATIVO, DESCRIPCION); }
        }
    }

    public partial class SAB_CAT_FUENTEFINANCIAMIENTOS : EntityObject
    {
        public string Grupo
        {
            get { return SAB_CAT_GRUPOSFUENTEFINANCIAMIENTO.DESCRIPCION ?? string.Empty; }
        }

        public string GrupoYFuente
        {
            get { return string.Format("{0}/{1}", Grupo, NOMBRE); }
        }

        public string NombreOrden
        {
            get { return NOMBRE == "GOES" ? "_GOES" : NOMBRE; }
        }

    }

    public partial class SAB_CAT_TIPODOCUMENTOCONTRATO : EntityObject
    {
        public string DescripcionCompleta
        {
            get { return APLICASOLOALMACEN == 1 ?  DESCRIPCION + " (Almacen)" : DESCRIPCION; }
        }
    
    }

    public partial class SAB_LAB_INFORMEMUESTRAS : EntityObject
    {
        public string TIPOINFORME
        {
            get
            {
                return SAB_CAT_TIPOINFORMES.DESCRIPCION;
            }
        }
    }

    public partial class SAB_UACI_FUENTEFINANCIAMIENTOSCONTRATOS : EntityObject
    {
        public string Nombre
        {
            get { return SAB_CAT_FUENTEFINANCIAMIENTOS.NOMBRE; }
        }
    }

    public partial class SAB_UACI_CONTRATOS : EntityObject
    {
        public string NombreProveedor
        {
            get
            {
                return SAB_CAT_PROVEEDORES.NOMBRE;
            }
        }

        public string DescripcionTipoDocumento
        {
            get
            {
                return SAB_CAT_TIPODOCUMENTOCONTRATO.DESCRIPCION;
            }
            
        }

        public int IdAlmacen { get; set; }
    }

    public partial class SAB_UACI_RESPONSABLEDISTRIBUCIONCONTRATO : EntityObject
    {
        public string Nombre
        {
            get { return SAB_CAT_RESPONSABLEDISTRIBUCION.NOMBRE; }
        }

        public string NombreCorto
        {
            get { return SAB_CAT_RESPONSABLEDISTRIBUCION.NOMBRECORTO; }
        }

    }

    public partial class SAB_CAT_EMPLEADOS : EntityObject
    {
        public string NombreCompleto
        {
            get { return NOMBRE + " " + APELLIDO; }
        }
    }

    public partial class SAB_UACI_PROCESOCOMPRAS : EntityObject
    {
        public string DescripcionProcesoCompra
        {
            get { return CODIGOLICITACION + " " + TITULOLICITACION; }
        }

        public string Descripcion
        {
            get { return SAB_CAT_ESTADOPROCESOSCOMPRAS.DESCRIPCION; }
        }

        public decimal MontoAutorizadoTotal
        {
            get { return SAB_EST_SOLICITUDESPROCESOCOMPRAS.Sum(spc => spc.SAB_EST_SOLICITUDES.MONTOAUTORIZADO) ?? 0; }
        }

        public decimal MontoDisponibleTotal
        {
            get { return SAB_EST_SOLICITUDESPROCESOCOMPRAS.Sum(spc => spc.SAB_EST_SOLICITUDES.MONTODISPONIBLE) ?? 0; }
        }

        public decimal MontoSolicitadoTotal
        {
            get { return SAB_EST_SOLICITUDESPROCESOCOMPRAS.Sum(spc => spc.SAB_EST_SOLICITUDES.MONTOSOLICITADO) ?? 0; }
        }

        public string Observacion
        {
            get
            {
                var obs = SAB_UACI_OBSERVACIONPROCESOSCOMPRAS.Select(opc => opc.OBSERVACION).ToList();
                if (!obs.Any()) return string.Empty;
                var res = obs.Aggregate((current, next) => current + ", " + next);
                return res;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return SAB_CAT_EMPLEADOS == null ? string.Empty : string.Format("{0} {1}", SAB_CAT_EMPLEADOS.NOMBRE, SAB_CAT_EMPLEADOS.APELLIDO);
            }
        }
    }

    public partial class SAB_EST_DISTRIBUCION : EntityObject
    {
        public string Periodo
        {
            get
            {
                return string.Format("{0}/{1}", FECHADISTRIBUCION.Month, FECHADISTRIBUCION.Year);
            }
        }

        public string Almacen
        {
            get { return SAB_CAT_ALMACENES.NOMBRE; }
        }

        public int SuministrosIdSuministro
        {
            get { return SAB_CAT_SUMINISTROS.IDSUMINISTRO; }
        }

        public string SuministrosDescripcion {
            get { return SAB_CAT_SUMINISTROS.DESCRIPCION; }
        }

        public string NombreEstado
        {
            get
            {
                 switch(ESTADO)
                {
                     case 0:
                        return "Iniciada";//"Liberada";
                     case 1:
                        return "Guardada";//"Iniciada";
                     case 2:
                        return "Cerrada";//"En proceso";
                     case 3://4
                        return "Pendiente";//"Anulada";
                     case 5://4
                        return "Anulada";
                       

                     default:
                        return "Finalizada";
                }
            }
        }

        public int idTipoEstablecimiento { get; set; }
    }

}
