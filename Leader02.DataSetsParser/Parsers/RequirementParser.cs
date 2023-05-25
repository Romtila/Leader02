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
        Parsing(3,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГИН\\Земельный контроль 22 ОТ\\22 ОТ.xlsx");
        Parsing(2,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГИН\\Нежилой фонд 7 ОТ\\7 от.xlsx");
        Parsing(1,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Главархив\\Архивное дело 38 ОТ\\38 ОТ.xlsx");
        Parsing(19,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГОЧСиПБ\\ЧС 22 ОТ\\22 ОТ.xlsx");
        Parsing(24,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Департамент культуры г.Москвы\\Достоверность 6 ОТ\\6 ОТ.xlsx");
        Parsing(23,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Департамент культуры г.Москвы\\Музейный фонд 594 ОТ\\594 ОТ.xlsx");
        Parsing(4,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЗМ\\Лекарственные препараты 5 ОТ\\5 ОТ.xlsx");
        Parsing(19,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДОНМ\\Контроль в сфере образования 143 ОТ\\143 ОТ.xlsx");
        Parsing(17,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТРТДИ\\Внеуличный транспорт 8 ОТ\\8 ОТ.xlsx");
        Parsing(8,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Инвалиды 2 ОТ\\2 ОТ.xlsx");
        Parsing(9,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Молодежь 2 ОТ\\2 ОТ.xlsx");
        Parsing(7,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Социальное обслуживание 37 ОТ\\37 ОТ.xlsx");
        Parsing(25,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Водоснабжение 6 ОТ\\6 ОТ.xlsx");
        Parsing(29,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Газоснабжение 2 ОТ\\2 ОТ.xlsx");
        Parsing(27,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Монополии 19 ОТ\\19 ОТ.xlsx");
        Parsing(30,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Теплоснабжение 6 ОТ\\6 ОТ.xlsx");
        Parsing(26,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\ТКО 3 ОТ\\3 ОТ.xlsx");
        Parsing(28,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Электроэнергетика 7 ОТ\\7 ОТ.xlsx");
        Parsing(14,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\МАДИ\\Такси 25 ОТ\\25 ОТ.xlsx");
        Parsing(43,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Горный 22 ОТ\\22 ОТ.xlsx");
        Parsing(45,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Промышленная безопасность 20 ОТ\\20 ОТ.xlsx");
        Parsing(46,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Строительный 6 ОТ\\6 ОТ.xlsx");
        Parsing(47,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Строительный в Москве 7 ОТ\\7 ОТ.xlsx");
        Parsing(44,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Энергетический 12 ОТ\\12 ОТ.xlsx");
        Parsing(5,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомвет\\Обращение с животными в г. Москве 40 ОТ\\40 ОТ.xlsx");
        Parsing(42,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомстройинвест\\Долевое строительство 108 ОТ\\108 ОТ.xlsx");
        Parsing(41,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомстройинвест\\Жилищно-строительные кооперативы 9 ОТ\\9 ОТ.xlsx");
        Parsing(37,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Геологический контроль 28 ОТ\\28 ОТ.xlsx");
        Parsing(36,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Городские почвы 10 ОТ\\10 ОТ.xlsx");
        Parsing(35,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Зеленые насаждения 145 ОТ\\145 ОТ.xlsx");
        Parsing(38,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Лицензионный контроль металлы 98 ОТ\\98 ОТ.xlsx");
        Parsing(32,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Особо охраняемые природные территории 31 ОТ\\31 ОТ.xlsx");
        Parsing(31,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Охотничий контроль 8 ОТ\\8 ОТ.xlsx");
        Parsing(33,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\ФЕД охрана, воспроизводство и использования объектов 9 ОТ\\9 ОТ.xlsx");
        Parsing(34,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Эколгический контроль 202 ОТ\\202 ОТ.xlsx");
        Parsing(11,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ОАТИ\\Благоустройство 1010 ОТ\\1010 ОТ.xlsx");
        Parsing(10,"C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ОАТИ\\Самоходки и аттракционы 57 ОТ\\57 ОТ.xlsx");
    }

    public void Parsing(int subDepartmentId, string fileName)
    {
        var subDepartment = _context.SubDepartments
            .Include(x => x.Department)
            .FirstOrDefault(x => x.Id == subDepartmentId);

        var existingFile = new FileInfo(fileName);

        using var package = new ExcelPackage(existingFile);
        
        var worksheet = package.Workbook.Worksheets[0];
        
        //var requirements = new List<Requirement>(worksheet.Dimension.Rows);
        var requirements = new List<Requirement>(worksheet.Dimension.Rows);

        #region инициализация всех переменных для ОТ
        var number = _context.Requirements.OrderByDescending(x => x.Id).FirstOrDefault()?.Number + 1 ?? 1;//номер требования
        var basicRequirementDescription = "";//Описание базового требования (группы ОТ)	
            var basicRequirementDetail = "";//Детализация базового требования	
            var requirementType = RequirementType.Object;
            var indicationOfNpa = "";//Указание на НПА, ПА (наименование, структурные единицы, текст нормы)	
            var validityPeriodOfLegalAct = "";//Период действия НПА (c - по)	
            var validityPeriodOfRequirement = "";//Период действия ОТ (c - по)
            var verificationMethod = VerificationMethod.Mock;

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
            #endregion 
            
        for (var i = 3; i <= worksheet.Dimension.Rows; i++)
        {
            if (worksheet.Cells[i, 3].Value != null && worksheet.Cells[i, 3].Value.ToString() != "")
            {
                basicRequirementDescription = worksheet.Cells[i, 3].Value.ToString();
                basicRequirementDetail = "";
             requirementType = RequirementType.Object;
             indicationOfNpa = "";
             validityPeriodOfLegalAct = "";
             validityPeriodOfRequirement = "";
             verificationMethod = VerificationMethod.Mock;
             confirmingComplianceDocuments = "";
             ogv = "";
             possibilityOfDocumentsObtaining = "";
             supportingDocumentsValidity = "";
             typeOfLiability = "";
             subjectOfResponsibility = "";
             sanction = "";
             sizeOfSanction = "";
             typeOfNorm = "";
             referenceToLegalAct = "";
             empoweredToHoldAuthority = "";
             responsibilityBringingProcedure = "";
             typesOfActivitiesOfSubjects = "";
             clarificationOfTypeOdActivity = "";
             characteristicForGeneralQuestion = "";
             businessQuestionContentForProfilingForGeneralQuestion = "";
             characteristicForClarifyingQuestion = "";
             businessQuestionContentForProfilingForClarifyingQuestion = "";
             continue;
            }

            if (worksheet.Cells[i, 4].Value != null && worksheet.Cells[i, 4].Value.ToString() != "")
            {
                basicRequirementDetail = worksheet.Cells[i, 4].Value.ToString();
                number += 1;
            }

            if (worksheet.Cells[i, 5].Value != null && worksheet.Cells[i, 5].Value.ToString() != "")
            {
                requirementType = worksheet.Cells[i, 5].Value.ToString() == "1"
                    ? RequirementType.Subject
                    : RequirementType.Object;
                
                indicationOfNpa = "";
                validityPeriodOfLegalAct = "";
                validityPeriodOfRequirement = "";
                verificationMethod = VerificationMethod.Mock;
                confirmingComplianceDocuments = "";
                ogv = "";
                possibilityOfDocumentsObtaining = "";
                supportingDocumentsValidity = "";
                typeOfLiability = "";
                subjectOfResponsibility = "";
                sanction = "";
                sizeOfSanction = "";
                typeOfNorm = "";
                referenceToLegalAct = "";
                empoweredToHoldAuthority = "";
                responsibilityBringingProcedure = "";
                typesOfActivitiesOfSubjects = "";
                clarificationOfTypeOdActivity = "";
                characteristicForGeneralQuestion = "";
                businessQuestionContentForProfilingForGeneralQuestion = "";
                characteristicForClarifyingQuestion = "";
                businessQuestionContentForProfilingForClarifyingQuestion = "";
                
            }

            if (worksheet.Cells[i, 6].Value != null && worksheet.Cells[i, 6].Value.ToString() != "")
            {
                indicationOfNpa = worksheet.Cells[i, 6].Value.ToString();
            }

            if (worksheet.Cells[i, 7].Value != null && worksheet.Cells[i, 7].Value.ToString() != "")
            {
                validityPeriodOfLegalAct = worksheet.Cells[i, 7].Value.ToString();
                validityPeriodOfRequirement = "";
            }

            if (worksheet.Cells[i, 8].Value != null && worksheet.Cells[i, 8].Value.ToString() != "")
            {
                validityPeriodOfRequirement = worksheet.Cells[i, 8].Value.ToString();
            }

            if (worksheet.Cells[i, 9].Value != null && worksheet.Cells[i, 9].Value.ToString() != "")
            {
                verificationMethod = worksheet.Cells[i, 9].Value.ToString() switch
                {
                    "1" => VerificationMethod.DocumentsConsideration
                    , "2" => VerificationMethod.InspectionAndResearch
                    , "3" => VerificationMethod.ProductsSampling
                    , "4" => VerificationMethod.ResearchConducting
                    , "5" => VerificationMethod.NetworksParametersMeasurement
                    , "6" => VerificationMethod.ComplianceMonitoring
                    , "7" => VerificationMethod.ControlPurchase
                    , "8" => VerificationMethod.Other
                    , _ => verificationMethod
                };
                
                confirmingComplianceDocuments = "";
                ogv = "";
                possibilityOfDocumentsObtaining = "";
                supportingDocumentsValidity = "";
                typeOfLiability = "";
                subjectOfResponsibility = "";
                sanction = "";
                sizeOfSanction = "";
                typeOfNorm = "";
                referenceToLegalAct = "";
                empoweredToHoldAuthority = "";
                responsibilityBringingProcedure = "";
                typesOfActivitiesOfSubjects = "";
                clarificationOfTypeOdActivity = "";
                characteristicForGeneralQuestion = "";
                businessQuestionContentForProfilingForGeneralQuestion = "";
                characteristicForClarifyingQuestion = "";
                businessQuestionContentForProfilingForClarifyingQuestion = "";
            }

            if (worksheet.Cells[i, 10].Value != null && worksheet.Cells[i, 10].Value.ToString() != "")
            {
                confirmingComplianceDocuments = worksheet.Cells[i, 10].Value.ToString();
            }
            
            if (worksheet.Cells[i, 11].Value != null && worksheet.Cells[i, 11].Value.ToString() != "")
            {
                ogv = worksheet.Cells[i, 11].Value.ToString();
            }
            
            if (worksheet.Cells[i, 12].Value != null && worksheet.Cells[i, 12].Value.ToString() != "")
            {
                possibilityOfDocumentsObtaining = worksheet.Cells[i, 12].Value.ToString();
            }
            
            if (worksheet.Cells[i, 13].Value != null && worksheet.Cells[i, 13].Value.ToString() != "")
            {
                supportingDocumentsValidity = worksheet.Cells[i, 13].Value.ToString();
            }
            
            if (worksheet.Cells[i, 14].Value != null && worksheet.Cells[i, 14].Value.ToString() != "")
            {
                typeOfLiability = worksheet.Cells[i, 14].Value.ToString();
            }
            
            if (worksheet.Cells[i, 15].Value != null && worksheet.Cells[i, 15].Value.ToString() != "")
            {
                subjectOfResponsibility = worksheet.Cells[i, 15].Value.ToString();
            }
            
            if (worksheet.Cells[i, 16].Value != null && worksheet.Cells[i, 16].Value.ToString() != "")
            {
                sanction = worksheet.Cells[i, 16].Value.ToString();
            }
            
            if (worksheet.Cells[i, 17].Value != null && worksheet.Cells[i, 17].Value.ToString() != "")
            {
                sizeOfSanction = worksheet.Cells[i, 17].Value.ToString();
            }
            
            if (worksheet.Cells[i, 18].Value != null && worksheet.Cells[i, 18].Value.ToString() != "")
            {
                typeOfNorm = worksheet.Cells[i, 18].Value.ToString();
            }
            
            if (worksheet.Cells[i, 19].Value != null && worksheet.Cells[i, 19].Value.ToString() != "")
            {
                referenceToLegalAct = worksheet.Cells[i, 19].Value.ToString();
            }
            
            if (worksheet.Cells[i, 20].Value != null && worksheet.Cells[i, 20].Value.ToString() != "")
            {
                empoweredToHoldAuthority = worksheet.Cells[i, 20].Value.ToString();
            }
            
            if (worksheet.Cells[i, 21].Value != null && worksheet.Cells[i, 21].Value.ToString() != "")
            {
                responsibilityBringingProcedure = worksheet.Cells[i, 21].Value.ToString();
            }
            
            if (worksheet.Cells[i, 22].Value != null && worksheet.Cells[i, 22].Value.ToString() != "")
            {
                typesOfActivitiesOfSubjects = worksheet.Cells[i, 22].Value.ToString();
            }
            
            if (worksheet.Cells[i, 23].Value != null && worksheet.Cells[i, 23].Value.ToString() != "")
            {
                clarificationOfTypeOdActivity = worksheet.Cells[i, 23].Value.ToString();
            }
            
            if (worksheet.Cells[i, 24].Value != null && worksheet.Cells[i, 24].Value.ToString() != "")
            {
                characteristicForGeneralQuestion = worksheet.Cells[i, 24].Value.ToString();
            }
            
            if (worksheet.Cells[i, 25].Value != null && worksheet.Cells[i, 25].Value.ToString() != "")
            {
                businessQuestionContentForProfilingForGeneralQuestion = worksheet.Cells[i, 25].Value.ToString();
            }
            
            if (worksheet.Cells[i, 26].Value != null && worksheet.Cells[i, 26].Value.ToString() != "")
            {
                characteristicForClarifyingQuestion = worksheet.Cells[i, 26].Value.ToString();
            }
            
            if (worksheet.Cells[i, 27].Value != null && worksheet.Cells[i, 27].Value.ToString() != "")
            {
                businessQuestionContentForProfilingForClarifyingQuestion = worksheet.Cells[i, 27].Value.ToString();
            }

            var requirement = new Requirement
            {
                RequirementBasicRequirement = new RequirementTsVector
                {
                    BasicRequirement = basicRequirementDescription + " " + basicRequirementDetail,
                    Number = number
                },
                Number = number,
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
    
    // 2 3 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГИН\\Земельный контроль 22 ОТ\\22 ОТ.xlsx
    // 2 2 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГИН\\Нежилой фонд 7 ОТ\\7 от.xlsx
    // 1 1 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Главархив\\Архивное дело 38 ОТ\\38 ОТ.xlsx
    // 10 19 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ГОЧСиПБ\\ЧС 22 ОТ\\22 ОТ.xlsx
    // 12 24 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Департамент культуры г.Москвы\\Достоверность 6 ОТ\\6 ОТ.xlsx
    // 12 23 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Департамент культуры г.Москвы\\Музейный фонд 594 ОТ\\594 ОТ.xlsx
    // 3 4 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЗМ\\Лекарственные препараты 5 ОТ\\5 ОТ.xlsx
    // 19 49 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДОНМ\\Контроль в сфере образования 143 ОТ\\143 ОТ.xlsx
    // 9 17 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТРТДИ\\Внеуличный транспорт 8 ОТ\\8 ОТ.xlsx
    // 6 8 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Инвалиды 2 ОТ\\2 ОТ.xlsx
     // 6 9 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Молодежь 2 ОТ\\2 ОТ.xlsx
    // 6 7 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДТСЗН\\Социальное обслуживание 37 ОТ\\37 ОТ.xlsx
    // 13 25 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Водоснабжение 6 ОТ\\6 ОТ.xlsx
    // 13 29 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Газоснабжение 2 ОТ\\2 ОТ.xlsx
    // 13 27 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Монополии 19 ОТ\\19 ОТ.xlsx
    // 13 30 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Теплоснабжение 6 ОТ\\6 ОТ.xlsx
    // 13 26 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\ТКО 3 ОТ\\3 ОТ.xlsx
    // 13 28 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ДЭПР\\Электроэнергетика 7 ОТ\\7 ОТ.xlsx
    // 8 14 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\МАДИ\\Такси 25 ОТ\\25 ОТ.xlsx
    // 17 43 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Горный 22 ОТ\\22 ОТ.xlsx
    // 17 45 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Промышленная безопасность 20 ОТ\\20 ОТ.xlsx
    // 17 46 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Строительный 6 ОТ\\6 ОТ.xlsx
    // 17 47 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Строительный в Москве 7 ОТ\\7 ОТ.xlsx
    // 17 44 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосгосстройнадзор\\Энергетический 12 ОТ\\12 ОТ.xlsx
    // 4 5 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомвет\\Обращение с животными в г. Москве 40 ОТ\\40 ОТ.xlsx
    // 16 42 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомстройинвест\\Долевое строительство 108 ОТ\\108 ОТ.xlsx
    // 16 41 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Москомстройинвест\\Жилищно-строительные кооперативы 9 ОТ\\9 ОТ.xlsx
    // 14 37 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Геологический контроль 28 ОТ\\28 ОТ.xlsx
    // 14 36 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Городские почвы 10 ОТ\\10 ОТ.xlsx
    // 14 35 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Зеленые насаждения 145 ОТ\\145 ОТ.xlsx
    // 14 38 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Лицензионный контроль металлы 98 ОТ\\98 ОТ.xlsx
    // 14 32 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Особо охраняемые природные территории 31 ОТ\\31 ОТ.xlsx
    // 14 31 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Охотничий контроль 8 ОТ\\8 ОТ.xlsx
    // 14 33 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\ФЕД охрана, воспроизводство и использования объектов 9 ОТ\\9 ОТ.xlsx
    // 14 34 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\Мосприрода\\Эколгический контроль 202 ОТ\\202 ОТ.xlsx
    // 7 11 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ОАТИ\\Благоустройство 1010 ОТ\\1010 ОТ.xlsx
    // 7 10 C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_1_Список_обязательных_требований_КНО_Москвы\\ОАТИ\\Самоходки и аттракционы 57 ОТ\\57 ОТ.xlsx
}