using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Models
{
    public class WorkplaceModel
    {
        public int IdWorkPlace { get; set; }
        public string IdExternal { get; set; }
        public int IdCompany { get; set; }
        public int IdPreApproval { get; set; }
        public int IdPosition { get; set; }
        public int IdLocation { get; set; }
        public int IdStructure { get; set; }
        public int IdContract { get; set; }
        public int IdJobDiagram { get; set; }
        public int IdManagementUnit { get; set; }
        public int IdManagement { get; set; }
        public int IdDepartment { get; set; }
        public int IdImpactType { get; set; }
        public int IdCoverageType { get; set; }
        public bool OilFieldAccess { get; set; }
        public bool InBudget { get; set; }
        public string Company { get; set; }
        public string ManagementUnit { get; set; }
        public string Contract { get; set; }
        public string Position { get; set; }
        public string ImpactType { get; set; }
        public int IdSector { get; set; }
        public int IdState { get; set; }
        public int IdCluster { get; set; }
        public int? IdCategory { get; set; }
        public int? IdAgreement { get; set; }
        public int? IdApplicationType { get; set; }
        public int IdReason { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string Observations { get; set; }
        public double? Percentage { get; set; }
        public string BossName { get; set; }
        public string BossPosition { get; set; }
        public string State { get; set; }
        public string ApplicationType { get; set; }
        public string Management { get; set; }
        public string UserHrbpFullName { get; set; }
        public string OpeUserFullName { get; set; }
        public string UserHrbpFullNameForReplacement { get; set; }
        public int? OpeUserId { get; set; }
        public int? HrbpUserId { get; set; }
        public string ReplacementOf { get; set; }
        public DateTime? CoverageDate { get; set; }
        public string StateDescription { get; set; }
        public string OldApplicationTypeDescription { get; set; }
        public bool Valorization { get; set; }
        public string Function { get; set; }
        public string Agreement { get; set; }
    }
}
