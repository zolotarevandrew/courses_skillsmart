using h_work.lesson1.example3;
using h_work.lesson27.example2;
using h_work.lesson8.Mixins;
using h_work.lesson9.example2;
using h_work.lesson9.example2.After;

var machine = new TaxIdentificationStateMachine(ETaxIdentificationStatus.Created);
var res = machine.Export();
var a =res;
Console.WriteLine(a);