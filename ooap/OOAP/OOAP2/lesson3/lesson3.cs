using System;
using MyModule;
using Newtonsoft.Json;

//функциональность в отдельном пространстве имен, импортируем в свою функциональность классы из другого пространства имен
namespace MyModule
{
    public class ModuleLogger
    {
        
    }
}

//отдельная сборка, импортируется в проект через csproj файл, интерфейс модуля будет доступен только из абстрактных классов или интерфейсов из DI, либо другим способом
namespace AssemblyModule
{
    public abstract class AssemblyClass
    {
        
    }
    
    internal class AssemblyClassImpl : AssemblyClass
    {
        
    }
}

//использование отдельного NUGET пакета на примере Newtonsoft.Json
namespace Package
{
    
    public class MyClass {}
    public class MyJsonConverter : JsonConverter<MyClass>
    {
        private readonly ModuleLogger _logger;

        public MyJsonConverter(ModuleLogger logger)
        {
            _logger = logger;
        }
        public override void WriteJson(JsonWriter writer, MyClass value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override MyClass ReadJson(JsonReader reader, Type objectType, MyClass existingValue, bool hasExistingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}

//подключение dll Библиотеки в виде модуля (чтобы не создавать библиотеку возьмем встроенную функциональность)
namespace ExternalLibrary
{
    public class LibClass
    {
        public void Calc()
        {
            var mylist = new string[]
            {
                "1",
                "2"
            };
            Array.Sort(mylist);
        }
    }

}