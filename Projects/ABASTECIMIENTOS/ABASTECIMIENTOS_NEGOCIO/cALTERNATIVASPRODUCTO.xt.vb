Partial Public Class cALTERNATIVASPRODUCTO

    ' Autor: Jos� Ch�vez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Funcion utilizada para obtener las alternativas de un producto
    ' Creaci�n: 14/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsAlternativas(ByVal IDPRODUCTO As Int64) As DataSet
        Return mDb.ObtenerDsAlternativas(IDPRODUCTO)
    End Function

    ' Autor: Jos� Ch�vez
    '-------------------------------------------------------------------------------------------------------------------------
    ' Utilidad: Funcion utilizada para verificar si un producto es alternativa de otro
    ' Creaci�n: 14/12/06 
    '-------------------------------------------------------------------------------------------------------------------------
    Public Function ObtenerDsAlternativasDe(ByVal IDALTERNATIVA As Int64) As Int16
        Return mDb.ObtenerDsAlternativasDe(IDALTERNATIVA)
    End Function

End Class
