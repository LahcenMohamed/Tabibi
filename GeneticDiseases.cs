using System;
using System.Threading.Tasks;
using MediatR;

public class AddGeneticDiseaseCommand : IRequest
{
    public int PatientId { get; set; }
    public string DiseaseName { get; set; }
    public DateTime DiagnosisDate { get; set; }
}

public class UpdateGeneticDiseaseCommand : IRequest
{
    public int Id { get; set; }
    public string DiseaseName { get; set; }
    public DateTime DiagnosisDate { get; set; }
}

public class DeleteGeneticDiseaseCommand : IRequest
{
    public int Id { get; set; }
}

public class GetByPatientIdQuery : IRequest<GeneticDisease[]>
{
    public int PatientId { get; set; }
}

public class GeneticDisease
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public string DiseaseName { get; set; }
    public DateTime DiagnosisDate { get; set; }
}