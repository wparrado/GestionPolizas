using System;

namespace GestionPolizas.Common
{
    public class Constants
    {
        public static string coveragePercentageError = "Para una póliza de seguro con línea de riesgo alto, el porcentaje de cubrimiento no puede ser superior al 50%.";
        public static string policyRelationError = "No es posible eliminar la poliza porque existen clientes relacionados a la misma";
        public static string policyCreated = "Poliza creada";
        public static string policyUpdated = "Poliza actualizada";
        public static string policyDeleted = "Poliza eliminada";
    }
}
