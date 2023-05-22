using Leader.Domain.Enums.Requirement;

namespace Leader02.Application.DtoModels;

public class RequirementDto
{
    public int Id { get; set; }
    
    public DepartmentDto? DepartmentDto { get; set; }
    
    public string? BasicRequirementDescription { get; set; }//Описание базового требования (группы ОТ)	
    public string? BasicRequirementDetail { get; set; }//Детализация базового требования	
    public RequirementType? RequirementType { get; set; }//Тип требования (1-к субъекту, 0-к объекту)	
    public string? IndicationOfNpa { get; set; }//Указание на НПА, ПА (наименование, структурные единицы, текст нормы)	
    public string? ValidityPeriodOfLegalAct { get; set; }//Период действия НПА (c - по)	
    public string? ValidityPeriodOfRequirement { get; set; }//Период действия ОТ (c - по)
    
    public VerificationMethod? VerificationMethod { get; set; }//Метод проверки  соответствия ОТ 1-8
    public string? ConfirmingComplianceDocuments { get; set; }//Документы, подтверждающие  соответствие субъекта/объекта контроля ОТ (если применимо)	
    public string? Ogv { get; set; }//ОГВ (ОМСУ), организации, в распоряжении которых находятся необходимые сведения (уполномоченные на выдачу подтверждающих документов)	
    public string? PossibilityOfDocumentsObtaining { get; set; }//Возможность получения КНО необходимых подтверждающих документов/сведений по межведомственному взаимодействию (да/нет)	
    public string? SupportingDocumentsValidity { get; set; }//Срок действия подтверждающих документов (если применимо)
    
    public string? TypeOfLiability { get; set; }//Вид ответственности (уголовная /административная/ гражданско-правовая/иная ответственность)	
    public string? SubjectOfResponsibility { get; set; }//Субъект ответственности	
    public string? Sanction { get; set; }//Санкция	
    public string? SizeOfSanction { get; set; }//Размер санкции	
    public string? TypeOfNorm { get; set; }//Вид нормы (общая, специальная) 	
    public string? ReferenceToLegalAct { get; set; }//Указание на НПА (НПА, структурные единицы, текст нормы)	
    public string? EmpoweredToHoldAuthority { get; set; }//Орган, уполномоченный на привлечение к ответственности	
    public string? ResponsibilityBringingProcedure { get; set; }//Порядок привлечения к ответственности (ссылка на файл без авторизации)
    
    public string? TypesOfActivitiesOfSubjects { get; set; }//Виды деятельности субъектов контроля, на которые распространяется ОТ (по ОКВЭД 2)	
    public string? ClarificationOfTypeOdActivity { get; set; }//Уточнение вида деятельности (при необходимости)
    
    public string? CharacteristicForGeneralQuestion { get; set; }//Характеристика (для общего вопроса)	
    public string? BusinessQuestionContentForProfilingForGeneralQuestion { get; set; }//Содержание вопроса бизнесу для профилирования (для общего вопроса)	
    public string? CharacteristicForClarifyingQuestion { get; set; }//Характеристика (для уточняющего вопроса)	
    public string? BusinessQuestionContentForProfilingForClarifyingQuestion { get; set; }//Содержание вопроса бизнесу для профилирования (для уточняющего вопроса)
}