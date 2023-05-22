using Leader.Domain.Entity;
using Leader.Domain.Enums.Requirement;
using Leader02.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Leader02.DataSetsParser.Parsers;

public class RequirementParser
{
    private readonly Leader02Context _context;

    public RequirementParser(Leader02Context context)
    {
        _context = context;
    }

    public void RequirementParsing()
    {
        
    }

    // 2 3 C:\\Users\\oRmtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГИН\\Земельный контроль 22 ОТ\\22 ОТ.xlsx
    public void Parsing0203()
    {
        var subDepartment = _context.SubDepartments
            .Include(x => x.Department)
            .FirstOrDefault(x => x.Id == 0);
        
        var fileName = "";
        
        var existingFile = new FileInfo(fileName);

        using var package = new ExcelPackage(existingFile);
        
        var worksheet = package.Workbook.Worksheets[0];
        
        var requirements = new List<Requirement>(worksheet.Dimension.Rows);

        for (var i = 3; i <= worksheet.Dimension.Rows; i++)
        {
            var requirementType = RequirementType.Object;
            var verificationMethod = VerificationMethod.Mock;
            var basicRequirementDescription = "";//Описание базового требования (группы ОТ)	
            var basicRequirementDetail = "";//Детализация базового требования	
            var indicationOfNpa = "";//Указание на НПА, ПА (наименование, структурные единицы, текст нормы)	
            var validityPeriodOfLegalAct = "";//Период действия НПА (c - по)	
            var validityPeriodOfRequirement = "";//Период действия ОТ (c - по)

            var confirmingComplianceDocuments = "";//Документы, подтверждающие  соответствие субъекта/объекта контроля ОТ (если применимо)	
            var ogv = "";//ОГВ (ОМСУ), организации, в распоряжении которых находятся необходимые сведения (уполномоченные на выдачу подтверждающих документов)	
            var possibilityOfDocumentsObtaining = "";//Возможность получения КНО необходимых подтверждающих документов/сведений по межведомственному взаимодействию (да/нет)	
            var supportingDocumentsValidity = "";//Срок действия подтверждающих документов (если применимо)

            var typeOfLiability = "";//Вид ответственности (уголовная /административная/ гражданско-правовая/иная ответственность)	
            var subjectOfResponsibility = "";//Субъект ответственности	
            var sanction = "";//Санкция	
            var sizeOfSanction = "";//Размер санкции	
            var typeOfNorm = "";//Вид нормы (общая, специальная) 	
            var referenceToLegalAct = "";//Указание на НПА (НПА, структурные единицы, текст нормы)	
            var empoweredToHoldAuthority = "";//Орган, уполномоченный на привлечение к ответственности	
            var responsibilityBringingProcedure = "";//Порядок привлечения к ответственности (ссылка на файл без авторизации)

            var typesOfActivitiesOfSubjects = "";//Виды деятельности субъектов контроля, на которые распространяется ОТ (по ОКВЭД 2)	
            var clarificationOfTypeOdActivity = "";//Уточнение вида деятельности (при необходимости)

            var characteristicForGeneralQuestion = "";//Характеристика (для общего вопроса)	
            var businessQuestionContentForProfilingForGeneralQuestion = "";//Содержание вопроса бизнесу для профилирования (для общего вопроса)	
            var characteristicForClarifyingQuestion = "";//Характеристика (для уточняющего вопроса)	
            var businessQuestionContentForProfilingForClarifyingQuestion = "";//Содержание вопроса бизнесу для профилирования (для уточняющего вопроса)
            
            var requirement = new Requirement
            {
                Department = subDepartment?.Department,
                SubDepartment = subDepartment,
                BasicRequirementDescription = basicRequirementDescription,
    BasicRequirementDetail = basicRequirementDetail,
    RequirementType = requirementType,
    IndicationOfNpa = indicationOfNpa,
    ValidityPeriodOfLegalAct = validityPeriodOfLegalAct,	
    ValidityPeriodOfRequirement = validityPeriodOfRequirement,
    VerificationMethod = verificationMethod,
    ConfirmingComplianceDocuments = confirmingComplianceDocuments,
    Ogv = ogv,
    PossibilityOfDocumentsObtaining = possibilityOfDocumentsObtaining,
    SupportingDocumentsValidity = supportingDocumentsValidity,
    TypeOfLiability = typeOfLiability,
    SubjectOfResponsibility = subjectOfResponsibility,
    Sanction = sanction,
    SizeOfSanction = sizeOfSanction,
    TypeOfNorm = typeOfNorm,
    ReferenceToLegalAct = referenceToLegalAct,
    EmpoweredToHoldAuthority = empoweredToHoldAuthority,
    ResponsibilityBringingProcedure = responsibilityBringingProcedure,
    TypesOfActivitiesOfSubjects = typesOfActivitiesOfSubjects,
    ClarificationOfTypeOdActivity = clarificationOfTypeOdActivity,
    
    CharacteristicForGeneralQuestion = characteristicForGeneralQuestion,
    BusinessQuestionContentForProfilingForGeneralQuestion = businessQuestionContentForProfilingForGeneralQuestion,
    CharacteristicForClarifyingQuestion = characteristicForClarifyingQuestion,
    BusinessQuestionContentForProfilingForClarifyingQuestion = businessQuestionContentForProfilingForClarifyingQuestion
            };

            requirements.Add(requirement);
        }

        _context.Requirements.AddRange(requirements);
        _context.SaveChanges();
    }
    
    // 2 2 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГИН\\Нежилой фонд 7 ОТ\\7 от.xlsx
    public void Parsing0202()
    {
    }
    
    // 1 1 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Главархив\\Архивное дело 38 ОТ\\38 ОТ.xlsx
    public void Parsing0101()
    {
    }
    
    // 10 19 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГОЧСиПБ\\ЧС 22 ОТ\\22 ОТ.xlsx
    public void Parsing1019()
    {
    }
    
    // 12 24 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Департамент культуры г.Москвы\\Достоверность 6 ОТ\\6 ОТ.xlsx
    public void Parsing1224()
    {
    }
    
    // 12 23 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Департамент культуры г.Москвы\\Музейный фонд 594 ОТ\\594 ОТ.xlsx
    public void Parsing1223()
    {
    }
    
    // 3 4 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЗМ\\Лекарственные препараты 5 ОТ\\5 ОТ.xlsx
    public void Parsing0304()
    {
    }
    
    // 19 49 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДОНМ\\Контроль в сфере образования 143 ОТ\\143 ОТ.xlsx
    public void Parsing1949()
    {
    }
    
    // 9 17 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТРТДИ\\Внеуличный транспорт 8 ОТ\\8 ОТ.xlsx
    public void Parsing0917()
    {
    }
    
    // 6 8 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Инвалиды 2 ОТ\\2 ОТ.xlsx
    public void Parsing0608()
    {
    }
    
    // 6 9 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Молодежь 2 ОТ\\2 ОТ.xlsx
    public void Parsing0609()
    {
    }
    
    // 6 7 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Социальное обслуживание 37 ОТ\\37 ОТ.xlsx
    public void Parsing0607()
    {
    }
    
    // 13 25 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Водоснабжение 6 ОТ\\6 ОТ.xlsx
    public void Parsing1325()
    {
    }
    
    // 13 29 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Газоснабжение 2 ОТ\\2 ОТ.xlsx
    public void Parsing1329()
    {
    }
    
    // 13 27 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Монополии 19 ОТ\\19 ОТ.xlsx
    public void Parsing1327()
    {
    }
    
    // 13 30 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Теплоснабжение 6 ОТ\\6 ОТ.xlsx
    public void Parsing1330()
    {
    }
    
    // 13 26 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\ТКО 3 ОТ\\3 ОТ.xlsx
    public void Parsing1326()
    {
    }
    
    // 13 28 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Электроэнергетика 7 ОТ\\7 ОТ.xlsx
    public void Parsing1328()
    {
    }
    
    // 8 14 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\МАДИ\\Такси 25 ОТ\\25 ОТ.xlsx
    public void Parsing0814()
    {
    }
    
    // 17 43 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Горный 22 ОТ\\22 ОТ.xlsx
    public void Parsing1743()
    {
    }
    
    // 17 45 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Промышленная безопасность 20 ОТ\\20 ОТ.xlsx
    public void Parsing1745()
    {
    }
    
    // 17 46 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Строительный 6 ОТ\\6 ОТ.xlsx
    public void Parsing1746()
    {
    }
    
    // 17 47 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Строительный в Москве 7 ОТ\\7 ОТ.xlsx
    public void Parsing1747()
    {
    }
    
    // 17 44 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Энергетический 12 ОТ\\12 ОТ.xlsx
    public void Parsing1744()
    {
    }
    
    // 4 5 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомвет\\Обращение с животными в г. Москве 40 ОТ\\40 ОТ.xlsx
    public void Parsing0405()
    {
    }
    
    // 16 42 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомстройинвест\\Долевое строительство 108 ОТ\\108 ОТ.xlsx
    public void Parsing1642()
    {
    }
    
    // 16 41 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомстройинвест\\Жилищно-строительные кооперативы 9 ОТ\\9 ОТ.xlsx
    public void Parsing1641()
    {
    }
    
    // 14 37 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Геологический контроль 28 ОТ\\28 ОТ.xlsx
    public void Parsing1437()
    {
    }
    
    // 14 36 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Городские почвы 10 ОТ\\10 ОТ.xlsx
    public void Parsing1436()
    {
    }
    
    // 14 35 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Зеленые насаждения 145 ОТ\\145 ОТ.xlsx
    public void Parsing1435()
    {
    }
    
    // 14 38 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Лицензионный контроль металлы 98 ОТ\\98 ОТ.xlsx
    public void Parsing1438()
    {
    }
    
    // 14 32 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Особо охраняемые природные территории 31 ОТ\\31 ОТ.xlsx
    public void Parsing1432()
    {
    }
    
    // 14 31 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Охотничий контроль 8 ОТ\\8 ОТ.xlsx
    public void Parsing1431()
    {
    }
    
    // 14 33 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\ФЕД охрана, воспроизводство и использования объектов 9 ОТ\\9 ОТ.xlsx
    public void Parsing1433()
    {
    }
    
    // 14 34 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Эколгический контроль 202 ОТ\\202 ОТ.xlsx
    public void Parsing1434()
    {
    }
    
    // 7 11 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ОАТИ\\Благоустройство 1010 ОТ\\1010 ОТ.xlsx
    public void Parsing0711()
    {
    }
    
    // 7 10 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ОАТИ\\Самоходки и аттракционы 57 ОТ\\57 ОТ.xlsx
    public void Parsing0710()
    {
    }
}