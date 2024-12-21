var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Contacts_Synchronizer_WebApi>("contacts-synchronizer-webapi");

builder.Build().Run();
