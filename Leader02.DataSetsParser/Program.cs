﻿using Leader02.DataSetsParser.Parsers;
using Leader02.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false);
var config = builder.Build();
var connectionString = config.GetConnectionString("Leader02");

var optionsBuilder = new DbContextOptionsBuilder<Leader02Context>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Leader02;Username=postgres;Password=admin");
var leader02Context = new Leader02Context(optionsBuilder.Options);

//парсинг департаментов и контрольных органов
//var departmentParser = new DepartmentParser(leader02Context);
//departmentParser.DepartmentParsing("C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_2_Слоты_для_записи_на_Консультирование.xlsx");

//парсинг НПА
var legalActParser = new LegalActParser(leader02Context);
legalActParser.LegalActParsing("C:\\Users\\Romtila\\Desktop\\Датасеты\\Приложение_3_Перечень_нормативных_правовых_актов.xlsx");

Console.WriteLine($"The answer is always {connectionString}");