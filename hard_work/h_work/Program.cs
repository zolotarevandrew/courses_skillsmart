using h_work.lesson1.example1;

var str1 = "A01111 growing of cereal";
var str2 = "A growing of cereal";
var res = new TypeOfActivityDictionary();
var items = res.Search(new ActivitySearchQuery(str1));