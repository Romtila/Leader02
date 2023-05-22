using Leader.Domain.Enums.Requirement;

namespace Leader.Domain.Entity;

public class Requirement
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }
    public Department? Department { get; set; } = new();
    
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

/*Описание базового требования				
//Описание базового требования (группы ОТ)	
//Детализация базового требования	
//Тип требования (1-к субъекту, 0-к объекту)	
//Указание на НПА, ПА (наименование, структурные единицы, текст нормы)	
//Период действия НПА (c - по)	
//Период действия ОТ (c - по)

*Description of the basic requirement
//Description of the basic requirement (OT group)
//Basic Requirement Detail
//Type of requirement (1-to the subject, 0-to the object)
//Indication of NLA, PA (name, structural units, text of the norm)
//Validity period of legal acts (from - to)
//Validity period FROM (from - to)*/

/*Подтверждение соответствия субъекта/объекта обязательным требованиям				
//Метод проверки  соответствия ОТ 1-8
//Документы, подтверждающие  соответствие субъекта/объекта контроля ОТ (если применимо)	
//ОГВ (ОМСУ), организации, в распоряжении которых находятся необходимые сведения (уполномоченные на выдачу подтверждающих документов)	
//Возможность получения КНО необходимых подтверждающих документов/сведений по межведомственному взаимодействию (да/нет)	
//Срок действия подтверждающих документов (если применимо)

* Confirmation of compliance of the subject / object with mandatory requirements
//Compliance test method OT 1-8
//Documents confirming compliance of the subject/object of control with OT (if applicable)
//OGV (LSG), organizations that have the necessary information at their disposal (authorized to issue supporting documents)
//Possibility of obtaining the necessary supporting documents/information on interdepartmental interaction (yes/no)
//Validity of supporting documents (if applicable)*/

/*Ответственность за нарушение обязательного требования							
//Вид ответственности (уголовная /административная/ гражданско-правовая/иная ответственность)	
//Субъект ответственности	
//Санкция	
//Размер санкции	
//Вид нормы (общая, специальная) 	
//Указание на НПА (НПА, структурные единицы, текст нормы)	
//Орган, уполномоченный на привлечение к ответственности	
//Порядок привлечения к ответственности (ссылка на файл без авторизации)

*Responsibility for violation of a mandatory requirement
//Type of liability (criminal / administrative / civil / other liability)
//Subject of responsibility
//Sanction
//Size of the sanction
//Type of norm (general, special)
//Reference to RLA (NLA, structural units, norm text)
//Authority empowered to hold accountable
//The procedure for bringing to responsibility (link to file without authorization)*/

/*Профилирование субъекта контроля	
//Виды деятельности субъектов контроля, на которые распространяется ОТ (по ОКВЭД 2)	
//Уточнение вида деятельности (при необходимости)

*Profiling the subject of control
//Types of activities of subjects of control to which the OT applies (according to OKVED 2)
//Clarification of the type of activity (if necessary)*/

/*Дополнительное профилирование			
//Характеристика (для общего вопроса)	
//Содержание вопроса бизнесу для профилирования (для общего вопроса)	
//Характеристика (для уточняющего вопроса)	
//Содержание вопроса бизнесу для профилирования (для уточняющего вопроса)

*Additional profiling
//Characteristic (for a general question)
//Business question content for profiling (for a general question)
//Characteristic (for a clarifying question)
//The content of the question to the business for profiling (for a clarifying question)*/